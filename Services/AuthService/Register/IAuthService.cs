using LibraryAPI.DTOs.AuthenticationDTOs;

namespace LibraryAPI.Services.AuthService.Register
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto registerDto);
       

    }
}
