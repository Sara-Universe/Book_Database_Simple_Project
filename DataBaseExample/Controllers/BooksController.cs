using DataBaseExample.Models;
using DataBaseExample.Services;
using Microsoft.AspNetCore.Mvc;
using DataBaseExample.Dtos;
using System.Threading.Tasks;

namespace DataBaseExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(AddBookDto bookdto)
        {
            var createdBook = await _bookService.AddBookAsync(bookdto);
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, AddBookDto bookdto)
        {
            var updated = await _bookService.UpdateBookAsync(id, bookdto);
            if (!updated) return BadRequest();
            return Ok($"Book with id : {id} was Updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/users")]
        public async Task<IActionResult> GetBookWithUsers(int id)
        {
            var bookWithUsers = await _bookService.GetBookWithUsersAsync(id);
            if (bookWithUsers == null) return NotFound();   
            return Ok(bookWithUsers);
        }
    }
}
