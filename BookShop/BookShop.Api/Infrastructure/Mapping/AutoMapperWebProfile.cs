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
            this.CreateMap<AuthorShortServiceModel, AuthorShortModel>()
                .ForMember(authorApiModel => authorApiModel.Name, cfg => cfg.MapFrom(authorServiceModel => authorServiceModel.FirstName + " " + authorServiceModel.LastName));

            this.CreateMap<AuthorDetailsServiceModel, AuthorDetailsModel>()
                .ForMember(authorApiModel => authorApiModel.Name, cfg => cfg.MapFrom(authorServiceModel => authorServiceModel.FirstName + " " + authorServiceModel.LastName));
        }

        private void BookMappings()
        {
            this.CreateMap<BookServiceModel, BookWithCategoriesModel>();

            this.CreateMap<BookServiceModel, BookDetailedModel>();

            this.CreateMap<BookRequestModel, BookInputServiceModel>();
        }
    }
}
