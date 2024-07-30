namespace Library.Models.Book
{
    using Library.Models.Category;
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.BookValidation;

    public class BookAddPostModel
    {
        public BookAddPostModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }

        [Required(AllowEmptyStrings = false)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
