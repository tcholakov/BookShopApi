﻿namespace BookShop.Api.Models.Book
{
    using System;
    using System.Collections.Generic;

    public class BookWithCategoriesModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public int? Edition { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
