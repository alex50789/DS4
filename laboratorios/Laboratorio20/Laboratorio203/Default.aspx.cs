using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio203
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public partial class _Default : System.Web.UI.Page
        {
            string connectionString = "Data Source=.;Initial Catalog=Laboratorio14;Integrated Security=True";

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    CargarEstudiantes();
                }
            }

            private void CargarEstudiantes()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Estudiantes";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvEstudiantes.DataSource = dt;
                    gvEstudiantes.DataBind();
                }
            }

            protected void btnInsertar_Click(object sender, EventArgs e)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Estudiantes (Nombre, Edad) VALUES (@Nombre, @Edad)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Edad", int.Parse(txtEdad.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                CargarEstudiantes();
            }

            // Implementar métodos similares para Actualizar, Eliminar y Buscar
        }
    }
}