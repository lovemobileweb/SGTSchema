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
<body class="sidebar-mini wysihtml5-supported skin-blue">
@If Request.IsAuthenticated Then
    @<div Class="wrapper">
        @Html.Partial("_Header")
        @Html.Partial("_DashboardMenu")
        <div Class="content-wrapper">
            @RenderBody()
        </div>
        @Html.Partial("_Footer")
    </div>
Else
    @RenderBody()
End If
    
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
