using LibraryAPI.DTOs.AuthenticationDTOs;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Services.AuthService.Register
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
        Task<string?> LoginAsync(LoginDto dto);

    }
}
