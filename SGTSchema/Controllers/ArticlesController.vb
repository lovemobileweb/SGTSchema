Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Security.Claims
Imports System.Web
Imports System.Web.Mvc
Imports SGTSchema

Namespace Controllers
    Public Class ArticlesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Articles
        Function Index() As ActionResult
            Return View(db.Articles.ToList())
        End Function

        ' GET: Articles/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim article As Article = db.Articles.Find(id)
            If IsNothing(article) Then
                Return HttpNotFound()
            End If
            Return View(article)
        End Function

        ' GET: Articles/Create
        Function Create() As ActionResult
            Return View()
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

        ' POST: Articles/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Niche,Title,Content,Spin")> ByVal article As Article) As ActionResult
            If ModelState.IsValid Then
                article.UserID = GetUserId()
                db.Articles.Add(article)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(article)
        End Function

        ' GET: Articles/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim article As Article = db.Articles.Find(id)
            If IsNothing(article) Then
                Return HttpNotFound()
            End If
            Return View(article)
        End Function

        ' POST: Articles/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Niche,Title,Content,Spin")> ByVal article As Article) As ActionResult
            If ModelState.IsValid Then
                db.Entry(article).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(article)
        End Function

        ' GET: Articles/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim article As Article = db.Articles.Find(id)
            If IsNothing(article) Then
                Return HttpNotFound()
            End If
            Return View(article)
        End Function

        ' POST: Articles/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim article As Article = db.Articles.Find(id)
            db.Articles.Remove(article)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
