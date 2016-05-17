Imports System.Data.Entity
Imports System.Net
Imports System.Security.Claims
Imports PagedList

Public Class SGTSchemaController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDbContext

    Function Index(ByVal sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
        If User.Identity.IsAuthenticated = False Then
            Return RedirectToAction("Login", "Account")
        End If
        ViewBag.CurrentSort = sortOrder
        ViewBag.NameSortParm = If(String.IsNullOrEmpty(sortOrder), "name_desc", String.Empty)
        ViewBag.DateSortParm = If(sortOrder = "Date", "date_desc", "Date")

        If Not searchString Is Nothing Then
            page = 1
        Else
            searchString = currentFilter
        End If

        ViewBag.CurrentFilter = searchString

        Dim sgtschemas = From s In db.SGTSchemas Select s
        If Not String.IsNullOrEmpty(searchString) Then
            sgtschemas = sgtschemas.Where(Function(s) s.cName.ToUpper().Contains(searchString.ToUpper()))
        End If
        Select Case sortOrder
            Case "name_desc"
                sgtschemas = sgtschemas.OrderByDescending(Function(s) s.cName)
            Case Else
                sgtschemas = sgtschemas.OrderBy(Function(s) s.cName)
        End Select

        Dim pageSize As Integer = 3
        Dim pageNumber As Integer = If(page, 1)
        Return View(sgtschemas.ToPagedList(pageNumber, pageSize))
    End Function

    ' GET: /SGTSchema/Details/5
    Function Details(ByVal id As Integer?) As ActionResult
        If User.Identity.IsAuthenticated = False Then
            Return RedirectToAction("Login", "Account")
        End If
        If IsNothing(id) Then
            Return View()
        End If
        Dim sgtschema As SGTSchemaModel = db.SGTSchemas.Find(id)
        If IsNothing(sgtschema) Then
            Return HttpNotFound()
        End If
        Return View(sgtschema)
    End Function

    Private Function FileExists(ByVal FileFullPath As String) _
      As Boolean

        Dim f As New IO.FileInfo(FileFullPath)
        Return f.Exists

    End Function

    Private Function FolderExists(ByVal FolderPath As String) _
       As Boolean

        Dim f As New IO.DirectoryInfo(FolderPath)
        Return f.Exists

    End Function

    Private Sub DeleteFolder(ByVal FolderPath As String)

        Dim f As New IO.DirectoryInfo(FolderPath)
        f.Delete(True)

    End Sub

    Private Function GetNewDirectory() _
        As String

        Dim randomGenerator = New Random(Integer.Parse((DateTime.Now.Ticks And Integer.MaxValue).ToString()))
        Dim flag As Boolean = True
        Dim path As String = "0"
        Dim fullPath As String = ""

        While flag
            path = randomGenerator.Next().ToString()
            fullPath = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), path)
            flag = FileExists(fullPath) Or FolderExists(fullPath)
        End While

        Dim f As New IO.DirectoryInfo(fullPath)
        f.Create()

        Return path

    End Function

    Private Function GetUserId() _
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

    ' POST: /Student/Save
    'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost(), ActionName("Create")>
    <ValidateAntiForgeryToken()>
    Function Create(file As HttpPostedFileBase, <Bind(Include:="cbBusiness, cName, cDescription, cUrl, cHomeContent, cAddress, cAddress2, cCity, cbCountry, cUSState, cAUState, cCAState, cUKState, cZip, MonFriCheckBox, MonFriOpen, MonFriClose, MonCheckBox, MonOpen, MonClose, TueCheckBox, TueOpen, TueClose, WedCheckBox, WedOpen, WedClose, ThuCheckBox, ThuOpen, ThuClose, FriCheckBox, FriOpen, FriClose, cCity1, cCity2, cCity3, cCity4, cCity5, cCity6, cCity7, cCity8, cCity9, cFB, cGPlus, cTwitter, cLinkedIn, cYT, cPinterest, cYouTube, cImage, SchemaCheckBox, PagesCheckBox, SpunCheckBox, cServiceCat, cService1, sCat1, sPic1, sVid1, cService2, sCat2, sPic2, sVid2, cService3, sCat3, sPic3, sVid3, cService4, sCat4, sPic4, sVid4, cService5, sCat5, sPic5, sVid5, cService6, sCat6, sPic6, sVid6, cService7, sCat7, sPic7, sVid7, cService8, sCat8, sPic8, sVid8, cService9, sCat9, sPic9, sVid9, cService10, sCat10, sPic10, sVid10, cLinkName1, cLinkURL1, cLinkName2, cLinkURL2, cLinkName3, cLinkURL3")> ByVal sgtschema As SGTSchemaModel) As ActionResult
        If User.Identity.IsAuthenticated = False Then
            Return RedirectToAction("Login", "Account")
        End If
        Dim subpath As String = GetNewDirectory()
        Dim imagename As String = ""
        Dim imagemodelname As String = ""
        Try
            If (Request.Files.Count > 0) Then
                imagename = "file_getimage"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("cImage")
                    ModelState.Add("cImage", New ModelState())
                    ModelState.SetModelValue("cImage", New ValueProviderResult(sgtschema.cImage, sgtschema.cImage, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic1"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.sPic1 = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic1")
                    ModelState.Add("sPic1", New ModelState())
                    ModelState.SetModelValue("sPic1", New ValueProviderResult(sgtschema.sPic1, sgtschema.sPic1, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic2"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic2")
                    ModelState.Add("sPic2", New ModelState())
                    ModelState.SetModelValue("sPic2", New ValueProviderResult(sgtschema.sPic2, sgtschema.sPic2, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic3"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic3")
                    ModelState.Add("sPic3", New ModelState())
                    ModelState.SetModelValue("sPic3", New ValueProviderResult(sgtschema.sPic3, sgtschema.sPic3, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic4"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic4")
                    ModelState.Add("sPic4", New ModelState())
                    ModelState.SetModelValue("sPic4", New ValueProviderResult(sgtschema.sPic4, sgtschema.sPic4, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic5"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic5")
                    ModelState.Add("sPic5", New ModelState())
                    ModelState.SetModelValue("sPic5", New ValueProviderResult(sgtschema.sPic5, sgtschema.sPic5, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic6"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic6")
                    ModelState.Add("sPic6", New ModelState())
                    ModelState.SetModelValue("sPic6", New ValueProviderResult(sgtschema.sPic6, sgtschema.sPic6, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic7"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic7")
                    ModelState.Add("sPic7", New ModelState())
                    ModelState.SetModelValue("sPic7", New ValueProviderResult(sgtschema.sPic7, sgtschema.sPic7, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic8"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic8")
                    ModelState.Add("sPic8", New ModelState())
                    ModelState.SetModelValue("sPic8", New ValueProviderResult(sgtschema.sPic8, sgtschema.sPic8, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic9"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic9")
                    ModelState.Add("sPic9", New ModelState())
                    ModelState.SetModelValue("sPic9", New ValueProviderResult(sgtschema.sPic9, sgtschema.sPic9, Nothing))
                    file.SaveAs(path)
                End If
                imagename = "file_pic10"
                file = Request.Files.Get(imagename)
                If (file IsNot Nothing And file.ContentLength > 0) Then
                    Dim fileName = System.IO.Path.GetFileName(file.FileName)
                    Dim path = System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath + "/" + imagename)
                    sgtschema.cImage = "~/App_Data/Images/" + subpath + "/" + imagename
                    ModelState.Remove("sPic10")
                    ModelState.Add("sPic10", New ModelState())
                    ModelState.SetModelValue("sPic10", New ValueProviderResult(sgtschema.sPic10, sgtschema.sPic10, Nothing))
                    file.SaveAs(path)
                End If
            End If
            If ModelState.IsValid Then
                sgtschema.UserID = GetUserId()
                db.SGTSchemas.Add(sgtschema)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
        Catch dex As DataException
            'Log the error (add a line here to write a log)
            ModelState.AddModelError("", "Unable to save changes. Try again, And of the problem persists see your system administrator. ")
        End Try
        'DeleteFolder(System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath))
        Return View("Details", sgtschema)
    End Function

    <HttpPost(), ActionName("Save")>
    <ValidateAntiForgeryToken()>
    Function SavePost(ByVal id? As Integer) As ActionResult
        If User.Identity.IsAuthenticated = False Then
            Return RedirectToAction("Login", "Account")
        End If
        If id Is Nothing Then
            Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        End If
        Dim sgtschemaToUpdate = db.SGTSchemas.Find(id)
        If TryUpdateModel(sgtschemaToUpdate, "", New String() {"cbBusiness", "cName", "cDescription", "cUrl", "cHomeContent", "cAddress", "cAddress2", "cCity", "cbCountry", "cUSState", "cAUState", "cCAState", "cUKState", "cZip", "MonFriCheckBox", "MonFriOpen", "MonFriClose", "MonCheckBox", "MonOpen", "MonClose", "TueCheckBox", "TueOpen", "TueClose", "WedCheckBox", "WedOpen", "WedClose", "ThuCheckBox", "ThuOpen", "ThuClose", "FriCheckBox", "FriOpen", "FriClose", "cCity1", "cCity2", "cCity3", "cCity4", "cCity5", "cCity6", "cCity7", "cCity8", "cCity9", "cFB", "cGPlus", "cTwitter", "cLinkedIn", "cYT", "cPinterest", "cYouTube", "cImage", "SchemaCheckBox", "PagesCheckBox", "SpunCheckBox", "cServiceCat", "cService1", "sCat1", "sPic1", "sVid1", "cService2", "sCat2", "sPic2", "sVid2", "cService3", "sCat3", "sPic3", "sVid3", "cService4", "sCat4", "sPic4", "sVid4", "cService5", "sCat5", "sPic5", "sVid5", "cService6", "sCat6", "sPic6", "sVid6", "cService7", "sCat7", "sPic7", "sVid7", "cService8", "sCat8", "sPic8", "sVid8", "cService9", "sCat9", "sPic9", "sVid9", "cService10", "sCat10", "sPic10", "sVid10",
                          "cLinkName1", "cLinkURL1", "cLinkName2", "cLinkURL2", "cLinkName3", "cLinkURL3"}) Then
            Try
                db.Entry(sgtschemaToUpdate).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            Catch Dex As DataException
                'Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, And If the problem persists see your system administrator.")
            End Try
        End If
        Return View(sgtschemaToUpdate)
    End Function

End Class
