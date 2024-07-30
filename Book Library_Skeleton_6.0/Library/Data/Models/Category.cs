namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.CategoryValidation;

    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}
