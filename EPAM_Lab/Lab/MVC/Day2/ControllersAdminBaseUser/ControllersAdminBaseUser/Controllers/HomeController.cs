using System.Web.Mvc;
using ControllersAdminBaseUser.Models;

namespace ControllersAdminBaseUser.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("ResultView", new ControllerViewModel
            {
                ControllerName = "Home",
                ActionName = "Index"
            });
        }
    }
}