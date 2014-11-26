using System.Collections.Generic;

namespace MyLib.Logging
{
    public interface IJsvDebugSupport
    {
        Dictionary<string, object> Dump();
    }
}