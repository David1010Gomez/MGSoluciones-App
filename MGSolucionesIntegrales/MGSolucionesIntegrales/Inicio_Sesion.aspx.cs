using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inicio_Sesion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Ingresar_Click(object sender, EventArgs e)
    {
        if (Cedula.Value == "1")
        {
            Response.Redirect("Inicio_Admin.aspx");
        }
        else
        {
            Response.Redirect("Inicio_Coordinador.aspx");
        }
    }
    
}