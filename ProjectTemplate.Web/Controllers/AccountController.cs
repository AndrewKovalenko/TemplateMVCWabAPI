using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infrastructure.BaseRepository.Interfaces;
using ProjectTemplate.Services.DTO;
using ProjectTemplate.Web.Models.Account;
using ProjectTemplate.Web.Models.Email;
using WebMatrix.WebData;
using System.Linq;

namespace ProjectTemplate.Web.Controllers
{
    public class AccountController : Controller
    {
        private const string UserRoleName = "User";
        private readonly IRepository<User> _userRepository;

        public AccountController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        //
        // GET: /Account/
        [Authorize]
        public ActionResult SignOut()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ViewResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                UserInfoDTO userInfo = Mapper.Map<UserInfoDTO>(model);
                string confirmationToken = WebSecurity.CreateUserAndAccount(model.Email, model.Password, userInfo, requireConfirmationToken: true);
                Roles.AddUserToRole(model.Email, UserRoleName);

                ConfirmAccountModel emailModel = Mapper.Map<ConfirmAccountModel>(model);
                emailModel.ConfirmationToken = confirmationToken;

                new MailSender().ConfirmAccount(emailModel).Deliver();

                return View("Information", model: "Please check your email to confirm registration.");
            }

            return View("Information", model: "Wrong registration data");
        }

        public ViewResult ConfirmEmail(string p)
        {
            string confirmationToken = p;

            if (WebSecurity.ConfirmAccount(confirmationToken))
            {
                return View("Information", model: "Your account was successfully activated. Use your credentials to sign in.");
            }

            return View("Information", model: "Error confirming your email");

        }

        [HttpGet]
        public ViewResult ResetPassword()
        {
            return View("ResetPassword");
        }

        [HttpPost]
        public ViewResult ResetPassword(string email)
        {
            email = email.Trim();
            
            User userToResetPassword = _userRepository.GetAll().SingleOrDefault(u => u.Email == email);
            
            if (userToResetPassword == null)
            {

                return View("Information", model: "There is no such registered users.");
            }

            SendResetPasswordEmailModel emailModel = Mapper.Map<SendResetPasswordEmailModel>(userToResetPassword);
            emailModel.ResetToken = WebSecurity.GeneratePasswordResetToken(email);

            new MailSender().ResetPassword(emailModel).Deliver();

            return View("Information", model: "Check your email to continue resetting password.");
        }

        [HttpGet]
        public ViewResult SetNewPassword(string p)
        {
            SetNewPasswordModel model = new SetNewPasswordModel
                                            {
                                                ResetToken = p
                                            };

            return View("SetNewPassword", model);
        }

        [HttpPost]
        public ActionResult SetNewPassword(SetNewPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("SetNewPassword", new { p = model.ResetToken });
            }

            WebSecurity.ResetPassword(model.ResetToken, model.NewPassword);

            return View("Information", model: "Your password was changed!");
        }

        [HttpGet]
        public JsonResult UserNameValidation(string email)
        {
            //string regexpForEmail = @"^[-a-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(?:aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$";
            return Json(!WebSecurity.UserExists(email.Trim()), JsonRequestBehavior.AllowGet);
        }
    }
}
