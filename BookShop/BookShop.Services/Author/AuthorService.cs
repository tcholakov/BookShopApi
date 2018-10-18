namespace BookShop.Services.Author
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Author.Contracts;
    using BookShop.Services.Models.Author;
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
    }
}
