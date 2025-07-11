namespace LibraryAPI.Domain.DTOs.FineDtos
{
    public class FineViewDto
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime IssuedDate { get; set; }

    }
}
