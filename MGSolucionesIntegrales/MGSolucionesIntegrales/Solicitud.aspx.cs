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
    public E_Turnos E_Turnos = new E_Turnos();
    public E_Notas_Solicitudes E_Notas_Solicitudes = new E_Notas_Solicitudes();

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView2.DataBind();
        GridView3.DataBind();
        GridView4.DataBind();
        Exp.Attributes.Add("onblur", "Bucar_Tecni();");
        Exp.Attributes.Add("onchange", "Bucar_Tecni();");
        CHCerrarCaso.Attributes.Add("onchange", "Cambia_Estado();");
        Casos_Abiertos();
        Casos_Asignados();
        Casos_Agendados();
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
        E_Solicitud.Tecnico = Convert.ToString(Lista_Tecnicos.SelectedItem);
        Guardar_Solicitud_Click();
    }
    private void Guardar_Solicitud_Click()
    {
        if (Exp.Text != "")
        {
            if ((Convert.ToString(Lista_Tecnicos.SelectedItem) != "- - SELECCIONE - -"))
            {
                Controles_Objetos();
                var Guardar_Datos = -1;
                Guardar_Datos = O_Neg_Solicitud.abc_Solicitudes(Accion.Text, E_Solicitud);
                if (Guardar_Datos != -1)
                {
                    if (E_Solicitud.Tecnico != string.Empty) { Guarda_Turno_Tecnico(); } 
                      
                    Guardar_Notas();
                    Limpiar_Controles();
                    string script1 = "mensaje1();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje1", script1, true);
                    Casos_Abiertos();
                    Casos_Asignados();
                    Casos_Agendados();
                    //Response.Redirect("Solicitud.aspx");
                }
                else
                {
                    string script = "mensaje2();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje2", script, true);
                }
            }
            else {
                string script = "mensaje3();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje3", script, true);
            }
        } else {
            string script = "mensaje4();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje4", script, true);
        }
    }

    private void Guardar_Notas()
    {
        var Guardar_Datos = -1;
        Guardar_Datos = O_Neg_Solicitud.Inserta_Notas_Solicitudes("INSERTAR", E_Notas_Solicitudes);
    }

    private void Controles_Objetos()
    {
        E_Solicitud.Id = Convert.ToInt32(ID_CASO.Text);
        E_Solicitud.Num_Exp = Convert.ToInt32(Exp.Text);
        E_Solicitud.Poliza = Poliza.Text;
        E_Solicitud.Asegurado = Asegurado.Text;
        E_Solicitud.Contacto = Contacto.Text;
        E_Solicitud.Fact = Fact.Text;
        if ((Convert.ToString(Lista_Tecnicos.SelectedItem) != "- - NO HAY TÉCNICOS DISPONIBLES - -")) { E_Solicitud.Tecnico = Convert.ToString(Lista_Tecnicos.SelectedItem); } else { E_Solicitud.Tecnico = string.Empty; }
        E_Solicitud.Direccion = Direccion.Text;
        if ((Convert.ToString(Lista_Tecnicos.SelectedItem) == "- - NO HAY TÉCNICOS DISPONIBLES - -"))
        {
            E_Solicitud.Estado_Caso = "ABIERTO";
        }
        else { if (Fecha_Agendamiento.Text != "") { E_Solicitud.Estado_Caso = "AGENDADO"; } else { E_Solicitud.Estado_Caso = "ASIGNADO"; } }
        if (CHCerrarCaso.Checked == true) { E_Solicitud.Estado_Caso = "CERRADO"; }
        E_Solicitud.Cedula_Usuario_Creacion = 1076;
        E_Solicitud.Fecha_Cierre = DateTime.Now;
        E_Solicitud.Cedula_Usuario_Cierre = 2569;
        E_Solicitud.Usuario_Ultima_Actualizacion = 555;

        E_Turnos.Id = Convert.ToInt32(ID_TURNO.Text);
        if ((Convert.ToString(Lista_Tecnicos.SelectedItem) != "- - NO HAY TÉCNICOS DISPONIBLES - -")) { E_Turnos.Cedula_Tecnico = Convert.ToInt32(Lista_Tecnicos.SelectedValue); }
        //E_Turnos.Cedula_Tecnico = Convert.ToInt32(E_Solicitud.Tecnico);
        E_Turnos.Num_Exp = Convert.ToInt32(ID_CASO.Text);
        E_Turnos.Fecha_Turno = Fecha_Agendamiento.Text;

        E_Notas_Solicitudes.Fecha_nota = "";
        E_Notas_Solicitudes.Num_Exp = Convert.ToInt32(Exp.Text);
        E_Notas_Solicitudes.Observaciones = Observaciones.Text;
        E_Notas_Solicitudes.Cedula_Usuario_Inserto_Nota = 123;
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
    private void Casos_Asignados()
    {
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Casos_Asignados();

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
    }
    private void Casos_Agendados()
    {
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Casos_Agendados();

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
    }

    private void Limpiar_Controles()
    {
        Exp.Text = string.Empty;
        Poliza.Text = string.Empty;
        Asegurado.Text=string.Empty;
        Contacto.Text=string.Empty;
        Fact.Text=string.Empty;
        Lista_Tecnicos.ClearSelection();
        Lista_Tecnicos.Items.Clear();
        Direccion.Text=string.Empty;
        Observaciones.Text=string.Empty;
        Estado_Caso_Creacion.Text = "";
        Accion.Text = "INSERTAR";
        Accion_Tecnico.Text = "INSERTAR";
        Fecha_Agendamiento.Text = string.Empty;
        CHCerrarCaso.Checked = false;
        Fecha_Agendamiento.Attributes.CssStyle.Add("display", "none");
        lblFecha_Agendamiento.Attributes.CssStyle.Add("display", "none");
        CHCerrarCaso.Attributes.CssStyle.Add("display", "none");
        lblCerrarCaso.Attributes.CssStyle.Add("display", "none");
    }

    protected void Cargar_Caso_Abierto_Click(object sender, EventArgs e)
    {
        E_Solicitud.Id = Convert.ToInt32(ID_CASO.Text);
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Selecciona_Solicitudes(E_Solicitud.Id);
        Limpiar_Controles();
        if (dt.Tables[0].Rows.Count > 0)
        {
            ID_CASO.Text = dt.Tables[0].Rows[0]["ID"].ToString();
            Exp.Text = dt.Tables[0].Rows[0]["NUM_EXP"].ToString();
            Poliza.Text= dt.Tables[0].Rows[0]["POLIZA"].ToString();
            Asegurado.Text = dt.Tables[0].Rows[0]["ASEGURADO"].ToString();
            Contacto.Text = dt.Tables[0].Rows[0]["CONTACTO"].ToString();
            Fact.Text = dt.Tables[0].Rows[0]["FACT"].ToString();
            Direccion.Text = dt.Tables[0].Rows[0]["DIRECCION"].ToString();
            Listar_Tecnicos();
            Accion.Text = "UPDATE";
            Accion_Tecnico.Text = "INSERTAR";
        }
        else
        {
            string script3 = "mensaje5();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje5", script3, true);

        }

    }
    protected void Cargar_Tecnicos_Click(object sender, EventArgs e)
    {
        Listar_Tecnicos();
    }

    private void Guarda_Turno_Tecnico()
    {
        var Guardar_Datos = -1;
        Guardar_Datos = O_Neg_Solicitud.abc_Turnos(Accion_Tecnico.Text, E_Turnos);
        if (Guardar_Datos != -1)
        {
            //string script1 = "mensaje1();";
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje1", script1, true);
            //Casos_Abiertos();
            ////Response.Redirect("Solicitud.aspx");
        }
        else
        {
            //string script = "mensaje2();";
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje2", script, true);
        }
    }

    protected void Cargar_Caso_Asignado_Click(object sender, EventArgs e)
    {
        E_Solicitud.Id = Convert.ToInt32(ID_CASO.Text);
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Selecciona_Solicitudes(E_Solicitud.Id);
        Limpiar_Controles();
        if (dt.Tables[0].Rows.Count > 0)
        {
            ID_CASO.Text = dt.Tables[0].Rows[0]["ID"].ToString();
            Exp.Text = dt.Tables[0].Rows[0]["NUM_EXP"].ToString();
            Poliza.Text = dt.Tables[0].Rows[0]["POLIZA"].ToString();
            Asegurado.Text = dt.Tables[0].Rows[0]["ASEGURADO"].ToString();
            Contacto.Text = dt.Tables[0].Rows[0]["CONTACTO"].ToString();
            Fact.Text = dt.Tables[0].Rows[0]["FACT"].ToString();
            Direccion.Text = dt.Tables[0].Rows[0]["DIRECCION"].ToString();
            Estado_Caso_Creacion.Text = "AGENDADO";
            Lista_Tecnicos.Items.Insert(0, new ListItem(dt.Tables[0].Rows[0]["TECNICO"].ToString(),"0"));
            Accion.Text = "UPDATE";
            Accion_Tecnico.Text = "UPDATE";
            Fecha_Agendamiento.Attributes.CssStyle.Add("display","block");
            lblFecha_Agendamiento.Attributes.CssStyle.Add("display", "block");
        }
        else
        {
            string script3 = "mensaje5();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje5", script3, true);

        }
    }

    protected void Cargar_Caso_Agendado_Click(object sender, EventArgs e)
    {
        E_Solicitud.Id = Convert.ToInt32(ID_CASO.Text);
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Selecciona_Solicitudes(E_Solicitud.Id);
        Limpiar_Controles();
        if (dt.Tables[0].Rows.Count > 0)
        {
            ID_CASO.Text = dt.Tables[0].Rows[0]["ID"].ToString();
            Exp.Text = dt.Tables[0].Rows[0]["NUM_EXP"].ToString();
            Poliza.Text = dt.Tables[0].Rows[0]["POLIZA"].ToString();
            Asegurado.Text = dt.Tables[0].Rows[0]["ASEGURADO"].ToString();
            Contacto.Text = dt.Tables[0].Rows[0]["CONTACTO"].ToString();
            Fact.Text = dt.Tables[0].Rows[0]["FACT"].ToString();
            Direccion.Text = dt.Tables[0].Rows[0]["DIRECCION"].ToString();
            Estado_Caso_Creacion.Text = "CERRADO";
            Lista_Tecnicos.Items.Insert(0, new ListItem(dt.Tables[0].Rows[0]["TECNICO"].ToString(), "0"));
            Accion.Text = "UPDATE";
            Accion_Tecnico.Text = "UPDATE";
            Fecha_Agendamiento.Attributes.CssStyle.Add("display", "block");
            lblFecha_Agendamiento.Attributes.CssStyle.Add("display", "block");
            lblCerrarCaso.Attributes.CssStyle.Add("display", "block");
            CHCerrarCaso.Attributes.CssStyle.Add("display", "block");
            DataSet ds = new DataSet();
            ds = O_Neg_Solicitud.Seleccionar_Turnos(Convert.ToInt32(ID_CASO.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Fecha_Agendamiento.Text = ds.Tables[0].Rows[0]["FECHA_TURNO"].ToString(); ;
            }
        }
        else
        {
            string script3 = "mensaje5();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje5", script3, true);

        }
    }

    
}