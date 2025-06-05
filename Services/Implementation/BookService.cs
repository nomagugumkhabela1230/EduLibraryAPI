using AutoMapper;
using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Models;
using LibraryAPI.Repositories.Interface;
using LibraryAPI.Services.Interface;

namespace LibraryAPI.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookViewDto>> GetAllBooksAsync()
        {
            var book = await _bookRepository.GetAllBooksAsync();
            return  _mapper.Map<List<BookViewDto>>(book);
        }

        public async Task<BookViewDto?> GetBookByIdAsync(int id)
        {
            var  book = await _bookRepository.GetBookByIdAsync(id);
            return book == null ? null : _mapper.Map<BookViewDto>(book);
        }
        public async Task AddBookAsync(BookViewDto bookViewDto)
        {
            
            var book = _mapper.Map<Book>(bookViewDto);
            await _bookRepository.AddBookAsync(book);
            await _bookRepository.SaveChangesAsync();
        }



        public async Task<bool> UpdateBookAsync(BookViewDto bookViewDto)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(bookViewDto.Id);
            if (existingBook == null)
                return false;
            _mapper.Map(bookViewDto, existingBook);

            _bookRepository.UpdateBook(existingBook);
            await _bookRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            {
                if (book == null) 
                    return false;

                _bookRepository.DeleteBook(book);
                await _bookRepository.SaveChangesAsync();
                return true;

            }
        }

    }
}
