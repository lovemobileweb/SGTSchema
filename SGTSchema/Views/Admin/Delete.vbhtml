@ModelType UserModel
@Code
    ViewData("Title") = "Details"
End Code

<section class="content-header">
    <h1>
        Reject confirmation
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">JSON-LD Generator</li>
    </ol>
</section>
<section class="content">
    <h3>Are you sure you want to reject the registeration of @Model.FullName? </h3>
    <p>Rejecting this registeration will remove user @Model.FullName.</p>
    <hr/>
    @Using Html.BeginForm()
        @Html.AntiForgeryToken()
        @<div class="form-actions no-color">
            @Html.ActionLink("Cancel", "Index", Nothing, htmlAttributes:=New With {.class = "btn btn-default btn-flat"})
            <input type="submit" value="Reject" class="btn btn-danger btn-flat" />
        </div>
    End Using
</section>