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
    public E_Solicitudes Obj_E_Solicitudes = new E_Solicitudes();
    public E_Usuarios Obj_Usuarios = new E_Usuarios();
    public E_Log_Aplazamientos E_L_Aplazamientos = new E_Log_Aplazamientos();
    public E_Notas_Solicitudes Notas_Solicitudes = new E_Notas_Solicitudes();
    public E_Turnos E_Turnos = new E_Turnos();

    protected void Page_Load(object sender, EventArgs e)
    {
        Listar_Tecnicos();
        Lista_Tecnicos.Attributes.Add("onchange", "Fijar_Tecnico();");
        Lista_Tecnicos_Materiales.Attributes.Add("onchange", "Fijar_Tecnico3();");
        Reabrir.Attributes.Add("onchange", "Cambia_Estado();");
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
        
        dt = O_Neg_Solicitud.Consulta_Solicitudes_Fecha(Fecha_Inicial.Text, Fecha_Final.Text);

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
        TotalFilas.Text = "Total de Resultados: " + Convert.ToString(GridView1.Rows.Count);
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
        TotalFilas.Text = "Total de Resultados: " + Convert.ToString(GridView1.Rows.Count);
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
        TotalFilas.Text = "Total de Resultados: " + Convert.ToString(GridView1.Rows.Count);
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
        TotalFilas2.Text = "Total de Resultados: "+Convert.ToString(GridView2.Rows.Count);
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
        TotalFilas2.Text = "Total de Resultados: " + Convert.ToString(GridView2.Rows.Count);
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
        TotalFilas3.Text = "Total de Resultados: " + Convert.ToString(GridView3.Rows.Count);
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
        TotalFilas3.Text = "Total de Resultados: " + Convert.ToString(GridView3.Rows.Count);
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
        TotalFilas3.Text = "Total de Resultados: " + Convert.ToString(GridView3.Rows.Count);
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

    protected void Exp_Reapertura_Casos_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Consulta_Solicitudes_Exp(Convert.ToInt32(Exp_Reapertura_Casos.Text));
        if (dt.Tables[0].Rows.Count > 0)
        {
            if (dt.Tables[0].Rows[0]["ESTADO_CASO"].ToString() == "CERRADO")
            {
                Id_Solicitud_ReAbrir.Text = dt.Tables[0].Rows[0]["ID"].ToString();
                NumExpReaAbrir.Text = dt.Tables[0].Rows[0]["NUM_EXP"].ToString();
                EstadoReaAbrir.Text = dt.Tables[0].Rows[0]["ESTADO_CASO"].ToString();
            }
            else
            {
                string script = "alert('Solo se Pueden ReAbrir los Casos Cerrados');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                Id_Solicitud_ReAbrir.Text = "";
                NumExpReaAbrir.Text = "";
                EstadoReaAbrir.Text = "";
            }
        }
        else
        {
            string script = "alert('Caso no existe');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
            Id_Solicitud_ReAbrir.Text = "";
            NumExpReaAbrir.Text = "";
            EstadoReaAbrir.Text = "";
            Reabrir.Checked = false;
        }
    }

    protected void Actualiza_Estado_caso_Click(object sender, EventArgs e)
    {
        if (Notas_Reapertura.Text != "")
        {
            Obj_E_Solicitudes.Id = Convert.ToInt32(Id_Solicitud_ReAbrir.Text);
            Obj_E_Solicitudes.Estado_Caso = Cambio_Estado.Text;

            var Guardar_Datos = -1;
            Guardar_Datos = O_Neg_Solicitud.Actualiza_Estado_Caso(Obj_E_Solicitudes);
            if (Guardar_Datos != -1)
            {
                DataSet dt = new DataSet();
                dt = O_Neg_Solicitud.Busca_Tecnicos_Solicitud("LISTAR", Convert.ToInt32(Id_Solicitud_ReAbrir.Text), 0);
                int i = 0;
                foreach (var l in dt.Tables[0].Rows)
                {
                    Obj_Usuarios.Cedula = Convert.ToInt32(dt.Tables[0].Rows[i]["CEDULA_TECNICO"].ToString());
                    Obj_Usuarios.Disponible = "OCUPADO";
                    var Guardar_Datos2 = -1;
                    Guardar_Datos2 = O_Neg_Solicitud.Actualiza_Estado_Tecnico(Obj_Usuarios);

                    E_L_Aplazamientos.Id_Solicitud = Convert.ToInt32(Id_Solicitud_ReAbrir.Text);
                    E_L_Aplazamientos.Cedula_Tecnico = Convert.ToInt32(dt.Tables[0].Rows[i]["CEDULA_TECNICO"].ToString());
                    E_L_Aplazamientos.Trabajo = "RE ABIERTO ADMINISTRADOR";
                    var Guardar_Datos3 = -1;
                    Guardar_Datos3 = O_Neg_Solicitud.Insertar_Log_Aplazamientos(E_L_Aplazamientos);

                    i++;
                }

                Notas_Solicitudes.Fecha_nota = "";
                Notas_Solicitudes.Num_Exp = Convert.ToInt32(Id_Solicitud_ReAbrir.Text);
                Notas_Solicitudes.Observaciones = Notas_Reapertura.Text;
                Notas_Solicitudes.Cedula_Usuario_Inserto_Nota = Convert.ToInt32(Session["Cedula"].ToString());
                Notas_Solicitudes.Estado_Caso = EstadoReaAbrir.Text;
                var Guardar_Datos4 = -1;
                Guardar_Datos4 = O_Neg_Solicitud.Inserta_Notas_Solicitudes("INSERTAR", Notas_Solicitudes);

                E_Turnos.Num_Exp = Convert.ToInt32(Id_Solicitud_ReAbrir.Text);
                E_Turnos.Trabajo = "REABIERTO ADMINISTRADOR";
                var Guardar_Datos5 = -1;
                Guardar_Datos5 = O_Neg_Solicitud.abc_Turnos("UPDATE TRABAJO", E_Turnos);


                string script = "alert('Caso ReAbierto Exitosamente');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);

                Exp_Reapertura_Casos.Text = "";
                Id_Solicitud_ReAbrir.Text = "";
                NumExpReaAbrir.Text = "";
                EstadoReaAbrir.Text = "";
                Reabrir.Checked = false;
                Cambio_Estado.Text = "";
            }
            else
            {
                string script = "alert('No se Guardo la actualizacion del estado del Caso, Tecnicos ni Notas');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
            }
        }
        else
        {
            string script = "alert('Las Notas No Pueden ser Vacias');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }
}