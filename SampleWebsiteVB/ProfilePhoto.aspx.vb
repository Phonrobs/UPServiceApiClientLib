
Imports UPServiceApiClientLib.Services.AzureAD
Imports UPServiceApiClientLib.Services.UserProfile

Partial Class ProfilePhoto
    Inherits System.Web.UI.Page

    Private Sub ProfilePhoto_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(AzureADClientService.CurrentUsername) Then
            ' user already login
            UserProfileService.DownloadUserPhoto(AzureADClientService.CurrentUsername)
        End If
    End Sub
End Class
