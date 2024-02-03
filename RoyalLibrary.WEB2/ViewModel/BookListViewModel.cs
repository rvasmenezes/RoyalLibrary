using RoyalLibrary.API.DTOs;
using RoyalLibrary.API.Helpers;
using RoyalLibrary.API.Models;

namespace RoyalLibrary.WEB2.Models.ViewModels
{
    public class BookListViewModel
    {
        public PaginatedResult<Book> BookListPaginated { get; set; }

        public List<Author> AuthorList { get; set; }

        public SearchBookDto searchBookDto { get; set; }
        
        /*public int? AuthorId { get; set; }
        public string? ISBN { get; set; }
        public bool? WantRead { get; set; }*/
    }
}
