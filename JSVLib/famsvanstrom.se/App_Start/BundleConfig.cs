using System.Web.Optimization;

namespace famsvanstrom.se.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ssn").Include("~/Scripts/ssn/ssntest.js"));
            bundles.Add(new ScriptBundle("~/bundles/mobile").Include("~/Scripts/detectmobile.js"));
            bundles.Add(new ScriptBundle("~/bundles/site").Include("~/Scripts/weather.js", 
                "~/Scripts/utils.js", 
                "~/Scripts/jsvdate.js", 
                "~/Scripts/load.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/less").Include("~/Content/less/site.less"));


        }
    }
}