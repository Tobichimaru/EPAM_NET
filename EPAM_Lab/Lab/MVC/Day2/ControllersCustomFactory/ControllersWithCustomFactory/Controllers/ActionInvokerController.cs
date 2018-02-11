using System.Web.Mvc;

namespace ControllersWithCustomFactory.Controllers
{
    public class ActionInvokerController : Controller
    {
        // GET: ActionInvoker
        public ActionInvokerController()
        {
            ActionInvoker = new ControllerActionInvoker();
        }
    }
}