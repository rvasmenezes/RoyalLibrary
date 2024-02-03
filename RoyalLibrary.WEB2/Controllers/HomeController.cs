using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyalLibrary.API.Data;
using RoyalLibrary.API.DTOs;
using RoyalLibrary.API.Services;
using RoyalLibrary.WEB2.Models.ViewModels;

namespace RoyalLibrary.WEB2.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFContext _context;
        public readonly BookServices _bookServices;
        
        public HomeController(EFContext context, BookServices bookServices)
        {
            _context = context;
            _bookServices = bookServices;
        }

        public async Task<IActionResult> IndexAsync(SearchBookDto dto)
        {
            var viewModel = new BookListViewModel
            {
                BookListPaginated = await _bookServices.GetPaginated(dto),
                AuthorList = await _context.Author.ToListAsync(),
                searchBookDto = dto
            };

            return View(viewModel);
        }
    }
}
