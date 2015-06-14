// // famsvanstrom.se: SmhiRawData.cs
// // Author: Johan Svanström
// // Created: 2015-06-09
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System;

#endregion

namespace famsvanstrom.se.Models.Smhi
{
    public class SmhiRawData
    {
        /*lat: 56.241981, lon: 15.492028, referenceTime: "2015-06-01T13:00:00Z", timeseries: Array[72]*/
        /*gust: 9.4hcc: 6lcc: 2mcc: 0msl: 1013.9pcat: 0pis: 0pit: 0r: 49t: 15.8tcc: 6tstm: 0validTime: "2015-06-01T14:00:00Z"vis: 42wd: 246ws: 4.2*/
        public double lat { get; set; }
        public double lon { get; set; }
        public DateTime referenceTime { get; set; }
        public Timeserie[] timeseries { get; set; }
    }
}