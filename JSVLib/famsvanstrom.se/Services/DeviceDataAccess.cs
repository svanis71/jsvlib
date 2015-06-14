// // famsvanstrom.se: DeviceDataAccess.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Data.SqlClient;
using famsvanstrom.se.Models;

#endregion

namespace hemstatus.fam_svanstrom.se.Services
{
    public class DeviceDataAccess
    {
        public void SaveAllDevices(Device[] devices)
        {
            using (var conn = new SqlConnection("DB"))
            using(var cmd = new SqlCommand("INSERT INTO DeviceStatus (Id, Name, Status) VALUES (:id, :name, :status)", conn))
            {
                foreach(var device in devices)
                {
                    cmd.Parameters.AddWithValue(":id", device.Id);
                    cmd.Parameters.AddWithValue(":name", device.Name);
                    cmd.Parameters.AddWithValue(":status", device.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}