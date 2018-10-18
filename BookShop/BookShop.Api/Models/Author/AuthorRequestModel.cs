namespace BookShop.Api.Models.Author
{
    using System.ComponentModel.DataAnnotations;

    using static BookShop.Common.Constants.AuthorConstants;

    public class AuthorRequestModel
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }
    }
}
