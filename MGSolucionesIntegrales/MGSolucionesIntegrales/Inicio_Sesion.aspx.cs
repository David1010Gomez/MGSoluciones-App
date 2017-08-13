using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inicio_Sesion : System.Web.UI.Page
{
    N_Usuarios obj_Neg_Usuarios = new N_Usuarios();
    protected void Page_Load(object sender, EventArgs e)
    {
        Cedula.Attributes.Add("autocomplete", "off");
        Contraseña.Attributes.Add("autocomplete", "off");
    }
    protected void Ingresar_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        ds = obj_Neg_Usuarios.Inicio_Sesion(Convert.ToInt32(Cedula.Text), Contraseña.Text);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["ESTADO"].ToString() == "ACTIVO")
            {
                Session["Cedula"] = ds.Tables[0].Rows[0]["CEDULA"].ToString();
                Session["Nombre"] = ds.Tables[0].Rows[0]["NOMBRE"].ToString();
                Session["Cargo"] = ds.Tables[0].Rows[0]["CARGO"].ToString();
                Session["Id_Rol"] = ds.Tables[0].Rows[0]["ID_ROL"].ToString();
                Session["Id"] = "";
                Session["Estado_Caso"] = "";

                if (Session["Id_Rol"].ToString() == "1")
                {
                    Response.Redirect("Inicio_Admin.aspx");
                }
                else
                {
                    if (Session["Id_Rol"].ToString() == "2")
                    {
                        Response.Redirect("Inicio_Coordinador.aspx");
                    }
                    else
                    {
                        if (Session["Id_Rol"].ToString() == "3")
                        {
                            Response.Redirect("Inicio_Tecnico.aspx");
                        }
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script> alert('Usuario NO se Encuentra Activo');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script> alert('Usuario o Contraseña Incorrecto');</script>");
        }
    }
    
}