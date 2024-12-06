using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaginaWeb.Models;
using PaginaWeb.Services;

namespace PaginaWeb
{
    public partial class ClientDashboard : System.Web.UI.Page
    {
        private ClientService clientService = new ClientService();
        private WorkerService workerService = new WorkerService();
        private ServiceService serviceService = new ServiceService();
        private AppointmentService appointmentService = new AppointmentService();
        private NoticeService noticeService = new NoticeService();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsUserAuthenticated())
                {
                    Response.Redirect("~/Login.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

                LoadInitialData();
            }
        }

        private bool IsUserAuthenticated()
        {
            return Session["UserId"] != null && Session["UserType"].ToString() == "Client";
        }

        private async void LoadInitialData()
        {
            await LoadWorkersAsync();
            await LoadServicesAsync();
            await LoadAppointmentsAsync();
        }

        private async System.Threading.Tasks.Task LoadWorkersAsync()
        {
            var workers = await workerService.GetAllWorkersAsync();
            ddlWorker.DataSource = workers;
            ddlWorker.DataTextField = "Name";
            ddlWorker.DataValueField = "Id";
            ddlWorker.DataBind();
        }

        private async System.Threading.Tasks.Task LoadServicesAsync()
        {
            var services = await serviceService.GetAllServicesAsync();
            ddlService.DataSource = services;
            ddlService.DataTextField = "Name";
            ddlService.DataValueField = "Id";
            ddlService.DataBind();
        }

        private async System.Threading.Tasks.Task LoadAppointmentsAsync()
        {
            long clientId = Convert.ToInt64(Session["UserId"]);
            var appointments = await appointmentService.GetClientAppointmentsAsync(clientId);
            appointments = appointments.Where(a => a.Status != "Cancelada").ToList();

            // Asegúrate de que Worker y Service estén incluidos en los resultados
            foreach (var appointment in appointments)
            {
                if (appointment.Worker == null)
                {
                    appointment.Worker = await workerService.GetWorkerAsync(appointment.WorkerId);
                }
                if (appointment.Service == null)
                {
                    appointment.Service = await serviceService.GetServiceAsync(appointment.ServiceId);
                }
            }

            rptAppointments.DataSource = appointments;
            rptAppointments.DataBind();
        }


        protected async void ddlWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar lógica adicional si es necesario
        }

        protected async void btnSchedule_Click(object sender, EventArgs e)
        {
            long clientId = Convert.ToInt64(Session["UserId"]);
            long workerId = Convert.ToInt64(ddlWorker.SelectedValue);
            long serviceId = Convert.ToInt64(ddlService.SelectedValue);
            DateTime appointmentDate;

            if (!DateTime.TryParse(txtAppointmentDate.Text, out appointmentDate))
            {
                lblScheduleMessage.Text = "Formato de fecha y hora inválido.";
                return;
            }

            // Verificar disponibilidad
            bool isAvailable = await appointmentService.IsTimeSlotAvailable(workerId, appointmentDate);
            if (!isAvailable)
            {
                lblScheduleMessage.Text = "El trabajador o el horario seleccionado no está disponible.";
                return;
            }

            // Crear la cita
            var appointment = new Appointment
            {
                ClientId = clientId,
                WorkerId = workerId,
                ServiceId = serviceId,
                AppointmentDate = appointmentDate,
                Status = "Pendiente"
            };

            try
            {
                await appointmentService.CreateAppointmentAsync(appointment);

                // Crear notificación
                var client = await clientService.GetClientAsync(clientId);
                await noticeService.CreateAppointmentNoticeAsync(client.Name, appointmentDate, workerId);

                lblMessage.Text = "Cita agendada con éxito.";
                await LoadAppointmentsAsync();
            }
            catch (Exception ex)
            {
                lblScheduleMessage.Text = "Error al agendar la cita: " + ex.Message;
            }
        }

        protected void btnCancel_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "CancelAppointment")
            {
                long appointmentId = Convert.ToInt64(e.CommandArgument);
                ViewState["CancelAppointmentId"] = appointmentId;
                pnlCancelAppointment.Visible = true;
            }
        }

        protected async void btnConfirmCancel_Click(object sender, EventArgs e)
        {
            long appointmentId = Convert.ToInt64(ViewState["CancelAppointmentId"]);
            string cancelReason = txtCancelReason.Text.Trim();

            if (string.IsNullOrEmpty(cancelReason))
            {
                lblMessage.Text = "Por favor, proporcione una razón para la cancelación.";
                return;
            }

            try
            {
                var appointment = await appointmentService.GetAppointmentAsync(appointmentId);
                appointment.Status = "Cancelada";
                await appointmentService.UpdateAppointmentAsync(appointmentId, appointment);

                var client = await clientService.GetClientAsync(appointment.ClientId);
                await noticeService.CreateCancellationNoticeAsync(client.Name, cancelReason, appointment.WorkerId);

                lblMessage.Text = "Cita cancelada con éxito.";
                pnlCancelAppointment.Visible = false;
                await LoadAppointmentsAsync();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al cancelar la cita: " + ex.Message;
            }
        }

        protected void btnCancelCancellation_Click(object sender, EventArgs e)
        {
            pnlCancelAppointment.Visible = false;
        }
    }
}






