using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace ProjectTemplate.Web.Models.Account
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Email(ErrorMessage = "Wrong email format")]
        [Remote("UserNameValidation", "Account", ErrorMessage = "Such email already registered")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Repeat password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RepeatedPassword { get; set; }
    }
}