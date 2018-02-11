using System.Web.Mvc;
using ControllersAdminBaseUser.Infrastructure;

namespace ControllersAdminBaseUser.Controllers
{
    public class AdminController : BaseController
    {
        [Local]
        public ActionResult Index()
        {
            ViewBag.Controller = "AdminController";
            ViewBag.Action = "Index";
            return View("ActionInfo");
        }

        [Local]
        public ActionResult RemoveAllUsers()
        {
            UserStorage.Clear();
            return View("UserList", UserStorage.GetUsers());
        }
    }
}