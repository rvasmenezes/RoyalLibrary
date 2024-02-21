using Microsoft.EntityFrameworkCore;
using RoyalLibrary.API.Data;
using RoyalLibrary.API.DTOs;
using RoyalLibrary.API.Helpers;
using RoyalLibrary.API.Model;

namespace RoyalLibrary.API.Services
{
    public class BookServices
    {
        private readonly EFContext _context;

        public BookServices(EFContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<Book>> GetPaginated(SearchBookDto dto)
        {
            var bookList = _context.Book
                            .Include(x => x.AuthorList).ThenInclude(y => y.Author)
                            .Include(x => x.PublisherList).ThenInclude(y => y.Publisher)
                            .Include(x => x.Type)
                            .Include(x => x.Category).AsQueryable();

            if (dto.WantRead.HasValue)
                bookList = bookList.Where(w => w.WantRead == dto.WantRead);

            if (!string.IsNullOrEmpty(dto.ISBN))
                bookList = bookList.Where(w => w.ISBN.Contains(dto.ISBN));

            if (dto.AuthorId.HasValue)
                bookList = bookList.Where(w => w.AuthorList.Any(a => a.AuthorId == dto.AuthorId));

            bookList = bookList.OrderBy(x => x.Title);

            return await bookList.GetPagedAsync(dto.Page, dto.ItemsPerPage);
        }
    }
}
