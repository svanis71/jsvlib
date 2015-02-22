using System.Web.Optimization;

namespace n2www_famsvanstrom.se.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ssn/js").IncludeDirectory("~/Scripts/ssn", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/mobile").Include("~/Scripts/detectmobile.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/knockoutjs").Include(
                "~/Scripts/knockout-2.1.0.js"));
            bundles.Add(new ScriptBundle("~/bundles/knockoutjsdebug").Include(
                "~/Scripts/knockout-2.1.0.debug.js"));
            bundles.Add(new ScriptBundle("~/bundles/load").Include("~/Scripts/jsvmenu-plugin.js", "~/Scripts/load.js"));
            bundles.Add(new ScriptBundle("~/bundles/openid").Include("~/Scripts/openid-jquery.js", "~/Scripts/openid-sv.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css", "~/Content/slider-base.css"));

            bundles.Add(new StyleBundle("~/Content/themes/svanstrom/css").Include(
                "~/Content/themes/svanstrom/jquery-ui.all.css"));

            bundles.Add(new StyleBundle("~/bundles/ssn/css").IncludeDirectory("~/Contents/ssbgen", "*.css"));
        }
    }
}