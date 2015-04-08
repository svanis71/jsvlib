using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace hemstatus.fam_svanstrom.se.Models
{
    public class PostStatusRequestData
    {
        public double OutdoorTemprature { get; set; }
        public double IndoorTemprature { get; set; }
        public double IndoorHumidity { get; set; }
        public DeviceModel[] DeviceArray { get; set; }

        private string DumpDeviceArrayToString()
        {
            var ret = new StringBuilder();
            ret.Append("[");
            foreach (var dev in DeviceArray)
            {
                ret.AppendLine(dev.AsDevice().ToString());
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