using hemstatus.fam_svanstrom.se.Svanstrom;

namespace hemstatus.fam_svanstrom.se.Models
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