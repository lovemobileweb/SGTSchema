<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/bundles/bootstrap")
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/AdminLTE.css")
    @Styles.Render("~/Content/skins/_all-skins.min.css")
    @Styles.Render("~/Content/bootstrap3-wysihtml5.css")
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
</head>
<body class="sidebar-mini wysihtml5-supported">
    <div class="wrapper">

        <header class="main-header">
            <a href="@Url.Action("Index", "SGTSchema")" class="logo">
                <!-- mini logo for sidebar mini 50x50 pixels -->
                <span class="logo-mini"><b>SGT</b></span>
                <!-- logo for regular state and mobile devices -->
                <span class="logo-lg"><b>SGTSchema</b></span>
            </a>
            <!-- Header Navbar: style can be found in header.less -->
            <nav class="navbar navbar-static-top" role="navigation">
                @Html.Partial("_LoginPartial")
            </nav>
        </header>

        <!-- Add the sidebar's background. This div must be placed
             immediately after the control sidebar -->
        <div class="control-sidebar-bg" style="position: fixed; height: auto;"></div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/Scripts/jquery-ui-1.11.4.js")
    @Scripts.Render("~/Scripts/bootstrap3-wysihtml5.all.js")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/Scripts/pages/dashboard.js")
    @Scripts.Render("~/Scripts/app.js")
    @Scripts.Render("~/Scripts/demo.js")
    @RenderSection("scripts", required:=False)
</body>
</html>
