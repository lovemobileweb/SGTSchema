@Imports Microsoft.AspNet.Identity
@Imports Microsoft.AspNet.Identity.EntityFramework


@If Request.IsAuthenticated Then
    Dim context = New ApplicationDbContext()
    Dim userStore = New UserStore(Of ApplicationUser)(context)
    Dim manager = New UserManager(Of ApplicationUser)(userStore)
    Dim userObj = manager.FindById(User.Identity.GetUserId())
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @Html.AntiForgeryToken()
        @<ul class="nav navbar-nav navbar-right">
            <li>
                @Html.ActionLink("Hello " + userObj.FullName + "!", "Index", "Manage", routeValues:=Nothing, htmlAttributes:=New With {.title = "Manage"})
            </li>
            <li><a href="javascript:document.getElementById('logoutForm').submit()">Log off</a></li>
        </ul>   End Using
Else
    @<ul class="nav navbar-nav navbar-right">
        <li>@Html.ActionLink("Register", "Register", "Account", routeValues := Nothing, htmlAttributes := New With { .id = "registerLink" })</li>
        <li>@Html.ActionLink("Log in", "Login", "Account", routeValues := Nothing, htmlAttributes := New With { .id = "loginLink" })</li>
    </ul>
End If

