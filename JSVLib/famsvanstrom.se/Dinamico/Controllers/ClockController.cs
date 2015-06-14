// // famsvanstrom.se: ClockController.cs
// // Author: Johan Svanström
// // Created: 2015-05-12
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Web.Mvc;

#endregion

namespace famsvanstrom.se.Dinamico.Controllers
{
    public class ClockController : Controller
    {
        //
        // GET: /Clock/
        public ActionResult Index()
        {
            return View();
        }
	}
}