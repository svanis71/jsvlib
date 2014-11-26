using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Contacts.Handlers;
using Contacts.Helpers;

namespace Contacts
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static Thread _keepAliveThread = new Thread(KeepAlive);

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.Add(new Route("image/get" ,new HttpHandlerRoute(typeof(GetImage))));
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            //StartKeepAliveThread();
        }

        protected void Application_End()
        {
            KillKeepAliveThread();
        }

        private void KillKeepAliveThread()
        {
            if(_keepAliveThread.IsAlive)
                _keepAliveThread.Abort();
        }

        private void StartKeepAliveThread()
        {
            _keepAliveThread.Start();            
        }

        static void KeepAlive()
        {
            while(true)
            {
                Debug.WriteLine(string.Format("{0}: KeepAlive!", DateTime.Now.ToString()));
                WebRequest req = WebRequest.Create("http://localhost:60567/KeepAlive");
                req.GetResponse();
                try
                {
                    Thread.Sleep(60000);
                }
                catch (ThreadAbortException)
                {
                    break;
                }
            }
        }
    }
}