﻿namespace LibraryAPI.Domain.DTOs.BookDTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int TotalCopies { get; set; }

    }
}
