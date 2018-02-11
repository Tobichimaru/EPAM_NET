using System;
using System.Web.Mvc;
using System.Web.Routing;
using ControllersWithCustomFactory.Controllers;

namespace ControllersWithCustomFactory.Infrastructure
{
    public class CustomControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(UserController))
                controllerType = typeof(HomeController);
            return (IController) DependencyResolver.Current.GetService(controllerType);
        }
    }
}