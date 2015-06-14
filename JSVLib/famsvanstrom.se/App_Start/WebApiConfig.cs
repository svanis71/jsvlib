// // famsvanstrom.se: WebApiConfig.cs
// // Author: Johan Svanström
// // Created: 2015-05-23
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Web.Http;

#endregion

namespace famsvanstrom.se
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
