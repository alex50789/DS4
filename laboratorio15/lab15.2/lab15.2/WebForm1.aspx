<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="lab15._2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
&nbsp;&nbsp;&nbsp; Introduzca el texto.<br />
            <br />
            <asp:TextBox ID="txt" runat="server" Width="128px"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="saludos" runat="server" OnClick="saludos_Click" Text="Mandar saludos" Width="106px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="resultado" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
