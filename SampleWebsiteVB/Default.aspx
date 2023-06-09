<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Home</h1>

    <asp:Literal ID="ltError" runat="server"></asp:Literal>

    <ul>
        <%If ViewState("IsAuthenticated").ToString() = "false" Then%>
        <li><a href="SignIn.aspx">Sign In</a></li>
        <%Else%>
        <li><a href="User.aspx">View Current Username</a></li>
        <li><a href="Profile.aspx">View Current User Profile</a></li>
        <li><a href="SendMessage.aspx">Send Message</a></li>
        <li><a href="SignOut.aspx">Sign Out</a></li>
        <%End If%>
    </ul>
</asp:Content>
