
using System.Linq;
using System.Web.Mvc;
using ViewsTask.Models;

namespace ViewsTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(UserStorage.Users);
        }

        public ActionResult Info(int userId)
        {
            return View(UserStorage.Users.First(u => u.Id == userId));
        }

        [HttpGet]
        public ActionResult DisplayHeader(User user)
        {
            return PartialView("_header", user);
        }

        public ActionResult ChangeFraction(int userId)
        {
            var userToChange = UserStorage.GetUsers().FirstOrDefault(p => p.Id == userId);
            userToChange?.ChangeFraction();
            return RedirectToAction("Info", new { userId = userId});
        }
    }
}