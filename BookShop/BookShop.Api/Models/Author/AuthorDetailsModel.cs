namespace BookShop.Api.Models.Author
{
    using System.Collections.Generic;
    
    public class AuthorDetailsModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<string> Books { get; set; }
    }
}
