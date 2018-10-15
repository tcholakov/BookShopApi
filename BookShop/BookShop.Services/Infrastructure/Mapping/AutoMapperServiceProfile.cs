namespace BookShop.Services.Infrastructure.Mapping
{
    using System.Linq;
    using AutoMapper;
    using BookShop.Data.Models;
    using BookShop.Services.Models.Author;
    
    public class AutoMapperServiceProfile : Profile
    {
        public AutoMapperServiceProfile()
        {
            this.AuthorMappings();
        }

        private void AuthorMappings()
        {
            this.CreateMap<Author, AuthorDetailsServiceModel>()
                .ForMember(authorServiceModel => authorServiceModel.Books, cfg => cfg.MapFrom(authorDataModel => authorDataModel.Books.Select(book => book.Title)));
        }
    }
}
