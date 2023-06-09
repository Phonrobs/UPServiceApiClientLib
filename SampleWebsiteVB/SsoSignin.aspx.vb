
Imports UPServiceApiClientLib.Services.AppSSO

Partial Class SsoSignin
    Inherits System.Web.UI.Page

    Private Sub SsoSignin_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' load profile from UPSmartApiService.
        Dim result = AppSSOService.ValidateAndGetUserProfile()

        If (Not result.Success) Then
            ' invalid token
            Response.Redirect("~/Error.aspx?message=" + result.ErrorMessage)
        Else
            ' profile loading successful, you should save its in Session Or do anything you want.
            ' show profile
            Dim Profile = result.UserProfile

            ViewState("Username") = Profile.Username
            ViewState("DisplayName") = Profile.DisplayName
            ViewState("Email") = Profile.Email
            ViewState("OtherEmails") = Profile.OtherEmails
            ViewState("BusinessPhones") = Profile.BusinessPhones
            ViewState("MobilePhone") = Profile.MobilePhone
            ViewState("JobTitle") = Profile.JobTitle
            ViewState("FacultyName") = Profile.FacultyName
            ViewState("PersonCode") = Profile.PersonCode
            ViewState("PersonType") = Profile.PersonType
        End If
    End Sub
End Class
