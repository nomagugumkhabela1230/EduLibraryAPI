namespace LibraryAPI.DTOs.MemberDTOs
{
    public class MemberViewDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
