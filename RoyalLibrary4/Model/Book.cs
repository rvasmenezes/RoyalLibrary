using RoyalLibrary.API.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoyalLibrary.API.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int TypeId { get; set; }
        public virtual Type Type { get; set; }

        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }

        [StringLength(13)]
        public string ISBN { get; set; }

        public bool WantRead { get; set; }

        //[NotMapped]
        public List<BookAuthor> AuthorList { get; set; } = new List<BookAuthor>();
        //[NotMapped]
        public List<BookPublisher> PublisherList { get; set; } = new List<BookPublisher>();

        public Book(
            string title, 
            int categoryId, 
            int typeId, 
            int totalCopies, 
            int copiesInUse, 
            string iSBN, 
            bool wantRead)
        {
            Title = title;
            CategoryId = categoryId;
            TypeId = typeId;
            TotalCopies = totalCopies;
            CopiesInUse = copiesInUse;
            ISBN = iSBN;
            WantRead = wantRead;
        }

        public void SetAuthorList(List<int> authorIdList)
            => AuthorList = authorIdList.Select(id => new BookAuthor(id)).ToList();

        public void SetPublisherList(List<int> publisherIdList)
            => PublisherList = publisherIdList.Select(id => new BookPublisher(id)).ToList();
    }
}

