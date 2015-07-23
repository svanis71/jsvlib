// // famsvanstrom.se: BundleConfig.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Web.Optimization;

#endregion

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
                "~/Scripts/jsvdate.js",
                "~/Scripts/site.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/breakout").IncludeDirectory("~/Scripts/games/breakout", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/game").IncludeDirectory("~/Scripts/gameengine", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/jsvlib").IncludeDirectory("~/Scripts/jsvlib.js", "*.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/less").Include("~/Content/less/site.less"));


        }
    }
}