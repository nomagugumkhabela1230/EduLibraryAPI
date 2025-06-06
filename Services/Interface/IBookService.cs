

using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interface
    {
        public interface IBookService
        {
            Task<List<BookDto>> GetAllAsync();
            Task<BookDto?> GetByIdAsync(int id);
            Task<BookDto> AddBookAsync(CreateBookDto createBookDto);
            Task<BookDto?> UpdateBookAsync(int id,CreateBookDto createBookDto);
            Task<bool> DeleteBookAsync(int id);
        }
    }


