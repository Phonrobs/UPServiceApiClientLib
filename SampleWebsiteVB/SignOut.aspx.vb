
Imports UPServiceApiClientLib.Services.AzureAD

Partial Class SignOut
    Inherits System.Web.UI.Page

    Private Sub SignOut_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' signout current user And rturn to home page (Default.aspx).
        AzureADClientService.SignOut()
    End Sub
End Class
