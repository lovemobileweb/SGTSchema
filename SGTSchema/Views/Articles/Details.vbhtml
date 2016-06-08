@ModelType SGTSchema.Article
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
    <div>
        <h4>Article</h4>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.Niche)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Niche)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Title)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Title)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Content)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Content)
            </dd>

            <dt>
                @Html.DisplayNameFor(Function(model) model.Spin)
            </dt>

            <dd>
                @Html.DisplayFor(Function(model) model.Spin)
            </dd>

        </dl>
    </div>
    <p>
        @Html.ActionLink("Edit", "Edit", New With {.id = Model.ID}) |
        @Html.ActionLink("Back to List", "Index")
    </p>
</section>
