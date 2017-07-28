using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configuracion_Tecnico : System.Web.UI.Page
{
    public N_Usuarios Neg_Usarios = new N_Usuarios();
    protected void Page_Load(object sender, EventArgs e)
    {
        Busca_Usuario();
    }
    private void Busca_Usuario()
    {
        DataSet dt = new DataSet();
        dt = Neg_Usarios.Selecciona_Usuario_Cedula(Convert.ToInt32(Session["Cedula"].ToString()));

        if (dt.Tables[0].Rows.Count > 0)
        {
            Cedula.Text = dt.Tables[0].Rows[0]["CEDULA"].ToString();
            Nombre.Text = dt.Tables[0].Rows[0]["NOMBRE"].ToString();
            Cargo.Text = dt.Tables[0].Rows[0]["CARGO"].ToString();
            Disponibilidad.Text = dt.Tables[0].Rows[0]["DISPONIBLE"].ToString();
            Contra_Actual.Value = dt.Tables[0].Rows[0]["CONTRASENA"].ToString();
        }
    }

    protected void Actualiza_Click(object sender, EventArgs e)
    {
        if ((Contraseña.Text != "") && (Nueva_Contraseña1.Text != "") && (Nueva_Contraseña2.Text != ""))
        {
            if (Contra_Actual.Value == Contraseña.Text)
            {
                if (Nueva_Contraseña1.Text == Nueva_Contraseña2.Text)
                {
                    var Contra = Nueva_Contraseña2.Text;

                    var Guardar_Datos = -1;
                    Guardar_Datos = Neg_Usarios.Actualiza_Contrasena(Convert.ToInt32(Cedula.Text), Contra);

                    if (Guardar_Datos != -1)
                    {
                        string script = "alert('Actualizado Exitosamente');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                        Limpiar_Controles();
                    }
                    else
                    {
                        string script = "alert('Hubo un Error');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                    }
                }
                else
                {
                    string script = "alert('Las Nuevas Contraseñas NO Coinciden. Deben Ser Iguales');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                }
            }
            else
            {
                string script = "alert('Las contraseña Antigua NO Coincide');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
            }
        }
        else
        {
            string script = "alert('Existen Campos Vacios');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }

    private void Limpiar_Controles()
    {
        Contraseña.Text = "";
        Nueva_Contraseña1.Text = "";
        Nueva_Contraseña2.Text = "";
        Busca_Usuario();
    }
}