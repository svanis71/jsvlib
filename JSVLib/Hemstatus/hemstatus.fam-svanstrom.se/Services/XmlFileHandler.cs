using System;
using System.IO;
using System.Web;
using System.Xml.Serialization;
using hemstatus.fam_svanstrom.se.Extensions;

namespace hemstatus.fam_svanstrom.se.Services
{
    public interface IXmlFileHandler<T>
    {
        T ReadFile();
        void Save(T repo);
    }

    [Serializable]
    public class XmlFileHandler<T> : IXmlFileHandler<T> where T : class
    {
        public const string FileName = "DeviceStatus";
        private readonly string _fileName;
        private readonly string _dataPath;

        public XmlFileHandler()
            : this(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), FileName)
        {
        }

        public XmlFileHandler(string path, string fileName)
        {
            _dataPath = path;
            _fileName = fileName;
        }

        public void Save(T repo)
        {
            var xml = Path.Combine(_dataPath, _fileName + ".xml");
            var serializer = new XmlSerializer(typeof(T));
            var lockObj = new object();

            lock (lockObj)
            {
                // Delete file before saving to prevent the file of being corrupted
                if (File.Exists(xml))
                    File.Delete(xml);

                using (var sw = File.OpenWrite(xml))
                {
                    serializer.Serialize(sw, repo);
                    sw.Close();
                }
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                    HttpContext.Current.Session["itemlist"] = repo.ToByteArray();

            }
        }

        public T ReadFile()
        {
            var xmlFile = Path.Combine(_dataPath, _fileName + ".xml");
            byte[] list = null;

            if (HttpContext.Current != null && HttpContext.Current.Session != null)
                list = HttpContext.Current.Session["itemlist"] as byte[];

            T repo = default(T);

            if (list == null && File.Exists(xmlFile))
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var sw = File.OpenRead(xmlFile))
                {
                    repo = serializer.Deserialize(sw) as T;
                    sw.Close();
                }
            }
            else if (list != null)
                repo = list.GetSerializedForm<T>();

            return repo;
        }
    }
}