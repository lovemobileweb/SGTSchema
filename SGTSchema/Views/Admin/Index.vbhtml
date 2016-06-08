@ModelType IEnumerable(Of UserModel)
@Code
    ViewData("Title") = "Index"
End Code

<section class="content-header">
    <h1>
        Admin
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">JSON-LD Generator</li>
    </ol>
</section>
<section class="content">
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.FullName)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Email)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Role)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.FullName)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Email)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Role)
                </td>
                <td>
                    @Html.ActionLink("Details", "Details", New With {.id = item.Id})
                </td>
            </tr>
        Next

    </table>
</section>