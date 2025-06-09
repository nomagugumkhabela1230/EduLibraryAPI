using LibraryAPI.Models;

namespace LibraryAPI.Services.AuthService.Register
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser user, IList<string> roles);
    }
}
