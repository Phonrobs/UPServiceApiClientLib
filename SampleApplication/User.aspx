<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="SampleApplication.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Current User</h1>

    <form id="form1" runat="server">
         <div>
            Current Username: <%=ViewState["CurrentUsername"]%>
        </div>
    </form>
</body>
</html>
