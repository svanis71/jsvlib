// // famsvanstrom.se: HemmaStatusController.cs
// // Author: Johan Svanström
// // Created: 2015-05-23
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using famsvanstrom.se.Models;
using famsvanstrom.se.Services;

#endregion

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
