using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hemstatus.fam_svanstrom.se.Models;

namespace hemstatus.fam_svanstrom.se.Controllers
{
    public class ProjectEulerController : Controller
    {
        //
        // GET: /ProjectEuler/

        public ActionResult Index()
        {
            return View(model: new ProblemList().GetResults());
        }

    }
}
