namespace LibraryAPI.Domain.DTOs.LoanDtos
{
    public class LoanCreateDto
    {

        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
