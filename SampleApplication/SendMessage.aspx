<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="SampleApplication.SendMessage" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send Message</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
</head>
<body>
    <div class="container my-5">
        <h1>Send Message</h1>

        <form id="form1" runat="server">
            <div class="alert alert-warning">
                <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            </div>

            <div class="form-group">
                <label>*Subject</label>
                <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>*Body</label>
                <asp:TextBox ID="txtBody" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>*SendBy</label>
                <asp:TextBox ID="txtSendBy" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>SendTo</label>
                <asp:TextBox ID="txtSendTo" runat="server" CssClass="form-control"></asp:TextBox>
                <small class="form-text text-muted">Input target email address or leave empty to send this message to all users.</small>
            </div>

            <div class="form-group">
                <label>Parameters</label>
                <asp:TextBox ID="txtParameters" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>MessagingBotId</label>
                <asp:TextBox ID="txtMessagingBotId" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <small class="form-text text-muted">Set to 0 to send this message to Smart UP mobile app.</small>
            </div>

            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </form>
    </div>
</body>
</html>
