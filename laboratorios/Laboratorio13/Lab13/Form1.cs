using System.Data;
using System.Data.SqlClient;
namespace Lab13
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server= DESKTOP-KVRUI1Q\SQLEXPRESS;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            MessageBox.Show("Se abrio la conexion con el servidor SQL Server y se selecciono la base de  datos");
            conexion.Close();
            MessageBox.Show("Se cerro la conexion");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
