namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static BookShop.Common.Constants.CategoryConstants;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<BookCategory> Books { get; set; } = new List<BookCategory>();
    }
}
