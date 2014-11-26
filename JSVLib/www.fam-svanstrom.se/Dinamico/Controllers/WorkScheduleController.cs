using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dinamico.Dinamico.Models;
using N2.Web;
using N2.Web.Mvc;

namespace www.fam_svanstrom.se.Dinamico.Controllers
{
    [Controls(typeof(SchemaModel))]
    public class WorkScheduleController : ContentController<SchemaModel>
    {
        public override ActionResult Index()
        {
            return View(CurrentItem);
        }
    }
}