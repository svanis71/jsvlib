// // famsvanstrom.se: SmhiWeatherForecast.cs
// // Author: Johan Svanström
// // Created: 2015-06-09
// //
// // Last changed: 2015-06-09
// //
// // Description:
namespace famsvanstrom.se.Models.Smhi
{
    public class SmhiWeatherForecast
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
}