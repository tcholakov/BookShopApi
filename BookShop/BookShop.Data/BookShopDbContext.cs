namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BookCategory> BooksInCateogies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<BookCategory>()
                .HasKey(bookCategory => new { bookCategory.BookId, bookCategory.CategoryId });

            modelBuilder
                .Entity<Book>()
                .HasMany(book => book.Categories)
                .WithOne(bookCategory => bookCategory.Book)
                .HasForeignKey(bookCategory => bookCategory.BookId);

            modelBuilder
                .Entity<Category>()
                .HasMany(category => category.Books)
                .WithOne(bookCategory => bookCategory.Category)
                .HasForeignKey(bookCategory => bookCategory.CategoryId);

            modelBuilder
                .Entity<Category>()
                .HasIndex(category => category.Name)
                .IsUnique();

            modelBuilder
                .Entity<Book>()
                .HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
