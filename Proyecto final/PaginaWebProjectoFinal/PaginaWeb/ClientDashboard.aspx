<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientDashboard.aspx.cs" Inherits="PaginaWeb.ClientDashboard" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard del Cliente</title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Dashboard del Cliente</h1>
            
            <h2>Agendar Nueva Cita</h2>
            <div class="form-group">
                <label for="ddlWorker">Trabajador:</label>
                <asp:DropDownList ID="ddlWorker" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWorker_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="ddlService">Servicio:</label>
                <asp:DropDownList ID="ddlService" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtAppointmentDate">Fecha y Hora:</label>
                <asp:TextBox ID="txtAppointmentDate" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            </div>
            <asp:Button ID="btnSchedule" runat="server" Text="Agendar Cita" CssClass="btn" OnClick="btnSchedule_Click" />
            <asp:Label ID="lblScheduleMessage" runat="server" CssClass="error-message"></asp:Label>

            <asp:Repeater ID="rptAppointments" runat="server">
                <HeaderTemplate>
                    <h2>Mis Citas</h2>
                </HeaderTemplate>
            <ItemTemplate>
            <div class="appointment-item">
                <p><strong>Trabajador:</strong> <%# Eval("Worker.Name") %></p>
                <p><strong>Servicio:</strong> <%# Eval("Service.Name") %></p>
                <p><strong>Fecha y Hora:</strong> <%# Eval("AppointmentDate") %></p>
                <p><strong>Estado:</strong> <%# Eval("Status") %></p>
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar Cita" CssClass="btn" 
                    CommandName="CancelAppointment" 
                    CommandArgument='<%# Eval("Id") %>'
                    OnCommand="btnCancel_Command" 
                    Visible='<%# Eval("Status").ToString() == "Pendiente" %>'/>
            </div>
            </ItemTemplate>
            <FooterTemplate>
            <asp:Label ID="lblNoAppointments" runat="server" Text="No hay citas agendadas." Visible="<%# ((Repeater)Container.NamingContainer).Items.Count == 0 %>" />
    </FooterTemplate>
                </asp:Repeater>


            <asp:Panel ID="pnlCancelAppointment" runat="server" Visible="false">
                <h2>Cancelar Cita</h2>
                <div class="form-group">
                    <label for="txtCancelReason">Razón de cancelación:</label>
                    <asp:TextBox ID="txtCancelReason" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                </div>
                <asp:Button ID="btnConfirmCancel" runat="server" Text="Confirmar Cancelación" CssClass="btn" OnClick="btnConfirmCancel_Click" />
                <asp:Button ID="btnCancelCancellation" runat="server" Text="Volver" CssClass="btn" OnClick="btnCancelCancellation_Click" />
            </asp:Panel>

            <asp:Label ID="lblMessage" runat="server" CssClass="success-message"></asp:Label>
        </div>
    </form>
</body>
</html>



