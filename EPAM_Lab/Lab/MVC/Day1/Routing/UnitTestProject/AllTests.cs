using System.Web.Routing;
using Machine.Specifications;
using Routing;
using It = Machine.Specifications.It;

namespace UnitTestProject
{
    [Subject("Routing")]
    public class When_routing_is_not_ok
    {
        static RouteCollection routes;
        static RouteData result;
        static bool value;
        static string url;

        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            url = "~/Home/Name/sometext";
        };

        Because of = () =>
        {
            result = routes.GetRouteData(TestHelpers.CreateHttpContext(url));
            value = (result == null || result.Route == null);
        };

        It should_not_pass = () => value.ShouldBeTrue();
    }

    [Subject("Routing")]
    public class When_routing_is_ok
    {
        static RouteCollection routes;
        static RouteData result;
        static string url;
        static string controller;
        static string action;
        static string routeProperties;

        Establish context = () =>
        {
            routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            url = "~/Home/Name/kate";
            controller = "Home";
            action = "Name";
            routeProperties = null;
        };

        Because of = () => result = routes.GetRouteData(TestHelpers.CreateHttpContext(url));

        It should_pass = () => result.ShouldNotBeNull();
        It should_also_pass = () => TestHelpers.TestIncomingRouteResult(result, controller, action, routeProperties).ShouldBeTrue();
    }
}
