using System;
using System.Collections.Generic;
using famsvanstrom.se.Svanstrom;

namespace famsvanstrom.se.Models
{
    public class DeviceModelRepo : List<DeviceModel>
    {
        
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