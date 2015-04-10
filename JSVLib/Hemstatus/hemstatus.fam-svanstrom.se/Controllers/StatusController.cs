using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using hemstatus.fam_svanstrom.se.Models;
using hemstatus.fam_svanstrom.se.Services;

namespace hemstatus.fam_svanstrom.se.Controllers
{
    public class StatusController : ApiController
    {
        private readonly DeviceRepository _repository;
        private readonly ILogger _logger;

        public StatusController()
            : this(new DeviceRepository())
        {
            _logger = new Logger(GetType(), true);
        }

        public StatusController(DeviceRepository repository)
        {
            _repository = repository;
        }

        internal ILogger Logger
        {
            get { return _logger; }
        }

        // GET api/status
        // Returns a new status string if there is any.
        // Format is "1101" or empty
        public string Get()
        {
            //var devices = _repository.GetAll();
            //var statusString = new StringBuilder();
            //foreach (var device in devices)
            //{
            //    statusString.Append(device.Status);
            //}
            var statusChangeRepo = new StatusChangeRepository();
            return statusChangeRepo.GetChangedStatus();
        }

        // GET api/status/5
        public Device Get(int id)
        {
            Debug.WriteLine(string.Format("Inparam was [{0}]", id));
            return _repository.SingleOrDefault(p => p.Id == id);
        }

        // POST api/status
        public string Post([FromBody]PostStatusRequestData indata)
        {
            string ret;
            try
            {
                if (indata == null)
                {
                    Logger.Error("indata was null!");
                    throw new ArgumentNullException("indata", "Indata to post was null");
                }
                var deviceStatusRepository = new DeviceStatusRepository();
                Logger.Debug("Incoming POST: {0}", indata.ToString());
                Debug.WriteLine(indata.ToString());
                new TempratureDataService().SaveTemp(indata.IndoorTemprature, indata.OutdoorTemprature,
                                                     indata.IndoorHumidity);
                var devs = indata.DeviceArray.Select(dev => dev.AsDevice()).ToList();
                deviceStatusRepository.UpdateStatus(devs);
                ret = deviceStatusRepository.GetChangedStatus();
            }
            catch (Exception ex)
            {
                Logger.Error("FATAL ERROR: {0}", ex.ToString());
                ret = ex.Message;
            }
            return ret;
        }

        // DELETE api/status/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
