using System.Web.Optimization;

namespace n2www_famsvanstrom_se.App_Start
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
            bundles.Add(new StyleBundle("~/bundles/ssn/css").IncludeDirectory("~/Contents/ssbgen", "*.css"));
        }
    }
}