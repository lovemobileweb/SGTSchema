@Imports Microsoft.AspNet.Identity
@Imports Microsoft.AspNet.Identity.EntityFramework


<!-- Sidebar toggle button-->
<a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
    <span class="sr-only">Toggle navigation</span>
</a>
@Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm"})
@<div Class="navbar-custom-menu">
    @Html.AntiForgeryToken()
    <ul Class="nav navbar-nav">
@If Request.IsAuthenticated Then
    Dim context = New ApplicationDbContext()
    Dim userStore = New UserStore(Of ApplicationUser)(context)
    Dim manager = New UserManager(Of ApplicationUser)(userStore)
    Dim userObj = manager.FindById(User.Identity.GetUserId())
        @<li>@Html.ActionLink("Hello " + userObj.FullName + "!", "Index", "Manage", routeValues:=Nothing, htmlAttributes:=New With {.title = "Manage"})</li>
        @<li>
             <a href="javascript:document.getElementById('logoutForm').submit()"> Log off</a>
        </li>
Else
        @<li>@Html.ActionLink("Register", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink"})</li>
        @<li>@Html.ActionLink("Log in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
End If
    </ul>
</div>
End Using
