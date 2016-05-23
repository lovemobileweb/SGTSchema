@ModelType LoginViewModel
@Code
    ViewBag.Title = "Log in"
End Code

<!-- iCheck -->
@Styles.Render("~/plugins/iCheck/square/blue.css")

<div class="login-box">
    <div class="login-logo">
        <a href="#"><b>SGTSchema</b></a>
    </div>
    <div class="login-box-body">
        <section id="loginForm">
            @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.role = "form"})
                @Html.AntiForgeryToken()
                @<text>
                    <p Class="login-box-msg">Sign in to start your session</p>
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                    <div Class="form-group has-feedback">
                        @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control", .type = "email", .placeholder = "Email"})
                        @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
                        <span Class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    </div>
                    <div Class="form-group has-feedback">
                        @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = "Password"})
                        @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                        <span Class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div Class="row">
                        <div Class="col-xs-8">
                            <div Class="checkbox icheck">
                                <Label>
                                    @Html.CheckBoxFor(Function(m) m.RememberMe, New With {.type = "checkbox"})
                                    Remember Me
                                </Label>
                            </div>
                        </div><!-- /.col -->
                        <div Class="col-xs-4">
                            <Button type="submit" Class="btn btn-primary btn-block btn-flat">Sign In</Button>
                        </div><!-- /.col -->
                    </div>
                    @Html.ActionLink("Register as a new user", "Register")
                    <!--a href = "register.html" Class="text-center">Register a New membership</a-->
                </text>
            End Using
        </section>
    </div><!-- /.login-box-body -->
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/plugins/iCheck/icheck.min.js")
    <script>
          $(function () {
            $('input').iCheck({
              checkboxClass: 'icheckbox_square-blue',
              radioClass: 'iradio_square-blue',
              increaseArea: '20%' // optional
            });
          });
    </script>
End Section
