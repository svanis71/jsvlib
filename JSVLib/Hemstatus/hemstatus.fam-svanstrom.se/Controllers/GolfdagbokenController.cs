using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hemstatus.fam_svanstrom.se.Controllers
{
    [Authorize]
    public class GolfdagbokenController : Controller
    {
        //
        // GET: /Golfdagboken/

        public ActionResult Index()
        {
            return View();
        }

    }
}
