using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Routing
{
    public class ExpectedValueConstrains : IRouteConstraint
    {
        private readonly string[] _values;

        public ExpectedValueConstrains(params string[] values)
        {
            _values = values;
        }

        public bool Match(HttpContextBase httpContext, Route route,
            string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return _values.Contains(values[parameterName].ToString(),
                StringComparer.InvariantCultureIgnoreCase);
        }
    }
   
}