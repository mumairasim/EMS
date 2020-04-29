using System.Web.Optimization;

namespace SMS.UI.HeadOffice
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/JsResources").Include(
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/modernizr-*",
                       //Angular Scripts
                       "~/Scripts/angular.min.js",
                       "~/Scripts/angular-route.min.js",
                       "~/Scripts/angular-cookies.min.js",
                       "~/Scripts/angular-resource.min.js",
                       "~/Scripts/angular-animate.min.js",
                       //BootStrap
                       "~/Scripts/bootstrap.min.js",
                       //App Scripts
                       "~/Scripts/App/checklist-model.js",
                       "~/Scripts/App/angular-growl-notifications.js",
                       "~/Scripts/App/angular-ui-router.min.js",
                       "~/Scripts/angular-local-storage.min.js",
                       //External Scripts
                       "~/Scripts/App/Login/jquery/jquery-3.2.1.min.js",
                       "~/Scripts/App/Login/animsition/js/animsition.min.js",
                       "~/Scripts/App/Login/bootstrap/js/popper.js",
                       "~/Scripts/App/Login/bootstrap/js/bootstrap.min.js",
                       "~/Scripts/App/Login/select2/select2.min.js",
                       "~/Scripts/App/Login/daterangepicker/moment.min.js",
                       "~/Scripts/App/Login/daterangepicker/daterangepicker.js",
                       "~/Scripts/App/Login/countdowntime/countdowntime.js",
                       "~/Scripts/App/Login/main.js",
                       //Angular App Scripts
                       "~/App/App.js",
                        "~/App/Services/*.js",
                        "~/App/Controllers/*.js",
                        "~/App/Controllers/Authentication/*.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      //External Contents
                      "~/Content/Login/bootstrap/css/bootstrap.min.css",
                      "~/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/fonts/Linearicons-Free-v1.0.0/icon-font.min.css",
                      "~/Content/Login/animate/animate.css",
                      "~/Content/Login/css-hamburgers/hamburgers.min.css",
                      "~/Content/Login/animsition/css/animsition.min.css",
                      "~/Content/Login/select2/select2.min.css",
                      "~/Content/Login/daterangepicker/daterangepicker.css",
                      "~/Content/Login/main.css",
                      "~/Content/Login/util.css"));
        }
    }
}
