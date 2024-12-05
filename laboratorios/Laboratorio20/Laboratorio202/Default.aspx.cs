using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio202
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtN.Text, out int n) && n > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table border='1'>");
                for (int i = 0; i < n; i++)
                {
                    sb.Append("<tr>");
                    for (int j = 0; j < n; j++)
                    {
                        sb.AppendFormat("<td>{0}</td>", (i + j == n - 1) ? "1" : "0");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                litResultado.Text = sb.ToString();
            }
            else
            {
                litResultado.Text = "Por favor, ingrese un número válido mayor que 0.";
            }
        }
    }
}