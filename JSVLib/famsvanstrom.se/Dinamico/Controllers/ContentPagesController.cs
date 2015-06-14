// // famsvanstrom.se: ContentPagesController.cs
// // Author: Johan Svanström
// // Created: 2015-04-30
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;

#endregion

namespace Dinamico.Controllers
{
	[Controls(typeof(Models.ContentPage))]
	public class ContentPagesController : ContentController<Models.ContentPage>
	{

		public override ActionResult Index()
		{
			if (CurrentItem == null)
			{
				//TODO: Maybe could search for an error page and display that instead?

				// no item to render, 404 error
				Response.StatusCode = 404;
				return new EmptyResult();
			}
			return View(CurrentItem.TemplateKey, CurrentItem);
		}
	}
}
