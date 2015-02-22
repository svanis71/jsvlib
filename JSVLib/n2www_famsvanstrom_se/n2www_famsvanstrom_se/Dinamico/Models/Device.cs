using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n2www_famsvanstrom.se.Dinamico.Models
{
    public enum DeviceStatus
    {
        On,
        Off
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