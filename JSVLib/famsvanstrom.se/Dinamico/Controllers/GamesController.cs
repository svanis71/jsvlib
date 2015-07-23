using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N2.Web.Mvc;
using famsvanstrom.se.Models.Pages;

namespace famsvanstrom.se.Dinamico.Controllers
{
    public class GamesController : ContentController<GamesPage>
    {
        //
        // GET: /Games/
        public override ActionResult Index()
        {
            if (CurrentItem == null)
            {
                // no item to render, 404 error
                Response.StatusCode = 404;
                return new EmptyResult();
            }
            return View(CurrentItem.TemplateKey, CurrentItem);
        }

        public ActionResult Breakout()
        {
            if (CurrentItem == null)
            {
                // no item to render, 404 error
                Response.StatusCode = 404;
                return new EmptyResult();
            }
            return View(CurrentItem.TemplateKey, CurrentItem);
        }
	}
}