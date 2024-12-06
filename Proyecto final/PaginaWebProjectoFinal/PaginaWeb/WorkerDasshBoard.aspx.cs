using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using PaginaWeb.Services;
using PaginaWeb.Models;

namespace PaginaWeb
{
    public partial class WorkerDashboard : System.Web.UI.Page
    {
        private readonly AppointmentService appointmentService = new AppointmentService();
        private readonly NoticeService noticeService = new NoticeService();

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Iniciando Page_Load en WorkerDashboard");
                if (!IsPostBack)
                {
                    if (!IsUserAuthenticated())
                    {
                        System.Diagnostics.Debug.WriteLine("Usuario no autenticado. Redirigiendo a Login.aspx");
                        Response.Redirect("~/Login.aspx", true);
                        return;
                    }

                    System.Diagnostics.Debug.WriteLine("Usuario autenticado. Cargando citas...");
                    await LoadAppointmentsAsync();
                    lblWelcome.Text = $"Bienvenido, {Session["UserEmail"]}";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error en Page_Load");
            }
        }

        private bool IsUserAuthenticated()
        {
            bool isAuthenticated = Session["UserId"] != null &&
                                   Session["UserType"] != null &&
                                   Session["UserType"].ToString() == "Worker";

            System.Diagnostics.Debug.WriteLine($"IsUserAuthenticated: {isAuthenticated}");
            System.Diagnostics.Debug.WriteLine($"UserId: {Session["UserId"]}");
            System.Diagnostics.Debug.WriteLine($"UserType: {Session["UserType"]}");
            System.Diagnostics.Debug.WriteLine($"UserEmail: {Session["UserEmail"]}");

            return isAuthenticated;
        }

        private async Task LoadAppointmentsAsync()
        {
            try
            {
                if (Session["UserId"] == null)
                {
                    throw new InvalidOperationException("UserId no está presente en la sesión");
                }

                long workerId = Convert.ToInt64(Session["UserId"]);
                System.Diagnostics.Debug.WriteLine($"Cargando citas para el trabajador ID: {workerId}");

                var appointments = await appointmentService.GetWorkerAppointmentsAsync(workerId);
                System.Diagnostics.Debug.WriteLine($"Citas cargadas: {appointments?.Count ?? 0}");

                rptAppointments.DataSource = appointments;
                rptAppointments.DataBind();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error al cargar citas");
            }
        }

        protected void btnUpdateStatus_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "UpdateStatus")
                {
                    long appointmentId = Convert.ToInt64(e.CommandArgument);
                    ViewState["UpdateAppointmentId"] = appointmentId;
                    pnlUpdateStatus.Visible = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error en btnUpdateStatus_Command");
            }
        }

        protected async void btnConfirmUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                long appointmentId = Convert.ToInt64(ViewState["UpdateAppointmentId"]);
                string newStatus = ddlStatus.SelectedValue;

                var appointment = await appointmentService.GetAppointmentAsync(appointmentId);
                if (appointment == null)
                {
                    lblMessage.Text = "No se encontró la cita especificada.";
                    return;
                }

                appointment.Status = newStatus;
                await appointmentService.UpdateAppointmentAsync(appointmentId, appointment);

                // Crear notificación
                await noticeService.CreateStatusUpdateNoticeAsync(
                    appointment.Client?.Name ?? "Cliente",
                    newStatus,
                    appointment.WorkerId
                );

                lblMessage.Text = "Estado de la cita actualizado con éxito.";
                pnlUpdateStatus.Visible = false;
                await LoadAppointmentsAsync();
            }
            catch (Exception ex)
            {
                HandleException(ex, "Error en btnConfirmUpdate_Click");
            }
        }

        protected void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            pnlUpdateStatus.Visible = false;
        }

        private void HandleException(Exception ex, string message)
        {
            System.Diagnostics.Debug.WriteLine($"{message}: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
            lblMessage.Text = $"{message}. Por favor, actualice la página o contacte al administrador.";
        }
    }
}

