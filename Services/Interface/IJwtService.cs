using LibraryAPI.Models;

namespace LibraryAPI.Services.Interface
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser user, IList<string> roles);
    }
}
