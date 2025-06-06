using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {

            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateBookAsync( Book book)
        {
            var existing = await _context.Books.FindAsync(book.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
       
    }
}
