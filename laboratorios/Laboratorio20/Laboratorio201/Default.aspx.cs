using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio201
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumero.Text, out int numero))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='1'>");
                for (int i = 1; i <= 25; i++)
                {
                    sb.AppendFormat("<tr><td>{0} x {1} = {2}</td></tr>", numero, i, numero * i);
                }
                sb.Append("</table>");
                litResultado.Text = sb.ToString();
            }
            else
            {
                litResultado.Text = "Por favor, ingrese un número válido.";
            }
        }
    }
}