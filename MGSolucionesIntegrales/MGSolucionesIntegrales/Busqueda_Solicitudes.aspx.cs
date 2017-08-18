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
    public E_Notas_Solicitudes E_Notas_Solicitudes = new E_Notas_Solicitudes();

    protected void Page_Load(object sender, EventArgs e)
    {
        Listar_Tecnicos();
        //Lista_Tecnicos.Attributes.Add("onchange", "Fijar_Tecnico();");
        Lista_Tecnicos_Materiales.Attributes.Add("onchange", "Fijar_Tecnico3();");
        Reabrir.Attributes.Add("onchange", "Cambia_Estado();");
        Valor_Trabajo_Mod.Attributes.Add("onchange", "Cambia_Valor();");
    }
    private void Listar_Tecnicos()
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Tecnicos();

        if (dt.Tables[0].Rows.Count > 0)
        {
            //Lista_Tecnicos.DataSource = dt;
            //Lista_Tecnicos.DataTextField = "NOMBRE";
            //Lista_Tecnicos.DataValueField = "CEDULA";
            //Lista_Tecnicos.DataBind();
            //Lista_Tecnicos.Items.Insert(0, "- - SELECCIONE - -");

            Lista_Tecnicos_Materiales.DataSource = dt;
            Lista_Tecnicos_Materiales.DataTextField = "NOMBRE";
            Lista_Tecnicos_Materiales.DataValueField = "CEDULA";
            Lista_Tecnicos_Materiales.DataBind();
            Lista_Tecnicos_Materiales.Items.Insert(0, "- - SELECCIONE - -");
        }
        else
        {
            //Lista_Tecnicos.Items.Clear();
            //Lista_Tecnicos.Items.Insert(0, new ListItem("- - NO EXISTEN TECNICOS - -", "0"));

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
        TotalFilas.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
    }

    protected void Exp_TextChanged(object sender, EventArgs e)
    {
        if (Exp.Text != "")
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
            TotalFilas.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
        }
        else
        {
            string script = "alert('Este Campo No Puede Ser Vacio');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
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
        TotalFilas.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
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
        TotalFilas2.Text = "Total de Resultados: "+Convert.ToString(dt.Tables[0].Rows.Count);
    }

    protected void Exp_Notas_TextChanged(object sender, EventArgs e)
    {
        if (Exp_Notas.Text != "")
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
            TotalFilas2.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
        }
        else
        {
            string script = "alert('Este Campo No Puede Ser Vacio');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
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
        TotalFilas3.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
    }

    protected void Exp_Materiales_TextChanged(object sender, EventArgs e)
    {
        if (Exp_Materiales.Text != "")
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
            TotalFilas3.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
        }
        else
        {
            string script = "alert('Este Campo No Puede Ser Vacio');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
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
        TotalFilas3.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
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
        if (Exp_Reapertura_Casos.Text != "")
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
        else
        {
            string script = "alert('Busqueda No Puede Ser Vacia');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }

    protected void Actualiza_Estado_caso_Click(object sender, EventArgs e)
    {
        if (Id_Solicitud_ReAbrir.Text != "")
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
        else
        {
            string script = "alert('Busque un Caso Antes de Guardar');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }

    protected void Busqueda_Caso_Id_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = O_Neg_Solicitud.Selecciona_Solicitud_Libre(Convert.ToInt32(Id_Caso.Text), Session["Cedula"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataSet dt = new DataSet();
            dt = O_Neg_Solicitud.Selecciona_Caso_Id(Convert.ToInt32(Id_Caso.Text));
            Limpiar_Controles_Modificacion();
            if (dt.Tables[0].Rows.Count > 0)
            {
                Id_Solicitud_Mod.Text = dt.Tables[0].Rows[0]["ID"].ToString();
                Id_Solicitud_Mod2.Text = dt.Tables[0].Rows[0]["ID"].ToString();
                Num_Exp_Mod.Text = dt.Tables[0].Rows[0]["NUM_EXP"].ToString();
                Poliza_Mod.Text = dt.Tables[0].Rows[0]["POLIZA"].ToString();
                Asegurado_Mod.Text = dt.Tables[0].Rows[0]["ASEGURADO"].ToString();
                Contacto_Mod.Text = dt.Tables[0].Rows[0]["CONTACTO"].ToString();
                Fact_Mod.Text = dt.Tables[0].Rows[0]["FACT"].ToString();
                Direccion_Mod.Text = dt.Tables[0].Rows[0]["DIRECCION"].ToString();
                Estado_Caso_Mod.Text = dt.Tables[0].Rows[0]["ESTADO_CASO"].ToString();
                Estado_Caso_Mod2.Text = dt.Tables[0].Rows[0]["ESTADO_CASO"].ToString();
                Valor_Trabajo_Mod.Text = dt.Tables[0].Rows[0]["VALOR_TRABAJO"].ToString();
                Valor_Total_Mod.Text = dt.Tables[0].Rows[0]["VALOR_TOTAL"].ToString();
                Valor_Trabajo_Mod2.Text = dt.Tables[0].Rows[0]["VALOR_TRABAJO"].ToString();
                Valor_Total_Mod2.Text = dt.Tables[0].Rows[0]["VALOR_TOTAL"].ToString();
                Valor_Total_Mod_Inicial.Text = dt.Tables[0].Rows[0]["VALOR_TOTAL"].ToString();
                Modifica_Caso.Attributes.CssStyle.Add("display","block");
                Gestionando_Caso();
            }
            else
            {
                string script3 = "alert('Este Caso No Existe. Error!!');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script3, true);

            }
        }
        else
        {
            string script3 = "alert('Este Caso Esta Siendo Editado por Otro Usuario');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script3, true);

        }
    }
    private void Limpiar_Controles_Modificacion()
    {
        Id_Solicitud_Mod.Text = "0";
        Id_Solicitud_Mod2.Text = "0";
        Num_Exp_Mod.Text = "";
        Poliza_Mod.Text = "";
        Asegurado_Mod.Text = "";
        Contacto_Mod.Text = "";
        Fact_Mod.Text = "";
        Direccion_Mod.Text = "";
        Estado_Caso_Mod.Text = "";
        Estado_Caso_Mod2.Text = "";
        Valor_Trabajo_Mod.Text = "";
        Valor_Total_Mod2.Text = "";
        Valor_Total_Mod.Text = "";
        Valor_Total_Mod2.Text = "";
        Valor_Total_Mod_Inicial.Text = "";
        Modifica_Caso.Attributes.CssStyle.Add("display", "none");
    }
    protected void Actualiza_Datos_Caso_Click(object sender, EventArgs e)
    {
        if (Valor_Trabajo_Mod.Text != "")
        {
            if (Observaciones_Mod.Text != "")
            {
                Controles_Objetos();
                var Guardar_Datos = -1;
                Guardar_Datos = O_Neg_Solicitud.abc_Solicitudes("UPDATE", E_Solicitudes);
                if (Guardar_Datos != -1)
                {
                    var Guardar_Datos2 = -1;
                    Guardar_Datos2 = O_Neg_Solicitud.Inserta_Notas_Solicitudes("INSERTAR", E_Notas_Solicitudes);
                    string script = "alert('Caso Actualizado Exitosamente');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                    Limpiar_Controles_Modificacion();
                }
                else
                {
                    string script = "alert('Error al guardar el registro');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                }
            }
            else
            {
                string script = "alert('Las Notas No Pueden Ser Vacias');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
            }
        }
        else
        {
            string script = "alert('Digite un Valor del Trabajo');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }

    private void Controles_Objetos()
    {
        E_Solicitudes.Id = Convert.ToInt32(Id_Solicitud_Mod2.Text);
        E_Solicitudes.Poliza = Poliza_Mod.Text;
        E_Solicitudes.Asegurado = Asegurado_Mod.Text;
        E_Solicitudes.Contacto = Contacto_Mod.Text;
        E_Solicitudes.Fact = Fact_Mod.Text;
        E_Solicitudes.Direccion = Direccion_Mod.Text;
        E_Solicitudes.Estado_Caso = Estado_Caso_Mod2.Text;
        E_Solicitudes.Usuario_Ultima_Actualizacion = Convert.ToInt32(Session["Cedula"].ToString());
        E_Solicitudes.Valor_Trabajo = Valor_Trabajo_Mod.Text;
        E_Solicitudes.Valor_Total = Convert.ToInt32(Valor_Total_Mod2.Text);
        E_Solicitudes.Usuario_Gestionando = "0";

        E_Notas_Solicitudes.Fecha_nota = "";
        E_Notas_Solicitudes.Num_Exp = Convert.ToInt32(Id_Solicitud_Mod2.Text);
        E_Notas_Solicitudes.Observaciones = Observaciones_Mod.Text;
        E_Notas_Solicitudes.Cedula_Usuario_Inserto_Nota = Convert.ToInt32(Session["Cedula"].ToString());
        E_Notas_Solicitudes.Estado_Caso = Estado_Caso_Mod2.Text;
    }

    private void Gestionando_Caso()
    {
        var Guardar_Datos = -1;
        Guardar_Datos = O_Neg_Solicitud.Usuario_Gestionando_Caso(Convert.ToInt32(Id_Caso.Text), Session["Cedula"].ToString());
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
        if (Fecha_Inicial_Tecnicos.Text != "" && Fecha_Final_Tecnicos.Text != "")
        {
            Fecha_Final_Tecnicos_TextChanged(sender, e);
        }
        if (Exp_Tecnicos.Text != "")
        {
            Exp_Tecnicos_TextChanged(sender, e);
        }
    }

    protected void Descraga_Base_Tecnicos_Click(object sender, EventArgs e)
    {
        if (Exp_Tecnicos.Text != "")
        {
            DataSet ds = new DataSet();

            ds = O_Neg_Solicitud.Consulta_Tecnicos_Solicitudes_Exp(Convert.ToInt32(Exp_Tecnicos.Text));
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Tecnicos_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        if (Fecha_Inicial_Tecnicos.Text != "" && Fecha_Final_Tecnicos.Text != "")
        {
            DataSet ds = new DataSet();
            var FecIni = Fecha_Inicial_Tecnicos.Text;
            var FecFin = Fecha_Final_Tecnicos.Text;

            ds = O_Neg_Solicitud.Consulta_Tecnicos_Solicitudes_Fecha(FecIni, FecFin);
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Base_Tecnicos_Solicitudes-" + DateTime.Now.ToShortDateString() + ".xls");
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

    protected void Fecha_Inicial_Tecnicos_TextChanged(object sender, EventArgs e)
    {
        if (Fecha_Final_Tecnicos.Text != "")
        {
            Fecha_Final_Tecnicos_TextChanged(sender, e);
        }
    }

    protected void Fecha_Final_Tecnicos_TextChanged(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();
        var FecIni = Fecha_Inicial_Tecnicos.Text;
        var FecFin = Fecha_Final_Tecnicos.Text;

        dt = O_Neg_Solicitud.Consulta_Tecnicos_Solicitudes_Fecha(FecIni, FecFin);

        if (dt.Tables[0].Rows.Count > 0)
        {
            GridView4.DataSource = dt.Tables[0];
            GridView4.DataBind();
        }
        else
        {
            GridView4.DataSource = null;
            GridView4.DataBind();
        }
        Exp_Tecnicos.Text = string.Empty;
        //Nombre_Tecnico_Materiales.Text = string.Empty;
        Listar_Tecnicos();
        TotalFilas4.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
    }

    protected void Exp_Tecnicos_TextChanged(object sender, EventArgs e)
    {
        if (Exp_Tecnicos.Text != "")
        {
            DataSet dt = new DataSet();

            dt = O_Neg_Solicitud.Consulta_Tecnicos_Solicitudes_Exp(Convert.ToInt32(Exp_Tecnicos.Text));

            if (dt.Tables[0].Rows.Count > 0)
            {
                GridView4.DataSource = dt.Tables[0];
                GridView4.DataBind();
            }
            else
            {
                GridView4.DataSource = null;
                GridView4.DataBind();
            }
            Fecha_Inicial_Tecnicos.Text = string.Empty;
            Fecha_Final_Tecnicos.Text = string.Empty;
            //Nombre_Tecnico_Materiales.Text = string.Empty;
            Listar_Tecnicos();
            TotalFilas4.Text = "Total de Resultados: " + Convert.ToString(dt.Tables[0].Rows.Count);
        }
        else
        {
            string script = "alert('Este Campo No Puede Ser Vacio');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }

    protected void Liquidar_Click(object sender, EventArgs e)
    {
        var Guardar_Datos = -1;
        Guardar_Datos = O_Neg_Solicitud.Liquida_Tecnicos_Solicitudes(Convert.ToInt32(Id_Solicitud_Liquida.Text), Convert.ToInt32(Cedula_Liquidado.Text), Liquidado.Text);
        if (Guardar_Datos != -1)
        {
            string script = "alert('Actualizacion Exitosa');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
            LiqTecni.Attributes.CssStyle.Add("display", "none");
        }
    }

    protected void LiquidarAccion_Click(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Busca_Tecnicos_Solicitud("INSERTAR", Convert.ToInt32(Id_Solicitud_Liquida.Text), Convert.ToInt32(Cedula_Liquidado.Text));
        if (dt.Tables[0].Rows.Count > 0)
        {
            Nombre_Liquidado.Text = dt.Tables[0].Rows[0]["NOMBRE_TECNICO"].ToString();
            Liquidado.Text = dt.Tables[0].Rows[0]["LIQUIDADO"].ToString();
            LiqTecni.Attributes.CssStyle.Add("display","block");
        }
    }
}