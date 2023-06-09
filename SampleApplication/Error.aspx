<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SampleApplication.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
</head>
<body>
    <h1>Error</h1>

    <form id="form1" runat="server">
        <div>
            <%=Request.QueryString["message"]%>
        </div>
    </form>
</body>
</html>
