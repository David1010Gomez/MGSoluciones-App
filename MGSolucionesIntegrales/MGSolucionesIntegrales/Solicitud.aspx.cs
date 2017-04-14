using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Solicitud : System.Web.UI.Page
{
    public N_Solicitud O_Neg_Solicitud = new N_Solicitud();
    public E_Solicitudes E_Solicitud = new E_Solicitudes();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView2.DataBind();
        GridView3.DataBind();
        GridView4.DataBind();
        Listar_Tecnicos();
        //string fullname1 = Request.QueryString["id"];
        //Id_Ingreso.Text = fullname1;
        Casos_Abiertos();
    }

    private void Listar_Tecnicos()
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Tecnicos_Libres();

        if (dt.Tables[0].Rows.Count > 0)
        {
            Lista_Tecnicos.DataSource = dt;
            Lista_Tecnicos.DataTextField = "NOMBRE";
            Lista_Tecnicos.DataValueField = "CEDULA";
            Lista_Tecnicos.DataBind();
            Lista_Tecnicos.Items.Insert(0, "- - SELECCIONE - -");
        }
        else
        {
            Lista_Tecnicos.Items.Clear();
            Lista_Tecnicos.Items.Insert(0, "- - NO HAY TÉCNICOS DISPONIBLES - -");
        }
    }

    protected void Guardar_Datos_Click(object sender, EventArgs e)
    {
        Guardar_Solicitud_Click();
    }
    private void Guardar_Solicitud_Click()
    {
        Controles_Objetos();
        var Guardar_Datos = -1;
        Guardar_Datos = O_Neg_Solicitud.abc_Solicitudes("INSERTAR", E_Solicitud);
        if (Guardar_Datos != -1)
        {
            //CC_Guardar_Datos_Log();
            //Limpiar_CC();
            string script1 = "mensaje1();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje1", script1, true);
            
        }
        else
        {
            string script = "mensaje2();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje2", script, true);
        }
        //Response.Redirect("Solicitud.aspx");
    }

    private void Controles_Objetos()
    {
        E_Solicitud.Id = 1;
        E_Solicitud.Num_Exp = Convert.ToInt32(Exp.Text);
        E_Solicitud.Poliza = Poliza.Text;
        E_Solicitud.Asegurado = Asegurado.Text;
        E_Solicitud.Contacto = Contacto.Text;
        E_Solicitud.Fact = Fact.Text;
        if (Convert.ToString(Lista_Tecnicos.SelectedItem) != "- - SELECCIONE - -") { E_Solicitud.Tecnico = Convert.ToString(Lista_Tecnicos.SelectedItem); } else { E_Solicitud.Tecnico = string.Empty; }
        E_Solicitud.Direccion = Direccion.Text;
        E_Solicitud.Observaciones = Observaciones.Text;
        E_Solicitud.Estado_Caso = "";
        E_Solicitud.Cedula_Usuario_Creacion = 1076;
    }

    private void Casos_Abiertos()
    {
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Casos_Abiertos();

        if (dt.Tables[0].Rows.Count > 0)
        {

            GridView1.DataSource = dt.Tables[0];
            GridView1.DataBind();

        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
}