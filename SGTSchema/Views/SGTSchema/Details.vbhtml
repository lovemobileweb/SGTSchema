@ModelType SGTSchemaModel
@Code
    ViewData("Title") = "Edit SGTSchema"
    Dim FuncName = "Save"
    If Model Is Nothing Then
        FuncName = "Create"
        ViewData("Title") = "Create SGTSchema"
    ElseIf Model.ID = 0 Then
        FuncName = "Create"
        ViewData("Title") = "Create SGTSchema"
    End If
End Code

<div Class="jumbotron">
    <h2> JSON-LD Generator For SEO Takeover</h2>
@Using Html.BeginForm(FuncName, "SGTSchema", FormMethod.Post, New With {.class = "form-horizontal", .role = "form", .enctype = "multipart/form-data"})
    @Html.AntiForgeryToken()
    @Html.HiddenFor(Function(m) m.ID)
    @<text>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(m) m.cbBusiness, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(m) m.cbBusiness, New SelectList([Enum].GetValues(GetType(LocalBusinessType))), "Select ...", New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cbBusiness, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.cName, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.cName, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cName, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.cDescription, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(m) m.cDescription, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cDescription, "", New With {.class = "text-danger"})
            </div>
        </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cUrl, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.cUrl, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cUrl, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cHomeContent, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextAreaFor(Function(m) m.cHomeContent, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cHomeContent, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cAddress, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.cAddress, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cAddress, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cAddress2, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.cAddress2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cAddress2, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cCity, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.cCity, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cCity, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cbCountry, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.DropDownListFor(Function(m) m.cbCountry, New SelectList([Enum].GetValues(GetType(Country))), "Select ...", New With {.class = "my-country form-control", .onchange = "onSelectCountry(this)"})
            @Html.ValidationMessageFor(Function(m) m.cbCountry, "", New With {.class = "text-danger"})
        </div>
        <div class="my-usstate col-md-8" style="display:none;">
            @Html.LabelFor(Function(m) m.cUSState, New With {.class = "col-md-3 control-label"})
            <div class="col-md-3">
                @Html.DropDownListFor(Function(m) m.cUSState, New SelectList([Enum].GetValues(GetType(USState))), "Select ...", New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cUSState, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="my-austate col-md-8" style="display:none;">
            @Html.LabelFor(Function(m) m.cAUState, New With {.class = "col-md-3 control-label"})
            <div class="col-md-3">
                @Html.DropDownListFor(Function(m) m.cAUState, New SelectList([Enum].GetValues(GetType(AUState))), "Select ...", New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cAUState, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="my-castate col-md-8" style="display:none;">
            @Html.LabelFor(Function(m) m.cCAState, New With {.class = "col-md-3 control-label"})
            <div class="col-md-3">
                @Html.DropDownListFor(Function(m) m.cCAState, New SelectList([Enum].GetValues(GetType(CAState))), "Select ...", New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCAState, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="my-ukstate col-md-8" style="display:none;">
            @Html.LabelFor(Function(m) m.cUKState, New With {.class = "col-md-3 control-label"})
            <div class="col-md-3">
                @Html.DropDownListFor(Function(m) m.cUKState, New SelectList([Enum].GetValues(GetType(UKState))), "Select ...", New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cUKState, "", New With {.class = "text-danger"})
            </div>
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cZip, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextBoxFor(Function(m) m.cZip, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cZip, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.MonFriCheckBox, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.CheckBoxFor(Function(m) m.MonFriCheckBox)
            @Html.ValidationMessageFor(Function(m) m.MonFriCheckBox, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.MonFriOpen, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.MonFriOpen, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.MonFriOpen, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.MonFriClose, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.MonFriClose, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.MonFriClose, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.MonCheckBox, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.CheckBoxFor(Function(m) m.MonCheckBox)
            @Html.ValidationMessageFor(Function(m) m.MonCheckBox, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.MonOpen, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.MonOpen, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.MonOpen, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.MonClose, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.MonClose, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.MonClose, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.TueCheckBox, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.CheckBoxFor(Function(m) m.TueCheckBox)
            @Html.ValidationMessageFor(Function(m) m.TueCheckBox, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.TueOpen, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.TueOpen, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.TueOpen, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.TueClose, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.TueClose, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.TueClose, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.WedCheckBox, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.CheckBoxFor(Function(m) m.WedCheckBox)
            @Html.ValidationMessageFor(Function(m) m.WedCheckBox, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.WedOpen, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.WedOpen, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.WedOpen, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.WedClose, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.WedClose, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.WedClose, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.ThuCheckBox, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.CheckBoxFor(Function(m) m.ThuCheckBox)
            @Html.ValidationMessageFor(Function(m) m.ThuCheckBox, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.ThuOpen, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.ThuOpen, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.ThuOpen, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.ThuClose, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.ThuClose, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.ThuClose, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.FriCheckBox, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.CheckBoxFor(Function(m) m.FriCheckBox)
            @Html.ValidationMessageFor(Function(m) m.FriCheckBox, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.FriOpen, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.FriOpen, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.FriOpen, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.FriClose, New With {.class = "col-md-2 control-label"})
        <div class="col-md-2">
            @Html.TextBoxFor(Function(m) m.FriClose, New With {.class = "form-control timepicker"})
            @Html.ValidationMessageFor(Function(m) m.FriClose, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("City or City ST or City ST Zip", New With {.class = "col-md-3 control-label"})
        <input type="button" value="Generate List of Cities" class="btn btn-default" />
    </div>
    <div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.cCity1, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity1, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity1, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cCity2, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity2, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity2, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cCity2, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity3, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity3, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.cCity4, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity4, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity4, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cCity5, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity5, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity5, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cCity6, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity6, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity6, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.cCity7, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity7, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity7, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cCity8, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity8, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity8, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cCity9, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cCity9, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cCity9, "", New With {.class = "text-danger"})
            </div>
        </div>
    </div>
    <div>
        <div class="form-group">
            @Html.Label("Social Profiles", New With {.class = "col-md-2 control-label"})
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.cFB, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cFB, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cFB, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cGPlus, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cGPlus, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cGPlus, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cTwitter, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cTwitter, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cTwitter, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.cLinkedIn, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cLinkedIn, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cLinkedIn, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cYT, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cYT, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cYT, "", New With {.class = "text-danger"})
            </div>
            @Html.LabelFor(Function(m) m.cPinterest, New With {.class = "col-md-2 control-label"})
            <div class="col-md-2">
                @Html.TextBoxFor(Function(m) m.cPinterest, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.cPinterest, "", New With {.class = "text-danger"})
            </div>
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cYouTube, New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            @Html.TextAreaFor(Function(m) m.cYouTube, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cYouTube, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Get Image", New With {.class = "col-md-2 control-label"})
        <div class="col-md-10">
            <input type="file" name="file_getimage" class="form-control" />
            @Html.HiddenFor(Function(m) m.cImage, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cImage, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.SchemaCheckBox, New With {.class = "col-md-2 control-label"})
        <div class="col-md-1">
            @Html.CheckBoxFor(Function(m) m.SchemaCheckBox)
            @Html.ValidationMessageFor(Function(m) m.SchemaCheckBox, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.PagesCheckBox, New With {.class = "col-md-3 control-label"})
        <div class="col-md-1">
            @Html.CheckBoxFor(Function(m) m.PagesCheckBox)
            @Html.ValidationMessageFor(Function(m) m.PagesCheckBox, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.SpunCheckBox, New With {.class = "col-md-2 control-label"})
        <div class="col-md-1">
            @Html.CheckBoxFor(Function(m) m.SpunCheckBox)
            @Html.ValidationMessageFor(Function(m) m.SpunCheckBox, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cServiceCat, New With {.class = "col-md-7 control-label"})
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cServiceCat, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cServiceCat, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("", New With {.class = "col-md-2 control-label"})
        @Html.LabelFor(Function(m) m.cService1, New With {.class = "col-md-5 control-label"})
        @Html.LabelFor(Function(m) m.cService2, New With {.class = "col-md-5 control-label"})
    </div>
    <div class="form-group">
        @Html.Label("Service", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService1, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService1, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService2, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Txt", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat1, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat1, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat2, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Img", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            <input type="file" name="file_pic1" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic1, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic1, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            <input type="file" name="file_pic2" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic2, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Video Embed Code", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid1, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid1, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid2, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("", New With {.class = "col-md-2 control-label"})
        @Html.LabelFor(Function(m) m.cService3, New With {.class = "col-md-5 control-label"})
        @Html.LabelFor(Function(m) m.cService4, New With {.class = "col-md-5 control-label"})
    </div>
    <div class="form-group">
        @Html.Label("Service", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService3, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService4, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService4, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Txt", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat3, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat4, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat4, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Img", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            <input type="file" name="file_pic3" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic3, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            <input type="file" name="file_pic4" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic4, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic4, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Video Embed Code", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid3, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid4, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid4, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("", New With {.class = "col-md-2 control-label"})
        @Html.LabelFor(Function(m) m.cService5, New With {.class = "col-md-5 control-label"})
        @Html.LabelFor(Function(m) m.cService6, New With {.class = "col-md-5 control-label"})
    </div>
    <div class="form-group">
        @Html.Label("Service", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService5, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService5, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService6, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService6, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Txt", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat5, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat5, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat6, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat6, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Img", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            <input type="file" name="file_pic5" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic5, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic5, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            <input type="file" name="file_pic6" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic6, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic6, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Video Embed Code", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid5, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid5, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid6, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid6, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("", New With {.class = "col-md-2 control-label"})
        @Html.LabelFor(Function(m) m.cService7, New With {.class = "col-md-5 control-label"})
        @Html.LabelFor(Function(m) m.cService8, New With {.class = "col-md-5 control-label"})
    </div>
    <div class="form-group">
        @Html.Label("Service", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService7, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService7, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService8, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService8, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Txt", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat7, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat7, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat8, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat8, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Img", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            <input type="file" name="file_pic7" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic7, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic7, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            <input type="file" name="file_pic8" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic8, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic8, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Video Embed Code", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid7, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid7, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid8, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid8, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("", New With {.class = "col-md-2 control-label"})
        @Html.LabelFor(Function(m) m.cService9, New With {.class = "col-md-5 control-label"})
        @Html.LabelFor(Function(m) m.cService10, New With {.class = "col-md-5 control-label"})
    </div>
    <div class="form-group">
        @Html.Label("Service", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService9, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService9, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextBoxFor(Function(m) m.cService10, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cService10, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Txt", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat9, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat9, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sCat10, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sCat10, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Img", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            <input type="file" name="file_pic9" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic9, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic9, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            <input type="file" name="file_pic10" class="form-control" />
            @Html.HiddenFor(Function(m) m.sPic10, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sPic10, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Video Embed Code", New With {.class = "col-md-2 control-label"})
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid9, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid9, "", New With {.class = "text-danger"})
        </div>
        <div class="col-md-5">
            @Html.TextAreaFor(Function(m) m.sVid10, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.sVid10, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.Label("Links to Relevant Sites for Main City, e.g. Local Chamber, City gov page, local associations", New With {.class = "col-md-8 control-label"})
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cLinkName1, New With {.class = "col-md-2 control-label"})
        <div class="col-md-4">
            @Html.TextBoxFor(Function(m) m.cLinkName1, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cLinkName1, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.cLinkURL1, New With {.class = "col-md-2 control-label"})
        <div class="col-md-4">
            @Html.TextBoxFor(Function(m) m.cLinkURL1, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cLinkURL1, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cLinkName2, New With {.class = "col-md-2 control-label"})
        <div class="col-md-4">
            @Html.TextBoxFor(Function(m) m.cLinkName2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cLinkName2, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.cLinkURL2, New With {.class = "col-md-2 control-label"})
        <div class="col-md-4">
            @Html.TextBoxFor(Function(m) m.cLinkURL2, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cLinkURL2, "", New With {.class = "text-danger"})
        </div>
    </div>
    <div class="form-group">
        @Html.LabelFor(Function(m) m.cLinkName3, New With {.class = "col-md-2 control-label"})
        <div class="col-md-4">
            @Html.TextBoxFor(Function(m) m.cLinkName3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cLinkName3, "", New With {.class = "text-danger"})
        </div>
        @Html.LabelFor(Function(m) m.cLinkURL3, New With {.class = "col-md-2 control-label"})
        <div class="col-md-4">
            @Html.TextBoxFor(Function(m) m.cLinkURL3, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(m) m.cLinkURL3, "", New With {.class = "text-danger"})
        </div>
    </div>
        <div Class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </text>
End Using

    <div>
        @Html.ActionLink("Back to List", "Index")
    </div>

</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/Scripts/jquery-ui-1.11.4.js")
    @Scripts.Render("~/Scripts/jquery-ui-sliderAccess.js")
    @Scripts.Render("~/Scripts/jquery-ui-timepicker-addon.js")
    <script type="text/javascript">
        $(function () { // will trigger when the document is ready
            $('.timepicker').timepicker({
                hourGrid: 4,
                minuteGrid: 10,
                timeFormat: 'hh:mm tt'
            });
            onSelectCountry($('.my-country')[0]);
        });
        function onSelectCountry(obj)
        {
            var selectBox = obj;
            var selectedValue = selectBox.options[selectBox.selectedIndex].value;
            $('.my-usstate').hide();
            $('.my-austate').hide();
            $('.my-castate').hide();
            $('.my-ukstate').hide();
            if (selectedValue == "US")
                $('.my-usstate').show();
            else if (selectedValue == "AU")
                $('.my-austate').show();
            else if (selectedValue == "CA")
                $('.my-castate').show();
            else if (selectedValue == "UK")
                $('.my-ukstate').show();
        }
    </script>
End Section

@Styles.Render("~/Content/jquery-ui.css")
@Styles.Render("~/Content/jquery-ui-timepicker-addon.css")
