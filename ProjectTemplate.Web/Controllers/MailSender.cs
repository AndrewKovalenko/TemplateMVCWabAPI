using ActionMailer.Net.Mvc;
using ProjectTemplate.Web.Models.Account;
using ProjectTemplate.Web.Models.Email;

namespace ProjectTemplate.Web.Controllers
{
    public class MailSender : MailerBase
    {
        private const string EmailAddress = "support@uarank.com";

        public EmailResult ConfirmAccount(ConfirmAccountModel model)
        {
            To.Add(model.Email);
            From = EmailAddress;
            Subject = "Confirm mail account";

            return Email("EmailConfirmation", model);
        }

        public EmailResult ResetPassword(SendResetPasswordEmailModel emailModel)
        {
            To.Add(emailModel.Email);
            From = EmailAddress;
            Subject = "Reset password";

            return Email("ResetPassword", emailModel);
        }
    }
}