using System;
using System.Web.Mvc;

namespace ControllersAdminBaseUser.Controllers
{
    public class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            try
            {
                View(actionName).ExecuteResult(ControllerContext);
            }
            catch (InvalidOperationException)
            {
                View("Error404").ExecuteResult(ControllerContext);
            }
        }
    }
}