namespace LibraryAPI.DTOs.BookDTOs
{
    public class BookUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public  string Category {  get; set; } = string.Empty;
        public int TotalCopies { get; set; }

    }
}
