namespace Library.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.UserValidation;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ApplicationUsersBooks = new HashSet<ApplicationUserBook>();
        }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(UserNameMaxLength)]
        public override string UserName
        {
            get => base.UserName;
            set => base.UserName = value;
        }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(EmailMaxLength)]
        public override string Email
        {
            get => base.Email;
            set => base.Email = value;
        }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; set; } = null!;

        public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; }
    }
}
