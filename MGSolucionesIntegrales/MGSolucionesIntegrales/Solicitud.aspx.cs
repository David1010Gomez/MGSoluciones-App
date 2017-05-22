using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Solicitud : System.Web.UI.Page
{
    public N_Solicitud O_Neg_Solicitud = new N_Solicitud();
    public E_Solicitudes E_Solicitud = new E_Solicitudes();
    public E_Materiales_Solicitudes E_Materiales_Solicitudes = new E_Materiales_Solicitudes();
    public E_Turnos E_Turnos = new E_Turnos();
    public E_Notas_Solicitudes E_Notas_Solicitudes = new E_Notas_Solicitudes();
    public E_Materiales E_Materiales = new E_Materiales();
    public E_Usuarios E_Usuarios = new E_Usuarios();
    public E_Tecnicos_Solicitudes E_Tecni_Solicitudes = new E_Tecnicos_Solicitudes();

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

    private void Materiales_A_Agregar()
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Materiales_a_Agregar();

        if (dt.Tables[0].Rows.Count > 0)
        {
            Select_Materiales.DataSource = dt;
            Select_Materiales.DataTextField = "MATERIAL";
            Select_Materiales.DataValueField = "ID";
            Select_Materiales.DataBind();
            Select_Materiales.Items.Insert(0, "- - SELECCIONE - -");
        }
        else
        {
            Select_Materiales.Items.Clear();
            Select_Materiales.Items.Insert(0, "- - NO HAY MATERIALES - -");
        }
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
            Lista_Tecnicos.Items.Insert(0, new ListItem("- - NO HAY TÉCNICOS DISPONIBLES - -", "0"));
        }
    }

    protected void Guardar_Datos_Click(object sender, EventArgs e)
    {
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
                    if (E_Tecni_Solicitudes.Nombre_Tecnico != string.Empty) { Guarda_Turno_Tecnico(); } 
                    Guardar_Notas();
                    Guarda_Tecnico_Solicitud();
                    Limpiar_Controles();
                    Limpiar_Controles_Materiales();
                    string script1 = "mensaje1();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje1", script1, true);
                    Casos_Abiertos();
                    Casos_Asignados();
                    Casos_Agendados();
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

    private void Guarda_Tecnico_Solicitud()
    {
        if (E_Tecni_Solicitudes.Nombre_Tecnico != "")
        {
            DataSet dt = new DataSet();
            dt = O_Neg_Solicitud.Busca_Tecnicos_Solicitud("INSERTAR", E_Tecni_Solicitudes.Id_Solicitud, E_Tecni_Solicitudes.Cedula_Tecnico);
            if (dt.Tables[0].Rows.Count == 0)
            {
                var Guardar_Datos = -1;
                Guardar_Datos = O_Neg_Solicitud.Inserta_Tecnico_Solicitudes(E_Tecni_Solicitudes);
            }
        }
    }

    private void Guardar_Notas()
    {
        if (E_Solicitud.Id == 0)
        {
            Selecciona_Max_ID();
        }
        var Guardar_Datos = -1;
        Guardar_Datos = O_Neg_Solicitud.Inserta_Notas_Solicitudes("INSERTAR", E_Notas_Solicitudes);
    }
    private void Selecciona_Max_ID()
    {
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Seleccionar_Maximo_ID(Convert.ToInt32(Exp.Text));
        E_Solicitud.Id = Convert.ToInt32(dt.Tables[0].Rows[0]["ID"].ToString());
        E_Turnos.Num_Exp = Convert.ToInt32(dt.Tables[0].Rows[0]["ID"].ToString());
        E_Tecni_Solicitudes.Id_Solicitud = Convert.ToInt32(dt.Tables[0].Rows[0]["ID"].ToString());
        E_Notas_Solicitudes.Num_Exp = Convert.ToInt32(dt.Tables[0].Rows[0]["ID"].ToString());
    }

    private void Controles_Objetos()
    {
        E_Solicitud.Id = Convert.ToInt32(ID_CASO.Text);
        E_Solicitud.Num_Exp = Convert.ToInt32(Exp.Text);
        E_Solicitud.Poliza = Poliza.Text;
        E_Solicitud.Asegurado = Asegurado.Text;
        E_Solicitud.Contacto = Contacto.Text;
        E_Solicitud.Fact = Fact.Text;
        E_Solicitud.Direccion = Direccion.Text;
        if ((Convert.ToString(Lista_Tecnicos.SelectedItem) == "- - NO HAY TÉCNICOS DISPONIBLES - -") && Estado_Caso_Creacion.Text == "ABIERTO")
        {
            E_Solicitud.Estado_Caso = "ABIERTO";
        }
        else
        {
            if (Fecha_Agendamiento.Text == "" && Estado_Caso_Creacion.Text == "ASIGNADO")
            {
                E_Solicitud.Estado_Caso = "ASIGNADO";
            }
            else
            {
                E_Solicitud.Estado_Caso = "AGENDADO";
            }
        }
        if (CHCerrarCaso.Checked == true) { E_Solicitud.Estado_Caso = "CERRADO"; }
        if (E_Solicitud.Estado_Caso == "ABIERTO" || E_Solicitud.Estado_Caso == "AGENDADO" || E_Solicitud.Estado_Caso == "ASIGNADO") { E_Turnos.Trabajo = "OCUPADO"; }
        if (E_Solicitud.Estado_Caso == "CERRADO") { E_Turnos.Trabajo = "TERMINADO"; }
        E_Solicitud.Cedula_Usuario_Creacion = 1076;
        E_Solicitud.Fecha_Cierre = DateTime.Now;
        E_Solicitud.Cedula_Usuario_Cierre = 2569;
        E_Solicitud.Usuario_Ultima_Actualizacion = 555;

        E_Tecni_Solicitudes.Id_Solicitud = Convert.ToInt32(ID_CASO.Text);
        E_Tecni_Solicitudes.Cedula_Tecnico = Convert.ToInt32(Lista_Tecnicos.SelectedValue);
        if ((Convert.ToString(Lista_Tecnicos.SelectedItem) != "- - NO HAY TÉCNICOS DISPONIBLES - -")) { E_Tecni_Solicitudes.Nombre_Tecnico = Convert.ToString(Lista_Tecnicos.SelectedItem); }
        else { E_Tecni_Solicitudes.Nombre_Tecnico = string.Empty; }

        E_Turnos.Id = Convert.ToInt32(ID_TURNO.Text);
        if ((Convert.ToString(Lista_Tecnicos.SelectedItem) != "- - NO HAY TÉCNICOS DISPONIBLES - -")) { E_Turnos.Cedula_Tecnico = Convert.ToInt32(Lista_Tecnicos.SelectedValue); }
        //E_Turnos.Cedula_Tecnico = Convert.ToInt32(E_Solicitud.Tecnico);
        E_Turnos.Num_Exp = Convert.ToInt32(ID_CASO.Text);
        E_Turnos.Fecha_Turno = Fecha_Agendamiento.Text;

        E_Notas_Solicitudes.Fecha_nota = "";
        E_Notas_Solicitudes.Num_Exp = Convert.ToInt32(ID_CASO.Text);
        E_Notas_Solicitudes.Observaciones = Observaciones.Text;
        E_Notas_Solicitudes.Cedula_Usuario_Inserto_Nota = 123;
        
    }
    private void Controles_Objetos_Solicitud()
    {
        E_Materiales_Solicitudes.Id_Solicitud = Convert.ToInt32(ID_CASO.Text);
        E_Materiales_Solicitudes.Id_Material = Convert.ToInt32(Select_Materiales.SelectedValue);
        E_Materiales_Solicitudes.Cantidad = CantidadMaterial.Text;
        E_Materiales_Solicitudes.Cedula_Tecnico = Convert.ToInt32(Lista_Tecnicos.SelectedValue);
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
        Div_Materiales.Attributes.CssStyle.Add("display", "none");
        Div_Agrega_Tecnicos.Attributes.CssStyle.Add("display","none");
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
            Estado_Caso_Creacion.Text = "ASIGNADO";
            Div_Agrega_Tecnicos.Attributes.CssStyle.Add("display", "none");
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
        if (E_Solicitud.Id == 0)
        {
            Selecciona_Max_ID();
        }
        var Guardar_Datos = -1;
        Guardar_Datos = O_Neg_Solicitud.abc_Turnos(Accion_Tecnico.Text, E_Turnos);


        if (E_Solicitud.Estado_Caso == "AGENDADO" || E_Solicitud.Estado_Caso == "ASIGNADO")
        {
            E_Usuarios.Cedula = Convert.ToInt32(Lista_Tecnicos.SelectedValue);
            E_Usuarios.Disponible = "OCUPADO";
            var Guardar_Datos2 = -1;
            Guardar_Datos2 = O_Neg_Solicitud.Actualiza_Estado_Tecnico(E_Usuarios);
        }
        else if (E_Solicitud.Estado_Caso == "CERRADO")
        {
            E_Usuarios.Cedula = Convert.ToInt32(Lista_Tecnicos.SelectedValue);
            E_Usuarios.Disponible = "DISPONIBLE";
            var Guardar_Datos2 = -1;
            Guardar_Datos2 = O_Neg_Solicitud.Actualiza_Estado_Tecnico(E_Usuarios);
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
            Carga_Tecnicos_solicitud();
            Accion.Text = "UPDATE";
            Accion_Tecnico.Text = "UPDATE";
            Fecha_Agendamiento.Attributes.CssStyle.Add("display","block");
            lblFecha_Agendamiento.Attributes.CssStyle.Add("display", "block");
            Div_Materiales.Attributes.CssStyle.Add("display","block");
            Materiales_A_Agregar();
            Tabla_Materiales_Solicitud();
            Div_Agrega_Tecnicos.Attributes.CssStyle.Add("display", "block");
        }
        else
        {
            string script3 = "mensaje5();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje5", script3, true);

        }
    }

    private void Carga_Tecnicos_solicitud()
    {
        DataSet dt = new DataSet();

        dt = O_Neg_Solicitud.Busca_Tecnicos_Solicitud("LISTAR", Convert.ToInt32(ID_CASO.Text), 0);

        if (dt.Tables[0].Rows.Count > 0)
        {
            Lista_Tecnicos.DataSource = dt;
            Lista_Tecnicos.DataTextField = "NOMBRE_TECNICO";
            Lista_Tecnicos.DataValueField = "CEDULA_TECNICO";
            Lista_Tecnicos.DataBind();
        }
        else
        {
            Lista_Tecnicos.Items.Clear();
        }
        //var Cedula_Tecnico = dt.Tables[0].Rows[0]["CEDULA_TECNICO"].ToString();
        //Lista_Tecnicos.Items.Insert(0, new ListItem(dt.Tables[0].Rows[0]["NOMBRE_TECNICO"].ToString(), "" + Cedula_Tecnico));
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
            Carga_Tecnicos_solicitud();
            Accion.Text = "UPDATE";
            Accion_Tecnico.Text = "UPDATE";
            Fecha_Agendamiento.Attributes.CssStyle.Add("display", "block");
            lblFecha_Agendamiento.Attributes.CssStyle.Add("display", "block");
            lblCerrarCaso.Attributes.CssStyle.Add("display", "block");
            CHCerrarCaso.Attributes.CssStyle.Add("display", "block");
            Div_Materiales.Attributes.CssStyle.Add("display", "block");
            Carga_Fecha_Asignada_Tecnico();
            Materiales_A_Agregar();
            Tabla_Materiales_Solicitud();
            Div_Agrega_Tecnicos.Attributes.CssStyle.Add("display", "block");
        }
        else
        {
            string script3 = "mensaje5();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje5", script3, true);

        }
    }

    private void Carga_Fecha_Asignada_Tecnico()
    {
        DataSet ds = new DataSet();
        ds = O_Neg_Solicitud.Seleccionar_Turnos(Convert.ToInt32(ID_CASO.Text), Convert.ToInt32(Lista_Tecnicos.SelectedValue));
        if (ds.Tables[0].Rows.Count > 0)
        {
            Fecha_Agendamiento.Text = ds.Tables[0].Rows[0]["FECHA_TURNO"].ToString();
            Accion_Tecnico.Text = "UPDATE";
        }
        else
        {
            Fecha_Agendamiento.Text = "";
            Accion_Tecnico.Text = "INSERTAR";
        }
    }

    protected void Guarda_Material_Caso_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Select_Materiales.SelectedItem) != "- - SELECCIONE - -" && Convert.ToString(Select_Materiales.SelectedItem) != "" && Convert.ToString(Select_Materiales.SelectedItem) != null)
        {
            if (CantidadMaterial.Text != "")
            {
                CantidadMaterial_TextChanged();
                if (MaterialDisponible.Text != "")
                {
                    if (Convert.ToInt32(CantidadMaterial.Text) <= Convert.ToInt32(MaterialDisponible.Text))
                    {
                        
                        Controles_Objetos_Solicitud();
                        var Guardar_Datos = -1;
                        Guardar_Datos = O_Neg_Solicitud.Abc_Materiales_Solicitudes("INSERTAR", E_Materiales_Solicitudes);
                        if (Guardar_Datos != -1)
                        {
                            Actualiza_Inventario();
                            Limpiar_Controles_Materiales();
                            string script1 = "mensaje7();";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje7", script1, true);
                            Materiales_A_Agregar();
                            Tabla_Materiales_Solicitud();
                        }
                        else
                        {
                            string script = "mensaje6();";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje6", script, true);
                            
                        }
                    }
                    else
                    {
                        string script = "mensaje10();";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje9", script, true);
                        Tabla_Materiales_Solicitud();
                    }
                }
                else
                {
                    string script = "mensaje12();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje9", script, true);
                    Tabla_Materiales_Solicitud();
                }
            }
            else {
                string script = "mensaje9();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje9", script, true);
                Tabla_Materiales_Solicitud();
            }
        }
        else {
            string script = "mensaje8();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje8", script, true);
            Tabla_Materiales_Solicitud();
        }
        

    }

    private void Actualiza_Inventario()
    {
        Controles_a_Objeto_Inventario();
        var Guardar_Datos = -1;
        Guardar_Datos = O_Neg_Solicitud.Abc_Materiales("UPDATE", E_Materiales);
    }

    private void Controles_a_Objeto_Inventario()
    {
        E_Materiales.Id = Convert.ToInt32(Select_Materiales.SelectedValue);
        E_Materiales.Cantidad = Convert.ToString((Convert.ToInt32(MaterialDisponible.Text))-(Convert.ToInt32(CantidadMaterial.Text)));
        E_Materiales.Material = Convert.ToString(Select_Materiales.SelectedItem);
    }

    private void Limpiar_Controles_Materiales()
    {
        Select_Materiales.ClearSelection();
        Select_Materiales.Items.Clear();
        CantidadMaterial.Text = "";
        Error.Attributes.CssStyle.Add("display", "none");
        Ok.Attributes.CssStyle.Add("display", "none");
    }
    private void Tabla_Materiales_Solicitud()
    {
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Seleccionar_Materiales_Solicitud(Convert.ToInt32(ID_CASO.Text), Convert.ToInt32(Lista_Tecnicos.SelectedValue));

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
        Div_Grid4.Attributes.CssStyle.Add("display","block");
    }
    public void CantidadMaterial_TextChanged()
    {
        if (Convert.ToString(Select_Materiales.SelectedItem) != "- - SELECCIONE - -" && CantidadMaterial.Text!= "")
        {
            DataSet dt = new DataSet();
            dt = O_Neg_Solicitud.Seleccionar_Cantidad_Material(Convert.ToInt32(Select_Materiales.SelectedValue));
            if (dt.Tables[0].Rows.Count > 0)
            {
                MaterialDisponible.Text = dt.Tables[0].Rows[0]["CANTIDAD"].ToString();
                if (Convert.ToInt32(CantidadMaterial.Text) > Convert.ToInt32(MaterialDisponible.Text))
                {
                    Ok.Attributes.CssStyle.Add("display", "none");
                    Error.Attributes.CssStyle.Add("display", "inline-block");
                }
                else
                {
                    Error.Attributes.CssStyle.Add("display", "none");
                    Ok.Attributes.CssStyle.Add("display", "inline-block");
                }
            }
            else
            {
                string script = "mensaje8();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje8", script, true);
                Limpiar_Controles_Materiales();

            }
        }
        else
        {
            string script = "mensaje8();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje8", script, true);
        }
        Tabla_Materiales_Solicitud();
    }

    

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
        Tabla_Materiales_Solicitud();
    }

    protected void Actualiza_Registro_Inventario_Click(object sender, EventArgs e)
    {
        var Guardar_Datos = -1;
        E_Materiales_Solicitudes.Id = Convert.ToInt32(Act_Id.Text);
        E_Materiales_Solicitudes.Cantidad = Act_Cantidad.Text;
        DataSet dt = new DataSet();
        dt = O_Neg_Solicitud.Seleccionar_Cantidad_Material(Convert.ToInt32(Act_Id_Material.Text));
        if (dt.Tables[0].Rows.Count > 0)
        {
            MaterialDisponible.Text = dt.Tables[0].Rows[0]["CANTIDAD"].ToString();
            //Ok2.Attributes.CssStyle.Add("display", "inline-block");
            //Error2.Attributes.CssStyle.Add("display", "none");
            var operacion = 0;
            if (Convert.ToInt32(Act_Cantidad.Text) > Convert.ToInt32(Act_CantidadInicial.Text))
            {
                operacion = Convert.ToInt32(Act_Cantidad.Text) - Convert.ToInt32(Act_CantidadInicial.Text);
            }

            if ((operacion <= Convert.ToInt32(MaterialDisponible.Text)) )
            {
                
                Calculos();
                Guardar_Datos = O_Neg_Solicitud.Abc_Materiales_Solicitudes("UPDATE", E_Materiales_Solicitudes);
                if (Guardar_Datos != -1)
                {
                    string script = "Oculta_Div_Actualiza();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Oculta_Div_Actualiza", script, true);

                }
                else
                {
                    string script = "mensaje13();";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje13", script, true);
                    Limpiar_Controles_Materiales();

                }
            }
            else
            {
                Error2.Attributes.CssStyle.Add("display", "inline-block");
                Ok2.Attributes.CssStyle.Add("display", "none");
                Div_Actualiza.Attributes.CssStyle.Add("display","block");
                Div_Grid4.Attributes.CssStyle.Add("display","none");
                string script = "mensaje10();";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje9", script, true);
            }
        } 
        else
        {
            string script = "mensaje14();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje8", script, true);
            Limpiar_Controles_Materiales();

        }
    }
    protected void Actualiza_Tabla_Materiales_Solicitud_Click1(object sender, EventArgs e)
    {
        Act_Id.Text = string.Empty;
        Act_Material.Text = string.Empty;
        Act_Cantidad.Text = string.Empty;
        Limpiar_Controles_Materiales();
        Materiales_A_Agregar();
        Tabla_Materiales_Solicitud();
        Div_Actualiza.Attributes.CssStyle.Add("display","none");
        Error2.Attributes.CssStyle.Add("display","none");
    }
    private void Calculos()
    {
        if (Convert.ToInt32(Act_CantidadInicial.Text) > Convert.ToInt32(Act_Cantidad.Text))
        {
            var Calculo = Convert.ToInt32(Act_CantidadInicial.Text) - Convert.ToInt32(Act_Cantidad.Text);
            var CantidadFinal = Calculo + Convert.ToInt32(MaterialDisponible.Text);
            E_Materiales.Id = Convert.ToInt32(Act_Id_Material.Text);
            E_Materiales.Cantidad = Convert.ToString(CantidadFinal);
            var Guardar_Datos = -1;
            Guardar_Datos = O_Neg_Solicitud.Abc_Materiales("UPDATE", E_Materiales);
        }
        if (Convert.ToInt32(Act_CantidadInicial.Text) < Convert.ToInt32(Act_Cantidad.Text))
        {
            var Calculo = Convert.ToInt32(Act_Cantidad.Text) - Convert.ToInt32(Act_CantidadInicial.Text);
            var CantidadFinal = Convert.ToInt32(MaterialDisponible.Text) - Calculo;
            E_Materiales.Id = Convert.ToInt32(Act_Id_Material.Text);
            E_Materiales.Cantidad = Convert.ToString(CantidadFinal);
            var Guardar_Datos = -1;
            Guardar_Datos = O_Neg_Solicitud.Abc_Materiales("UPDATE", E_Materiales);
        }
    }

    protected void Lista_Tecnicos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Carga_Fecha_Asignada_Tecnico();
    }
}