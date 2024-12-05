<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio202.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ingrese un numero entero:
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Matriz NxN</h2>
        <asp:TextBox ID="txtN" runat="server"></asp:TextBox>
        <asp:Button ID="btnGenerar" runat="server" Text="Generar Matriz" OnClick="btnGenerar_Click" />
        <br /><br />
        <asp:Literal ID="litResultado" runat="server"></asp:Literal>
    </div>
</form>
    </form>
</body>
</html>
