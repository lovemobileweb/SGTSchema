Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class CompanyModel
    Public Property ID As Integer

    <Required>
    <StringLength(40)>
    Public Property Name As String

    <Required>
    <StringLength(40)>
    Public Property Country As String

    <Required>
    <StringLength(40)>
    Public Property Address As String

    <Required>
    <StringLength(40)>
    Public Property City As String

    <Required>
    <StringLength(40)>
    Public Property State As String

    <StringLength(40)>
    Public Property Latitude As String

    <StringLength(40)>
    Public Property Longitude As String

End Class

Public Class CompanyDbContext
    Inherits DbContext

    Public Property Companies As DbSet(Of CompanyModel)
End Class
