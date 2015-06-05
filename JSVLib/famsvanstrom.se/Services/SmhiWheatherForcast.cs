﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace famsvanstrom.se.Services
{
    public class SmhiWheatherForcast
    {
        public string Time { get; set; }
        public double Temprature { get; set; }
        public string WeatherCss { get; set; }
        public int WindDirection { get; set; }
        public int CloudLevel { get; set; }
        public int AverageWind { get; set; }
        public int GustWind { get; set; }
        public double Rain { get; set; }
        public double ThunderProbabilty { get; set; }
        public int AirPressure { get; set; }
    }

    public class SmhiRawData
    {
        /*lat: 56.241981, lon: 15.492028, referenceTime: "2015-06-01T13:00:00Z", timeseries: Array[72]*/
        /*gust: 9.4hcc: 6lcc: 2mcc: 0msl: 1013.9pcat: 0pis: 0pit: 0r: 49t: 15.8tcc: 6tstm: 0validTime: "2015-06-01T14:00:00Z"vis: 42wd: 246ws: 4.2*/
        public double lat { get; set; }
        public double lon { get; set; }
        public DateTime referenceTime { get; set; }
        public Timeserie[] timeseries { get; set; }
    }

    public class Timeserie
    {
        public double gust { get; set; } // Byvind
        public double hcc { get; set; } // Höga moln mängd
        public double lcc { get; set; } // Läga moln mängd
        public double mcc { get; set; } // Medelhöga moln mängd
        public double msl { get; set; } // Lufttryck reducerat till havsytans nivå.
        public double pcat { get; set; } // Nederbördsform
        public double pis { get; set; } // Nederbörd som snö
        public double pit { get; set; } // Nederbörd totalt
        public double r { get; set; } // Luftfuktighet
        public double t { get; set; } // Temp
        public double tcc { get; set; } // Total molnmängd
        public double tstm { get; set; } // Sannolikhet för åska
        public DateTime validTime { get; set; } // Prognostid   
        public double vis { get; set; } // Sikt
        public double wd { get; set; } // Vindriktning
        public double ws { get; set; } // Medelvind
    }

    public class SmhiForecastService
    {
        private string _longitude;
        private string _lattitude;

        public SmhiForecastService()
        {
            
        }

        public SmhiForecastService(string coordinate)
        {
            var coords = coordinate.Split(';');
            _lattitude = coords[0];
            _longitude = coords[1];
        }

        public IEnumerable<SmhiWheatherForcast> GetForecast(int hours = 4, int hourInterval = 3)
        {
            var forecastList = new List<SmhiWheatherForcast>();
            var url = new Uri(string.Format("http://opendata-download-metfcst.smhi.se/api/category/pmp1.5g" +
                "/version/1/geopoint/lat/{0}/lon/{1}/data.json",_lattitude, _longitude));
            using (var wc = new WebClient())
            {
                string data = wc.DownloadString(url);
                var fc = JsonConvert.DeserializeObject<SmhiRawData>(data);

                var now = DateTime.Now;
                var cnt = 0;
                var idx = 0;
                foreach (var itm in fc.timeseries)
                {
                    if (itm.validTime.CompareTo(now) >= 0)
                    {
                        if (cnt%hourInterval == 0)
                        {
                            var theForecast = new SmhiWheatherForcast()
                                {
                                    Time = itm.validTime.ToString("HH:mm"), Temprature = itm.t, AirPressure = (int) itm.msl, ThunderProbabilty = itm.tstm,
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