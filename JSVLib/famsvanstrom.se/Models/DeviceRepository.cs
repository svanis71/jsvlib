// // famsvanstrom.se: DeviceRepository.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using famsvanstrom.se.Extensions;
using famsvanstrom.se.Services;
using famsvanstrom.se.Svanstrom;

#endregion

namespace famsvanstrom.se.Models
{
    [Serializable]
    public class DeviceRepository : List<Device>
    {
        private readonly IXmlFileHandler<DeviceRepository> _fileHandler;
        private readonly ILogger _logger;

        public DeviceRepository()
        {
            _fileHandler = new XmlFileHandler<DeviceRepository>();
            _logger = new Logger(GetType(), true);
        }

        public static Device New(int id, string name, DeviceStatus status)
        {
            return new Device() {Id = id, Name = name, Status = status};
        }

        public void Modify(IEnumerable<Device> deviceList)
        {
            var all = GetAll();
            if (all != null)
            {
                var devices = deviceList as Device[] ?? deviceList.ToArray();
                foreach (var device in devices)
                {
                    try 
                    {
                        var dev = devices.SingleOrDefault(p => p.Id == device.Id);
                        if (dev != null)
                        {
                            _logger.Debug("Change device #{0} to {1}", dev.Id, dev.Status);
                            device.Status = dev.Status;
                            device.Name = device.Name;
                        }
                    }
                    catch(InvalidOperationException ioex)
                    {
                        _logger.Error("Indata has a duplicate key {0}", device.ToString());
                    }
                }
            }
            else
            {
                foreach (var device in deviceList)
                {
                    Add(device);
                }
            }
            Save();
        }

        public void Modify(Device device)
        {
            var all = GetAll();
            Device deviceToSave = null;
            if (all != null)
                deviceToSave = all.SingleOrDefault(d => d.Id == device.Id);
            if (deviceToSave != null)
            {
                deviceToSave.Id = device.Id;
                deviceToSave.Name = device.Name;
                deviceToSave.Status = device.Status;
            }
            else
                Add(device);
            Save();
        }

        public DeviceRepository(IXmlFileHandler<DeviceRepository> fileHandlerMock)
        {
            _fileHandler = fileHandlerMock;
        }

        public IEnumerable<Device> GetAll()
        {
            var repo = _fileHandler.ReadFile();
            if (repo != null)
            {
                foreach (var device in repo.Where(device => !this.Any(p => p.Id == device.Id)))
                {
                    Add(device);
                }

                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                    HttpContext.Current.Session["devices"] = this.ToByteArray();
            }

            return this;
        }

        public void Save()
        {
            _fileHandler.Save(this);
        }

    }
}