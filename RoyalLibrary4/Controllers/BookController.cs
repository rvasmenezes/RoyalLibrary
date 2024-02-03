using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.API.Data;
using RoyalLibrary.API.DTOs;
using RoyalLibrary.API.Models;
using RoyalLibrary.API.Services;

namespace RoyalLibrary4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly EFContext _context;
        public readonly BookServices _bookServices;

        public BookController(EFContext context, BookServices bookServices)
        {
            _context = context;
            _bookServices = bookServices;
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookDto dto)
        {           
            var book = new Book(dto.Title, dto.CategoryId, dto.TypeId, 
                                dto.TotalCopies, dto.CopiesInUse, dto.ISBN, dto.WantRead);

            book.SetAuthorList(dto.AuthorIdList);
            book.SetPublisherList(dto.PublisherIdList);

            var newBook = await _context.Book.AddAsync(book);

            await _context.SaveChangesAsync();

            return Ok(newBook.Entity);           
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginated([FromQuery] SearchBookDto dto)
        {
            var bookList = await _bookServices.GetPaginated(dto);

            if (!bookList.Result.Any())
                return NoContent();

            return Ok(bookList);
        }
    }
}
