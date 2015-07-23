using hemstatus.fam_svanstrom.se.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using hemstatus.fam_svanstrom.se.Svanstrom;

namespace hemstatus.fam_svanstrom.se.Services
{
    public class DeviceStatusRepository
    {
        private readonly string _connectionString;
        readonly ILogger _logger;

        public DeviceStatusRepository()
            : this(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString)
        {
        }

        public DeviceStatusRepository(string connectionString)
        {
            _connectionString = connectionString;
            _logger = new Logger(this.GetType());
        }

        public IEnumerable<Device> GetCurrentStatus()
        {
            var list = new List<Device>();
            var connString = ConnectionString;
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("select id, name, status from DeviceStatus order by id", conn))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            var dev = new Device();
                            dev.Id = rdr.GetInt32(0);
                            dev.Name = rdr.GetString(1);
                            dev.Status = rdr.GetInt32(2) == 1 ? DeviceStatus.On : DeviceStatus.Off;
                            list.Add(dev);
                        }
                    }
                }
            }
            return list;

        }

        public void UpdateStatus(Device device)
        {
            var connString = ConnectionString;
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using(var cmd = new SqlCommand("UpdateDevice", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = device.Id;
                    cmd.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 30).Value = device.Name;
                    cmd.Parameters.Add("@Status", System.Data.SqlDbType.Int).Value = device.Status == DeviceStatus.On ? 1 : 0;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStatus(IEnumerable<Device> devices)
        {
            foreach (var device in devices)
            {
                UpdateStatus(device);
            }
        }

        public void ChangeStatus(IEnumerable<Device> devices)
        {
            var file = GetFileName();
            lock (this)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                using (var sw = new StreamWriter(file))
                {
                    var sb = new StringBuilder();
                    foreach (var dev in devices)
                    {
                        sb.Append(dev.Status == DeviceStatus.On ? "1" : "0");
                    }
                    sw.WriteLine(sb.ToString());
                    sw.Close();
                }
            }
        }

        public string GetChangedStatus()
        {
            var newStatus = new StringBuilder();

            try
            {
                var file = GetFileName();
                lock (this)
                {
                    if (File.Exists(file))
                    {
                        using (var sr = new StreamReader(file))
                        {
                            var line = sr.ReadLine();
                            if (line != null && line.EndsWith(Environment.NewLine))
                                line.Remove(line.Length - Environment.NewLine.Length);
                            newStatus.Append(line);
                            sr.Close();
                        }
                        File.Delete(file);
                    }
                }

            }
            catch (Exception e)
            {
                newStatus.Append("ERR 0x4711: ");
                newStatus.Append(e.Message);
            }
            return newStatus.ToString();
        }

        private static string GetFileName()
        {
            var dataDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            var file = Path.Combine(dataDir, "newstatus.txt");
            return file;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

    }
}