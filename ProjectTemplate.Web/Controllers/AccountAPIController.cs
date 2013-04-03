using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infrastructure.BaseRepository.Interfaces;
using ProjectTemplate.Services.DTO;
using ProjectTemplate.Web.Models.Account;
using WebMatrix.WebData;
using System.Linq;

namespace ProjectTemplate.Web.Controllers
{
    public class AccountAPIController : ApiController
    {
        private readonly IRepository<User> _userRepository;

        public AccountAPIController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public HttpResponseMessage PostSignIn(AccountModel model)
        {

            object responseContent;
            if (ModelState.IsValid)
            {
                responseContent = new
                                      {
                                          loginStatus =
                                              WebSecurity.Login(model.UserName,
                                                                model.Password)
                                      };
            }
            else
            {
                responseContent = new
                {
                    loginStatus = false
                };
            }

            return Request.CreateResponse(HttpStatusCode.OK, responseContent);
        }

        public HttpResponseMessage AuthorizeFbUser(FacebookUserInformation userInformation)
        {
            User fbProjectTemplateUser =
                _userRepository.GetAll().SingleOrDefault(u => u.FacebookUid == userInformation.FacebookUid);

            if (fbProjectTemplateUser == null)
            {
                User ProjectTemplateUser = _userRepository.GetAll().SingleOrDefault(u => u.Email == userInformation.Email);

                if (ProjectTemplateUser != null)
                {
                    ProjectTemplateUser.FacebookUid = userInformation.FacebookUid;
                    _userRepository.SaveOrUpdate(ProjectTemplateUser);
                }
                else
                {
                    UserInfoDTO userInfo = Mapper.Map<UserInfoDTO>(userInformation);
                    string password = Membership.GeneratePassword(6, 3);
                    WebSecurity.CreateUserAndAccount(userInformation.Email, password, userInfo);
                }
            }

            FormsAuthentication.SetAuthCookie(userInformation.Email, createPersistentCookie: false);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new { url = Url.Link("Default", new { controller = "Dashboard", action = "Index" }) });
            return response;
        }
    }
}
