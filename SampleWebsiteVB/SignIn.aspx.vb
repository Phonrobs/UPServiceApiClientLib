
Imports UPServiceApiClientLib.Services.AzureAD

Partial Class SignIn
    Inherits System.Web.UI.Page

    Private Sub SignIn_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' show Azure AD login screen.
        AzureADClientService.SignIn()
    End Sub
End Class
