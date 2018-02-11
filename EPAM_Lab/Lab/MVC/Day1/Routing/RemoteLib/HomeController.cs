using System.Web.Mvc;

namespace RemoteLib
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Json("Hello from remote controller", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Name(string name)
        {
            ViewBag.LinkableId = name;
            return Json(name, JsonRequestBehavior.AllowGet);
        }
        
    }
}
