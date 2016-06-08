Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations

Public Class UserModel
    Public Property Id As String

    Public Property FullName As String
    Public Property Email As String
    Public Property Role As String

    Public Sub New()
        Me.Id = ""
        Me.FullName = ""
        Me.Email = ""
        Me.Role = ""
    End Sub

    Public Sub New(id As String, fullName As String, email As String, role As String)
        Me.Id = id
        Me.FullName = fullName
        Me.Email = email
        Me.Role = role
    End Sub
End Class
