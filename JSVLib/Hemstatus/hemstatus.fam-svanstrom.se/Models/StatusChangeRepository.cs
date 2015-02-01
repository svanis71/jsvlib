using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace hemstatus.fam_svanstrom.se.Models
{
    public class StatusChangeRepository
    {
        public string GetChangedStatus()
        {
            var newStatus = new StringBuilder();

            try
            {
                var dataDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                var file = Path.Combine(dataDir, "newstatus.txt");
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
    }
}