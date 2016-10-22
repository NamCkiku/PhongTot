using System.Web;
using System.Web.Optimization;

namespace PhongTot.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                       "~/Content/Client/js/jquery-1.10.2.min.js",
                       "~/Content/Client/Plugins/bootstrap/js/bootstrap.js",
                       "~/Content/Client/Plugins/owl-carousel/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/Content/angular").Include(
                       "~/bower_components/angular/angular.js",
                       "~/app/app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Client/Plugins/bootstrap/css/bootstrap.css",
                      "~/Content/Client/Plugins/font-awesome-4.5.0/css/font-awesome.css",
                      "~/Content/Client/css/Style.css",
                      "~/Content/Client/Plugins/owl-carousel/owl.carousel.css,",
                      "~/bower_components/toastr/toastr.css"));
        }
    }
}
