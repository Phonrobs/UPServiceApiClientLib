
Imports UPServiceApiClientLib.Services.AzureAD
Imports UPServiceApiClientLib.Services.UserProfile

Partial Class Profile
    Inherits System.Web.UI.Page

    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(AzureADClientService.CurrentUsername) Then
            ' user already login
            Dim Profile = UserProfileService.GetUserProfile(AzureADClientService.CurrentUsername)

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
        Else
            ' re-login
            AzureADClientService.SignIn()
        End If
    End Sub
End Class
