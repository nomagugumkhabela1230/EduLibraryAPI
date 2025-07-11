namespace LibraryAPI.Domain.DTOs.MemberDTOs
{
    public class MapToDto
    {
        public int MemberId { get; set; }
        public string MicrosoftId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
   
    }
}
