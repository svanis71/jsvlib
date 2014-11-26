using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using N2.Web.Mvc;

namespace Dinamico.Dinamico.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("LogOn");
        }

        public ActionResult LogOn()
        {
            return RedirectToActionPermanent("LogOn", "Membership", new { returnUrl = Request["returnUrl"] ?? N2.Find.StartPage.Url });
        }

        public ActionResult ControlPanel()
        {
            return RedirectToActionPermanent("LogOn", "Membership", new { returnUrl = "/N2" });
        }
    }
}