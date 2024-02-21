using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RoyalLibrary.API.Model
{
    public class BookAuthor
    {
        [JsonIgnore]
        public int BookId { get; set; }

        [JsonIgnore]
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [JsonIgnore]
        public int AuthorId { get; set; }

        //[JsonIgnore]
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public BookAuthor(int authorId) => AuthorId = authorId;
    }
}

