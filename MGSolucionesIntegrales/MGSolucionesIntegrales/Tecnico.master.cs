using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tecnico : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AddHeader("cache-control", "private");
        Response.AddHeader("pragma", "no-cache");
        Response.AddHeader("Cache-Control", "must-revalidate");
        Response.AddHeader("Cache-Control", "no-cache");

        if (Session["Id_Rol"].ToString() == "3")
        {

        }
        else
        {
            Response.Redirect("Inicio_Sesion.aspx?id=" + Session["Id_Rol"].ToString() + "");
        }
        //Nombre_Usuario.Text = Session["Nombre_Usuario"].ToString();
    }
    protected void Salir_Click(object sender, EventArgs e)
    {
        Session["Cedula"] = "";
        Session["Nombre"] = "";
        Session["Cargo"] = "";
        Session["Id_Rol"] = "";
        Response.Redirect("Inicio_Sesion.aspx");
    }
}
