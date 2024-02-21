using Microsoft.EntityFrameworkCore;
using RoyalLibrary.API.Model;
using Type = RoyalLibrary.API.Model.Type;

namespace RoyalLibrary.API.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookPublisher> BookPublisher { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Type> Type { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<BookAuthor>()
        .       HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.AuthorList)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookPublisher>()
                .HasKey(ba => new { ba.BookId, ba.PublisherId });

            modelBuilder.Entity<BookPublisher>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.PublisherList)
                .HasForeignKey(ba => ba.BookId);
        }

    }
}
