@ModelType IEnumerable(Of SGTSchema.Article)
@Code
ViewData("Title") = "Index"
End Code

<section class="content-header">
    <h1>
        Articles
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">JSON-LD Generator</li>
    </ol>
</section>
<section class="content">
    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Niche)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Title)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Content)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.Spin)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Niche)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Title)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Content)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Spin)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID})
        </td>
    </tr>
        Next

    </table>
</section>
