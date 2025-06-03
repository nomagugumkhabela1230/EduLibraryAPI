using LibraryAPI.DTOs.BookDTOs;

namespace LibraryAPI.Services.Interfaces;

   public interface IBookService
    {
        Task<List<BookViewDto>> GetAllBooksAsync();
        Task<BookViewDto> GetBookByIdAsync(int id);
        Task AddBookAsync(BookCreateDto bookDto);
        Task<bool> UpdateBookAsync(int id, BookUpdateDto bookDto);
        Task<bool> DeleteBookAsync(int id);
    
}



