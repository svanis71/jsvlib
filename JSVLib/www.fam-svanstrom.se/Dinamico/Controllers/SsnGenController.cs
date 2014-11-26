using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using Dinamico.Dinamico.Models;
using N2.Web;
using N2.Web.Mail;
using N2.Web.Mvc;

namespace Dinamico.Dinamico.Controllers
{
    [Controls(typeof(SsnGenModel))]
    public class SsnGenController : ContentController<SsnGenModel>
    {
        public override ActionResult Index()
        {
            //return View(new SsnGenModel() { DefaultNumberOfSsn = "1000" });
            return View(CurrentItem);
        }

        //public ActionResult SendMessage(string mess)
        //{
        //    var mailer = new SmtpMailSender();
        //    var msg = new MailMessage("info@fam-svanstrom.se", "johan@fam-svanstrom.se");
        //    msg.Body = "Hej från webben";
        //    msg.Subject = "Mail test";

        //    mailer.Send(msg);

        //    return RedirectToAction("Test");
        //}
    }
}