@ModelType IEnumerable(Of CityModel)

@Code
    ViewData("Title") = "Home Page"
End Code

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        Cities
        <small>manage your cities </small>
    </h1>
</section>
<!-- Main content -->
<section class="content">
    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-header">
                    <div class="pull-right">
                        <a href="@Url.Action("Create")" class="btn btn-sm btn-success"><i class="fa fa-plus"></i> Add Cities</a>
                        @*<a data-refreshgrid class="btn btn-sm btn-success" href="javascript:;" title="refresh compines list"><i class="fa fa-refresh"></i></a>*@
                    </div>
                </div><!-- /.box-header -->
                <div class="box-body">
                    <table id="tblCities" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>@Html.DisplayNameFor(Function(model) model.City)</th>
                                <th>@Html.DisplayNameFor(Function(model) model.State)</th>
                                <th>@Html.DisplayNameFor(Function(model) model.Radius)</th>
                                <th>@Html.DisplayNameFor(Function(model) model.MaxToSelect)</th>
                                <th>@Html.DisplayNameFor(Function(model) model.Population)</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            @For Each item In Model
                                @<tr>
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) item.City)
                                    </td>
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) item.State)
                                    </td>
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) item.Radius)
                                    </td>
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) item.MaxToSelect)
                                    </td>
                                    <td>
                                        @Html.DisplayFor(Function(modelItem) item.Spopulation)
                                    </td>
                                    <td>
                                        <a id="row_a_@item.Id" href="javascript:;" class="btn btn-xs btn-danger" onclick='manageDelete("@item.Id")'>Delete</a>
                                    </td>
                                </tr>
                            Next
                        </tbody>
                    </table>
                </div><!-- /.box-body -->
            </div><!-- /.box -->
        </div><!-- /.col -->
    </div><!-- /.row -->
</section>
@Section Scripts
    <script>
        var cityTable;
        $(function () {
            cityTable = $('#tblCities').dataTable();
        });

        function manageDelete(arg) {
            var confirm = window.confirm("Are you sure about this action ?");
            if (confirm) {
                $.post("@Url.Action("DeleteCity")", { id: arg }, function () {
                    cityTable.DataTable()
                    .row($('#row_a_' + arg).parents('tr'))
                    .remove()
                    .draw()
                })
                .done(function () {
                    //alert("second success");
                })
                .fail(function () {
                    //  alert("error");
                })
                .always(function () {
                    // alert("finished");
                });
            }

        };
    </script>
End Section