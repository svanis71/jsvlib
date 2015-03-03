using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace www.fam_svanstrom.se.Services
{
    public class TempratureDataService
    {
        public void SaveTemp(float IndoorTemprature, float OutdoorTemprature, float indoorHumidity)
        {
            using(var conn = new SqlConnection("N2CMS"))
            using(var cmd = new SqlCommand("insert into TempratureStatistics (ObservationDate, IndoorTemprature, OutdoorTemprature, IndoorHumidity) values (@od, @it, @ot, @ih)"))
            {

            }
        }
    }
}