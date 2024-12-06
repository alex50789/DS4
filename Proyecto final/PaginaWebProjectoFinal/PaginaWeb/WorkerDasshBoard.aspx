<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerDashboard.aspx.cs" Inherits="PaginaWeb.WorkerDashboard" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard del Trabajador</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f0f0f0;
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
            background-color: white;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h1, h2 {
            color: #333;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
        }
        .form-group input,
        .form-group select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }
        .btn {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 4px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #0056b3;
        }
        .error-message {
            color: red;
            margin-top: 10px;
        }
        .success-message {
            color: green;
            margin-top: 10px;
        }
        .appointment-list {
            margin-top: 20px;
        }
        .appointment-item {
            background-color: #f9f9f9;
            border: 1px solid #ddd;
            padding: 10px;
            margin-bottom: 10px;
            border-radius: 4px;
        }
        .welcome-message {
            font-size: 18px;
            margin-bottom: 20px;
            color: #007bff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Dashboard del Trabajador</h1>
            <asp:Label ID="lblWelcome" runat="server" CssClass="welcome-message"></asp:Label>
            
            <h2>Mis Citas</h2>
            <asp:Repeater ID="rptAppointments" runat="server">
                <ItemTemplate>
                    <div class="appointment-item">
                        <p><strong>Cliente:</strong> <%# Eval("Client.Name") %></p>
                        <p><strong>Servicio:</strong> <%# Eval("Service.Name") %></p>
                        <p><strong>Fecha y Hora:</strong> <%# Eval("AppointmentDate") %></p>
                        <p><strong>Estado:</strong> <%# Eval("Status") %></p>
                        <asp:Button ID="btnUpdateStatus" runat="server" Text="Actualizar Estado" CssClass="btn" 
                            CommandName="UpdateStatus" 
                            CommandArgument='<%# Eval("Id") %>'
                            OnCommand="btnUpdateStatus_Command" />
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblNoAppointments" runat="server" Text="No hay citas programadas." Visible="<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>" />
                </FooterTemplate>
            </asp:Repeater>

            <asp:Panel ID="pnlUpdateStatus" runat="server" Visible="false">
                <h2>Actualizar Estado de la Cita</h2>
                <div class="form-group">
                    <label for="ddlStatus">Nuevo Estado:</label>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Text="Pendiente" Value="Pendiente" />
                        <asp:ListItem Text="En Progreso" Value="En Progreso" />
                        <asp:ListItem Text="Completada" Value="Completada" />
                        <asp:ListItem Text="Cancelada" Value="Cancelada" />
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnConfirmUpdate" runat="server" Text="Confirmar Actualización" CssClass="btn" OnClick="btnConfirmUpdate_Click" />
                <asp:Button ID="btnCancelUpdate" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelUpdate_Click" />
            </asp:Panel>

            <asp:Label ID="lblMessage" runat="server" CssClass="success-message"></asp:Label>
        </div>
    </form>
</body>
</html>

