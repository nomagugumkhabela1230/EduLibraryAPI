using LibraryAPI.DTOs.BookDTOs;
using LibraryAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var book = await _bookService.GetAllBooksAsync();
            return Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookViewDto bookViewDto)
        {
            await _bookService.AddBookAsync(bookViewDto);

            return CreatedAtAction(nameof(GetById), new { id = bookViewDto.Id }, bookViewDto);
        }

        [HttpPut("{id}")]

        public async Task <IActionResult>Update (int id, BookViewDto bookViewDto)

        {
            if (id != bookViewDto.Id)
                return BadRequest("Book ID mismatch");// verify if the  ID in the route matches the ID in the body

            var updated = await _bookService.UpdateBookAsync(bookViewDto);
            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete]
        public async Task <IActionResult>Delete(int id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }

    }
}
