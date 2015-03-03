using hemstatus.fam_svanstrom.se.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace hemstatus.fam_svanstrom.se.Services
{
    public class DeviceDataAccess
    {
        public void SaveAllDevices(Device[] devices)
        {
            using (SqlConnection conn = new SqlConnection("DB"))
            using(SqlCommand cmd = new SqlCommand("INSERT INTO DeviceStatus (Id, Name, Status) VALUES (:id, :name, :status)", conn))
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