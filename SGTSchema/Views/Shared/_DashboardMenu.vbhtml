
@Scripts.Render("~/bundles/jquery")
@Scripts.Render("~/Scripts/pages/dashboard.js")
@Scripts.Render("~/Scripts/demo.js")

@Code
    Dim admin = False
    If User.Identity.Name = "admin@sgtschema.com" Then
        admin = True
    End If
End Code

<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar" style="height: auto;">
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <ul class="sidebar-menu">
            <li class="header">Dashboard</li>
            @Code
                If admin = True Then
                    @Html.Raw("<li><a href = '/Admin/Index'><i class='fa fa-users'></i><span>Admin registeration</span></a></li>")
                End If
            End Code
            <li class="treeview">
                <a href="#">
                    <i class="fa fa-files-o"></i> <span>Build</span> <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li><a href="/SchemaOnly/Index"><i class="fa fa-circle-o"></i> Schema Only</a></li>
                    <li><a href="/SGTSchema/Index"><i class="fa fa-circle-o"></i> Pages w/Schema</a></li>
                </ul>
            </li>
            <li class="treeview">
                <a href="#">
                    <i class="fa fa-table"></i> <span>Tables</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li><a href="/Cities/Index"><i class="fa fa-circle-o"></i> Cities</a></li>
                    <li><a href="/Articles/Index"><i class="fa fa-circle-o"></i> Content</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Themes</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Niche Template</a></li>
                </ul>
            </li>
            <li class="treeview">
                <a href="#">
                    <i class="fa fa-th"></i> <span>Resources</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li><a href="#"><i class="fa fa-circle-o"></i> Image Editor</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Spin Articles</a></li>
                </ul>
            </li>
        </ul>
    </section>
    <!-- /.sidebar -->
</aside>
