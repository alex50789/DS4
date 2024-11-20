namespace Lab12._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btSemi_Click(object sender, EventArgs e)
        {
            double ladoA = double.Parse(LadoA.Text);
            double ladoB = double.Parse(LadoB.Text);
            double ladoC = double.Parse(LadoC.Text);


            double semiperimetro = (ladoA + ladoB + ladoC) / 2;


            Semi.Text = semiperimetro.ToString();
        }

        private void btTriangulo_Click(object sender, EventArgs e)
        {
            double ladoA = double.Parse(LadoA.Text);
            double ladoB = double.Parse(LadoB.Text);
            double ladoC = double.Parse(LadoC.Text);


            double semiperimetro = (ladoA + ladoB + ladoC) / 2;


            double area = Math.Sqrt(semiperimetro * (semiperimetro - ladoA) * (semiperimetro - ladoB) * (semiperimetro - ladoC));


            Triangulo.Text = area.ToString();
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            LadoA.Text = "";
            LadoB.Text = "";
            LadoC.Text = "";
            Semi.Text = "";
            Triangulo.Text = "";
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
