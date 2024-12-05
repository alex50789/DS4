<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio153.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Leer y Mostrar Texto</title>
</head>
<body>
    <form id="form1" runat="server">
        <div><asp:Label ID="Label1" runat="server" Text="Ingrese texto:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Mostrar Mensaje" OnClick="Button1_Click" />
              </div>
    </form>
</body>
</html>
