namespace BookShop.Services.Book
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Services.Book.Contracts;
    using BookShop.Services.Models.Book;
    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        private readonly BookShopDbContext bookShopDbContext;
        private readonly IMapper mapper;

        public BookService(BookShopDbContext bookShopDbContext, IMapper mapper)
        {
            this.bookShopDbContext = bookShopDbContext;
            this.mapper = mapper;
        }

        public async Task<int> Create(BookInputServiceModel book)
        {
            var bookDataModel = this.mapper.Map<Book>(book);

            if (book.CategoryIds != null)
            {
                foreach (var categoryId in book.CategoryIds)
                {
                    var bookCategory = new BookCategory
                    {
                        CategoryId = categoryId
                    };

                    bookDataModel.Categories.Add(bookCategory);
                }
            }

            this.bookShopDbContext.Add(bookDataModel);
            await this.bookShopDbContext.SaveChangesAsync();

            return bookDataModel.Id;
        }

        public async Task<IEnumerable<BookServiceModel>> Filter(string searchText)
        {
            var books = await this.bookShopDbContext
                .Books
                .Include(book => book.Author)
                .Include(book => book.Categories)
                .ThenInclude(bookCategory => bookCategory.Category)
                .Where(book => book.Title.ToLower().Contains(searchText.ToLower()) || book.Description.ToLower().Contains(searchText.ToLower()))
                .OrderBy(book => book.Title)
                .ToAsyncEnumerable()
                .Select(bookDataModel => this.mapper.Map<BookServiceModel>(bookDataModel))
                .ToList();

            return books;
        }

        public async Task<BookServiceModel> Details(int id)
        {
            var bookModel = await this.bookShopDbContext
                .Books
                .Include(book => book.Author)
                .Include(book => book.Categories)
                .ThenInclude(bookCategory => bookCategory.Category)
                .Where(book => book.Id == id)
                .ToAsyncEnumerable()
                .Select(bookDataModel => this.mapper.Map<BookServiceModel>(bookDataModel))
                .FirstOrDefault();

            return bookModel;
        }
    }
}
