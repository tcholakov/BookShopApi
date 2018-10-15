namespace BookShop.Api.Infrastructure.Mapping
{
    using AutoMapper;
    using BookShop.Api.Models.Author;
    using BookShop.Services.Models.Author;

    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            this.AuthorMappings();
        }

        private void AuthorMappings()
        {
            this.CreateMap<AuthorDetailsServiceModel, AuthorDetailsModel>();
        }
    }
}
