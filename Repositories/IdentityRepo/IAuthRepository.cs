using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Repositories.IdentityRepo
{
    public interface IAuthRepository
    {
        Task<ApplicationUser> FindByUsernameAsync(string username);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task AddToRoleAsync(ApplicationUser user, string role);
        Task<bool> RoleExistsAsync(string role);
        Task CreateRoleAsync(string role);
    }

}