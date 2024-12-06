using System;
using System.Web.UI;
using PaginaWeb.Services;
using PaginaWeb.Models;
using System.Threading.Tasks;

namespace PaginaWeb
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly ClientService clientService = new ClientService();
        private readonly WorkerService workerService = new WorkerService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    lblErrorMessage.Text = "Por favor, ingrese email y contraseña.";
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Intentando iniciar sesión con email: {email}");

                // Intentar iniciar sesión como trabajador primero
                try
                {
                    var worker = await workerService.LoginAsync(email, password);
                    System.Diagnostics.Debug.WriteLine($"Respuesta de login de trabajador: {worker != null}");

                    if (worker != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Trabajador encontrado. ID: {worker.Id}");
                        Session["UserId"] = worker.Id;
                        Session["UserType"] = "Worker";
                        Session["UserEmail"] = email;

                        System.Diagnostics.Debug.WriteLine("Redirigiendo a WorkerDashboard.aspx");
                        string redirectUrl = "~/WorkerDashboard.aspx";
                        Response.Redirect(redirectUrl, false);
                        Context.ApplicationInstance.CompleteRequest();
                        return;
                    }
                }
                catch (Exception workerEx)
                {
                    System.Diagnostics.Debug.WriteLine($"Error en login de trabajador: {workerEx.Message}");
                    System.Diagnostics.Debug.WriteLine($"StackTrace de trabajador: {workerEx.StackTrace}");
                }

                // Si no es trabajador, intentar como cliente
                try
                {
                    var client = await clientService.LoginAsync(email, password);
                    System.Diagnostics.Debug.WriteLine($"Respuesta de login de cliente: {client != null}");

                    if (client != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Cliente encontrado. ID: {client.Id}");
                        Session["UserId"] = client.Id;
                        Session["UserType"] = "Client";
                        Session["UserEmail"] = email;

                        System.Diagnostics.Debug.WriteLine("Redirigiendo a ClientDashboard.aspx");
                        string redirectUrl = "~/ClientDashboard.aspx";
                        Response.Redirect(redirectUrl, false);
                        Context.ApplicationInstance.CompleteRequest();
                        return;
                    }
                }
                catch (Exception clientEx)
                {
                    System.Diagnostics.Debug.WriteLine($"Error en login de cliente: {clientEx.Message}");
                    System.Diagnostics.Debug.WriteLine($"StackTrace de cliente: {clientEx.StackTrace}");
                }

                lblErrorMessage.Text = "Email o contraseña incorrectos.";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error general de inicio de sesión: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace general: {ex.StackTrace}");
                lblErrorMessage.Text = "Error al iniciar sesión. Por favor, intente de nuevo más tarde.";
            }
        }
    }
}

