namespace labo12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double velocidad = Convert.ToDouble(Variable1.Text);
                double tiempo = Convert.ToDouble(Variable2.Text);
                double distancia = velocidad * tiempo;

                resultado.Text = distancia.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos.");
            }

        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            Variable1.Clear();
            Variable2.Clear();
            resultado.Clear();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
