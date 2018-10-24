namespace BookShop.Services.Author
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Author.Contracts;
    using BookShop.Services.Models.Author;
    using BookShop.Services.Models.Book;
    using Microsoft.EntityFrameworkCore;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext bookShopDbContext;
        private readonly IMapper mapper;

        public AuthorService(BookShopDbContext bookShopDbContext, IMapper mapper)
        {
            this.bookShopDbContext = bookShopDbContext;
            this.mapper = mapper;
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            this.bookShopDbContext.Add(author);
            await this.bookShopDbContext.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorDetailsServiceModel> Details(int id)
        {
            var authorServiceModelTask = await this.bookShopDbContext
                .Authors
                .Where(author => author.Id == id)
                .Select(author => this.mapper.Map<AuthorDetailsServiceModel>(author))
                .FirstOrDefaultAsync();

            return authorServiceModelTask;
        }

        public async Task<IEnumerable<BookServiceModel>> BooksByAuthor(int authorId)
        {
            var booksTask = await this.bookShopDbContext
                .Books
                .Include(book => book.Author)
                .Include(book => book.Categories)
                .ThenInclude(bookCategory => bookCategory.Category)
                .Where(book => book.AuthorId == authorId)
                .Select(bookDataModel => this.mapper.Map<BookServiceModel>(bookDataModel))
                .ToListAsync();

            return booksTask;
        }

        public async Task<bool> Exists(int authorId)
        {
            bool exists = await this.bookShopDbContext.Authors.AnyAsync(author => author.Id == authorId);

            return exists;
        }
    }
}
