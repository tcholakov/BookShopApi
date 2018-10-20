namespace BookShop.Api.Models.Author
{
    using System.Collections.Generic;
    
    public class AuthorDetailsModel : AuthorShortModel
    {
        public IEnumerable<string> Books { get; set; }
    }
}
