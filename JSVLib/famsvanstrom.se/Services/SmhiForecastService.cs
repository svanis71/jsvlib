// // famsvanstrom.se: SmhiForecastService.cs
// // Author: Johan Svanström
// // Created: 2015-06-09
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using famsvanstrom.se.Models.Smhi;

#endregion

namespace famsvanstrom.se.Services
{
    public class SmhiForecastService
    {
        private readonly string _longitude;
        private readonly string _lattitude;

        public SmhiForecastService()
        {
            
        }

        public SmhiForecastService(string coordinate)
        {
            var coords = coordinate.Split(';');
            _lattitude = coords[0];
            _longitude = coords[1];
        }

        public IEnumerable<SmhiWeatherForecast> GetForecast(int hours = 4, int hourInterval = 3)
        {
            var forecastList = new List<SmhiWeatherForecast>();
            var url = new Uri(string.Format("http://opendata-download-metfcst.smhi.se/api/category/pmp1.5g" +
                                            "/version/1/geopoint/lat/{0}/lon/{1}/data.json",_lattitude, _longitude));
            using (var wc = new WebClient())
            {
                string data = wc.DownloadString(url);
                var fc = JsonConvert.DeserializeObject<SmhiRawData>(data);

                var now = DateTime.Now;
                var cnt = 0;
                var idx = 0;
                var itms = from itm in fc.timeseries let validTimeAsLocal = itm.validTime.ToLocalTime() where validTimeAsLocal.CompareTo(now) >= 0 select itm;
                foreach (var itm in itms)
                {
                    if (cnt%hourInterval == 0)
                    {
                        var theForecast = new SmhiWeatherForecast()
                            {
                                Time = itm.validTime.ToLocalTime().ToString("HH:mm"), Temprature = itm.t, AirPressure = (int) itm.msl, ThunderProbabilty = itm.tstm,
                                AverageWind = (int)itm.ws, GustWind = (int)itm.gust, Rain = itm.pit
                            };
                        theForecast.CloudLevel = CloudLevel((int)itm.tcc);
                        theForecast.WindDirection = WindDir((int)itm.wd);
                        theForecast.WeatherCss = FindOutWeatherCss(theForecast.CloudLevel, theForecast.Rain);
                        forecastList.Add(theForecast);
                        idx++;
                    }
                    cnt++;
                }
            }
            return forecastList.Take(hours);
        }

        private static string FindOutWeatherCss(int cloudLevel, double rain)
        {
            var css = string.Empty;
            if (cloudLevel == 0)
                css = "wi-day-sunny";
            if (cloudLevel == 1 && rain < 0.07)
                css = "wi-day-sunny-overcast";
            if (cloudLevel == 1 && rain > 0.07)
                css = "wi-day-showers";
            return css;
        }

        private static int WindDir(int windDir)
        {
            windDir -= windDir%15;
            return windDir;
        }

        private int CloudLevel(int totalClouds)
        {
            var clouds = totalClouds;
            int cloudLevel = 0;
            if (clouds > 0) cloudLevel = 1;
            if (clouds > 3) cloudLevel = 2;
            if (clouds > 7) cloudLevel = 3;
            return cloudLevel;
        }
    }
}