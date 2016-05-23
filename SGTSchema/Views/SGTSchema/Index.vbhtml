@ModelType PagedList.IPagedList(Of SGTSchemaModel)
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Home Page"
End Code

<section class="content-header">
    <h1>
        JSON-LD Generator For SEO Takeover
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">JSON-LD Generator</li>
    </ol>
</section>
<section class="content">
    <p>
        @Html.ActionLink("Create New", "Details")
    </p>

    @If (Model.Count > 0) Then
    @<ul Class="form-group">
        @For Each item In Model
    @<li Class="col-md-12">
        @Html.ActionLink(item.cName, "Details", New With {.id = item.ID})
    </li>
        Next
    </ul>
    Else
    @<div Class="form-group" style="text-align: center">
        @Html.Raw("There is no item!")
    </div>
    End If
    <hr />
    Page @IIf(Model.PageCount < Model.PageNumber, 0, Model.PageNumber) of @Model.PageCount
    @Html.PagedListPager(Model, Function(page) Url.Action("Index",
                                                                            New With {page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter}))
</section>

    @Section Scripts
        @Scripts.Render("~/bundles/jqueryval")
    End Section

    @Styles.Render("~/Content/PagedList.css")
