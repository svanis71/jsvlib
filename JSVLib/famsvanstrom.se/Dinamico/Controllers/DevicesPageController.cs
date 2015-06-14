// // famsvanstrom.se: DevicesPageController.cs
// // Author: Johan Svanström
// // Created: 2015-05-09
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using famsvanstrom.se.Models.Pages;

#endregion

namespace famsvanstrom.se.Dinamico.Controllers
{
    [Controls(typeof(DevicesPageModel))]
    public class DevicesPageController : ContentController<DevicesPageModel>
    {
        //
        // GET: /DevicesPage/
        public override ActionResult Index()
        {
            CurrentItem = new DevicesPageModel();
            return View(CurrentItem);
        }
	}
}