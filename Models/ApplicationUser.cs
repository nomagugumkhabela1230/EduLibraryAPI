
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime JoinedDate { get; set; }


    }
}