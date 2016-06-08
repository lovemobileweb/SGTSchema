Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class CityModel
    Public Property Id As Integer
    Public Property UserId As String
    <Required>
    <StringLength(40)>
    Public Property City As String
    <Required>
    Public Property State As String
    <Required>
    <StringLength(2)>
    Public Property Country As String
    <Required>
    Public Property Population As Int32
    <Required>
    <DisplayName("Radius (< 185 Miles)")>
    Public Property Radius As Int32
    <StringLength(40)>
    Public Property SurroundingCity As String
    <StringLength(40)>
    Public Property SurroundingState As String
    <DisplayName("Max #to Select")>
    Public Property MaxToSelect As Int32?
    Public ReadOnly Property Spopulation() As String
        Get
            Return GetSpopulation(Population)
        End Get
    End Property

    Public Shared Function GetSpopulation(population As Int32) As String
        Dim displaytext As String = ""
        Select Case population
            Case 1
                displaytext = "1000"
                Exit Select
            Case 2
                displaytext = "5000"
                Exit Select
            Case 3
                displaytext = "15000"
                Exit Select
            Case Else
                displaytext = population
                Exit Select
        End Select
        Return displaytext
    End Function

    Public Sub New()
        Me.Id = 0
        Me.UserId = ""
        Me.City = ""
        Me.State = ""
        Me.Country = ""
        Me.Population = 0
        Me.Radius = 0
        Me.SurroundingCity = ""
        Me.SurroundingState = ""
        Me.MaxToSelect = 0
    End Sub

    Public Sub New(id As Integer, userId As String, city As String, state As String, country As String, population As Int32, radius As Int32, surroundingCity As String, surroundingState As String, maxToSelect As Integer)
        Me.Id = id
        Me.UserId = userId
        Me.City = city
        Me.State = state
        Me.Country = country
        Me.Population = population
        Me.Radius = radius
        Me.SurroundingCity = surroundingCity
        Me.SurroundingState = surroundingState
        Me.MaxToSelect = maxToSelect
    End Sub
End Class
