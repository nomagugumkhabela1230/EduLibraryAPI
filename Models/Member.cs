using LibraryAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Member 
    {

        public int Id { get; set; }
        public string UserId { get; set; }  = Guid.NewGuid().ToString();
        public ApplicationUser User { get; set; }

        public DateTime JoinedDate { get; set; }
        public string MembershipNumber { get; set; } = string.Empty;


        public List<Loan> Loans { get; set; } = [];
    }
}
