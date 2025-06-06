using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibraryAPI.Services.Interface;
using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
    

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            return NotFound();

            return Ok(book);
        }


        [HttpPost]

        public async Task<ActionResult<BookDto>> CreateBook([FromBody]CreateBookDto createBookDto)
        {
            var created = await _bookService.AddBookAsync(createBookDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateBookDto createBookDto)
        {
            var updated = await _bookService.UpdateBookAsync(id, createBookDto);
            if (updated == null) return NotFound();
            return Ok(updated);
             
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            if (!deleted) return NotFound(new { message = $"Book with ID {id} not found." });
            return NoContent ();
        }
    }
}
