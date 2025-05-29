using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Model
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }= string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;

        // Navigation
        public List<Loan> Loans { get; set; } = [];
    }
}