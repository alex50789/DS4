<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PaginaWeb.Register" Async="true" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-color: #f0f0f0;
        }
        .register-container {
            background-color: white;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            width: 300px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
        }
        .form-group input[type="text"],
        .form-group input[type="password"],
        .form-group input[type="email"],
        .form-group select {
            width: 100%;
            padding: 5px;
            border: 1px solid #ddd;
            border-radius: 3px;
        }
        .btn {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 3px;
            cursor: pointer;
            width: 100%;
        }
        .btn:hover {
            background-color: #0056b3;
        }
        .error-message {
            color: red;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <h2>Registro</h2>
            <div class="form-group">
                <label for="txtName">Nombre:</label>
                <asp:TextBox ID="txtName" runat="server" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPassword">Contraseña:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlUserType">Tipo de Usuario:</label>
                <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                    <asp:ListItem Text="Cliente" Value="Client" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Trabajador" Value="Worker"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div id="workerCodeSection" runat="server" visible="false" class="form-group">
                <label for="txtWorkerCode">Código de Trabajador:</label>
                <asp:TextBox ID="txtWorkerCode" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Registrarse" CssClass="btn" OnClick="btnRegister_Click" />
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
            <div>
                <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">¿Ya tienes una cuenta? Inicia sesión aquí</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>

