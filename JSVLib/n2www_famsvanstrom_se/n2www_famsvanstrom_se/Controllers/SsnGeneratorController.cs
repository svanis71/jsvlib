using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using n2www_famsvanstrom_se.Models;

namespace n2www_famsvanstrom_se.Controllers
{
    [Controls(typeof(SsnGenerator))]
    public class SsnGeneratorController : ContentController<SsnGenerator>
    {
        public override ActionResult Index()
        {
            return PartialView((string)CurrentItem.TemplateKey, CurrentItem);
        }
    }
}