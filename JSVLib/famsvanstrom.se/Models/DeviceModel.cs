// // famsvanstrom.se: DeviceModel.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using famsvanstrom.se.Svanstrom;

#endregion

namespace famsvanstrom.se.Models
{
    public class DeviceModel 
    {
        public DeviceModel() {}
        public DeviceModel(Device device)
        {
            Device = new Device()
                {
                    Id = device.Id,
                    Name = device.Name,
                    Status = device.Status
                };
            Id = device.Id;
            Name = device.Name;
            Status = device.Status == DeviceStatus.On;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public Device Device { get; private set; }
        public Device AsDevice()
        {
            return new Device()
                {
                    Id = Id,
                    Name = Name,
                    Status = Status ? DeviceStatus.On : DeviceStatus.Off
                };
        }
        
    }
}