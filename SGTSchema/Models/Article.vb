Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class Article
    Public Property ID As Integer

    <Display(Name:="User ID")>
    Public Property UserID As String

    <Required>
    <StringLength(40)>
    Public Property Niche As String

    <Required>
    <StringLength(40)>
    Public Property Title As String

    <Required>
    <AllowHtml>
    <DataType(DataType.MultilineText)>
    Public Property Content As String

    <Required>
    Public Property Spin As Boolean
End Class
