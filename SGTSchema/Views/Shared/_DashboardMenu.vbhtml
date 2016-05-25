@Scripts.Render("~/Scripts/pages/dashboard.js")
@Scripts.Render("~/Scripts/app.js")
@Scripts.Render("~/Scripts/demo.js")

<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar" style="height: auto;">
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <ul class="sidebar-menu">
            <li class="header">Dashboard</li>
            <li class="active treeview">
                <a href="#">
                    <i class="fa fa-files-o"></i> <span>Build</span> <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li class="active"><a href="#"><i class="fa fa-circle-o"></i> SGTSchema</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Schema Only</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Pages w/Schema</a></li>
                </ul>
            </li>
            <li class="treeview">
                <a href="#">
                    <i class="fa fa-table"></i> <span>Tables</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li><a href="#"><i class="fa fa-circle-o"></i> Cities</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Content</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Company</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Niche Template</a></li>
                </ul>
            </li>
            <li class="treeview">
                <a href="#">
                    <i class="fa fa-th"></i> <span>Resources</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li><a href="#"><i class="fa fa-circle-o"></i> Images</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Spun Content</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Themes</a></li>
                </ul>
            </li>
        </ul>
    </section>
    <!-- /.sidebar -->
</aside>
