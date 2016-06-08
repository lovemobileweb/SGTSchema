@ModelType CompanyModel
@Code
    ViewData("Title") = "Details"
    Dim FuncName = "Save"
    If Model Is Nothing Then
        FuncName = "Create"
        ViewData("Title") = "Create Company"
    ElseIf Model.ID = 0 Then
        FuncName = "Create"
        ViewData("Title") = "Create Company"
    End If
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
    @Using Html.BeginForm(FuncName, "Company", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Company</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.ID)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Country, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Country, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Country, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Address, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Address, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Address, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.City, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.City, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.City)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.State, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.State, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.State)
            </div>
        </div>

        <div class="form-group">
            @Html.Label(" ", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-2">
                <input id="GetGeolocation" type="button" value="Get Geolocation" class="btn btn-default" />
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Latitude, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.Latitude, New With {.class = "form-control", .readonly = "readonly"})
                @Html.ValidationMessageFor(Function(model) model.Latitude)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Longitude, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(model) model.Longitude, New With {.class = "form-control", .readonly = "readonly"})
                @Html.ValidationMessageFor(Function(model) model.Longitude)
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
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
