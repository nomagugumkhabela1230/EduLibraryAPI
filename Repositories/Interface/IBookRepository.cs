using LibraryAPI.Models;

namespace LibraryAPI.Repositories.Interface;

   public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
       void UpdateBook(Book book); // doesn’t hit the database — it only updates the EF Core tracking state.
    void DeleteBook(Book book);
       Task SaveChangesAsync();

}



