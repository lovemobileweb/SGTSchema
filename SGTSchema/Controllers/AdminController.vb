Imports System.Data.Entity
Imports System.Net
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports PagedList

Public Class AdminController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDbContext

    ' GET: Users
    Function Index() As ActionResult
        Dim userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim roleManager = System.Web.HttpContext.Current.GetOwinContext().Get(Of ApplicationRoleManager)()
        Dim users = (From u In userManager.Users Where u.Email.ToString() <> "admin@sgtschema.com" And u.Flag = False
                     Select New With {.Id = u.Id, .FullName = u.FullName, .Email = u.Email, .Role = ""}).ToList()
        Dim userModels = users.Select(Function(u) New UserModel(u.Id, u.FullName, u.Email, "")).ToList()
        For Each u In userModels
            u.Role = userManager.GetRoles(u.Id).First
        Next
        Return View(userModels)
    End Function

    ' GET: /Admin/Details/5
    Function Details(ByVal id As String) As ActionResult
        Dim userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim roleManager = System.Web.HttpContext.Current.GetOwinContext().Get(Of ApplicationRoleManager)()
        Dim user = userManager.FindById(id)
        If (user Is Nothing) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim roleName = userManager.GetRoles(user.Id).First
        If (roleName Is Nothing Or roleName = "") Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim userModel = New UserModel()
        userModel.Id = user.Id
        userModel.FullName = user.FullName
        userModel.Email = user.Email
        userModel.Role = roleName
        Return View(userModel)
    End Function

    ' POST: Admin/Edit/5
    'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost(), ActionName("Accept")>
    <ValidateAntiForgeryToken()>
    Function Accept(ByVal userModel As UserModel) As ActionResult
        If ModelState.IsValid Then
            Dim userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim user = userManager.FindById(userModel.Id)
            If (user Is Nothing) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            user.Flag = True
            userManager.Update(user)
            Return RedirectToAction("Index")
        End If
        Return View("Details", userModel)
    End Function

    ' GET: Admin/Delete/5
    Function Delete(ByVal id As String) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim roleManager = System.Web.HttpContext.Current.GetOwinContext().Get(Of ApplicationRoleManager)()
        Dim user = userManager.FindById(id)
        If (user Is Nothing) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim roleName = userManager.GetRoles(user.Id).First
        If (roleName Is Nothing Or roleName = "") Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim userModel = New UserModel()
        userModel.Id = user.Id
        userModel.FullName = user.FullName
        userModel.Email = user.Email
        userModel.Role = roleName
        Return View(userModel)
    End Function

    ' POST: Admin/Delete/5
    <HttpPost()>
    <ActionName("Delete")>
    <ValidateAntiForgeryToken()>
    Function DeleteConfirmed(ByVal id As String) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim roleManager = System.Web.HttpContext.Current.GetOwinContext().Get(Of ApplicationRoleManager)()
        Dim user = userManager.FindById(id)
        If (user Is Nothing) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim roleName = userManager.GetRoles(user.Id).First
        If (roleName Is Nothing Or roleName = "") Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        userManager.Delete(user)
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing) Then
            db.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
