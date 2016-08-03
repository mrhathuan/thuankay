using System.Web;
using System.Web.Optimization;

namespace Shop_Nhi
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/Scripts/jquery.smartmenus.js",
                      "~/Scripts/jquery.smartmenus.bootstrap.js",
                      "~/Scripts/sequence.js",
                      "~/Scripts/sequence-theme.modern-slide-in.js",
                      "~/Scripts/nouislider.js",
                      "~/Scripts/slick.js",
                      "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery.smartmenus.bootstrap.css",
                      "~/Content/font-awesome.css",
                       "~/Content/slick.css",
                        "~/Content/nouislider.css",
                         "~/Content/sequence-theme.modern-slide-in.css",
                        "~/Content/eagle.gallery.css",
                        "~/Content/style.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/JsAdmin").Include(
                     "~/Scripts/Admin/bootstrap.min.js",
                     "~/Scripts/Admin/custom.js",
                     "~/Scripts/Admin/validator/validator.js",
                     "~/Scripts/Plugin/ckfinder/ckfinder.js",
                     "~/Scripts/Plugin/ckeditor/ckeditor.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/CssAdmin").Include(
                     "~/fonts/css/font-awesome.min.css",
                     "~/Content/Admin/css/animate.min.css",
                     "~/Content/Admin/css/custom.css",
                     "~/Content/Admin/css/datatables/css/jquery.dataTables.min.css",
                      "~/Content/Admin/css/datatables/css/scroller.bootstrap.min.css",
                      "~/Content/Admin/css/datatables/css/buttons.dataTables.min.css"
                      ));
        }
    }
}
