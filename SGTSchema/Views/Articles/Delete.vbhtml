@ModelType SGTSchema.Article
@Code
    ViewData("Title") = "Delete"
End Code

<section class="content-header">
    <h1>
        Delete
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">JSON-LD Generator</li>
    </ol>
</section>
<section class="content">
    <h3>Are you sure you want to delete this?</h3>
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
        @Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-actions no-color">
        <input type="submit" value="Delete" class="btn btn-default" /> |
        @Html.ActionLink("Back to List", "Index")
    </div>
        End Using
    </div>
</section>
