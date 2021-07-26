using firstTUT.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace my_Books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorsToBooks>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.AuthorBook)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<AuthorsToBooks>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.AuthorBook)
                .HasForeignKey(bi => bi.AuthorId);
        }

        public DbSet<Book> Books {get; set;}
        public DbSet<Author> Authors {get; set;}
        public DbSet<AuthorsToBooks> BooksToAuthors { get; set; }
        public DbSet<Publisher> publishers {get; set;}
    }
}