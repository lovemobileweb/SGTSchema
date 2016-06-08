@ModelType UserModel
@Code
    ViewData("Title") = "Details"
End Code

<section class="content-header">
    <h1>
        Details
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">JSON-LD Generator</li>
    </ol>
</section>
<section class="content">
    @Using Html.BeginForm("Accept", "Admin", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>User registeration</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.Id)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.FullName, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.FullName, New With {.class = "form-control", .readonly = "readonly"})
                @Html.ValidationMessageFor(Function(model) model.FullName, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.Email, New With {.class = "form-control", .readonly = "readonly"})
                @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Role, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.Role, New With {.class = "form-control", .readonly = "readonly"})
                @Html.ValidationMessageFor(Function(model) model.Role, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-10 col-md-2">
                <input type="submit" value="Accept" class="btn btn-primary btn-flat" />
                @Html.ActionLink("Reject", "Delete", New With {.id = Model.Id}, htmlAttributes:=New With {.class = "btn btn-danger btn-flat pull-right"})
            </div>
        </div>
    </div>
    End Using

    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>
</section>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/ckeditor/ckeditor.js")
    @Scripts.Render("~/ckeditor/adapters/jquery.js")
    <script type="text/javascript">
        $(function () { // will trigger when the document is ready
            $('#GetGeolocation').click(function () {
                var country = $("#Country").val();
                var address = $("#Address").val();
                var city = $("#City").val();
                var state = $("#State").val();
                var inString = "";
                if (country != "UK")
                    inString = address + " " + city + " " + state;
                else
                    inString = address + " " + city + " " + state + " " + country;
                var googleAPI = "http://maps.googleapis.com/maps/api/geocode/json";
                $.getJSON(googleAPI, {
                    address: inString,
                    sensor: "true"
                })
                .done(function (data) {
                    $('#Latitude').val(data.results[0].geometry.location.lat);
                    $('#Longitude').val(data.results[0].geometry.location.lng);
                });
            });
        });
    </script>
End Section
