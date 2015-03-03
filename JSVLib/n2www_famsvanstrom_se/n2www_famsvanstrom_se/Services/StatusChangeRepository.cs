using n2www_famsvanstrom.se.Dinamico.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace www.fam_svanstrom.se.Services
{
    public class StatusChangeRepository
    {
        public void ChangeStatus(IEnumerable<Device> devices)
        {
            var file = GetFileName();
            lock (this)
            {
                if(File.Exists(file))
                {
                    File.Delete(file);
                }
                using(var sw = new StreamWriter(file))
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
    }
}