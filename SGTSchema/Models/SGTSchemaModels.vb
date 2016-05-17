Imports System.ComponentModel.DataAnnotations

Public Enum LocalBusinessType
    AccountingService
    Attorney
    AutoBodyShop
    AutoDealer
    AutoPartsStore
    AutoRental
    AutoRepair
    AutoWash
    Bakery
    BarOrPub
    BeautySalon
    BedAndBreakfast
    BikeStore
    BookStore
    CafeOrCoffeeShop
    ChildCare
    ClothingStore
    ComputerStore
    DaySpa
    Dentist
    DryCleaningOrLaundry
    Electrician
    ElectronicsStore
    EmergencyService
    EntertainmentBusiness
    EventVenue
    ExerciseGym
    FinancialService
    Florist
    FoodEstablishment
    FurnitureStore
    GardenStore
    GeneralContractor
    GolfCourse
    HairSalon
    HardwareStore
    HealthAndBeautyBusiness
    HobbyShop
    HomeAndConstructionBusiness
    HomeGoodsStore
    Hospital
    Hotel
    HousePainter
    HVACBusiness
    InsuranceAgency
    JewelryStore
    LiquorStore
    Locksmith
    LodgingBusiness
    MedicalClinic
    MensClothingStore
    MobilePhoneStore
    Motel
    MotorcycleDealer
    MotorcycleRepair
    MovingCompany
    MusicStore
    NailSalon
    NightClub
    Notary
    OfficeEquipmentStore
    Optician
    PetStore
    Physician
    Plumber
    ProfessionalService
    RealEstateAgent
    Residence
    Restaurant
    RoofingContractor
    RVPark
    School
    SelfStorage
    ShoeStore
    SkiResort
    SportingGoodsStore
    SportsClub
    Store
    TattooParlor
    Taxi
    TennisComplex
    TireShop
    ToyStore
    TravelAgency
    VeterinaryCare
    WholesaleStore
    Winery
End Enum

Public Enum Country
    US
    AU
    CA
    UK
End Enum

Public Enum USState
    AL
    AK
    AZ
    AR
    CA
    CO
    CT
    DE
    FL
    GA
    HI
    ID
    IL
    [IN]
    IA
    KS
    KY
    LA
    [ME]
    MD
    MA
    MI
    MN
    MS
    MO
    MT
    NE
    NV
    NH
    NJ
    NM
    NY
    NC
    ND
    OH
    OK
    [OR]
    PA
    RI
    SC
    SD
    TN
    TX
    UT
    VT
    VA
    WA
    WV
    WI
    WY
End Enum

Public Enum AUState
    ACT
    NSW
    NT
    QLD
    SA
    TAS
    VIC
    WA
End Enum

Public Enum CAState
    AB
    BC
    MB
    NB
    NL
    NS
    NT
    NU
    [ON]
    PE
    QC
    SK
    YT
End Enum

Public Enum UKState
    ABD
    AGY
    ALD
    ANS
    ANT
    ARL
    ARM
    AVN
    AYR
    BAN
    BDF
    BEW
    BKM
    BOR
    BRE
    BRK
    BUT
    CAE
    CAI
    CAM
    CAR
    CAV
    CEN
    CGN
    CHS
    CLA
    CLK
    CLV
    CMA
    CMN
    CON
    COR
    CUL
    CWD
    DBY
    DEN
    DEV
    DFD
    DFS
    DGY
    DNB
    DON
    DOR
    DOW
    DUB
    DUR
    ELN
    ERY
    ESS
    FER
    FIF
    FLN
    GAL
    GLA
    GLS
    GMP
    GNT
    GSY
    GTM
    GWN
    HAM
    HEF
    HLD
    HRT
    HUM
    HUN
    HWR
    INV
    IOW
    JSY
    KCD
    KEN
    KER
    KID
    KIK
    KKD
    KRS
    LAN
    LDY
    LEI
    [LET]
    LEX
    LIM
    LIN
    LKS
    LOG
    LOU
    LTN
    MAY
    MEA
    MER
    MGM
    MGY
    MLN
    MOG
    MON
    MOR
    MSY
    NAI
    NBL
    NFK
    NRY
    NTH
    NTT
    NYK
    OFF
    OKI
    OXF
    PEE
    PEM
    PER
    POW
    RAD
    RFW
    ROC
    ROS
    ROX
    RUT
    SAL
    SEL
    SFK
    SGM
    SHI
    SLI
    SOM
    SRK
    SRY
    SSX
    STD
    STI
    STS
    SUT
    SXE
    SXW
    SYK
    TAY
    TIP
    TWR
    TYR
    WAR
    WAT
    WEM
    WES
    WEX
    WGM
    WIC
    WIG
    WIL
    WIS
    WLN
    WMD
    WOR
    WRY
    WYK
    YKS
