using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ControllersWithCustomFactory.Infrastructure;

namespace ControllersWithCustomFactory
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new CustomControllerActivator()));
        }
    }
}