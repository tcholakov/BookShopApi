namespace BookShop.Services.Infrastructure.Mapping
{
    using System.Linq;
    using AutoMapper;
    using BookShop.Data.Models;
    using BookShop.Services.Models.Author;
    using BookShop.Services.Models.Book;

    public class AutoMapperServiceProfile : Profile
    {
        public AutoMapperServiceProfile()
        {
            this.AuthorMappings();
            this.BookMappings();
        }

        private void AuthorMappings()
        {
            this.CreateMap<Author, AuthorShortServiceModel>();

            this.CreateMap<Author, AuthorDetailsServiceModel>()
                .ForMember(authorServiceModel => authorServiceModel.Books, cfg => cfg.MapFrom(authorDataModel => authorDataModel.Books.Select(book => book.Title)));
        }

        private void BookMappings()
        {
            this.CreateMap<Book, BookServiceModel>()
                .ForMember(bookServiceModel => bookServiceModel.Categories, cfg => cfg.MapFrom(bookDataModel => bookDataModel.Categories.Select(bookCategory => bookCategory.Category.Name)));

            this.CreateMap<BookInputServiceModel, Book>();
        }
    }
}
