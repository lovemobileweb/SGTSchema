@ModelType IEnumerable(Of CompanyModel)
@Code
    ViewData("Title") = "Index"
End Code

<section class="content-header">
    <h1>
        Company
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
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Country)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Address)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.City)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.State)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Latitude)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Longitude)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Country)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Address)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.City)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.State)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Latitude)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Longitude)
                </td>
                <td>
                    @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
                </td>
            </tr>
        Next

    </table>
</section>
