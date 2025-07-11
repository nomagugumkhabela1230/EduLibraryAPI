using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Domain.Models
{
    public class FinePolicy
    {
        public int Id { get; set; }
        public decimal DailyFine { get; set; }
        public decimal MaxFinePerLoan { get; set; }



    }
}
