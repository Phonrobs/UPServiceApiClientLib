
Imports UPServiceApiClientLib.Services.AzureAD
Imports UPServiceApiClientLib.Services.Messaging

Partial Class SendMessage
    Inherits System.Web.UI.Page

    Private Sub SendMessage_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            txtMessagingBotId.Text = "0"
        End If
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' validate
        If (String.IsNullOrEmpty(txtSubject.Text)) Then
            ltMessage.Text = "Subject has required!"
            Return
        End If

        If (String.IsNullOrEmpty(txtBody.Text)) Then
            ltMessage.Text = "Body has required!"
            Return
        End If

        If (String.IsNullOrEmpty(txtSendBy.Text)) Then
            ltMessage.Text = "SendBy has required!"
            Return
        End If

        ' send message
        ' run async task in sync.
        ' first check user account exit in MSAL cache ot Not?
        ' REMOVE THIS CONDITION IF USING WITH CLIENT CREDENTIAL FLOW
        If Not String.IsNullOrEmpty(AzureADClientService.CurrentUsername) Then
            ' create message payload
            Dim payload = New MessagePayload()

            payload.Subject = txtSubject.Text
            payload.Body = txtBody.Text
            payload.SendTo = txtSendTo.Text
            payload.TopicId = Long.Parse(txtTopic.Text)

            ' cache exit then we shall proceed.
            ' send message
            Dim result = MessagingService.Send(payload)

            If (result.Success) Then
                ltMessage.Text = "Message send complete."
            Else
                ltMessage.Text = result.ErrorMessage
            End If
        Else
            AzureADClientService.SignIn()
        End If
    End Sub
End Class
