// // famsvanstrom.se: Global.asax.cs
// // Author: Johan Svanström
// // Created: 2015-04-30
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using famsvanstrom.se.App_Start;

#endregion

namespace famsvanstrom.se
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
