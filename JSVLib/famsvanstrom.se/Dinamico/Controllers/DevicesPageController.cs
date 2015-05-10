using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using famsvanstrom.se.Models.Pages;

namespace famsvanstrom.se.Dinamico.Controllers
{
    [Controls(typeof(DevicesPageModel))]
    public class DevicesPageController : ContentController<DevicesPageModel>
    {
        //
        // GET: /DevicesPage/
        public override ActionResult Index()
        {
            return View(CurrentItem);
        }
	}
}