End Enum

Public Class SGTSchemaModel
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

    <DataType(DataType.MultilineText)>
    <Display(Name:="Home Page Content")>
    Public Property cHomeContent As String

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
    Public Property cbCountry As Nullable(Of Country)

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
    Public Property MonFriOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="MonFriClose")>
    Public Property MonFriClose As String

    <Display(Name:="Monday Check")>
    Public Property MonCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="MonOpen")>
    Public Property MonOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="MonClose")>
    Public Property MonClose As String

    <Display(Name:="Tuesday Check")>
    Public Property TueCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="TueOpen")>
    Public Property TueOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="TueClose")>
    Public Property TueClose As String

    <Display(Name:="Wednesday Check")>
    Public Property WedCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="WedOpen")>
    Public Property WedOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="WedClose")>
    Public Property WedClose As String

    <Display(Name:="Thursday Check")>
    Public Property ThuCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="ThuOpen")>
    Public Property ThuOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="ThuClose")>
    Public Property ThuClose As String

    <Display(Name:="Friday Check")>
    Public Property FriCheckBox As Boolean

    <DataType(DataType.Text)>
    <Display(Name:="FriOpen")>
    Public Property FriOpen As String

    <DataType(DataType.Text)>
    <Display(Name:="FriClose")>
    Public Property FriClose As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 1")>
    Public Property cCity1 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 2")>
    Public Property cCity2 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 3")>
    Public Property cCity3 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 4")>
    Public Property cCity4 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 5")>
    Public Property cCity5 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 6")>
    Public Property cCity6 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 7")>
    Public Property cCity7 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 8")>
    Public Property cCity8 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="City 9")>
    Public Property cCity9 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Facebook")>
    Public Property cFB As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Google+")>
    Public Property cGPlus As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Twitter")>
    Public Property cTwitter As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="LinkedIn")>
    Public Property cLinkedIn As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Youtube")>
    Public Property cYT As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Pinterest")>
    Public Property cPinterest As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code")>
    Public Property cYouTube As String

    <StringLength(260, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=0)>
    <DataType(DataType.ImageUrl)>
    <Display(Name:="Image")>
    Public Property cImage As String

    <Display(Name:="Schema Only")>
    Public Property SchemaCheckBox As Boolean

    <Display(Name:="Pages for Categories")>
    Public Property PagesCheckBox As Boolean

    <Display(Name:="Spun Content")>
    Public Property SpunCheckBox As Boolean

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service Category (e.g. Landscape Services, Auto Repair Services, Attorney)")>
    Public Property cServiceCat As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 1")>
    Public Property cService1 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 1")>
    Public Property sCat1 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 1")>
    Public Property sPic1 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 1")>
    Public Property sVid1 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 2")>
    Public Property cService2 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 2")>
    Public Property sCat2 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 2")>
    Public Property sPic2 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 2")>
    Public Property sVid2 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 3")>
    Public Property cService3 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 3")>
    Public Property sCat3 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 3")>
    Public Property sPic3 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 3")>
    Public Property sVid3 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 4")>
    Public Property cService4 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 4")>
    Public Property sCat4 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 4")>
    Public Property sPic4 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 4")>
    Public Property sVid4 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 5")>
    Public Property cService5 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 5")>
    Public Property sCat5 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 5")>
    Public Property sPic5 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 5")>
    Public Property sVid5 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 6")>
    Public Property cService6 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 6")>
    Public Property sCat6 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 6")>
    Public Property sPic6 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 6")>
    Public Property sVid6 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 7")>
    Public Property cService7 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 7")>
    Public Property sCat7 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 7")>
    Public Property sPic7 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 7")>
    Public Property sVid7 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 8")>
    Public Property cService8 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 8")>
    Public Property sCat8 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 8")>
    Public Property sPic8 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 8")>
    Public Property sVid8 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 9")>
    Public Property cService9 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 9")>
    Public Property sCat9 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 9")>
    Public Property sPic9 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 9")>
    Public Property sVid9 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Service 10")>
    Public Property cService10 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Txt 10")>
    Public Property sCat10 As String

    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.Text)>
    <Display(Name:="Img 10")>
    Public Property sPic10 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Video Embed Code 10")>
    Public Property sVid10 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Name 1")>
    Public Property cLinkName1 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="URL 1")>
    Public Property cLinkURL1 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Name 2")>
    Public Property cLinkName2 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="URL 2")>
    Public Property cLinkURL2 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="Name 3")>
    Public Property cLinkName3 As String

    <StringLength(4096, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=2)>
    <DataType(DataType.MultilineText)>
    <Display(Name:="URL 3")>
    Public Property cLinkURL3 As String

End Class
