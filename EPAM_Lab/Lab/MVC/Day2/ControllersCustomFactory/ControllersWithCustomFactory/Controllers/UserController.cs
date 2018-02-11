using System.Web.Mvc;
using ControllersWithCustomFactory.Models;

namespace ControllersWithCustomFactory.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View("ResultView", new Result
            {
                ControllerName = "User",
                ActionName = "Index"
            });
        }

        public ActionResult List()
        {
            return View("ResultView", new Result
            {
                ControllerName = "User",
                ActionName = "List"
            });
        }
    }
}