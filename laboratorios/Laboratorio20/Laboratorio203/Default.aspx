<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio203.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Gestión de Estudiantes</h2>
        <asp:TextBox ID="txtId" runat="server" Placeholder="ID"></asp:TextBox>
        <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre"></asp:TextBox>
        <asp:TextBox ID="txtEdad" runat="server" Placeholder="Edad"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        <br /><br />
        <asp:GridView ID="gvEstudiantes" runat="server"></asp:GridView>
    </div>
</form>
</body>
</html>
