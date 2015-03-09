using JSVLib.Logging;
using n2www_famsvanstrom.se.Dinamico.Models;
using n2www_famsvanstrom.se.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using www.fam_svanstrom.se.Models;
using www.fam_svanstrom.se.Services;

namespace www.fam_svanstrom.se.Dinamico.Controllers
{
    public class HemmaController : ApiController
    {
        ILog log;

        public HemmaController()
        {
            log = new JSVLib.Logging.JsvLogger(this.GetType());
        }

        public string Get()
        {
            return new DeviceStatusRepository().GetChangedStatus();
        }

        public string Post([FromBody]PostStatusRequestData indata)
        {
            log.DebugFormat("Incoming POST: {0}", indata.ToString());
            Debug.WriteLine(indata.ToString());
            new TempratureDataService().SaveTemp(indata.IndoorTemprature, indata.OutdoorTemprature, indata.IndoorHumidity);
            List<Device> devs = new List<Device>();
            foreach (var dev in indata.DeviceArray)
            {
                devs.Add(dev.AsDevice());
            }
            new DeviceStatusRepository().UpdateStatus(devs);
            return new DeviceStatusRepository().GetChangedStatus();
        }
    }
}