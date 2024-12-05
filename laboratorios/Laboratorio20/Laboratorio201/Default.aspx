<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio201.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Tabla de Multiplicar</h2>
        <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
        <asp:Button ID="btnGenerar" runat="server" Text="Generar Tabla" OnClick="btnGenerar_Click" />
        <br /><br />
        <asp:Literal ID="litResultado" runat="server"></asp:Literal>
    </div>
</form>
</body>
</html>
