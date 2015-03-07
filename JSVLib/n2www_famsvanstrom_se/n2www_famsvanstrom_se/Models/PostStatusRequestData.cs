using n2www_famsvanstrom.se.Dinamico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace www.fam_svanstrom.se.Models
{
    public class PostStatusRequestData
    {
        public DeviceViewModel[] DeviceArray { get; set; }
        public double OutdoorTemprature { get; set; }
        public double IndoorTemprature { get; set; }
        public double IndoorHumidity { get; set; }

        private string DumpDeviceArrayToString()
        {
            var ret = new StringBuilder();
            ret.Append("[");
            foreach(var dev in DeviceArray)
            {
                ret.AppendLine(dev.ToString());
            }
            ret.Append("]");
            return ret.ToString();
        }
        public override string ToString()
        {
            return string.Format("PostStatusRequestData: [OutdoorTemprature = {0}, IndoorTemprature = {1}, IndoorHumidity = {2}, Devices = {3}]",
                OutdoorTemprature, IndoorTemprature, IndoorHumidity, DumpDeviceArrayToString());
        }
    }
}