namespace Lab12._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calcular_Click(object sender, EventArgs e)
        {
            try
            {
                double nota1 = double.Parse(N1.Text);
                double nota2 = double.Parse(N2.Text);
                double nota3 = double.Parse(N3.Text);
                double promedio = (nota1 + nota2 + nota3) / 3;
                Resultado.Text = promedio.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, ingrese notas válidas.");
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            N1.Clear();
            N2.Clear();
            N3.Clear();
            Resultado.Clear();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
