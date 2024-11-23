using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio154
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {z

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(TextBox1.Text);
            int num2 = int.Parse(TextBox2.Text);
            int suma = num1 + num2;
            Label1.Text = "Resultado: " + suma.ToString();
        }
    }
}