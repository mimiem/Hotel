namespace Hotel.Web.Hotel.Web.ViewModels.Account
{
    using CustomAttributes;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [Email]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Text can be only {1} symbols")]
        [RegularExpression("^[a-zA-Z0-9-]+$", ErrorMessage = "{0} can contain letters, digits and dash")]
        [DataType(DataType.Text)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Text can be only {1} symbols")]
        [RegularExpression("^[a-zA-Z0-9-]+$", ErrorMessage = "{0} can contain letters, digits and dash")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [PhoneNumber]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърди парола")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}