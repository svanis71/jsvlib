using System.Web;
using System.Web.Mvc;

namespace hemstatus.fam_svanstrom.se
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}