using System.Collections.Generic;
using hemstatus.fam_svanstrom.se.Services;

namespace hemstatus.fam_svanstrom.se.Models
{
    public class HomeViewModel
    {
        TempratureDataService _tempratureDataService;
        private DeviceStatusRepository _repo;

        public HomeViewModel()
        {
            _tempratureDataService = new TempratureDataService();
            _repo = new DeviceStatusRepository();
        }

        public TempratureDataService.CurrentWeather Weather
        {
            get
            {
                return _tempratureDataService.Weather;
            }
        }

        public IEnumerable<Device> Devices
        {
            get
            {
                var l = new List<Device>();
                foreach (var device in _repo.GetCurrentStatus())
                {
                    l.Add(device);
                }
                return l;
            }
        }
    }

    //[PageDefinition("DevicesController")]
    //[WithEditableTitle, WithEditableName]
    //public class DevicePageModel : PageModelBase
    //{
    //    DeviceStatusRepository _repo;
    //    TempratureDataService _tempratureDataService;

    //    public DevicePageModel()
    //    {
    //        _repo = new DeviceStatusRepository();
    //        _tempratureDataService = new TempratureDataService();
    //    }

    //    public TempratureDataService.CurrentWeather Weather
    //    {
    //        get
    //        {
    //            return _tempratureDataService.Weather;
    //        }
    //    }

    //    public IEnumerable<DeviceViewModel> Devices
    //    {
    //        get
    //        {
    //            var l = new List<DeviceViewModel>();
    //            foreach (var device in _repo.GetCurrentStatus())
    //            {
    //                l.Add(new DeviceViewModel(device));
    //            }
    //            return l;
    //        }
    //    }

    //    //public void Save(IEnumerable<Device> devices)
    //    //{
    //    //    _repo.Modify(devices);
    //    //}
    //}
}