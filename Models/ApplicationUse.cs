
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;



        public Member? MemberProfile { get; set; }
    }
}