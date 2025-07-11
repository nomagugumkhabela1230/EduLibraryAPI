using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class Member 
    {

        public int Id { get; set; }

        public string MicrosoftId { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; }= string.Empty;

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public List<Loan> Loans { get; set; } = [];
    }
}
