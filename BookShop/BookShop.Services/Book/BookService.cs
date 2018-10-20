namespace BookShop.Services.Book
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Data;
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

        public async Task<BookServiceModel> Details(int id)
        {
            var bookModel = await this.bookShopDbContext
                .Books
                .Include(book => book.Author)
                .Include(book => book.Categories)
                .ThenInclude(bookCategory => bookCategory.Category)
                .Where(book => book.Id == id)
                .ToAsyncEnumerable()
                .Select(bookDataModel =>
                {
                    var bookServiceModel = this.mapper.Map<BookServiceModel>(bookDataModel);
                    bookServiceModel.Categories = bookDataModel.Categories.Select(categoryBook => categoryBook.Category.Name);
                    return bookServiceModel;
                })
                .FirstOrDefault();

            return bookModel;
        }
    }
}
