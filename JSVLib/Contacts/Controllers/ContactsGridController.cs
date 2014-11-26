using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts.Models.Page;

namespace Contacts.Controllers
{
    public class ContactsGridController : Controller
    {
        //
        // GET: /ContactsGrid/

        public ActionResult Index()
        {


            return View(new ContactDataProvider().GetItems());
        }

        public JsonResult Test()
        {
            //{
            //    "total":"1",
            //    "page":"1",
            //    "records":"1",

            //    "rows":[
            //        {"id":"1",
            //        "cell":[
            //            {"invid":1,
            //            "invdate":"2010-01-01",
            //            "amount":1001,
            //            "tax":250,
            //            "total":1251,
            //            "note":"Funka nu!"}
            //        ]
            //        }
            //    ]
            //}
            var prov = new ContactDataProvider();
            var cnts = from p in prov.GetItems()
                       select new
                       {
                           id = p.Id,
                           cell = new string[] { p.Id.ToString(), p.Lastname + ", " + p.Firstname, p.Email },
                       };
            var resp = new
            {
                total = cnts.Count(),
                page = 1,
                records = cnts.Count(),
                rows = cnts.ToArray()
            };
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
    }
}
