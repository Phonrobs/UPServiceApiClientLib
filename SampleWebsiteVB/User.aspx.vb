
Imports UPServiceApiClientLib.Services.AzureAD

Partial Class User
    Inherits System.Web.UI.Page

    Private Sub User_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' check user was signedin?
        If Not String.IsNullOrEmpty(AzureADClientService.CurrentUsername) Then
            ' yes, then get current username from id_token claim (cookie).
            ViewState("CurrentUsername") = AzureADClientService.CurrentUsername
        Else
            ' no, then signin user again.
            Response.Redirect("~/SignIn.aspx")
        End If
    End Sub
End Class
