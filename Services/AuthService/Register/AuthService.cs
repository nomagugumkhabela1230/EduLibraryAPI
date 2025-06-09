using LibraryAPI.Data;
using LibraryAPI.DTOs.AuthenticationDTOs;
using LibraryAPI.Models;
using LibraryAPI.Repositories.IdentityRepo;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace LibraryAPI.Services.AuthService.Register
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;


        public AuthService(IAuthRepository authRepository, IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;

        }



        public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _authRepository.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                var errorResult = IdentityResult.Failed(new IdentityError
                {
                    Description = "Email is already taken."
                });
                return errorResult;
            }

            var newUser = new ApplicationUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                FullName = registerDto.FullName,
                JoinedDate = DateTime.UtcNow,


            };

            var result = await _authRepository.CreateUserAsync(newUser, registerDto.Password);

            if (result.Succeeded)
            {
                if (!await _authRepository.RoleExistsAsync(registerDto.Role))
                {
                    await _authRepository.CreateRoleAsync(registerDto.Role);
                }

                await _authRepository.AddToRoleAsync(newUser, registerDto.Role);
            }

            return result;
        }
        // Login
        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user  = await _authRepository.FindByEmailAsync(dto.Email);
            if (user == null || !await _authRepository.CheckPasswordAsync(user, dto.Password))
                return null;

            var roles = await _authRepository.GetRolesAsync(user); //roles are needed to embed into the JWT token
            return _jwtService.GenerateToken(user, roles);

        }

    }
}