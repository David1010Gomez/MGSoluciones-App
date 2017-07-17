using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Busqueda_Solicitudes : System.Web.UI.Page
{
    public N_Solicitud O_Neg_Solicitud = new N_Solicitud();
    public E_Solicitudes E_Solicitudes = new E_Solicitudes();
    protected void Page_Load(object sender, EventArgs e)
    {
        Listar_Tecnicos();
        Lista_Tecnicos.Attributes.Add("onchange", "Fijar_Tecnico();");
        Lista_Tecnicos_Materiales.Attributes.Add("onchange", "Fijar_Tecnico3();");
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

            Lista_Tecnicos_Materiales.DataSource = dt;
            Lista_Tecnicos_Materiales.DataTextField = "NOMBRE";
            Lista_Tecnicos_Materiales.DataValueField = "CEDULA";
            Lista_Tecnicos_Materiales.DataBind();
            Lista_Tecnicos_Materiales.Items.Insert(0, "- - SELECCIONE - -");
        }
        else
        {
            Lista_Tecnicos.Items.Clear();
            Lista_Tecnicos.Items.Insert(0, new ListItem("- - NO EXISTEN TECNICOS - -", "0"));

            Lista_Tecnicos_Materiales.Items.Clear();
            Lista_Tecnicos_Materiales.Items.Insert(0, new ListItem("- - NO EXISTEN TECNICOS - -", "0"));
        }
    }
    protected void Fecha_Inicial_TextChanged(object sender, EventArgs e)
    {
        if (Fecha_Final.Text != "")
        {
            Fecha_Final_TextChanged(sender, e);
        }

    }

    protected void Fecha_Final_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();
        var FecIni = Fecha_Inicial.Text;
        var FecFin = Fecha_Final.Text;

        dt = O_Neg_Solicitud.Consulta_Solicitudes_Fecha(FecIni, FecFin);

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
        Exp.Text = string.Empty;
        Nombre_Tecnico.Text = string.Empty;
        Listar_Tecnicos();
    }

    protected void Exp_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Consulta_Solicitudes_Exp(Convert.ToInt32(Exp.Text));

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
        Fecha_Inicial.Text = string.Empty;
        Fecha_Final.Text = string.Empty;
        Nombre_Tecnico.Text = string.Empty;
        Listar_Tecnicos();
    }

    protected void Desacarga_Base_Click(object sender, EventArgs e)
    {
        if (Fecha_Inicial.Text != "" && Fecha_Final.Text != "")
        {
            DataSet ds = new DataSet();
            var FecIni = Fecha_Inicial.Text;
            var FecFin = Fecha_Final.Text;

            ds = O_Neg_Solicitud.Consulta_Solicitudes_Fecha(FecIni, FecFin);
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        if (Exp.Text != "")
        {
            DataSet ds = new DataSet();

            ds = O_Neg_Solicitud.Consulta_Solicitudes_Exp(Convert.ToInt32(Exp.Text));
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        if (Nombre_Tecnico.Text != "")
        {
            DataSet ds = new DataSet();

            ds = O_Neg_Solicitud.Consulta_Solicitudes_Tecnico(Nombre_Tecnico.Text);
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    protected void Busqueda_Click(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Consulta_Solicitudes_Tecnico(Nombre_Tecnico.Text);

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
        Fecha_Inicial.Text = string.Empty;
        Fecha_Final.Text = string.Empty;
        Exp.Text = string.Empty;
    }



    protected void Fecha_Inicial_Notas_TextChanged(object sender, EventArgs e)
    {
        if (Fecha_Final_Notas.Text != "")
        {
            Fecha_Final_Notas_TextChanged(sender, e);
        }
    }

    protected void Fecha_Final_Notas_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();
        var FecIni = Fecha_Inicial_Notas.Text;
        var FecFin = Fecha_Final_Notas.Text;

        dt = O_Neg_Solicitud.Consulta_Notas_Solicitudes_Fecha(FecIni, FecFin);

        if (dt.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = dt.Tables[0];
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
        Exp_Notas.Text = string.Empty;
    }

    protected void Exp_Notas_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Consulta_Notas_Solicitudes_Exp(Convert.ToInt32(Exp_Notas.Text));

        if (dt.Tables[0].Rows.Count > 0)
        {
            GridView2.DataSource = dt.Tables[0];
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
        Fecha_Inicial_Notas.Text = string.Empty;
        Fecha_Final_Notas.Text = string.Empty;
    }

    protected void Fecha_Inicial_Materiales_TextChanged(object sender, EventArgs e)
    {
        if (Fecha_Final_Materiales.Text != "")
        {
            Fecha_Final_Materiales_TextChanged(sender, e);
        }
    }

    protected void Fecha_Final_Materiales_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();
        var FecIni = Fecha_Inicial_Materiales.Text;
        var FecFin = Fecha_Final_Materiales.Text;

        dt = O_Neg_Solicitud.Consulta_Materiales_Solicitudes_Fecha(FecIni, FecFin);

        if (dt.Tables[0].Rows.Count > 0)
        {
            GridView3.DataSource = dt.Tables[0];
            GridView3.DataBind();
        }
        else
        {
            GridView3.DataSource = null;
            GridView3.DataBind();
        }
        Exp_Materiales.Text = string.Empty;
        Nombre_Tecnico_Materiales.Text = string.Empty;
        Listar_Tecnicos();
    }

    protected void Exp_Materiales_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Consulta_Materiales_Solicitudes_Exp(Convert.ToInt32(Exp_Materiales.Text));

        if (dt.Tables[0].Rows.Count > 0)
        {
            GridView3.DataSource = dt.Tables[0];
            GridView3.DataBind();
        }
        else
        {
            GridView3.DataSource = null;
            GridView3.DataBind();
        }
        Fecha_Inicial_Materiales.Text = string.Empty;
        Fecha_Final_Materiales.Text = string.Empty;
        Nombre_Tecnico_Materiales.Text = string.Empty;
        Listar_Tecnicos();
    }

    protected void Busqueda_Materiales_Click(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Consulta_Materiales_Solicitudes_Tecnico(Nombre_Tecnico_Materiales.Text);

        if (dt.Tables[0].Rows.Count > 0)
        {
            GridView3.DataSource = dt.Tables[0];
            GridView3.DataBind();
        }
        else
        {
            GridView3.DataSource = null;
            GridView3.DataBind();
        }
        Fecha_Final_Materiales.Text = string.Empty;
        Fecha_Inicial_Materiales.Text = string.Empty;
        Exp_Materiales.Text = string.Empty;
    }

    protected void Desacarga_Base_Notas_Click(object sender, EventArgs e)
    {
        if (Exp_Notas.Text != "")
        {
            DataSet ds = new DataSet();

            ds = O_Neg_Solicitud.Consulta_Notas_Solicitudes_Exp(Convert.ToInt32(Exp_Notas.Text));
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Notas_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        if (Fecha_Inicial_Notas.Text != "" && Fecha_Final_Notas.Text != "")
        {
            DataSet ds = new DataSet();
            var FecIni = Fecha_Inicial_Notas.Text;
            var FecFin = Fecha_Final_Notas.Text;

            ds = O_Neg_Solicitud.Consulta_Notas_Solicitudes_Fecha(FecIni, FecFin);
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Notas_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    protected void Desacarga_Base_Materiales_Click(object sender, EventArgs e)
    {
        if (Exp_Materiales.Text != "")
        {
            DataSet ds = new DataSet();

            ds = O_Neg_Solicitud.Consulta_Materiales_Solicitudes_Exp(Convert.ToInt32(Exp_Materiales.Text));
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Materiales_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        if (Fecha_Inicial_Materiales.Text != "" && Fecha_Final_Materiales.Text != "")
        {
            DataSet ds = new DataSet();
            var FecIni = Fecha_Inicial_Materiales.Text;
            var FecFin = Fecha_Final_Materiales.Text;

            ds = O_Neg_Solicitud.Consulta_Materiales_Solicitudes_Fecha(FecIni, FecFin);
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Materiales_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        if (Nombre_Tecnico_Materiales.Text != "")
        {
            DataSet ds = new DataSet();

            ds = O_Neg_Solicitud.Consulta_Materiales_Solicitudes_Tecnico(Nombre_Tecnico_Materiales.Text);
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Materiales_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        if (Fecha_Inicial_Materiales.Text != "" && Fecha_Final_Materiales.Text != "")
        {
            Fecha_Final_Materiales_TextChanged(sender,e);
        }
        if (Exp_Materiales.Text != "")
        {
            Exp_Materiales_TextChanged(sender, e);
        }
        if (Nombre_Tecnico_Materiales.Text != "")
        {
            Busqueda_Materiales_Click(sender,e);
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        if (Fecha_Inicial_Notas.Text != "" && Fecha_Final_Notas.Text != "")
        {
            Fecha_Final_Notas_TextChanged(sender, e);
        }
        if (Exp_Notas.Text != "")
        {
            Exp_Notas_TextChanged(sender, e);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (Fecha_Inicial.Text != "" && Fecha_Final.Text != "")
        {
            Fecha_Final_TextChanged(sender, e);
        }
        if (Exp_Notas.Text != "")
        {
            Exp_TextChanged(sender, e);
        }
        if (Nombre_Tecnico.Text != "")
        {
            Busqueda_Click(sender, e);
        }
    }
}