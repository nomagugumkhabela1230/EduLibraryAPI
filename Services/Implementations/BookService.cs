using AutoMapper;
using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Services.Interfaces;

namespace LibraryAPI.Services.Implementations
{
    public class BookService: IBookService
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookService(IBookService bookService, IMapper mapper)
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
