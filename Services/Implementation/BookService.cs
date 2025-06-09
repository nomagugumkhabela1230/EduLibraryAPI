
using AutoMapper;
using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Models;
using LibraryAPI.Repositories.Interface;
using LibraryAPI.Services.Interface;

namespace LibraryAPI.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var book =await _repository.GetAllBooksAsync();
            return _mapper.Map<List<BookDto>>(book);
        }

        public async  Task<BookDto?> GetByIdAsync(int id)
        {
           var book = await _repository.GetByIdAsync(id);
            return book == null ? null :  _mapper.Map<BookDto>(book);
        }
        public async Task<BookDto> AddBookAsync(CreateBookDto createBookDto)
        {

            var book = _mapper.Map<Book>(createBookDto);
            var created = await _repository.AddBookAsync(book);
            return _mapper.Map<BookDto>(created);
        } 

        public async Task<BookDto?> UpdateBookAsync(int id, CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            book.Id = id;
            var updated = await _repository.UpdateBookAsync(book);
            return updated == null  ? null : _mapper.Map<BookDto?>(updated);
            
        }

        public Task<bool> DeleteBookAsync(int id)
        {
            return _repository.DeleteBookAsync(id); 
        }
    }
}
