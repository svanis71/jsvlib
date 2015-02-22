using N2.Web;
using N2.Web.Mvc;
using n2www_famsvanstrom.se.Dinamico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n2www_famsvanstrom.se.Dinamico.Controllers
{
    [Controls(typeof(DevicePageModel))]
    public class DevicesController : ContentController<DevicePageModel>
    {
        public override ActionResult Index()
        {
            return View(CurrentItem);
        }

        [HttpPost]
        public ActionResult SendNewStatus(Device[] newData) 
        {
            return Json(new { saved = true });
        }
    }
}