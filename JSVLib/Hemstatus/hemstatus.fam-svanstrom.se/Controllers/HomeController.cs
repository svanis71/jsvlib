using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hemstatus.fam_svanstrom.se.Models;

namespace hemstatus.fam_svanstrom.se.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var repo = new DeviceRepository();
            var devs = new DeviceModelRepo();
            devs.AddRange(repo.GetAll().Select(device => new DeviceModel(device)));
            return View(devs);
        }
    }
}
