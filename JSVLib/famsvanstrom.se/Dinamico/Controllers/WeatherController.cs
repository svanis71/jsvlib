// // famsvanstrom.se: WeatherController.cs
// // Author: Johan Svanström
// // Created: 2015-05-10
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Linq;
using System.Web.Mvc;
using N2.Web;
using N2.Web.Mvc;
using famsvanstrom.se.Models.Partials;
using famsvanstrom.se.Services;

#endregion

namespace famsvanstrom.se.Dinamico.Controllers
{
    [Controls(typeof(WeatherPartialModel))]
    public class WeatherController : ContentController<WeatherPartialModel>
    {
        //
        // GET: /Weather/
        public override ActionResult Index()
        {
            return PartialView(CurrentItem);
        }

        [HttpGet]
        public ActionResult GetForecast(string id)
        {
            var forecasts = new SmhiForecastService(id).GetForecast().ToArray();
            return PartialView(forecasts); //Json(forecasts, JsonRequestBehavior.AllowGet);
        }
	}
}