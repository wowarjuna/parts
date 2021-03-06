﻿using System.Web;
using System.Web.Optimization;

namespace CP
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

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     "~/Scripts/bootstrap.min.js",
                     "~/Scripts/respond.min.js"));



            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                     "~/Scripts/plugins/metisMenu.min.js",
                     "~/Scripts/plugins/bootstrap-table.min.js",
                     "~/Scripts/plugins/iCheck/icheck.min.js",
                     "~/Scripts/plugins/maskMoney/jquery.maskMoney.min.js",
                     "~/Scripts/plugins/numeral/numeral.min.js",
                     "~/Scripts/plugins/daterangepicker/daterangepicker.js",
                     "~/Scripts/plugins/jquery.formatDateTime.min.js",
                     "~/Scripts/plugins/datepicker/bootstrap-datepicker.js",
                     "~/Scripts/plugins/morris/morris.min.js",
                     "~/Scripts/plugins/fileinput.min.js",
                     "~/Scripts/plugins/jquery.magnific-popup.min.js"));

           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/plugins").Include(
                 "~/Content/bootstrap-table.min.css",
                 "~/Content/daterangepicker/daterangepicker-bs3.css",
                 "~/Content/datepicker/datepicker3.css",
                 "~/Content/morris/morris.css",
                 "~/Content/fileinput.min.css",
                 "~/Content/magnific-popup.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
