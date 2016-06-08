Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css",
                  "~/Content/ladda-bootstrap-master/dist/ladda-themeless.css",
                  "~/Content/font-awesome.min.css",
                  "~/Content/ionicons.min.css",
                  "~/Content/plugins/datatables/dataTables.bootstrap.css",
                  "~/Content/AdminLTE.css",
                  "~/Content/skins/skin-blue.css"))

        bundles.Add(New ScriptBundle("~/bundles/scripts").Include(
                  "~/Scripts/ims.js",
                  "~/Scripts/app.js",
                  "~/Scripts/jquery.validate*",
                  "~/Scripts/jquery.unobtrusive*",
                  "~/Content/datatables/jquery.dataTables.js",
                  "~/Content/datatables/dataTables.bootstrap.js",
                  "~/Content/ladda-bootstrap-master/dist/spin.js",
                  "~/Content/ladda-bootstrap-master/dist/ladda.js"))

    End Sub
End Module

