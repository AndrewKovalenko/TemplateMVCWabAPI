namespace ProjectTemplate.Web.Models.Account
{
    public class SendResetPasswordEmailModel
    {
        public string Email { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string ResetToken { get; set; }
    }
}