@ModelType CityModel
@Code
    ViewData("Title") = "Create"
End Code

<!-- Content Header (Page header) -->
<section class="content-header">
    <h1>
        Generate Cities
    </h1>
</section>
<!-- Main content -->
<section class="content">
    <div class="row">
        <div class="col-md-12">
            <!-- Horizontal Form -->
            <div class="box box-primary">
                <!-- form start -->
                <form class="form-horizontal">
                    <div class="col-md-6">
                        <h3>Cities Criteria </h3>
                        <div class="form-group">
                            @Html.LabelFor(Function(m) m.City, New With {.class = "col-md-3 control-label"})
                            <div class="col-md-9">
                                @Html.TextBoxFor(Function(m) m.City, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.City, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(m) m.State, New With {.class = "col-md-3 control-label"})
                            <div class="col-md-9">
                                @Html.TextBoxFor(Function(m) m.State, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.State, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(m) m.Country, New With {.class = "col-md-3 control-label"})
                            <div class="col-md-9">
                                @Html.TextBoxFor(Function(m) m.Country, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.Country, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(m) m.Radius, New With {.class = "col-md-3 control-label"})
                            <div class="col-md-9">
                                @Html.TextBoxFor(Function(m) m.Radius, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.Radius, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(m) m.MaxToSelect, New With {.class = "col-md-3 control-label"})
                            <div class="col-md-9">

                                @Html.TextBoxFor(Function(m) m.MaxToSelect, New With {.class = "form-control"})
                                @Html.ValidationMessageFor(Function(m) m.MaxToSelect, "", New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label">Select city size</label>
                            <div class="col-md-9">
                                <select class="form-control" id="ddlCitySize">
                                    <option value="cities1000">cities > 1000</option>
                                    <option value="cities5000">cities > 5000</option>
                                    <option value="cities15000">cities > 15000</option>
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <h3>Results</h3>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-md-3 control-label"># of cities Selected</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="txtSeletedCity" disabled>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-md-3 control-label">List of cities Selected</label>
                            <div class="col-md-9">
                                <select id="mySelect" class="selected form-control" style="height: 200px; width: 100%;" multiple="" name=""></select>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-3 col-md-9">
                                <button type="submit" class="btn btn-primary ladda-button" id="btnSaveDB" data-style="expand-left"><span class="ladda-label">Save</span></button>
                            </div>
                        </div>
                    </div>


                    <div class="box-footer">
                        <div class="col-md-offset-3 col-md-9">
                            <a href="javascript:;" id="GetGeolocation" class="btn btn-primary ladda-button" data-style="expand-left"><span class="ladda-label"> Submit</span></a>
                        </div>
                    </div>
                    @*<div class="form-group">
                            <div class="col-md-offset-3 col-md-9">

                            </div>
                        </div>*@
                </form>
            </div><!-- /.box -->
        </div><!--/.col -->
    </div> <!-- /.row -->
</section><!-- /.content -->

@Section Scripts
    <script type="text/javascript">
        var searchResult = new Array();
        $(function () {
            Ladda.bind('input[type=submit]');

            $('#btnSaveDB').click(function (evt) {
                evt.preventDefault();
                var selectedCity = $('#City').val();
                var selectedState = $('#State').val();
                var selectedMax = $('#MaxToSelect').val();
                var selectedPopulation = $('#ddlCitySize').val();
                var l = Ladda.create(this);
                if ($('#mySelect').html()) {
                    l.start();
                    // Find n save to db
                    var postSelection = [];
                    $('#mySelect option').each(function (i, e) {
                        postSelection.push(searchResult[i])
                    });
                    $.post("/Cities/SaveResult", { selectdCities: postSelection, city: selectedCity, state: selectedState, max: selectedMax, population: selectedPopulation }, function (data) {
                        if (data.response) {
                            $('#modelmsg').html("Cities saved sucessfully");
                        }
                        else {
                            $('#modelmsg').html(data.message);
                        }
                        $('#confirmModel').modal('show');
                    }).done(function () {
                        l.stop();
                    });
                }
                return false;
            });

            $('#GetGeolocation').click(function (evt) {

                var l = Ladda.create(this);
                //$(this).html("Loading...").addClass("disabled")
                $("form").validate();
                evt.preventDefault();
                var $form = $('form');
                if ($form.valid()) {
                    //Ajax call here
                    l.start();
                    var country = $("#Country").val();
                    var city = $("#City").val();
                    var state = $("#State").val();
                    var inString = "";
                    if (country != "UK")
                        inString = city + " " + state + " " + country;
                    else
                        inString = city + " " + state + " " + country;
                    var googleAPI = "http://maps.googleapis.com/maps/api/geocode/json";

                    $.getJSON(googleAPI, {
                        address: inString,
                        sensor: "true"
                    })
                    .done(function (data) {
                        if (data.results.length > 0) {
                            CallGeoname(data.results[0].geometry.location.lat, data.results[0].geometry.location.lng, $("#MaxToSelect").val(), $('#Radius').val(), $("#ddlCitySize").val(), l);
                        }
                        else {
                            //alert("No result found");
                            $('#modelmsg').html("No result found");
                            $('#confirmModel').modal('show');

                            $('#mySelect').empty();
                            $("#txtSeletedCity").val("");
                            // $("#GetGeolocation").html("Submit").removeClass("disabled");
                            l.stop();
                        }

                    });
                    return false;
                }
                else {
                    //  $("#GetGeolocation").html("Submit").removeClass("disabled");
                    l.stop();
                }
            });

        });
        function CallGeoname(lat, lng, maxrow, radius, cities, loder) {
            var url = "http://api.geonames.org/findNearbyPlaceNameJSON";

            var params = "lat=" + lat + "&lng=" + lng + "&username=gsynccontact" + "&cities=" + cities
            if (IsNotEmpty(radius)) {
                var intrad = parseInt(radius);
                intrad = (radius * 1.6);
                if (intrad > 300) {
                    intrad = 299;
                }
                params = params + "&radius=" + intrad;
            }

            if (IsNotEmpty(maxrow)) {
                params = params + "&maxRows=" + maxrow;
            }
            var serviceurl = url + "?" + params;
            //serviceurl = "http://api.geonames.org/findNearbyPlaceNameJSON?lat=23.022505&lng=72.571362&username=gsynccontact&radius=100&maxRows=50";
            //serviceurl = serviceurl;
            console.log(serviceurl);
            $.getJSON(serviceurl)
            .done(function (data) {
                $('#mySelect').empty();
                searchResult = new Array();
                $("#GetGeolocation").html("Submit").removeClass("disabled");
                if (data.geonames.length > 0) {
                    $.each(data.geonames, function (key, value) {
                        searchResult.push(value);
                        $('#mySelect')
                            .append($("<option></option>")
                                       .attr("value", key)
                                       .text(value.name));
                    });
                    //total number of results
                    $("#txtSeletedCity").val(data.geonames.length);
                }
                loder.stop();
            });
        }
        function IsNotEmpty(val) {
            return (val === undefined || val == null || val.length <= 0) ? false : true;
        }
    </script>
End Section
