

using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Fine
    {
            public int Id { get; set; }

            public int LoanId { get; set; }

            public decimal Amount { get; set; }

            public bool IsPaid { get; set; }
            public DateTime IssuedDate { get; set; } = DateTime.UtcNow;

            public Loan Loan { get; set; }
        }


    }

