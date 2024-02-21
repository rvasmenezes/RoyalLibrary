using System.ComponentModel.DataAnnotations;

namespace RoyalLibrary.API.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        //public List<BookAuthor> BookList { get; set; }
    }
}

