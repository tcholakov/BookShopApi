namespace BookShop.Services.Models.Book
{
    using BookShop.Services.Models.Author;
    using System;
    using System.Collections.Generic;

    public class BookServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public decimal Price { get; set; }
        
        public int Copies { get; set; }

        public int? Edition { get; set; }

        public AuthorShortServiceModel Author { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
