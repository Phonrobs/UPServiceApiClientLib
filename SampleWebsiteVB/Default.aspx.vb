
Imports UPServiceApiClientLib.Services.AzureAD

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' process signin callback
        Dim result = AzureADClientService.SignInCallback()

        If Not result.Success Then
            ltError.Text = "<div class=""alert alert-danger"">" & result.ErrorMessage & "</div>"
        End If

        ' check user was signedin to ADD.
        If Not String.IsNullOrEmpty(AzureADClientService.CurrentUsername) Then
            ' yes
            ViewState("IsAuthenticated") = "true"
        Else
            ' no
            ViewState("IsAuthenticated") = "false"
        End If
    End Sub
End Class
