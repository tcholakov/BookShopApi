namespace BookShop.Api.Models.Book
{
    using BookShop.Api.Models.Author;

    public class BookDetailedModel : BookWithCategoriesModel
    {
        public AuthorShortModel Author { get; set; }
    }
}
