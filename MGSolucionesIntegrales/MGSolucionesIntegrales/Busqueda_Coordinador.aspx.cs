using Negocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Busqueda_Coordinador : System.Web.UI.Page
{
    public N_Solicitud O_Neg_Solicitud = new N_Solicitud();
    protected void Page_Load(object sender, EventArgs e)
    {
        Listar_Tecnicos();
        GridView1.DataBind();
    }
    private void Listar_Tecnicos()
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Tecnicos();

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
            Lista_Tecnicos.Items.Insert(0, new ListItem("- - NO EXISTEN TECNICOS - -", "0"));
        }
    }

    protected void Fecha_Inicial_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Fecha_Final_TextChanged(object sender, EventArgs e)
    {

    }
}