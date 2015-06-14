// // famsvanstrom.se: SsnTestController.cs
// // Author: Johan Svanström
// // Created: 2015-05-28
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
    [Controls(typeof (SsnTestPage))]
    public class SsnTestController : ContentController<SsnTestPage>
    {
        //
        // GET: /SsnTest/
        public override ActionResult Index()
        {
            if (CurrentItem == null)
            {
                // no item to render, 404 error
                Response.StatusCode = 404;
                return new EmptyResult();
            }
            return View(CurrentItem.TemplateKey, CurrentItem);
        }
	}
}