using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contacts.Models.Page;

namespace Contacts.Controllers
{
    public class EnergyStatementsController : Controller
    {
        //
        // GET: /EnergyStatements/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EnergystatementModel model)
        {
            try
            {
                string url1 =
            string.Format("https://gripen2.boverket.se/Gripen/Public/CreatePdf?p={0}&full=1&loggId=43&email=kalle.anka@ankeborg.se&apikey=8DD8AE50-BB53-4224-B4EB-AD58AB5DB1FB", model.DeklId);

                // För att förhindra SSL certifikatfel
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                HttpWebRequest webRequest1 = (HttpWebRequest)WebRequest.Create(url1);
                webRequest1.ContentType = "text/plain";
                webRequest1.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705)";
                var resp1 = (HttpWebResponse)webRequest1.GetResponse();
                StreamReader sr1 = new StreamReader(resp1.GetResponseStream());
                var url = sr1.ReadToEnd();
                var webRequest = HttpWebRequest.Create(url);

                var resp = (HttpWebResponse)webRequest.GetResponse();
                var appDataPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
                var fileName = Path.Combine(appDataPath, model.Filename);
                using (Stream localFileStream = System.IO.File.Create(fileName))
                {
                    var sr = resp.GetResponseStream();
                    sr.CopyTo(localFileStream);
                    sr.Close();
                    localFileStream.Close();
                }
            }
            catch (Exception)
            {
            }

            try
            {
                var url1 =
            string.Format("https://gripen2.boverket.se/Gripen/Public/DeletePdf?p={0}&apikey=8DD8AE50-BB53-4224-B4EB-AD58AB5DB1FB", model.DeklId);
                var webRequest1 = HttpWebRequest.Create(url1);
                var resp1 = (HttpWebResponse)webRequest1.GetResponse();
                webRequest1.Method = "POST";
                var sr1 = new StreamReader(resp1.GetResponseStream());
                var stat = sr1.ReadToEnd();

            }
            catch (Exception)
            {
            }

            return View();
        }
    }
}
