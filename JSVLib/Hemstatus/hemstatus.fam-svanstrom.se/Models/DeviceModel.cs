using hemstatus.fam_svanstrom.se.Svanstrom;

namespace hemstatus.fam_svanstrom.se.Models
{
    public class DeviceModel 
    {
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

        public Device Device { get; private set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

    }
}