using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts.Models.Page;

namespace Contacts.Controllers
{
    public class MathsController : Controller
    {
        //
        // GET: /MathTraining/

        public ActionResult Index()
        {
            return View(new MathTraingViewModel());
        }

        [HttpPost]
        public ActionResult Train(int numbers, Difficulty difficulty)
        {
            var mgr = new MathTraining();
            var list = mgr.GetItems(numbers, difficulty);
            return View(list);
        }
    }
}
