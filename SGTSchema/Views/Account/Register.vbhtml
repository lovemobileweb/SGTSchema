@ModelType RegisterViewModel
@Code
    ViewBag.Title = "Register"
    Dim membershipLabel = "<p Class='login-box-msg'>Register a New <b>" + Model.Role.ToString() + "</b> membership</p>"
End Code

<div class="register-box">
    <div class="register-logo">
        <a href="#"><b>SGTSchema</b></a>
    </div>
    <div class="register-box-body">
        <section id="registerForm">
            @Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.role = "form"})
                @Html.AntiForgeryToken()
                @<text>
                    @Html.Raw(membershipLabel)
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                    <div class="form-group has-feedback">
                        @Html.HiddenFor(Function(m) m.Role)
                        @Html.ValidationMessageFor(Function(m) m.Role, "", New With {.class = "text-danger"})
                    </div>
                    <div class="form-group has-feedback">
                        @Html.TextBoxFor(Function(m) m.Nickname, New With {.class = "form-control", .placeholder = "Full name"})
                        @Html.ValidationMessageFor(Function(m) m.Nickname, "", New With {.class = "text-danger"})
                        <span class="glyphicon glyphicon-user form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control", .placeholder = "Email"})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
                        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = "Password"})
                        @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control", .placeholder = "Retype password"})
                        @Html.ValidationMessageFor(Function(m) m.ConfirmPassword, "", New With {.class = "text-danger"})
                        <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
                    </div>
                    <div Class="row">
                        <div Class="col-xs-8">
                            <div Class="checkbox icheck">
                                @Html.ActionLink("I already have a membership", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.class = "text-center"})
                            </div>
                        </div><!-- /.col -->
                        <div Class="col-xs-4">
                            <input type="submit" class="btn btn-primary btn-block btn-flat" value="Register" />
                        </div>
                    </div>
                </text>
            End Using
        </section>
    </div>
</div>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
