Imports System.Data.Entity
Imports System.Net
Imports System.Security.Claims
Imports PagedList

Public Class CompanyController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDbContext

    ' GET: Companies
    Function Index() As ActionResult
        Return View(db.Companies.ToList())
    End Function

    ' POST: Company/Create
    'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost(), ActionName("Create")>
    <ValidateAntiForgeryToken()>
    Function Create(<Bind(Include:="Name,Country,Address,City,State,Latitude,Longitude")> ByVal company As CompanyModel) As ActionResult
        If ModelState.IsValid Then
            db.Companies.Add(company)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If
        Return View("Details", company)
    End Function

    ' GET: /Company/Details/5
    Function Details(ByVal id As Integer?) As ActionResult
        If IsNothing(id) Then
            Return View()
        End If
        Dim company As CompanyModel = db.Companies.Find(id)
        If IsNothing(company) Then
            Return HttpNotFound()
        End If
        Return View(company)
    End Function

    ' POST: Company/Edit/5
    'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost(), ActionName("Save")>
    <ValidateAntiForgeryToken()>
    Function Save(<Bind(Include:="ID,Name,Country,Address,City,State,Latitude,Longitude")> ByVal company As CompanyModel) As ActionResult
        If ModelState.IsValid Then
            db.Entry(company).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If
        Return View("Details", company)
    End Function

    ' GET: Company/Delete/5
    Function Delete(ByVal id As Integer?) As ActionResult
        If IsNothing(id) Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim company As CompanyModel = db.Companies.Find(id)
        If IsNothing(company) Then
            Return HttpNotFound()
        End If
        Return View(company)
    End Function

    ' POST: Company/Delete/5
    <HttpPost()>
    <ActionName("Delete")>
    <ValidateAntiForgeryToken()>
    Function DeleteConfirmed(ByVal id As Integer) As ActionResult
        Dim company As CompanyModel = db.Companies.Find(id)
        db.Companies.Remove(company)
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
