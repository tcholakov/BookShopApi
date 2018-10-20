namespace BookShop.Services.Book.Contracts
{
    using System.Threading.Tasks;
    using BookShop.Services.Models.Book;

    public interface IBookService
    {
        Task<BookServiceModel> Details(int id);
    }
}
