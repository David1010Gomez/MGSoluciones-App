using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuarios : System.Web.UI.Page
{
    public N_Usuarios Neg_Usarios = new N_Usuarios();
    public E_Usuarios Ent_Usuarios = new E_Usuarios();
    protected void Page_Load(object sender, EventArgs e)
    {
        Selecciona_Usuarios();
        Nombre_Usuario.Attributes.Add("autocomplete", "off");
        Contrasena_Usuario.Attributes.Add("autocomplete", "off");
    }

    private void Selecciona_Usuarios()
    {
        DataSet dt = new DataSet();
        dt = Neg_Usarios.Selecciona_Usuarios();

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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Selecciona_Usuarios();
    }

    protected void Cargar_Usuario_Click(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();
        dt = Neg_Usarios.Selecciona_Usuario_Cedula(Convert.ToInt32(Cedula.Text));

        if (dt.Tables[0].Rows.Count > 0)
        {
            Cedula_Usuario.Text = dt.Tables[0].Rows[0]["CEDULA"].ToString();
            Nombre_Usuario.Text = dt.Tables[0].Rows[0]["NOMBRE"].ToString();
            ContraseñaActual.Value = dt.Tables[0].Rows[0]["CONTRASENA"].ToString();
            Cargo_Usuario.Text = dt.Tables[0].Rows[0]["CARGO"].ToString();

        }
        if (dt.Tables[0].Rows.Count > 0)
        {
            Rol_Usuario.DataSource = dt;
            Rol_Usuario.DataTextField = "ID_ROL";
            Rol_Usuario.DataValueField = "";
            Rol_Usuario.DataBind();
            //Rol_Usuario.Text = dt.Tables[0].Rows[0]["ID_ROL"].ToString();
            Estado_Usuario.DataSource = dt;
            Estado_Usuario.DataTextField = "ESTADO";
            Estado_Usuario.DataValueField = "ESTADO";
            Estado_Usuario.DataBind();
            //Estado_Usuario.Text = dt.Tables[0].Rows[0]["ESTADO"].ToString();
            Disponible_Usuario.DataSource = dt;
            Disponible_Usuario.DataTextField = "DISPONIBLE";
            Disponible_Usuario.DataValueField = "DISPONIBLE";
            Disponible_Usuario.DataBind();
            //Disponible_Usuario.Text = dt.Tables[0].Rows[0]["DISPONIBLE"].ToString();
        }
    }

    protected void Guarda_Usuario_Click(object sender, EventArgs e)
    {
        if (Cedula_Usuario.Text != "")
        {
            if ((Convert.ToString(Rol_Usuario.SelectedItem) != "- - SELECCIONE - -") && !(Convert.ToString(Rol_Usuario.SelectedItem).Equals("")))
            {
                if ((Convert.ToString(Estado_Usuario.SelectedItem) != "- - SELECCIONE - -") && !(Convert.ToString(Estado_Usuario.SelectedItem).Equals("")))
                {
                    if ((Convert.ToString(Disponible_Usuario.SelectedItem) != "- - SELECCIONE - -") && !(Convert.ToString(Disponible_Usuario.SelectedItem).Equals("")))
                    {
                        if (Accion.Text == "INSERTAR")
                        {
                            DataSet dt = new DataSet();
                            dt = Neg_Usarios.Selecciona_Usuario_Cedula(Convert.ToInt32(Cedula_Usuario.Text));
                            if ((dt.Tables[0].Rows.Count == 0))
                            {
                                Controles_Objetos();
                                var Guardar_Datos = -1;
                                Guardar_Datos = Neg_Usarios.Abc_Usuarios(Accion.Text, Ent_Usuarios);

                                if (Guardar_Datos != -1)
                                {
                                    string script = "alert('Registro Exitoso');";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                                }
                                else
                                {
                                    string script = "alert('Ha Ocurrido un Error');";
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                                }
                                Selecciona_Usuarios();
                                Limpiar_Controles();
                            }
                            else
                            {
                                string script = "alert('Esta Cedula ya Existe en la Base de Datos');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                            }
                        }
                        else
                        {
                            Controles_Objetos();
                            var Guardar_Datos = -1;
                            Guardar_Datos = Neg_Usarios.Abc_Usuarios(Accion.Text, Ent_Usuarios);

                            if (Guardar_Datos != -1)
                            {
                                string script = "alert('Registro Exitoso');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                            }
                            else
                            {
                                string script = "alert('Ha Ocurrido un Error');";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                            }
                            Selecciona_Usuarios();
                            Limpiar_Controles();
                        }
                        
                    }
                    else
                    {
                        string script = "alert('Seleccione Disponibilidad al Usuario');";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                    }
                }
                else
                {
                    string script = "alert('Seleccione un Estado al Usuario');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                }
            }
            else
            {
                string script = "alert('Seleccione un Rol al Usuario');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
            }
        }
        else
        {
            string script = "alert('Digite una cédula');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }

    private void Limpiar_Controles()
    {
        Cedula_Usuario.Text = "";
        Nombre_Usuario.Text = "";
        Contrasena_Usuario.Text = "";
        Cargo_Usuario.Text = "";
        Rol_Usuario.Items.Clear();
        Rol_Usuario.ClearSelection();
        Estado_Usuario.Items.Clear();
        Estado_Usuario.ClearSelection();
        Disponible_Usuario.Items.Clear();
        Disponible_Usuario.ClearSelection();
        Accion.Text = "INSERTAR";
        Cedula.Text = "0";
        ContraseñaActual.Value = "";
    }

    private void Controles_Objetos()
    {
        Ent_Usuarios.Cedula = Convert.ToInt32(Cedula_Usuario.Text);
        Ent_Usuarios.Nombre = Nombre_Usuario.Text;

        if (Contrasena_Usuario.Text != "")
        {
            Ent_Usuarios.Contraseña = Contrasena_Usuario.Text;
        }
        else
        {
            Ent_Usuarios.Contraseña = ContraseñaActual.Value;
        }

        Ent_Usuarios.Cargo = Cargo_Usuario.Text;
        Ent_Usuarios.Id_Rol = Convert.ToInt32(Rol_Usuario.SelectedValue);
        Ent_Usuarios.Estado = Convert.ToString(Estado_Usuario.SelectedItem);
        Ent_Usuarios.Disponible = Convert.ToString(Disponible_Usuario.SelectedItem);
    }

    private void Rol_Usuarios()
    {
        DataSet dt = new DataSet();

        dt = Neg_Usarios.Selecciona_Rol_Usuario();

        if (dt.Tables[0].Rows.Count > 0)
        {
            Rol_Usuario.DataSource = dt;
            Rol_Usuario.DataTextField = "ROL_USUARIO";
            Rol_Usuario.DataValueField = "ID_ROL";
            Rol_Usuario.DataBind();
            Rol_Usuario.Items.Insert(0, new ListItem("- - SELECCIONE - -", "0"));
        }
        else
        {
            Rol_Usuario.Items.Clear();
            Rol_Usuario.Items.Insert(0, new ListItem("- - SIN ROLES - -", "0"));
        }
    }

    protected void Lista_Roles_Click(object sender, EventArgs e)
    {
        Rol_Usuarios();
    }

    protected void Lista_Estado_Click(object sender, EventArgs e)
    {
        Estado_Usuario.Items.Clear();
        Estado_Usuario.ClearSelection();
        Estado_Usuario.Items.Insert(0, new ListItem("- - SELECCIONE - -", "0"));
        Estado_Usuario.Items.Insert(1, new ListItem("ACTIVO", "1"));
        Estado_Usuario.Items.Insert(2, new ListItem("INACTIVO", "2"));
    }

    protected void Lista_Disponible_Click(object sender, EventArgs e)
    {
        Disponible_Usuario.Items.Clear();
        Disponible_Usuario.ClearSelection();
        Disponible_Usuario.Items.Insert(0, new ListItem("- - SELECCIONE - -", "0"));
        Disponible_Usuario.Items.Insert(1, new ListItem("DISPONIBLE", "1"));
        Disponible_Usuario.Items.Insert(2, new ListItem("OCUPADO", "2"));

    }
}