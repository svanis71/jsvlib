using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using famsvanstrom.se.Models.Partials;

namespace famsvanstrom.se.Dinamico.Controllers
{
    [Controls(typeof(WeatherPartialModel))]
    public class WeatherController : ContentController<WeatherPartialModel>
    {
        //
        // GET: /Weather/
        public override ActionResult Index()
        {
            return PartialView();
        }
	}
}