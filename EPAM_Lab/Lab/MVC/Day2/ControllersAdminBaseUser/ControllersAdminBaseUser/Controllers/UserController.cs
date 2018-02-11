using System.Threading.Tasks;
using System.Web.Mvc;
using ControllersAdminBaseUser.Infrastructure;
using ControllersAdminBaseUser.Models;

namespace ControllersAdminBaseUser.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "User";
            ViewBag.Action = "Index";
            return View("ActionInfo");
        }

        [HttpPost]
        [ActionName("AddUser")]
        public async Task<ActionResult> AddUser(UserViewModel user)
        {
            await Task.Factory.StartNew(() => UserStorage.AddAsync(user));
            return RedirectToAction("UserList");
        }

        [ActionName("AddUser")]
        [HttpGet]
        public ActionResult Add()
        {
            return View("AddUser");
        }

        [HttpPost]
        [ActionName("UserList")]
        public ActionResult GetUserList()
        {
            var users = UserStorage.GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("UserList")]
        public ActionResult DisplayUserList()
        {
            return View("UserList", UserStorage.GetUsers());
        }
    }
}