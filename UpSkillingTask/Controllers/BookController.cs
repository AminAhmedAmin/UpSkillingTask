using Microsoft.AspNetCore.Mvc;
using UpSkillingTask.DTOs.BooksDtos;
using UpSkillingTask.Services.Interfaces;

namespace UpSkillingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("GetBook{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }



        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto addBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isSuccess = await _bookService.AddBookAsync(addBookDto);
            if (isSuccess)
            {
                return Ok(new { Message = "Book Added successfully." });
            }
            return BadRequest(new { Message = "Failed to add the book." });
        }


        [HttpPut("UpdateBook{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] EditBookDto editBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = await _bookService.UpdateBookAsync(id, editBookDto);
            if (!isUpdated)
            {
                return NotFound(new { Message = "Book not found." });
            }

            return Ok(new { Message = "Book updated successfully." });
        }

        [HttpDelete("DeleteBook{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var isDeleted = await _bookService.DeleteBookAsync(id);
            if (!isDeleted)
            {
                return NotFound(new { Message = "Book not found." });
            }

            return Ok(new { Message = "Book deleted successfully." });
        }
    }
}
