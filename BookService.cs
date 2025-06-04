using AutoMapper;
using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Repositories.Interface;

namespace LibraryAPI
{
    public class BookService: IBookRepository
    {
        private readonly IBookRepository _bookService;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public async Task<List<BookViewDto>> GetAllBooksAsync()
        {
            var books = await _bookService.GetAllAsync();
            return _mapper.Map<List<BookViewDto>>(books);
        }
        public Task<BookViewDto?> GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task AddBookAsync(BookCreateDto bookViewDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBookAsync(int id, BookUpdateDto bookViewDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
