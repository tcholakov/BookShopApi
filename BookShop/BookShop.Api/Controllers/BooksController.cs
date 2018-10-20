namespace BookShop.Api.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Api.Models.Book;
    using BookShop.Services.Book.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
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
    }
}
