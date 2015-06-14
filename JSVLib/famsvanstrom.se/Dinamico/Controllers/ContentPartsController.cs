// // famsvanstrom.se: ContentPartsController.cs
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
    [Controls(typeof(Models.ContentPart))]
    public class ContentPartsController : ContentController<Models.ContentPart>
    {

        public override ActionResult Index()
        {
            return PartialView((string)CurrentItem.TemplateKey, CurrentItem);
        }

    }

    [Controls(typeof(Slideshow))]
    public class SlideshowController : ContentController<Slideshow>
    {
        public override ActionResult Index()
        {
            return PartialView((string)CurrentItem.TemplateKey, CurrentItem);
        }
    }

}
