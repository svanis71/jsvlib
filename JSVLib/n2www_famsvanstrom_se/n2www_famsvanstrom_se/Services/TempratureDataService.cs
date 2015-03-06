using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace www.fam_svanstrom.se.Services
{
    public class TempratureDataService
    {
        public void SaveTemp(float indoorTemprature, float outdoorTemprature, float indoorHumidity)
        {
            var connString = ConfigurationManager.ConnectionStrings["N2CMS"].ConnectionString;         
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
        }
    }
}