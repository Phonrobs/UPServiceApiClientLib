<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SendMessage.aspx.vb" Inherits="SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Send Message</h1>
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
        <label>Topic (for FCM only)</label>
        <asp:TextBox ID="txtTopic" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>MessagingBotId</label>
        <asp:TextBox ID="txtMessagingBotId" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        <small class="form-text text-muted">Set to 0 to send this message to Smart UP mobile app.</small>
    </div>

    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button1_Click" />
</asp:Content>

