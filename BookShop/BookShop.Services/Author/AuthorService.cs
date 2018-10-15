namespace BookShop.Services.Author
{
    using AutoMapper;
    using BookShop.Data;
    using BookShop.Services.Author.Contracts;
    using BookShop.Services.Models.Author;
    using System.Linq;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext dbContext;
        private readonly IMapper mapper;

        public AuthorService(BookShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AuthorDetailsServiceModel Details(int id)
        {
            var authorServiceModel = this.dbContext
                .Authors
                .Where(author => author.Id == id)
                .Select(author => this.mapper.Map<AuthorDetailsServiceModel>(author))
                .FirstOrDefault();

            return authorServiceModel;
        }
    }
}
