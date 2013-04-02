namespace ProjectTemplate.Web.Models.Email
{
    public class ConfirmAccountModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ConfirmationToken { get; set; }
        public string Email { get; set; }
    }
}