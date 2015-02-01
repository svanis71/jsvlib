using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hemstatus.fam_svanstrom.se.Models
{
    public enum DeviceStatus
    {
        On,
        Off
    }

    public class DeviceModelRepo : List<DeviceModel>
    {
        
    }

    public class DeviceModel 
    {
        private Device device;

        public DeviceModel(Device device)
        {
            Id = device.Id;
            Name = device.Name;
            Status = device.Status == DeviceStatus.On;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

    }

    [Serializable]
    public class Device 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceStatus Status { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: [Id = {1}, Name = {2}, Status = {3}]",
                                 this.GetType().Name, Id, Name, Status);
        }
    }
}