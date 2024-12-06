using System;
using System.Web.UI;
using PaginaWeb.Services;
using PaginaWeb.Models;
using System.Threading.Tasks;

namespace PaginaWeb
{
    public partial class Register : System.Web.UI.Page
    {
        private ClientService clientService = new ClientService();
        private WorkerService workerService = new WorkerService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicialización si es necesaria
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            workerCodeSection.Visible = ddlUserType.SelectedValue == "Worker";
        }

        protected async void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string userType = ddlUserType.SelectedValue;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Text = "Por favor, complete todos los campos.";
                return;
            }

            try
            {
                if (userType == "Client")
                {
                    var client = new Client { Name = name, Email = email, Password = password };
                    await clientService.CreateClientAsync(client);
                    Response.Redirect("~/Login.aspx");
                }
                else if (userType == "Worker")
                {
                    string workerCode = txtWorkerCode.Text.Trim();
                    if (workerCode != "2003") // Código de trabajador hardcodeado para este ejemplo
                    {
                        lblErrorMessage.Text = "Código de trabajador inválido.";
                        return;
                    }

                    var worker = new Worker { Name = name, Email = email, Password = password };
                    await workerService.CreateWorkerAsync(worker);
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error al registrar. Por favor, intente de nuevo más tarde.";
                // Loguear el error para debugging
                System.Diagnostics.Debug.WriteLine($"Error de registro: {ex.Message}");
            }
        }
    }
}

