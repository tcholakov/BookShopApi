namespace BookShop.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Api.Infrastructure.Filters;
    using BookShop.Api.Models.Book;
    using BookShop.Services.Author.Contracts;
    using BookShop.Services.Book.Contracts;
    using BookShop.Services.Category.Contracts;
    using BookShop.Services.Models.Book;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public BooksController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService, IMapper mapper)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bookServiceModel = await this.bookService.Details(id);

            if (bookServiceModel == null)
            {
                return this.NotFound();
            }

            var bookApiModel = this.mapper.Map<BookDetailedModel>(bookServiceModel);

            return this.Ok(bookApiModel);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
        {
            var booksServiceModel = await this.bookService.Filter(search);

            var booksApiModel = booksServiceModel.Select(bookServiceModel => this.mapper.Map<BookDetailedModel>(bookServiceModel));

            return this.Ok(booksApiModel);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post(BookRequestModel book)
        {
            bool authorExists = await this.authorService.Exists(book.AuthorId);

            if (!authorExists)
            {
                return this.BadRequest("Author does not exist");
            }

            var bookInputModel = this.mapper.Map<BookInputServiceModel>(book);
            
            if (book.Categories != null)
            {
                var categoryIds = new List<int>();
                foreach (var categoryName in book.Categories)
                {
                    var category = await this.categoryService.GetByName(categoryName);

                    if (category == null)
                    {
                        categoryIds.Add(await this.categoryService.Create(categoryName));
                    }
                    else
                    {
                        categoryIds.Add(category.Id);
                    }
                }

                bookInputModel.CategoryIds = categoryIds;
            }

            int bookId = await this.bookService.Create(bookInputModel);

            return this.Ok(bookId);
        }
    }
}
