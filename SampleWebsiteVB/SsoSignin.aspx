<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SsoSignin.aspx.vb" Inherits="SsoSignin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>My Profile</h1>

    <ul>
        <li>Username: <%=ViewState("Username")%></li>
        <li>DisplayName: <%=ViewState("DisplayName")%></li>
        <li>Email: <%=ViewState("Email")%></li>
        <li>OtherEmails: <%=ViewState("OtherEmails")%></li>
        <li>BusinessPhones: <%=ViewState("BusinessPhones")%></li>
        <li>MobilePhone: <%=ViewState("MobilePhone")%></li>
        <li>JobTitle: <%=ViewState("JobTitle")%></li>
        <li>FacultyName: <%=ViewState("FacultyName")%></li>
        <li>PersonCode: <%=ViewState("PersonCode")%></li>
        <li>PersonType: <%=ViewState("PersonType")%></li>
    </ul>
</asp:Content>

