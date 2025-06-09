using LibraryAPI.Models;
using LibraryAPI.Repositories.IdentityRepo;
using Microsoft.AspNetCore.Identity;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<ApplicationUser?> FindByEmailAsync(string Email) // find user by Email
    {
        return await _userManager.FindByNameAsync(Email);
    }


    public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password) //Create new user with password
    {
        return  await _userManager.CreateAsync(user, password);
    }

    public async Task AddToRoleAsync(ApplicationUser user, string role) // Add user to role
    {
        await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<bool> RoleExistsAsync(string role)   // Check if role exists
    {
        return await _roleManager.RoleExistsAsync(role);
    }
    public async Task CreateRoleAsync(string role) // Create new user with password
    {
        await _roleManager.CreateAsync(new IdentityRole(role));
    }

    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }
}
