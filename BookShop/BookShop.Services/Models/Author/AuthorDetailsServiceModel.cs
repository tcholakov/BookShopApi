namespace BookShop.Services.Models.Author
{
    using System.Collections.Generic;

    public class AuthorDetailsServiceModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public IEnumerable<string> Books { get; set; }
    }
}
