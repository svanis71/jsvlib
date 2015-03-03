using Dinamico.Models;
using N2;
using N2.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n2www_famsvanstrom.se.Dinamico.Models
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public DeviceViewModel() { }

        public DeviceViewModel(Device device)
        {
            Id = device.Id;
            Name = device.Name;
            Status = (device.Status == DeviceStatus.On);
        }

        public Device AsDevice()
        {
            return new Device() { Id = Id, Name = Name, Status = Status ? DeviceStatus.On : DeviceStatus.Off };
        }

        public override string ToString()
        {
            return string.Format("{0}: [Id = {1}, Name = {2}, Status = {3}]",
                                 this.GetType().Name, Id, Name, Status);
        }

    }

    [PageDefinition("DevicesController")]
    [WithEditableTitle, WithEditableName]
    public class DevicePageModel : PageModelBase
    {
        DeviceRepository _repo;

        public DevicePageModel()
        {
            _repo = new DeviceRepository();
        }

        public IEnumerable<DeviceViewModel> Devices
        {
            get
            {
                var l = new List<DeviceViewModel>();
                foreach (var device in _repo.GetAll())
                {
                    l.Add(new DeviceViewModel(device));
                }
                return l;
            }
        }

        public void Save(IEnumerable<Device> devices)
        {
            _repo.Modify(devices);
        }
    }
}