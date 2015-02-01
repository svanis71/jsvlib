using System;
using System.IO;

namespace hemstatus.fam_svanstrom.se.Services
{
    public interface ILogger
    {
        void Debug(string fmt, params object[] args);
        void Info(string fmt, params object[] args);
        void Error(string fmt, params object[] args);
    }

    [Serializable]
    public class Logger : ILogger
    {
        private bool _isDebug;
        private Type _sourceType;

        public Logger(Type sourceType)
            : this(sourceType, false)
        {
        }

        public Logger(Type sourceType, bool isDebug)
        {
            _isDebug = isDebug;
            _sourceType = sourceType;
        }

        public void Debug(string fmt, params object[] args)
        {
            if (!_isDebug)
                return;

            WriteToFile(LogMsg("D", fmt, args));
        }

        private string LogMsg(string logType, string fmt, object[] args)
        {
            string message = string.Format(fmt, args);
            var logMsg = string.Format("{0}:{1}\t{2}\t{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), logType, _sourceType.Name,
                                       message);
            return logMsg;
        }

        public void Info(string fmt, params object[] args)
        {
            WriteToFile(LogMsg("I", fmt, args));
        }

        public void Error(string fmt, params object[] args)
        {
            WriteToFile(LogMsg("I", fmt, args));
        }

        private void WriteToFile(string text)
        {

            string path = null;
            string fileName = null;
            string logPath = null;
            StreamWriter fs = null;

            try
            {
                path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); //HttpContext.Current.Server.MapPath("~/AppData");
                fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
                logPath = Path.Combine(path, fileName);

                using (fs = new StreamWriter(logPath, true))
                {
                    fs.WriteLine(text);
                }

            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }
}