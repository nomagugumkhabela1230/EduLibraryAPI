using LibraryAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Member : ApplicationUser
    {

        public int Id { get; set; } 
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime JoinedDate { get; set; }


        public List<Loan> Loans { get; set; } = [];
    }
}
