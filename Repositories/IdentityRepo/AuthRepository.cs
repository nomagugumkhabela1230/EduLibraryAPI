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

    public async Task<ApplicationUser> FindByUsernameAsync(string username)
        => await _userManager.FindByNameAsync(username);

    public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        => await _userManager.CreateAsync(user, password);

    public async Task AddToRoleAsync(ApplicationUser user, string role)
        => await _userManager.AddToRoleAsync(user, role);

    public async Task<bool> RoleExistsAsync(string role)
        => await _roleManager.RoleExistsAsync(role);

    public async Task CreateRoleAsync(string role)
        => await _roleManager.CreateAsync(new IdentityRole(role));
}
