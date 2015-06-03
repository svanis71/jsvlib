using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dinamico;
using Dinamico.Models;
using N2;
using N2.Details;
using famsvanstrom.se.Services;

namespace famsvanstrom.se.Models.Pages
{
    [PageDefinition(Name = "Mina grejer", Title = "Mina grejer", Description = "Visar status på mina grejer som kopplats till tellsticken.")]
    [WithEditableTemplateSelection(ContainerName = Defaults.Containers.Metadata)]
    public class DevicesPageModel : ContentPage
    {
        private DeviceStatusRepository _repo;

        public DevicesPageModel()
        {
            _repo = new DeviceStatusRepository();
        }

        public DevicesPageModel(DeviceStatusRepository repo)
        {
            _repo = repo;
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
}