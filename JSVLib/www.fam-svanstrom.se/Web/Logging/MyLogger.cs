using System.Diagnostics;
using System.IO;
using MyLib.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace www.fam_svanstrom.se.Web.Logging
{
    public class FamSvanstromListener : TraceListener
    {
        private string logFile = string.Empty;

        public FamSvanstromListener()
        {
            var dataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            logFile = Path.Combine(dataPath, "www-famsvanstrom-se.log");
        }

        public FamSvanstromListener(string name) : base(name)
        {
            var dataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            logFile = Path.Combine(dataPath, "www-famsvanstrom-se.log");
        }

        public override void Write(string message)
        {
            var user = "anonymous";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
                user = HttpContext.Current.User.Identity.Name;
            var time = DateTime.Now.ToString("yyyyMMdd-HHmmdd");
            var log = string.Format("{0}|{1}|{2}", user, time, message);
            File.AppendAllText(logFile, log);
        }

        public override void WriteLine(string message)
        {
            message += Environment.NewLine;
            var user = "anonymous";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
                user = HttpContext.Current.User.Identity.Name;
            var time = DateTime.Now.ToString("yyyyMMdd-HHmmdd");
            var log = string.Format("{0}|{1}|{2}", user, time, message);
            File.AppendAllText(logFile, log);
        }
    }

    public class MyLogger : IMyLogger
    {
        private const int LevelInfo = 0;
        private const int LevelDebug = 1;
        int level = LevelDebug;
        TraceSwitch tw = new TraceSwitch("MyLevel", "Trace level for the web site", "Info");

        public void Info(string message, params object[] parmList)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Info<T>(T obj) where T : IJsvDebugSupport
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, params object[] parmList)
        {
            if (level < LevelDebug)
                return;
            Debug(string.Format(message, parmList));
        }

        public void Debug(string message)
        {
            Trace.WriteLineIf(tw.TraceVerbose, message);
        }

        public void Debug<T>(T obj) where T : IJsvDebugSupport
        {
            throw new NotImplementedException();
        }
    }
}