using System;
using System.Web.Mvc;
using Dinamico.Models;
using N2.Web;
using N2.Web.Mvc;

namespace Dinamico.Controllers
{
    /// <summary>
    /// This controller returns a view that displays the item created via the management interface
    /// </summary>
    [Controls(typeof(Models.MathTraining))]
    public class MathTrainingController : ContentController<Models.MathTraining>
    {
        public override ActionResult Index()
        {
            // Right-click and Add View..
            return View(CurrentItem); // Passing the current content item is optional
        }

        public ActionResult Train(int numbers, Level level)
        {
            var mgr = new MathTraining();
            var list = mgr.GetItems(numbers, level);
            return View(list);
        }
    }
}