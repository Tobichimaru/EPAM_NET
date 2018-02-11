using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ControllersWithCustomFactory.Controllers;

namespace ControllersWithCustomFactory.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName)
            {
                case "Home":
                    targetType = typeof(HomeController);
                    break;
                case "User":
                    targetType = typeof(UserController);
                    break;
                default:
                    requestContext.RouteData.Values["controller"] = "User";
                    targetType = typeof(UserController);
                    break;
            }
            return (IController) DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            disposable?.Dispose();
        }
    }
}