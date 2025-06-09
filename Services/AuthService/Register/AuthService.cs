using LibraryAPI.Data;
using LibraryAPI.DTOs.AuthenticationDTOs;
using LibraryAPI.Models;
using LibraryAPI.Repositories.IdentityRepo;
using System.Data;

namespace LibraryAPI.Services.AuthService.Register
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepo;
        private readonly IJwtService _jwtService;
        
        private readonly LibraryDbContext _context;

        public AuthService(IAuthRepository authRepo, IJwtService jwtService, LibraryDbContext context)
        {
            _authRepo = authRepo;
            _jwtService = jwtService;
            _context = context;
        }
        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _authRepo.FindByUsernameAsync(registerDto.UserName);
            if (existingUser != null)
                return "User already exists";

            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                JoinedDate = DateTime.Now,

            };
            var result = await _authRepo.CreateUserAsync(user, registerDto.Password);
            if (result.Succeeded)
                return string.Join(",", result.Errors.Select(e => e.Description));

            if (!await _authRepo.RoleExistsAsync(registerDto.Role))
                await _authRepo.CreateRoleAsync(registerDto.Role);

            await _authRepo.AddToRoleAsync(user, registerDto.Role);


            var rolesForMembers = new List<string> { "Admin", "Student", "Librarian", };

            if (rolesForMembers.Contains(registerDto.Role, StringComparer.OrdinalIgnoreCase))
            {
                var member = new Member
                {
                    UserId = user.Id,
                    JoinedDate = DateTime.UtcNow,
                    MembershipNumber = Guid.NewGuid().ToString().Substring(0, 8)
                };

                _context.Members.Add(member);
                await _context.SaveChangesAsync();
            }
            return "user registerd successfuly happy reading";

        

        }
    }
}
