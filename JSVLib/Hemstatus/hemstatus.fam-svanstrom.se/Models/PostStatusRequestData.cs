using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hemstatus.fam_svanstrom.se.Models
{
    public class PostStatusRequestData
    {
        public Device[] DeviceArray { get; set; }
        public float OutdoorTemprature { get; set; }
        public float IndoorTemprature { get; set; }
        public float IndoorTemprature { get; set; }
    }
}