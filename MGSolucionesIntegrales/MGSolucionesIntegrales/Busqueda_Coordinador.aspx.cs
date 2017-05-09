﻿using Negocios;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Busqueda_Coordinador : System.Web.UI.Page
{
    public N_Solicitud O_Neg_Solicitud = new N_Solicitud();
    public E_Solicitudes E_Solicitudes = new E_Solicitudes();
    protected void Page_Load(object sender, EventArgs e)
    {
        Listar_Tecnicos();
        Lista_Tecnicos.Attributes.Add("onchange", "Fijar_Tecnico();");
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
}