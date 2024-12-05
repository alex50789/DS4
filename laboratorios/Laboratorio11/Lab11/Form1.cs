namespace Lab11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClickThis_Click(object sender, EventArgs e)
        {
            iblHelloWorld.Text = "Hello World";
        }
    }
}
