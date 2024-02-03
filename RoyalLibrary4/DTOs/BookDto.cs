using System.ComponentModel.DataAnnotations;

namespace RoyalLibrary.API.DTOs
{
    public class BookDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int TypeId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int TotalCopies { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CopiesInUse { get; set; }
        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        public bool WantRead { get; set; }

        public List<int> AuthorIdList { get; set; }
        public List<int> PublisherIdList { get; set; }
    }
}

