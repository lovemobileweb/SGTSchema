Imports System.Data.Entity.Validation
Imports System.Security.Claims

Public Class CitiesController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDbContext

    Function Index() As ActionResult
        Dim userID = GetUserId()
        Dim cities = (From city In db.Cities Where city.UserId = userID
                      Select New With {.Id = city.Id, .UserId = city.UserId, .City = city.City, .State = city.State, .Country = city.Country, .Population = city.Population, .Radius = city.Radius, .SurroundingCity = city.SurroundingCity, .SurroundingState = city.SurroundingState, .MaxToSelect = city.MaxToSelect}).ToList()
        Dim cityModels = cities.Select(Function(city) New CityModel(city.Id, city.UserId, city.City, city.State, city.Country, city.Population, city.Radius, city.SurroundingCity, city.SurroundingState, city.MaxToSelect)).ToList()
        Return View(cityModels)
    End Function

    Function GetCities() As ActionResult
        Dim list As List(Of CityModel)
        list = db.Cities.ToList()
        Return Me.Json(list, JsonRequestBehavior.AllowGet)
    End Function

    Function Create() As ActionResult
        Return View()
    End Function

    Function SaveResult(selectdCities As List(Of Geoname), city As String, state As String, max As Integer, population As String) As ActionResult
        Dim sucess = False
        Dim errormsg = ""

        Try
            If population = "cities1000" Then
                population = 1
            ElseIf population = "cities5000" Then
                population = 2
            ElseIf population = "cities15000" Then
                population = 3
            End If

            Dim listCity = New List(Of CityModel)
            For Each objGeoname In selectdCities
                Dim geocity = New CityModel
                geocity.UserId = GetUserId()
                geocity.Country = objGeoname.countryCode
                geocity.City = city
                geocity.State = state
                geocity.SurroundingCity = objGeoname.name
                geocity.SurroundingState = objGeoname.adminName1
                geocity.Population = population
                geocity.Radius = objGeoname.distance
                geocity.MaxToSelect = max
                listCity.Add(geocity)
            Next

            db.Cities.AddRange(listCity)
            db.SaveChanges()
            sucess = True
            errormsg = "Cities saved sucessfully"
        Catch e As DbEntityValidationException
            errormsg = e.Message

        Catch e As Exception
            errormsg = e.Message

        End Try
        Dim response = New With {.sucess = sucess, .message = errormsg}

        Return Me.Json(response, JsonRequestBehavior.AllowGet)
        ' Return Content(sucess)
    End Function

    Function DeleteCity(id As Integer) As ActionResult
        Dim sucess = False
        Dim city = db.Cities.FirstOrDefault(Function(x) x.Id = id)
        If Not city Is Nothing Then
            db.Cities.Remove(city)
            db.SaveChanges()
            sucess = True
        End If
        Return Content(sucess)
    End Function

    Public Function GetUserId() _
        As String
        Dim userIdValue = ""
        Dim claimsIdentity As ClaimsIdentity = User.Identity
        If (claimsIdentity IsNot Nothing) Then
            Dim userIdClaim = claimsIdentity.Claims.FirstOrDefault(Function(x) x.Type = ClaimTypes.NameIdentifier)

            If (userIdClaim IsNot Nothing) Then
                userIdValue = userIdClaim.Value
            End If
        End If
        Return userIdValue
    End Function

End Class