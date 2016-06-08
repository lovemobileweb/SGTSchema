@ModelType SchemaOnlyDownloadModel
@Imports PagedList.Mvc
@Code
    ViewData("Title") = "Schema Only Download"
End Code

<section class="content-header">
    <h1>
        Schema Only Download
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">Schema Only</li>
    </ol>
</section>
<section class="content">
@Using Html.BeginForm("Download", "SchemaOnly", FormMethod.Post, New With {.class = "form-horizontal", .role = "form", .enctype = "multipart/form-data"})
    @Html.HiddenFor(Function(m) m.FileUrl)
    @<div Class="form-group" style="padding-left:30px">
        @Html.Raw("Downloading SchemaOnly... If the download doesn't start please ")
        <a href="#" onclick="onDownload();return false;">click here</a>
        @Html.Raw(".")
    </div>
End Using
    @Html.ActionLink("Back to List", "Index")
</section>

@Section Scripts
    <script type="text/javascript">
        function onDownload()
        {
            $('form').submit();
        }
        $(function () {
            setTimeout(onDownload, 2000)
        });
    </script>
End Section