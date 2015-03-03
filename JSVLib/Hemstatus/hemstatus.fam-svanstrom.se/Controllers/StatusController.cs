using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            
        }

        public StatusController(DeviceRepository repository)
        {
            _repository = repository;
            _logger = new Logger(GetType(), true);
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
        public void Post([FromBody]PostStatusRequestData indata)
        {
            try
            {
                _logger.Debug("Enter Post");

                if (indata != null)
                {

                    //foreach (var device in indata)
                    //{
                    //    if(device.Id <= 0) // Something was very wrong
                    //        continue;
                        //_repository.Modify(devArray);
                    //}
                    
                }
                else
                {
                    _logger.Error("Input to post was null :-(");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("FATAL ERROR: {0}", ex.ToString());
            }
        }

        // DELETE api/status/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
