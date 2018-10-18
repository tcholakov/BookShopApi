namespace BookShop.Services.Author.Contracts
{
    using System.Threading.Tasks;
    using BookShop.Services.Models.Author;

    public interface IAuthorService
    {
        Task<int> Create(string firstName, string lastName);

        Task<AuthorDetailsServiceModel> Details(int id);
    }
}
