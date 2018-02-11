using System.Web.Mvc;
using ControllersWithCustomFactory.Models;

namespace ControllersWithCustomFactory.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("ResultView", new Result
            {
                ControllerName = "Home",
                ActionName = "Index"
            });
        }

        public ActionResult List()
        {
            return View("ResultView", new Result
            {
                ControllerName = "Home",
                ActionName = "List"
            });
        }
    }
}