@Code
    ViewBag.Title = "Pricing page"
End Code

<div class="pricing-box">
    <div class="pricing-logo">
        <b>@Html.Raw(ViewBag.Title)</b>
    </div>
    <div class="pricing-box-body">
        <p class="login-box-msg">Select your membership</p>
        <div class="col-md-4">
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Standard</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                    <div>
                        <p>Your membership is standard (free)</p>
                    </div>
                    @Html.ActionLink("Choose Plan", "Standard", Nothing, htmlAttributes:=New With {.class = "btn btn-block btn-default btn-flat"})
                </div><!-- /.box-body -->
            </div><!-- /.box -->
        </div><!-- /.col -->

        <div class="col-md-4">
            <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">Premium</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                    <div>
                        <p>Your membership is premium ($30)</p>
                    </div>
                    @Html.ActionLink("Choose Plan", "Premium", Nothing, htmlAttributes:=New With {.class = "btn btn-block btn-info btn-flat"})
                </div><!-- /.box-body -->
            </div><!-- /.box -->
        </div><!-- /.col -->

        <div class="col-md-4">
            <div class="box box-warning">
                <div class="box-header with-border">
                    <h3 class="box-title">Enterprise</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                    <div>
                        <p>Your membership is enterprise ($100)</p>
                    </div>
                    @Html.ActionLink("Choose Plan", "Enterprise", Nothing, htmlAttributes:=New With {.class = "btn btn-block btn-warning btn-flat"})
                </div><!-- /.box-body -->
            </div><!-- /.box -->
        </div><!-- /.col -->
    </div>
</div>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
