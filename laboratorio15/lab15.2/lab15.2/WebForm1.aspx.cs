using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab15._2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saludos_Click(object sender, EventArgs e)
        {
            String texto = txt.Text;
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), 
                "MessageBox", "window.alert('hola:'" + texto + "');", true);

        }
    }
}