namespace BookShop.Services.Author.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookShop.Services.Models.Author;
    using BookShop.Services.Models.Book;

    public interface IAuthorService
    {
        Task<int> Create(string firstName, string lastName);

        Task<AuthorDetailsServiceModel> Details(int id);

        Task<IEnumerable<BookServiceModel>> BooksByAuthor(int authorId);

        Task<bool> Exists(int authorId);
    }
}
