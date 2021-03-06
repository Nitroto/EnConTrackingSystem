﻿using System.Web.Optimization;

namespace EnConTrackingSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/datatables/jquery.datatables.js",
                "~/Scripts/datatables/datatables.bootstrap.js",
                "~/Scripts/jquery-ui-1.12.1.js",
                "~/Scripts/typeahead.bundle.js",
                "~/Scripts/typeahead.mvc.model.js",
                "~/Scripts/moment-with-locales.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootbox.js",
                "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js").Include(
                "~/Scripts/toastr.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Stylesheets/bootstrap.css",
                "~/Content/DataTables/css/dataTables.bootstrap.css",
                "~/Content/DataTables/css/dataTables.jqueryui.css",
                "~/Content/Stylesheets/jquery-ui/jquery-ui.css",
                "~/Content/Stylesheets/typeahead.css",
                "~/Content/Stylesheets/Site.css"));

            bundles.Add(new StyleBundle("~/content/toastr", "http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css")
                .Include("~/Content/Stylesheets/toastr.css"));
        }
    }
}