namespace BookShop.Api.Models.Book
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static BookShop.Common.Constants.BookConstants;

    public class BookRequestModel
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; }

        public int AuthorId { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}
