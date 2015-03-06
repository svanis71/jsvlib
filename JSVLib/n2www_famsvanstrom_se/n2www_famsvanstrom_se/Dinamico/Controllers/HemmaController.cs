using n2www_famsvanstrom.se.Dinamico.Models;
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
        public string Get()
        {
            return new DeviceStatusRepository().GetChangedStatus();
        }

        public string Post([FromBody]PostStatusRequestData indata)
        {
            Debug.WriteLine(indata.ToString());
            new TempratureDataService().SaveTemp(indata.IndoorTemprature, indata.OutdoorTemprature, indata.IndoorHumidity);
            List<Device> devs = new List<Device>();
            foreach (var dev in indata.DeviceArray)
            {
                devs.Add(dev.AsDevice());
            }
            new DeviceStatusRepository().UpdateStatus(devs);
            return "OK";
        }
    }
}