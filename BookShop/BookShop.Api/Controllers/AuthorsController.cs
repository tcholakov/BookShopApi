namespace BookShop.Api.Controllers
{
    using AutoMapper;
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
        public IActionResult Get(int id)
        {
            var authorServiceModel = this.authorService.Details(id);

            if(authorServiceModel == null)
            {
                return this.NotFound();
            }

            var authorModel = this.mapper.Map<AuthorDetailsModel>(authorServiceModel);

            return this.Ok(authorModel);
        }
    }
}
