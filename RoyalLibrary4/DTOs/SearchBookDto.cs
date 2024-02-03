using System.ComponentModel.DataAnnotations;

namespace RoyalLibrary.API.DTOs
{
    public class SearchBookDto : PaginationDto
    {
        public int? AuthorId { get; set; }
        public string? ISBN { get; set; }
        public bool? WantRead { get; set; }
    }
}

