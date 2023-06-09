<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SampleApplication.Profile" Async="true" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Profile</title>
</head>
<body>
    <h1>My Profile</h1>

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
        <p>Photo: <img src="ProfilePhoto.aspx" /></p>
    </form>
</body>
</html>
