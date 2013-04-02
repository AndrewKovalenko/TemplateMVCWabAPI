using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjectTemplate.Web.Models.Account
{
    public class SetNewPasswordModel
    {
        public string ResetToken { get; set; }
        [Display(Name = "New password:")]
        public string NewPassword { get; set; }

        [Display(Name = "Repeat new password:")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}