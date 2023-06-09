<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <h1>Home</h1>

    <form id="form1" runat="server">
        <ul>
            <%if (ViewState["IsAuthenticated"].ToString() == "false")
                {%>
            <li><a href="Signin.aspx">Signin</a></li>
            <%}
                else
                {%>
            <li><a href="User.aspx">View current user.</a></li>
            <li><a href="Profile.aspx">View my profile.</a></li>
            <li><a href="SendMessage.aspx">Send message.</a></li>
            <li><a href="SignOut.aspx">Signout</a></li>
            <%}%>
        </ul>
    </form>
</body>
</html>
