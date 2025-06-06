using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Models;

namespace LibraryAPI.Repositories.Interface;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<Book> AddBookAsync(Book book);
    Task<Book?> UpdateBookAsync(Book book);
    Task<bool> DeleteBookAsync(int id);
   
}


