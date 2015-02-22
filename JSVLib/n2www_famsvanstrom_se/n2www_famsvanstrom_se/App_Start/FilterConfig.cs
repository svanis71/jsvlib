using System.Web;
using System.Web.Mvc;

namespace n2www_famsvanstrom.se
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}