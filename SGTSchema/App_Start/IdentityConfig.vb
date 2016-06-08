Imports System.Threading.Tasks
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports System.Data.Entity

Public Class EmailService
    Implements IIdentityMessageService

    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' Plug in your email service here to send an email.
        Return Task.FromResult(0)
    End Function
End Class

Public Class SmsService
    Implements IIdentityMessageService

    Public Function SendAsync(message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
        ' Plug in your SMS service here to send a text message.
        Return Task.FromResult(0)
    End Function
End Class

' Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
Public Class ApplicationUserManager
    Inherits UserManager(Of ApplicationUser)

    Public Sub New(store As IUserStore(Of ApplicationUser))
        MyBase.New(store)
    End Sub

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationUserManager), context As IOwinContext) As ApplicationUserManager
        Dim manager = New ApplicationUserManager(New UserStore(Of ApplicationUser)(context.Get(Of ApplicationDbContext)()))

        ' Configure validation logic for usernames
        manager.UserValidator = New UserValidator(Of ApplicationUser)(manager) With {
            .AllowOnlyAlphanumericUserNames = False,
            .RequireUniqueEmail = True
        }

        ' Configure validation logic for passwords
        manager.PasswordValidator = New PasswordValidator With {
            .RequiredLength = 3,
            .RequireNonLetterOrDigit = False,
            .RequireDigit = False,
            .RequireLowercase = False,
            .RequireUppercase = False
        }

        ' Configure user lockout defaults
        manager.UserLockoutEnabledByDefault = True
        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5)
        manager.MaxFailedAccessAttemptsBeforeLockout = 5

        ' Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
        ' You can write your own provider and plug it in here.
        manager.RegisterTwoFactorProvider("Phone Code", New PhoneNumberTokenProvider(Of ApplicationUser) With {
                                          .MessageFormat = "Your security code is {0}"
                                      })
        manager.RegisterTwoFactorProvider("Email Code", New EmailTokenProvider(Of ApplicationUser) With {
                                          .Subject = "Security Code",
                                          .BodyFormat = "Your security code is {0}"
                                          })
        manager.EmailService = New EmailService()
        manager.SmsService = New SmsService()
        Dim dataProtectionProvider = options.DataProtectionProvider
        If (dataProtectionProvider IsNot Nothing) Then
            manager.UserTokenProvider = New DataProtectorTokenProvider(Of ApplicationUser)(dataProtectionProvider.Create("ASP.NET Identity"))
        End If

        Return manager
    End Function

End Class

' Configure the RoleManager used in the application. RoleManager Is defined in the ASP.NET Identity core assembly
Public Class ApplicationRoleManager
    Inherits RoleManager(Of IdentityRole)
    Public Sub New(roleStore As IRoleStore(Of IdentityRole, String))
        MyBase.New(roleStore)
    End Sub

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationRoleManager), context As IOwinContext) As ApplicationRoleManager
        Return New ApplicationRoleManager(New RoleStore(Of IdentityRole)(context.Get(Of ApplicationDbContext)()))
    End Function
End Class

' Configure the application sign-in manager which is used in this application.
Public Class ApplicationSignInManager
    Inherits SignInManager(Of ApplicationUser, String)
    Public Sub New(userManager As ApplicationUserManager, authenticationManager As IAuthenticationManager)
        MyBase.New(userManager, authenticationManager)
    End Sub

    Public Overrides Function CreateUserIdentityAsync(user As ApplicationUser) As Task(Of ClaimsIdentity)
        Return user.GenerateUserIdentityAsync(DirectCast(UserManager, ApplicationUserManager))
    End Function

    Public Shared Function Create(options As IdentityFactoryOptions(Of ApplicationSignInManager), context As IOwinContext) As ApplicationSignInManager

        Dim userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim roleManager = System.Web.HttpContext.Current.GetOwinContext().Get(Of ApplicationRoleManager)()

        ' Create Role Admin if it does Not exist
        Const email = "admin@sgtschema.com"
        Const fullName = "Admin"
        Const password = "Admin@123456"
        Dim roleName = "Admin"
        Dim role = roleManager.FindByName(roleName)
        If (role Is Nothing) Then
            role = New IdentityRole(roleName)
            Dim roleresult = roleManager.Create(role)
        End If
        Dim user As ApplicationUser = userManager.FindByEmail(email)
        If (user Is Nothing) Then
            user = New ApplicationUser() With {
                .UserName = email,
                .Email = email,
                .FullName = fullName,
                .Flag = True
            }
            Dim result = userManager.Create(user, password)
            result = userManager.SetLockoutEnabled(user.Id, False)
        End If

        ' Add user admin to Role Admin if Not already added
        Dim rolesForUser = userManager.GetRoles(user.Id)
        If (rolesForUser.Contains(role.Name) = False) Then
            Dim result = userManager.AddToRole(user.Id, role.Name)
        End If

        ' Create Roles if it does Not exist
        roleName = "Enterprise"
        role = roleManager.FindByName(roleName)
        If (role Is Nothing) Then
            role = New IdentityRole(roleName)
            Dim roleresult = roleManager.Create(role)
        End If
        roleName = "Premium"
        role = roleManager.FindByName(roleName)
        If (role Is Nothing) Then
            role = New IdentityRole(roleName)
            Dim roleresult = roleManager.Create(role)
        End If
        roleName = "Standard"
        role = roleManager.FindByName(roleName)
        If (role Is Nothing) Then
            role = New IdentityRole(roleName)
            Dim roleresult = roleManager.Create(role)
        End If

        Return New ApplicationSignInManager(context.GetUserManager(Of ApplicationUserManager)(), context.Authentication)
    End Function
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
    End Sub

    Public Property SGTSchemas() As DbSet(Of SGTSchemaModel)
    Public Property Articles As DbSet(Of Article)
    Public Property Schemas As DbSet(Of SchemaOnlyModel)
    Public Property Cities As DbSet(Of CityModel)
    Public Property Companies As DbSet(Of CompanyModel)

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function
End Class
