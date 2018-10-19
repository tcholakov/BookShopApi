namespace BookShop.Services.Models.Author
{
    using System.Collections.Generic;

    public class AuthorDetailsServiceModel : AuthorShortServiceModel
    {
        public IEnumerable<string> Books { get; set; }
    }
}
