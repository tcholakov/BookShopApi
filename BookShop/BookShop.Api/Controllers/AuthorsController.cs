namespace BookShop.Api.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using BookShop.Api.Infrastructure.Filters;
    using BookShop.Api.Models.Author;
    using BookShop.Services.Author.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            this.authorService = authorService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var authorServiceModel = await this.authorService.Details(id);

            if (authorServiceModel == null)
            {
                return this.NotFound();
            }

            var authorModel = this.mapper.Map<AuthorDetailsModel>(authorServiceModel);

            return this.Ok(authorModel);
        }
        
        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetBooks(int id)
        {
            var authorsBooks = await this.authorService.BooksByAuthor(id);

            return this.Ok(authorsBooks);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post(AuthorRequestModel author)
        {
            int id = await this.authorService.Create(author.FirstName, author.LastName);

            return this.Ok(id);
        }
    }
}
