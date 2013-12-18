using System.Web;
using System.Web.Optimization;

namespace SimpleBlog.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery.unobtrusive*","~/Scripts/jquery.validate*")
            );
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //"~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            //bundles.Add(new StyleBundle("~/Content/Themes/base/css").Include(
            //"~/Content/Themes/base/jquery.ui.core.css",
            //"~/Content/Themes/base/jquery.ui.resizable.css",
            //"~/Content/Themes/base/jquery.ui.selectable.css",
            //"~/Content/Themes/base/jquery.ui.accordion.css",
            //"~/Content/Themes/base/jquery.ui.autocomplete.css",
            //"~/Content/Themes/base/jquery.ui.button.css",
            //"~/Content/Themes/base/jquery.ui.dialog.css",
            //"~/Content/Themes/base/jquery.ui.slider.css",
            //"~/Content/Themes/base/jquery.ui.tabs.css",
            //"~/Content/Themes/base/jquery.ui.datepicker.css",
            //"~/Content/Themes/base/jquery.ui.progressbar.css",
            //"~/Content/Themes/base/jquery.ui.theme.css"));
        }

    }
}
