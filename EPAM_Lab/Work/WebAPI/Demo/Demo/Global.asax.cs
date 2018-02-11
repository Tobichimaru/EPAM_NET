using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Demo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs args)
        {
            GlobalConfiguration.Configuration.Routes.Add("default", new HttpRoute("{controller}"));
        }

        protected void Session_Start(object sender, EventArgs args)
        {

        }
    }
}
