namespace Library.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.UserValidation;

    public class UserLoginFormModel
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;
    }
}
