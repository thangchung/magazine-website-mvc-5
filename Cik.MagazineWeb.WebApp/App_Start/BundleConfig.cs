using System.Web.Optimization;

namespace Cik.MagazineWeb.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(
                 new ScriptBundle("~/andia-agency/scripts")
                     .Include("~/Scripts/jquery-1.10.2.min.js")
                     .Include("~/Content/bootstrap.min.js")
                     .Include("~/Content/andia-agency/assets/js/jquery.flexslider.js")
                     .Include("~/Content/andia-agency/assets/js/jquery.tweet.js")
                     .Include("~/Content/andia-agency/assets/js/jflickrfeed.js")
                     .Include("~/Content/andia-agency/assets/js/jquery.ui.map.min.js")
                     .Include("~/Content/andia-agency/assets/js/jquery.quicksand.js")
                     .Include("~/Content/andia-agency/assets/prettyPhoto/js/jquery.prettyPhoto.js")
                     .Include("~/Content/andia-agency/assets/js/scripts.js"));

            bundles.Add(
                new ScriptBundle("~/andia-agency/css")
                .Include("~/Content/andia-agency/assets/bootstrap/css/bootstrap.min.css")
                .Include("~/Content/andia-agency/assets/prettyPhoto/css/prettyPhoto.css")
                .Include("~/Content/andia-agency/assets/css/flexslider.css")
                .Include("~/Content/andia-agency/assets/css/font-awesome.css")
                .Include("~/Content/andia-agency/assets/css/style.css"));

            //bundles.Add(
            //  new StyleBundle("~/Content/css")
            //    .Include("~/Content/bootstrap.css")
            //    .Include("~/Content/app.css")
            //    .Include("~/Content/style.css")
            //  );

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/docs.css",
                      "~/Content/pygments-manni.css"));
        }
    }
}
