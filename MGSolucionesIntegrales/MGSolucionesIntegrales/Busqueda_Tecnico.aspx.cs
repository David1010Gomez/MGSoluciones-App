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

public partial class Busqueda_Tecnico : System.Web.UI.Page
{
    public N_Solicitud O_Neg_Solicitud = new N_Solicitud();
    public E_Solicitudes E_Solicitudes = new E_Solicitudes();
    E_Solicitudes Obj_E_Solicitudes = new E_Solicitudes();
    protected void Page_Load(object sender, EventArgs e)
    {

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
        Obj_E_Solicitudes.Fecha_Inicial = Fecha_Inicial.Text;
        Obj_E_Solicitudes.Fecha_Final = Fecha_Final.Text;

        dt = O_Neg_Solicitud.Consulta_Solicitudes_Fecha_Tecnico(Obj_E_Solicitudes.Fecha_Inicial, Obj_E_Solicitudes.Fecha_Final, Convert.ToInt32(Session["Cedula"].ToString()));

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
        
    }

    protected void Exp_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Consulta_Solicitudes_Exp_Tecnico(Convert.ToInt32(Exp.Text), Convert.ToInt32(Session["Cedula"].ToString()));

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

        dt = O_Neg_Solicitud.Consulta_Materiales_Fecha_Tecnico(FecIni, FecFin, Convert.ToInt32(Session["Cedula"].ToString()));

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
        Exp_Materiales.Text = string.Empty;
    }

    protected void Exp_Materiales_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Consulta_Materiales_Exp_Tecnico(Convert.ToInt32(Exp_Materiales.Text), Convert.ToInt32(Session["Cedula"].ToString()));

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
        Fecha_Inicial_Materiales.Text = string.Empty;
        Fecha_Final_Materiales.Text = string.Empty;
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if ((Fecha_Inicial.Text != "") && (Fecha_Final.Text != ""))
        {
            Fecha_Final_TextChanged(sender, e);
        }
        if (Exp.Text != "")
        {
            Exp_TextChanged(sender, e);
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        if (Fecha_Inicial_Materiales.Text != "" && Fecha_Final_Materiales.Text != "")
        {
            Fecha_Final_Materiales_TextChanged(sender, e);
        }
        if (Exp_Materiales.Text != "")
        {
            Exp_Materiales_TextChanged(sender, e);
        }
    }

    protected void Desacarga_Base_Click(object sender, EventArgs e)
    {
        if (Fecha_Inicial.Text != "" && Fecha_Final.Text != "")
        {
            DataSet ds = new DataSet();
            var FecIni = Fecha_Inicial.Text;
            var FecFin = Fecha_Final.Text;

            ds = O_Neg_Solicitud.Consulta_Solicitudes_Fecha_Tecnico(FecIni, FecFin, Convert.ToInt32(Session["Cedula"].ToString()));
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Solicitudes_Tecnico-" + DateTime.Now.ToShortDateString() + ".xls");
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

            ds = O_Neg_Solicitud.Consulta_Solicitudes_Exp_Tecnico(Convert.ToInt32(Exp.Text), Convert.ToInt32(Session["Cedula"].ToString()));
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Solicitudes_Tecnico-" + DateTime.Now.ToShortDateString() + ".xls");
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

            ds = O_Neg_Solicitud.Consulta_Materiales_Exp_Tecnico(Convert.ToInt32(Exp_Materiales.Text), Convert.ToInt32(Session["Cedula"].ToString()));
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Materiales_Tecnico-" + DateTime.Now.ToShortDateString() + ".xls");
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

            ds = O_Neg_Solicitud.Consulta_Materiales_Fecha_Tecnico(FecIni, FecFin, Convert.ToInt32(Session["Cedula"].ToString()));
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Materiales_Tecnico-" + DateTime.Now.ToShortDateString() + ".xls");
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
}