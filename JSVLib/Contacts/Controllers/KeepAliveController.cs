using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Controllers
{
    public class KeepAliveController : Controller
    {
        //
        // GET: /KeepAlive/

        public JsonResult Index()
        {
            return Json(new {Dummy = 1}, JsonRequestBehavior.AllowGet );
        }

    }
}
