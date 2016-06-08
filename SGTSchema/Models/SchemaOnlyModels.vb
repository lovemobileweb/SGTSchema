Imports System.ComponentModel.DataAnnotations

Public Class SchemaOnlyModel
    <Key>
    Public Property ID As Integer

    <Display(Name:="User ID")>
    Public Property UserID As String

    <Required>
    <Display(Name:="Local Business Type")>
    Public Property cbBusiness As LocalBusinessType

    <Required>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Name")>
    Public Property cName As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Description")>
    Public Property cDescription As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <Url>
    <Display(Name:="Url")>
    Public Property cUrl As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Address")>
    Public Property cAddress As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Address2")>
    Public Property cAddress2 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City")>
    Public Property cCity As String

    <Display(Name:="Country")>
    Public Property cbCountry As String

    <Display(Name:="State")>
    Public Property cUSState As Nullable(Of USState)

    <Display(Name:="State")>
    Public Property cAUState As Nullable(Of AUState)

    <Display(Name:="Prov")>
    Public Property cCAState As Nullable(Of CAState)

    <Display(Name:="County")>
    Public Property cUKState As Nullable(Of UKState)

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.PostalCode)>
    <Display(Name:="Zip")>
    Public Property cZip As String

    <Display(Name:="MonFri Check")>
    Public Property MonFriCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="MonFriOpen")>
    <OpenCloseTimeAttribute("MonFriCheckBox", "MonFriClose", Comparison.IsEqualOrSmaller, ErrorMessage:="The {0} must be equal or smaller than MonFriClose")>
    Public Property MonFriOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="MonFriClose")>
    <OpenCloseTimeAttribute("MonFriCheckBox", "MonFriOpen", Comparison.IsEqualOrGreater, ErrorMessage:="The {0} must be equal or greater than MonFriOpen")>
    Public Property MonFriClose As String

    <Display(Name:="Monday Check")>
    Public Property MonCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="MonOpen")>
    <OpenCloseTimeAttribute("MonCheckBox", "MonClose", Comparison.IsEqualOrSmaller, ErrorMessage:="The {0} must be equal or smaller than MonClose")>
    Public Property MonOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="MonClose")>
    <OpenCloseTimeAttribute("MonCheckBox", "MonOpen", Comparison.IsEqualOrGreater, ErrorMessage:="The {0} must be equal or greater than MonOpen")>
    Public Property MonClose As String

    <Display(Name:="Tuesday Check")>
    Public Property TueCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="TueOpen")>
    <OpenCloseTimeAttribute("TueCheckBox", "TueClose", Comparison.IsEqualOrSmaller, ErrorMessage:="The {0} must be equal or smaller than TueClose")>
    Public Property TueOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="TueClose")>
    <OpenCloseTimeAttribute("TueCheckBox", "TueOpen", Comparison.IsEqualOrGreater, ErrorMessage:="The {0} must be equal or greater than TueOpen")>
    Public Property TueClose As String

    <Display(Name:="Wednesday Check")>
    Public Property WedCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="WedOpen")>
    <OpenCloseTimeAttribute("WedCheckBox", "WedClose", Comparison.IsEqualOrSmaller, ErrorMessage:="The {0} must be equal or smaller than WedClose")>
    Public Property WedOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="WedClose")>
    <OpenCloseTimeAttribute("WedCheckBox", "WedOpen", Comparison.IsEqualOrGreater, ErrorMessage:="The {0} must be equal or greater than WedOpen")>
    Public Property WedClose As String

    <Display(Name:="Thursday Check")>
    Public Property ThuCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="ThuOpen")>
    <OpenCloseTimeAttribute("ThuCheckBox", "ThuClose", Comparison.IsEqualOrSmaller, ErrorMessage:="The {0} must be equal or smaller than ThuClose")>
    Public Property ThuOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="ThuClose")>
    <OpenCloseTimeAttribute("ThuCheckBox", "ThuOpen", Comparison.IsEqualOrGreater, ErrorMessage:="The {0} must be equal or greater than ThuOpen")>
    Public Property ThuClose As String

    <Display(Name:="Friday Check")>
    Public Property FriCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="FriOpen")>
    <OpenCloseTimeAttribute("FriCheckBox", "FriClose", Comparison.IsEqualOrSmaller, ErrorMessage:="The {0} must be equal or smaller than FriClose")>
    Public Property FriOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="FriClose")>
    <OpenCloseTimeAttribute("FriCheckBox", "FriOpen", Comparison.IsEqualOrGreater, ErrorMessage:="The {0} must be equal or greater than FriOpen")>
    Public Property FriClose As String

    <Display(Name:="Saturday Check")>
    Public Property SatCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="SatOpen")>
    <OpenCloseTimeAttribute("SatCheckBox", "SatClose", Comparison.IsEqualOrSmaller, ErrorMessage:="The {0} must be equal or smaller than SatClose")>
    Public Property SatOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="SatClose")>
    <OpenCloseTimeAttribute("SatCheckBox", "SatOpen", Comparison.IsEqualOrGreater, ErrorMessage:="The {0} must be equal or greater than SatOpen")>
    Public Property SatClose As String

    <Display(Name:="Sunday Check")>
    Public Property SunCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="SunOpen")>
    <OpenCloseTimeAttribute("SunCheckBox", "SunClose", Comparison.IsEqualOrSmaller, ErrorMessage:="The {0} must be equal or smaller than SunClose")>
    Public Property SunOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="SunClose")>
    <OpenCloseTimeAttribute("SunCheckBox", "SunOpen", Comparison.IsEqualOrGreater, ErrorMessage:="The {0} must be equal or greater than SunOpen")>
    Public Property SunClose As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <Url>
    <Display(Name:="Facebook")>
    Public Property cFB As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <Url>
    <Display(Name:="Google+")>
    Public Property cGPlus As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <Url>
    <Display(Name:="Twitter")>
    Public Property cTwitter As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <Url>
    <Display(Name:="LinkedIn")>
    Public Property cLinkedIn As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <Url>
    <Display(Name:="Youtube")>
    Public Property cYT As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <Url>
    <Display(Name:="Pinterest")>
    Public Property cPinterest As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters Long.", MinimumLength:=1)>
    <DataType(DataType.Text)>
    <Display(Name:="Service Category (e.g. Landscape Services, Auto Repair Services, Attorney)")>
    Public Property cServiceCat As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 1")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService1 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 2")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService2 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 3")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService3 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 4")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService4 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 5")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService5 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 6")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService6 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 7")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService7 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 8")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService8 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 9")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService9 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 10")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cService10 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 1")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity1 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 2")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity2 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 3")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity3 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 4")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity4 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 5")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity5 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 6")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity6 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 7")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity7 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 8")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity8 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 9")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity9 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 10")>
    <RegularExpression("^([a-zA-Z0-9/ &]+)$", ErrorMessage:="The {0} should only be Aa - Zz, 0 - 9, &, space and dash")>
    Public Property cCity10 As String
End Class

Public Class SchemaOnlyDownloadModel
    Public Property FileUrl As String
End Class