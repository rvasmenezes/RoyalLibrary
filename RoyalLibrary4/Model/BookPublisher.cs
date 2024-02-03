using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RoyalLibrary.API.Models
{
    public class BookPublisher
    {
        [JsonIgnore]
        public int BookId { get; set; }

        [JsonIgnore]
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [JsonIgnore]
        public int PublisherId { get; set; }

        //[JsonIgnore]
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public BookPublisher(int publisherId) => PublisherId = publisherId;
    }
}

