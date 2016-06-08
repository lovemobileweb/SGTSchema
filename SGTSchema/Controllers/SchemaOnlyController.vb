Imports System.Data.Entity
Imports System.IO
Imports System.Net
Imports System.Security.Claims
Imports PagedList
Imports System.Web
Imports System.Xml

Public Class SchemaOnlyController
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

        Dim schemas = From s In db.Schemas Select s
        If Not String.IsNullOrEmpty(searchString) Then
            schemas = schemas.Where(Function(s) s.cName.ToUpper().Contains(searchString.ToUpper()))
        End If
        Select Case sortOrder
            Case "name_desc"
                schemas = schemas.OrderByDescending(Function(s) s.cName)
            Case Else
                schemas = schemas.OrderBy(Function(s) s.cName)
        End Select

        Dim pageSize As Integer = 3
        Dim pageNumber As Integer = If(page, 1)
        Return View(schemas.ToPagedList(pageNumber, pageSize))
    End Function

    ' GET: /SchemaOnly/Details/5
    Function Details(ByVal id As Integer?) As ActionResult
        If User.Identity.IsAuthenticated = False Then
            Return RedirectToAction("Login", "Account")
        End If

        Dim userID = GetUserId()

        Dim query = From article In db.Articles
                    Group article By Niche = article.Niche Into g = Group
                    Select New With {
                        .Text = Niche,
                        .Value = Niche
                    }

        Dim ListItem As List(Of SelectListItem) = New List(Of SelectListItem)
        For Each niche In query
            ListItem.Add(New SelectListItem With {.Text = niche.Text, .Value = niche.Value})
        Next

        ViewBag.NicheList = New SelectList(ListItem, "Value", "Text", "")
        Dim ListItem2 As List(Of SelectListItem) = New List(Of SelectListItem)
        ViewBag.ArticleList = New SelectList(ListItem2, "Value", "Text", "")

        If IsNothing(id) Then
            Return View()
        End If

        Dim schema As SchemaOnlyModel = db.Schemas.Find(id)
        If IsNothing(schema) Then
            Return HttpNotFound()
        End If

        Dim query2 = From article In db.Articles
                     Where article.Niche = schema.cServiceCat And article.UserID = userID
                     Select New With {
                        .Text = article.Title,
                        .Value = article.ID
                    }

        For Each article In query2
            ListItem2.Add(New SelectListItem With {.Text = article.Text, .Value = article.Value})
        Next

        ViewBag.ArticleList = New SelectList(ListItem2, "Value", "Text", "")

        Return View(schema)
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

    ' POST: /SchemaOnly/Create
    'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    <HttpPost(), ActionName("Create")>
    <ValidateAntiForgeryToken()>
    Function Create(file As HttpPostedFileBase, <Bind(Include:="cbBusiness, cName, cDescription, cUrl, cAddress, cAddress2, cCity, cbCountry, cUSState, cAUState, cCAState, cUKState, cZip, MonFriCheckBox, MonFriOpen, MonFriClose, MonCheckBox, MonOpen, MonClose, TueCheckBox, TueOpen, TueClose, WedCheckBox, WedOpen, WedClose, ThuCheckBox, ThuOpen, ThuClose, FriCheckBox, FriOpen, FriClose, cFB, cGPlus, cTwitter, cLinkedIn, cYT, cPinterest, cServiceCat, cService1, cService2, cService3, cService4, cService5, cService6, cService7, cService8, cService9, cService10, cCity1,cCity2,cCity3,cCity4,cCity5,cCity6,cCity7,cCity8,cCity9,cCity10")> ByVal schema As SchemaOnlyModel) As ActionResult
        If User.Identity.IsAuthenticated = False Then
            Return RedirectToAction("Login", "Account")
        End If
        Dim subpath As String = GetNewDirectory()
        Dim imagename As String = ""
        Dim imagemodelname As String = ""
        Try
            If ModelState.IsValid Then
                schema.UserID = GetUserId()
                db.Schemas.Add(schema)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
        Catch dex As DataException
            'Log the error (add a line here to write a log)
            ModelState.AddModelError("", "Unable to save changes. Try again, And of the problem persists see your system administrator. ")
        End Try
        'DeleteFolder(System.IO.Path.Combine(Server.MapPath("~/App_Data/Images/"), subpath))
        Return View("Details", schema)
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
        Dim schemaToUpdate = db.Schemas.Find(id)
        If TryUpdateModel(schemaToUpdate, "", New String() {"cbBusiness", "cName", "cDescription", "cUrl", "cAddress", "cAddress2", "cCity", "cbCountry", "cUSState", "cAUState", "cCAState", "cUKState", "cZip", "MonFriCheckBox", "MonFriOpen", "MonFriClose", "MonCheckBox", "MonOpen", "MonClose", "TueCheckBox", "TueOpen", "TueClose", "WedCheckBox", "WedOpen", "WedClose", "ThuCheckBox", "ThuOpen", "ThuClose", "FriCheckBox", "FriOpen", "FriClose", "cFB", "cGPlus", "cTwitter", "cLinkedIn", "cYT", "cPinterest",
                          "cServiceCat", "cService1", "cService2", "cService3", "cService4", "cService5", "cService6", "cService7", "cService8", "cService9", "cService10", "cCity1", "cCity2", "cCity3", "cCity4", "cCity5", "cCity6", "cCity7", "cCity8", "cCity9", "cCity10"}) Then
            Try
                db.Entry(schemaToUpdate).State = EntityState.Modified
                db.SaveChanges()
                Return View("Download", SaveToText(schemaToUpdate))
            Catch Dex As DataException
                'Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, And If the problem persists see your system administrator.")
            End Try
        End If
        Return View("Details", schemaToUpdate)
    End Function

    Function SaveToText(ByVal data As SchemaOnlyModel) As SchemaOnlyDownloadModel
        Dim strfilename As String = System.IO.Path.GetTempFileName
        Dim q As String = """"
        Dim j1 As String
        Dim b As Boolean
        Dim lj As String
        Dim BusType As String
        BusType = data.cbBusiness.ToString
        j1 = "<script type=" + q + "application/ld+json" + q + ">" + "{" + q + "@context" + q + ":" + q + "http://www.schema.org" + q
        lj = BusType
        lj = lj.Replace(" ", "")
        If Len(lj) <> 0 Then
            j1 = j1 + "," + q + "@type" + q + ":" + q + lj + q
        End If
        j1 = j1 + "," + q + "@id" + q + ": " + q + data.cUrl + q
        lj = data.cName
        If Len(lj) <> 0 Then
            j1 = j1 + "," + q + "name" + q + ":" + q + lj + q
        End If
        lj = data.cUrl
        If Len(lj) <> 0 Then
            j1 = j1 + "," + q + "url" + q + ":" + q + lj + q
        End If
        lj = data.cDescription
        If Len(lj) <> 0 Then
            j1 = j1 + "," + q + "description" + q + ":" + q + lj + q
        End If
        If Len(data.cAddress + data.cCity) <> 0 Then
            j1 = j1 + "," + q + "address" + q + ":{" + q + "@type" + q + ":" + q + "PostalAddress" + q
            lj = data.cAddress
            If Len(lj) <> 0 Then
                j1 = j1 + "," + q + "streetAddress" + q + ":" + q + lj + q
            End If
            lj = data.cCity
            If Len(lj) <> 0 Then
                j1 = j1 + "," + q + "addressLocality" + q + ":" + q + lj + q
            End If
            If Len(data.cUSState) > 0 Then
                lj = data.cUSState
            Else
                If Len(data.cAUState) > 0 Then
                    lj = data.cAUState
                Else
                    If Len(data.cCAState) > 0 Then
                        lj = data.cCAState
                    Else
                        If Len(data.cUKState) > 0 Then
                            lj = data.cUKState
                        Else
                            lj = ""
                        End If
                    End If
                End If
            End If
            If Len(lj) <> 0 Then
                j1 = j1 + "," + q + "addressRegion" + q + ":" + q + lj + q
            End If
            lj = data.cZip
            If Len(lj) <> 0 Then
                j1 = j1 + "," + q + "postalCode" + q + ":" + q + lj + q
            End If
            lj = data.cbCountry
            If Len(lj) > 0 Then
                j1 = j1 + "," + q + "addressCountry" + q + ":" + q + data.cbCountry + q
            End If
            j1 = j1 + "}"

            Dim webClient As New System.Net.WebClient
            Dim inString As String = ""
            If data.cbCountry <> "UK" Then
                inString = data.cAddress + " " + data.cCity + " " + data.cUSState.ToString
            Else
                inString = data.cAddress + " " + data.cAddress2 + " " + data.cCity + " " + data.cUKState.ToString + " " + data.cbCountry
            End If
            'inString = cAddress.Text + " " + cCity.Text + " " + cState.Text
            Dim lat As String = "0"
            Dim lng As String = "0"
            Dim tmap As String
            Dim result As String = webClient.DownloadString("http://maps.googleapis.com/maps/api/geocode/xml?address=" & inString & ",&sensor=true")
            Dim xmldoc As XmlDocument = New XmlDocument()
            xmldoc.LoadXml(result)
            lat = xmldoc.SelectSingleNode("//GeocodeResponse/result/geometry/location/lat").InnerText
            lng = xmldoc.SelectSingleNode("//GeocodeResponse/result/geometry/location/lng").InnerText

            If Len(lat) > 0 And Len(lng) > 0 Then
                j1 = j1 + "," + q + "geo" + q + ":{" + q + "@type" + q + ":" + q + "GeoCoordinates" + q + ","
                j1 = j1 + q + "latitude" + q + ":" + q + lat + q + ","
                j1 = j1 + q + "longitude" + q + ":" + q + lng + q
                j1 = j1 + "}"

                ' hasmap
                tmap = lat + "," + lng
                j1 = j1 + "," + q + "hasMap" + q + ": {"
                j1 = j1 + q + "@type" + q + ": " + q + "Map" + q
                j1 = j1 + "," + q + "url" + q + ":" + q + "https://maps.google.com/maps?q=" + tmap + q
                j1 = j1 + "}"
            End If
        End If
        'lj = data.cPhone
        'If Len(lj) > 0 Then
        '    j1 = j1 + "," + q + "telephone" + q + ":" + q + lj + q
        'End If
        If data.MonCheckBox Or data.TueCheckBox Or data.WedCheckBox Or data.ThuCheckBox Or data.FriCheckBox Or data.SatCheckBox Or data.SunCheckBox Then
            b = False
            j1 = j1 + "," + q + "openingHours" + q + ":"
            If data.MonCheckBox Then
                j1 = j1 + q + "Mo " + data.MonOpen + "-" + data.MonClose
                b = True
            End If
            If data.TueCheckBox Then
                If b Then
                    j1 = j1 + " Tu " + data.TueOpen + "-" + data.TueClose
                Else
                    j1 = j1 + q + "Tu " + data.TueOpen + "-" + data.TueClose
                    b = True
                End If
            End If
            If data.WedCheckBox Then
                If b Then
                    j1 = j1 + " We " + data.WedOpen + "-" + data.WedClose
                Else
                    j1 = j1 + q + "We " + data.WedOpen + "-" + data.WedClose
                    b = True
                End If
            End If
            If data.ThuCheckBox Then
                If b Then
                    j1 = j1 + " Th " + data.ThuOpen + "-" + data.ThuClose
                Else
                    j1 = j1 + q + "Th " + data.ThuOpen + "-" + data.ThuClose
                    b = True
                End If
            End If
            If data.FriCheckBox Then
                If b Then
                    j1 = j1 + " Fr " + data.FriOpen + "-" + data.FriClose
                Else
                    j1 = j1 + q + "Fr " + data.FriOpen + "-" + data.FriClose
                    b = True
                End If
            End If
            If data.SatCheckBox Then
                If b Then
                    j1 = j1 + " Sa " + data.SatOpen + "-" + data.SatClose
                Else
                    j1 = j1 + q + "Sa " + data.SatOpen + "-" + data.SatClose
                    b = True
                End If
            End If
            If data.SunCheckBox Then
                If b Then
                    j1 = j1 + " Su " + data.SunOpen + "-" + data.SunClose
                Else
                    j1 = j1 + q + "Su " + data.SunOpen + "-" + data.SunClose
                End If
            End If
            j1 = j1 + q
        End If

        b = False
        Dim vcity As String = data.cCity1 + data.cCity2 + data.cCity3 + data.cCity4 + data.cCity5 + data.cCity6 + data.cCity7 + data.cCity8 + data.cCity9 + data.cCity10
        If Len(vcity) > 0 Then
            If Len(data.cCity1) > 0 Then
                j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                j1 = j1 + q + "name" + q + ": ["
                j1 = j1 + q + data.cCity1 + q
                b = True
            End If
            If Len(data.cCity2) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity2 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity2 + q
                    b = True
                End If
            End If
            If Len(data.cCity3) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity3 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity3 + q
                    b = True
                End If

            End If
            If Len(data.cCity4) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity4 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity4 + q
                    b = True
                End If
            End If

            If Len(data.cCity5) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity5 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity5 + q
                    b = True
                End If
            End If
            If Len(data.cCity6) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity6 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity6 + q
                    b = True
                End If
            End If
            If Len(data.cCity7) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity7 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity7 + q
                    b = True
                End If
            End If
            If Len(data.cCity8) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity8 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity8 + q
                    b = True
                End If
            End If
            If Len(data.cCity9) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity9 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity9 + q
                    b = True
                End If
            End If
            If Len(data.cCity10) > 0 Then
                If b Then
                    j1 = j1 + "," + q + data.cCity10 + q
                Else
                    j1 = j1 + "," + q + "areaServed" + q + ":{" + q + "@type" + q + ":" + q + "City" + q + ","
                    j1 = j1 + q + "name" + q + ": ["
                    j1 = j1 + q + data.cCity10 + q
                    b = True
                End If
            End If
            j1 = j1 + "]}"
        End If
        b = False
        If Len(data.cFB) > 0 Or Len(data.cGPlus) > 0 Or Len(data.cTwitter) > 0 Or Len(data.cLinkedIn) > 0 Or Len(data.cYT) > 0 Or Len(data.cPinterest) > 0 Then
            j1 = j1 + "," + q + "sameAs" + q + ": ["
            If Len(data.cFB) > 0 Then
                j1 = j1 + q + data.cFB + q
                b = True
            End If
            If Len(data.cGPlus) > 0 Then
                If b Then
                    j1 = j1 + ","
                End If
                j1 = j1 + q + data.cGPlus + q
                b = True
            End If
            If Len(data.cTwitter) > 0 Then
                If b Then
                    j1 = j1 + ","
                End If
                j1 = j1 + q + data.cTwitter + q
                b = True
            End If
            If Len(data.cLinkedIn) > 0 Then
                If b Then
                    j1 = j1 + ","
                End If
                j1 = j1 + q + data.cLinkedIn + q
                b = True
            End If
            If Len(data.cYT) > 0 Then
                If b Then
                    j1 = j1 + ","
                End If
                j1 = j1 + q + data.cYT + q
                b = True
            End If
            If Len(data.cPinterest) > 0 Then
                If b Then
                    j1 = j1 + ","
                End If
                j1 = j1 + q + data.cPinterest + q
                b = True
            End If
            j1 = j1 + "]"
        End If

        j1 = j1 + "}</script>"
        Dim j2 As String
        If Len(data.cServiceCat) > 0 And Len(data.cService1) > 0 Then
            j2 = "<script type=" + q + "application/ld+json" + q + ">" + "{" + q + "@context" + q + ":" + q + "http://www.schema.org" + q
            j2 = j2 + "," + q + "@type" + q + ":" + q + "Service" + q + ","
            j2 = j2 + q + "serviceType" + q + ":" + q + data.cServiceCat + q + ","
            j2 = j2 + q + "provider" + q + ": {"
            j2 = j2 + q + "@type" + q + ":" + q + "LocalBusiness" + q + ","
            j2 = j2 + q + "name" + q + ":" + q + data.cName + q + "},"
            Dim tservice As String
            tservice = q + "hasOfferCatalog" + q + ": {"
            tservice = tservice + q + "@type" + q + ": " + q + "offerCatalog" + q + ","
            tservice = tservice + q + "name" + q + ": " + q + data.cServiceCat + q + ","
            tservice = tservice + q + "itemListElement" + q + ": ["

            tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
            tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
            tservice = tservice + q + "name" + q + ": " + q + data.cService1 + q + "}}"

            If Len(data.cService2) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService2 + q + "}}"
            End If
            If Len(data.cService3) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService3 + q + "}}"
            End If
            If Len(data.cService4) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService4 + q + "}}"
            End If
            If Len(data.cService5) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService5 + q + "}}"
            End If
            If Len(data.cService6) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService6 + q + "}}"
            End If
            If Len(data.cService7) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService7 + q + "}}"
            End If
            If Len(data.cService8) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService8 + q + "}}"
            End If
            If Len(data.cService9) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService9 + q + "}}"
            End If
            If Len(data.cService10) > 0 Then
                tservice = tservice + ","
                tservice = tservice + "{" + q + "@type" + q + ": " + q + "Offer" + q + "," + q + "itemOffered" + q + ": {"
                tservice = tservice + q + "@type" + q + ": " + q + "Service" + q + ","
                tservice = tservice + q + "name" + q + ": " + q + data.cService10 + q + "}}"
            End If
            tservice = tservice + "]}"
            j2 = j2 + tservice
            j2 = j2 + "}</script>"
        End If
        IO.File.WriteAllText(strfilename, j1 + j2)
        Dim model As SchemaOnlyDownloadModel = New SchemaOnlyDownloadModel()
        model.FileUrl = strfilename
        Return model
    End Function

    <HttpPost()>
    Function Download(ByVal model As SchemaOnlyDownloadModel) As ActionResult
        If User.Identity.IsAuthenticated = False Then
            Return RedirectToAction("Login", "Account")
        End If
        Return File(model.FileUrl, System.Net.Mime.MediaTypeNames.Application.Octet, "SchemaOnly.txt")
    End Function
End Class
