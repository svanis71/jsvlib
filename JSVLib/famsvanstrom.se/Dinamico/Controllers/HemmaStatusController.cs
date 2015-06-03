using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using famsvanstrom.se.Models;
using famsvanstrom.se.Services;

namespace famsvanstrom.se.Dinamico.Controllers
{
    public class HemmaStatusController : ApiController
    {
        public string Get()
        {
            return new DeviceStatusRepository().GetChangedStatus();
        }

        public string Post([FromBody]PostStatusRequestData indata)
        {
            //log.DebugFormat("Incoming POST: {0}", indata.ToString());
            Debug.WriteLine(indata.ToString());
            new TempratureDataService().SaveTemp(indata.IndoorTemprature, indata.OutdoorTemprature, indata.IndoorHumidity);
            var devs = indata.DeviceArray.Select(dev => dev.AsDevice()).ToList();
            new DeviceStatusRepository().UpdateStatus(devs);
            return new DeviceStatusRepository().GetChangedStatus();
        }

    }
}
