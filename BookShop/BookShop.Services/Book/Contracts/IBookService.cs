namespace BookShop.Services.Book.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookShop.Services.Models.Book;

    public interface IBookService
    {
        Task<int> Create(BookInputServiceModel book);

        Task<IEnumerable<BookServiceModel>> Filter(string searchText);

        Task<BookServiceModel> Details(int id);
    }
}
