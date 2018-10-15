namespace BookShop.Services.Author.Contracts
{
    using BookShop.Services.Models.Author;

    public interface IAuthorService
    {
        AuthorDetailsServiceModel Details(int id);
    }
}
