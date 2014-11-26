using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Logging
{
    public interface IMyLogger
    {
        void Info(string message, params object[] parmList);
        void Info(string message);
        void Info<T>(T obj) where T : IJsvDebugSupport;

        void Debug(string message, params object[] parmList);
        void Debug(string message);
        void Debug<T>(T obj) where T : IJsvDebugSupport;

    }
}
