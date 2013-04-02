using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace ProjectTemplate.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Membership.DeleteUser("archebald245@gmail.com", true);
            //((ExtendedMembershipProvider)Membership.Provider).DeleteAccount("archebald245@gmail.com");
            
            if (WebSecurity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard");
            return View("Index");
        }
    }
}
