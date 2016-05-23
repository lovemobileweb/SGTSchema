
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization

Public Enum Comparison
    IsEqualOrGreater
    IsEqualOrSmaller
End Enum

<AttributeUsage(AttributeTargets.[Property] Or AttributeTargets.Field, AllowMultiple:=False, Inherited:=True)>
Public Class OpenCloseTimeAttribute
    Inherits ValidationAttribute
    Implements IClientValidatable

    ReadOnly _enableProperty As String
    ReadOnly _otherProperty As String
    ReadOnly _comparison As Comparison

    Public ReadOnly Property EnableProperty() As String
        Get
            Return _enableProperty
        End Get
    End Property

    Public ReadOnly Property OtherProperty() As String
        Get
            Return _otherProperty
        End Get
    End Property

    Public ReadOnly Property Comparison() As Comparison
        Get
            Return _comparison
        End Get
    End Property

    Public Sub New(ByVal enableProperty As String, ByVal otherProperty As String, ByVal comparison As Comparison)
        _enableProperty = enableProperty
        _otherProperty = otherProperty
        _comparison = comparison
    End Sub

    Protected Overrides Function IsValid(ByVal value As Object, validationContext As ValidationContext) As ValidationResult
        Dim propertyValue As String = DirectCast(value, String)
        Dim result As ValidationResult = ValidationResult.Success
        Dim enableProperty As Reflection.PropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(Me.EnableProperty)
        Dim enablePropertyValue As Boolean = enableProperty.GetValue(validationContext.ObjectInstance, Nothing)
        Dim otherProperty As Reflection.PropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(Me.OtherProperty)
        Dim otherPropertyValue As String = otherProperty.GetValue(validationContext.ObjectInstance, Nothing)

        If (enablePropertyValue = False) Then
            Return ValidationResult.Success
        End If

        If (propertyValue = Nothing) Then
            Return New ValidationResult(String.Format(ErrorMessageString, validationContext.DisplayName))
        End If

        If (otherPropertyValue = Nothing) Then
            Return ValidationResult.Success
        End If

        Dim time1 As DateTime = Convert.ToDateTime(propertyValue)
        Dim time2 As DateTime = Convert.ToDateTime(otherPropertyValue)

        If (((Me.Comparison = Comparison.IsEqualOrGreater) And (time1 < time2)) Or ((Me.Comparison = Comparison.IsEqualOrSmaller) And (time1 > time2))) Then
            Return New ValidationResult(String.Format(ErrorMessageString, validationContext.DisplayName))
        End If

        Return ValidationResult.Success
    End Function

    Public Overrides Function FormatErrorMessage(ByVal name As String) As String
        Return [String].Format(CultureInfo.CurrentCulture, ErrorMessageString, name)
    End Function

    Public Function GetClientValidationRules(ByVal metadata As ModelMetadata, ByVal context As ControllerContext) As IEnumerable(Of ModelClientValidationRule) _
        Implements IClientValidatable.GetClientValidationRules
        Dim ret = New List(Of ModelClientValidationRule)
        ret.Add(New ModelClientValidationOpenCloseTimeRule(FormatErrorMessage(metadata.GetDisplayName()), EnableProperty, OtherProperty, Comparison))
        Return ret
    End Function

End Class

Public Class ModelClientValidationOpenCloseTimeRule
    Inherits ModelClientValidationRule

    Public Sub New(ByVal errorMessage As String,
                    ByVal enableProperty As String,
                    ByVal otherProperty As String,
                    ByVal comparison As Comparison)
        Me.ErrorMessage = errorMessage
        Me.ValidationType = "openclosetime"
        Me.ValidationParameters.Add("enable", enableProperty)
        Me.ValidationParameters.Add("other", otherProperty)
        Me.ValidationParameters.Add("comp", comparison.ToString().ToLower())
    End Sub
End Class
