using N2.Web;
using N2.Web.Mvc;
using n2www_famsvanstrom_se.Dinamico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n2www_famsvanstrom_se.Dinamico.Controllers
{
    [Controls(typeof(DevicePageModel))]
    public class DevicesController : ContentController<DevicePageModel>
    {
        public override System.Web.Mvc.ActionResult Index()
        {
            return View(CurrentItem);
        }
    }
}