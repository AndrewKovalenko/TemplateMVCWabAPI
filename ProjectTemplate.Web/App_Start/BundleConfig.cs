using System.Web.Optimization;

namespace ProjectTemplate.Web.App_Start
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/commonPlugins").Include(
                        "~/Scripts/jq-progressbar.js"));

            CoffeeBundles(bundles);

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            LessBundles(bundles);
        }

        private static void LessBundles(BundleCollection bundles)
        {
            bundles.Add(LessBundleFactory.CreateLessBundle("~/bundles/commonStyles", "~/Content/styles/common.less", 
                "~/Content/styles/jq-progress.less",
                "~/Content/styles/sign-in.less",
                "~/Content/styles/sign-up.less"));

            bundles.Add(LessBundleFactory.CreateLessBundle("~/bundles/logoCommonStyles", "~/Content/styles/logo-layout.less"));
            bundles.Add(LessBundleFactory.CreateLessBundle("~/bundles/homeStyles", "~/Content/styles/home.less",
                "~/Content/styles/reset-password.less"));

            bundles.Add(LessBundleFactory.CreateLessBundle("~/bundles/dashboardStyles", "~/Content/styles/dashboard.less"));


            bundles.Add(LessBundleFactory.CreateLessBundle("~/bundles/resetPassword", "~/Content/styles/reset-password.less"));
            bundles.Add(LessBundleFactory.CreateLessBundle("~/bundles/setNewPassword", "~/Content/styles/set-new-password.less"));
            
            bundles.Add(LessBundleFactory.CreateLessBundle("~/bundles/information", "~/Content/styles/information.less"));
        }

        private static void CoffeeBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/helpers").Include("~/Scripts/helpers.js"));
            bundles.Add(new ScriptBundle("~/bundles/common").IncludeDirectory("~/Scripts/coffee/", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/signin").IncludeDirectory("~/Scripts/coffee/sign-in", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/signout").IncludeDirectory("~/Scripts/coffee/sign-out", "*.js"));
        }
    }
}