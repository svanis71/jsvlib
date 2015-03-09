using JSVLib.Logging;
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
        ILog _logger;

        public DevicesController()
        {
            _logger = new JsvLogger(this.GetType());
        }

        public override ActionResult Index()
        {
            _logger.DebugFormat("Index in {0}", CurrentItem.Weather.ToString());
            return View(CurrentItem);
        }

        [HttpPost]
        public ActionResult SendNewStatus(Device[] newData) 
        {
            return Json(new { saved = true });
        }
    }
}