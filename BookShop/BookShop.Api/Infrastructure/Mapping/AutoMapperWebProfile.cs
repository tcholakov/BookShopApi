namespace BookShop.Api.Infrastructure.Mapping
{
    using AutoMapper;
    using BookShop.Api.Models.Author;
    using BookShop.Api.Models.Book;
    using BookShop.Services.Models.Author;
    using BookShop.Services.Models.Book;

    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            this.AuthorMappings();
            this.BookMappings();
        }

        private void AuthorMappings()
        {
            this.CreateMap<AuthorDetailsServiceModel, AuthorDetailsModel>();
        }

        private void BookMappings()
        {
            this.CreateMap<BookServiceModel, BookByAuthorModel>();
        }
    }
}
