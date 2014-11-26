using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace playwithcanvas.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Breakout()
        {
            return View();
        }

        public ActionResult Scroller()
        {
            return View();
        }
    }
}
