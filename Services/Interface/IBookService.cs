using LibraryAPI.DTOs.BookDTOs;

namespace LibraryAPI.Services.Interface
{
    public interface IBookService
    {
        Task<List<BookViewDto>> GetAllBooksAsync();
        Task<BookViewDto?> GetBookByIdAsync(int id);
        Task AddBookAsync(BookViewDto bookViewDto);
        Task<bool> DeleteBookAsync(int id);

    }
}
