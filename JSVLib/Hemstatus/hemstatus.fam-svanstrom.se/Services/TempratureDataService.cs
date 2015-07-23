using System;
using System.Data.SqlClient;
using System.Configuration;

namespace hemstatus.fam_svanstrom.se.Services
{
    public class TempratureDataService
    {
        readonly ILogger _logger;
 
        public TempratureDataService()
        {
            _logger = new Logger(this.GetType());
        }

        public class CurrentWeather
        {
            public DateTime LatestObservationDate { get; set; }
            public double IndoorTemprature { get; set; }
            public double IndoorHumidity { get; set; }
            public double OutdoorTemprature { get; set; }
        }

        public CurrentWeather Weather
        {
            get
            {
                return FetchWeatherInfo();
            }
        }

        private static TempratureDataService.CurrentWeather FetchWeatherInfo()
        {
            var cw = new CurrentWeather();
            var connString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("select top 1 observationdate, indoortemprature, outdoortemprature, indoorhumidity from TempratureStatistics order by observationdate desc", conn))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        
                        if(rdr.Read())
                        {
                            cw.LatestObservationDate = rdr.GetDateTime(0);
                            cw.IndoorTemprature = rdr.GetInt32(1) / 100.0;
                            cw.OutdoorTemprature = rdr.GetInt32(2) / 100.0;
                            cw.IndoorHumidity = rdr.GetInt32(3) / 100.0;
                        }
                    }
                }
            }
            return cw;
        }

        public void SaveTemp(double indoorTemprature, double outdoorTemprature, double indoorHumidity)
        {
            _logger.Debug("SaveTemp in");
            var latestSaved = FetchWeatherInfo();

            var diffIt = Math.Abs(indoorTemprature - latestSaved.IndoorTemprature);
            var diffOt = Math.Abs(outdoorTemprature - latestSaved.OutdoorTemprature);
            var diffIh = Math.Abs(indoorHumidity - latestSaved.IndoorHumidity);

            _logger.Debug("diffIt = {0}, diffOt = {1}, diffIh = {2}", diffIt, diffOt, diffIh);

            // Only save if something has changed
            if( diffIt < 0.01 && diffOt < 0.01 && diffIh < 0.01)
                return;

            _logger.Debug("Write to database");

            var connString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;         
            using(var conn = new SqlConnection(connString))
            {
                conn.Open();
                using(var cmd = new SqlCommand("insert into TempratureStatistics (ObservationDate, IndoorTemprature, OutdoorTemprature, IndoorHumidity) values (@od, @it, @ot, @ih)", conn))
                {
                    cmd.Parameters.Add("@od", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@it", System.Data.SqlDbType.Int).Value = Math.Floor(indoorTemprature * 100);
                    cmd.Parameters.Add("@ot", System.Data.SqlDbType.Int).Value = Math.Floor(outdoorTemprature * 100);
                    cmd.Parameters.Add("@ih", System.Data.SqlDbType.Int).Value = Math.Floor(indoorHumidity * 100);
                    cmd.ExecuteNonQuery();
                }
            }
            _logger.Info("Temprature changed: {0}", outdoorTemprature);
        }
    }
}