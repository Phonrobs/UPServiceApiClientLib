<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SssoSignin.aspx.cs" Inherits="SampleApplication.SssoSignin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SsoSignin</title>
</head>
<body>
    <h1>Mobile App User Profile</h1>

    <form id="form1" runat="server">
        <ul>
            <li>Username: <%=ViewState["Username"]%></li>
            <li>DisplayName: <%=ViewState["DisplayName"]%></li>
            <li>Email: <%=ViewState["Email"]%></li>
            <li>OtherEmails: <%=ViewState["OtherEmails"]%></li>
            <li>BusinessPhones: <%=ViewState["BusinessPhones"]%></li>
            <li>MobilePhone: <%=ViewState["MobilePhone"]%></li>
            <li>JobTitle: <%=ViewState["JobTitle"]%></li>
            <li>FacultyName: <%=ViewState["FacultyName"]%></li>
            <li>PersonCode: <%=ViewState["PersonCode"]%></li>
            <li>PersonType: <%=ViewState["PersonType"]%></li>
        </ul>
    </form>
</body>
</html>
