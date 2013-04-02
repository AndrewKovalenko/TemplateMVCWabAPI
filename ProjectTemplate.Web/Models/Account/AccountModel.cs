using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Web.Models.Account
{
    public class AccountModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}