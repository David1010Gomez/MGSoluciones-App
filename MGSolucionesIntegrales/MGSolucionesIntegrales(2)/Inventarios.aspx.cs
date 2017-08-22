using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventarios : System.Web.UI.Page
{
    public N_Materiales Obj_Neg_Materiales = new N_Materiales();
    public E_Materiales obj_E_Materiales = new E_Materiales();
    public E_Tipo_Servicio obj_E_Tipo_Servicio= new E_Tipo_Servicio();
    public N_Imagenes Obj_Neg_Imagenes = new N_Imagenes();
    public E_Exp_Imagenes obj_E_Exp_Imagenes = new E_Exp_Imagenes();

    protected void Page_Load(object sender, EventArgs e)
    {
        EstadoEliminar.Attributes.Add("onchange", "Cambia_Estado();");
        Selecciona_Materiales();
        Selecciona_Servicios();
        Selecciona_Carpetas_Imagenes();
    }

    private void Selecciona_Carpetas_Imagenes()
    {
        DataSet dt = new DataSet();
        dt = Obj_Neg_Materiales.Selecciona_Lista_Imagenes();

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

    private void Selecciona_Materiales()
    {
        DataSet dt = new DataSet();
        dt = Obj_Neg_Materiales.Selecciona_Materiales();

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
        TotalFilas.Text = "Total de Elementos: " + Convert.ToString(GridView1.Rows.Count);
    }
    private void Selecciona_Servicios()
    {
        DataSet dt = new DataSet();
        dt = Obj_Neg_Materiales.Selecciona_Tipo_Servicio();

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
    protected void Guarda_Material_Click(object sender, EventArgs e)
    {
        if (Material_Inv.Text != "")
        {
            if (Cantidad_Inv.Text != "")
            {
                if (Precio_Inv.Text != "")
                {
                    Controles_Objetos();
                    var Guardar_Datos = -1;
                    Guardar_Datos = Obj_Neg_Materiales.Abc_Materiales(Accion.Text, obj_E_Materiales);

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
                    Selecciona_Materiales();
                    Selecciona_Servicios();
                    Limpia_Controles();
                }
                else
                {
                    string script = "alert('Digite un Precio');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
                }
            }
            else
            {
                string script = "alert('Digite una Cantidad');";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
            }
        }
        else
        {
            string script = "alert('Digite un nombre del Material');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }

    private void Limpia_Controles()
    {
        Id_Material.Text = "0";
        Id_Servicio.Text = "0";
        Material_Inv.Text = "";
        Cantidad_Inv.Text = "";
        Precio_Inv.Text = "";
        Accion.Text = "INSERTAR";
        Servicio.Text = "";
        Accion_Servicio.Text = "INSERTAR";
        Eliminar.Attributes.CssStyle.Add("display", "none");
        EstadoEliminar.Checked = false;


    }

    private void Controles_Objetos()
    {
        obj_E_Materiales.Id = Convert.ToInt32(Id_Material.Text);
        obj_E_Materiales.Material = Material_Inv.Text;
        obj_E_Materiales.Cantidad = Cantidad_Inv.Text;
        obj_E_Materiales.Precio_Unidad = Convert.ToInt32(Precio_Inv.Text);

    }

    protected void Cargar_Material_Click(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();
        dt = Obj_Neg_Materiales.Selecciona_Materiales_Id(Convert.ToInt32(Id_Material.Text));

        if (dt.Tables[0].Rows.Count > 0)
        {
            Id_Material.Text = dt.Tables[0].Rows[0]["ID"].ToString();
            Material_Inv.Text = dt.Tables[0].Rows[0]["MATERIAL"].ToString();
            Cantidad_Inv.Text = dt.Tables[0].Rows[0]["CANTIDAD"].ToString();
            Precio_Inv.Text = dt.Tables[0].Rows[0]["PRECIO_UNIDAD"].ToString();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Selecciona_Materiales();
    }

    protected void Guarda_Servicio_Click(object sender, EventArgs e)
    {
        if (Servicio.Text != "")
        {
            Controles_Objetos_Tipo_Servicio();
            var Guardar_Datos = -1;
            Guardar_Datos = Obj_Neg_Materiales.Abc_Tipo_Servicio(Accion_Servicio.Text, obj_E_Tipo_Servicio);

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
            Selecciona_Materiales();
            Selecciona_Servicios();
            Limpia_Controles();
        }
        else
        {
            string script = "alert('Digite un Servicio');";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);
        }
    }

    private void Controles_Objetos_Tipo_Servicio()
    {
        obj_E_Tipo_Servicio.Id_Servicio = Convert.ToInt32(Id_Servicio.Text);
        obj_E_Tipo_Servicio.Servicio = Servicio.Text;
        if (Accion_Servicio.Text != "DELETE")
        {
            obj_E_Tipo_Servicio.Estado = "ACTIVO";
        }
        else
        {
            obj_E_Tipo_Servicio.Estado = "INACTIVO";
        }
        
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Selecciona_Servicios();
    }

    protected void Tipo_Servicio_Click(object sender, EventArgs e)
    {
        DataSet dt = new DataSet();
        dt = Obj_Neg_Materiales.Selecciona_Tipo_Servicio_Id(Convert.ToInt32(Id_Servicio.Text));

        if (dt.Tables[0].Rows.Count > 0)
        {
            Id_Servicio.Text = dt.Tables[0].Rows[0]["ID_SERVICIO"].ToString();
            Servicio.Text = dt.Tables[0].Rows[0]["SERVICIO"].ToString();
            Eliminar.Attributes.CssStyle.Add("display","block");
        }
    }

    protected void Descarga_Carpeta_Imagenes_Click(object sender, EventArgs e)
    {
        string dlDir = @"Imagenes_Expedientes/";
        string sourcePath = Server.MapPath(dlDir + Nom_Carpeta.Text + "/"); 
        string pathPC = System.IO.Path.GetFullPath("C:/"+ Nom_Carpeta.Text);

        //string script1 = "alert(''+" + sourcePath + "); ";
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script1, true);
        //string script2 = "alert(''+" + pathPC + "); ";
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script2, true);

        Prueba.Text = sourcePath;
        Prueba2.Text = pathPC;

        if (!System.IO.Directory.Exists(pathPC))
        {
            System.IO.Directory.CreateDirectory(pathPC);
        }

        string[] files = System.IO.Directory.GetFiles(sourcePath);

        foreach (string s in files)
        {
            var fileName = System.IO.Path.GetFileName(s);
            var destFile = System.IO.Path.Combine(pathPC, fileName);
            System.IO.File.Copy(s, destFile, true);
        }
        System.IO.Directory.Delete(sourcePath, true);

        obj_E_Exp_Imagenes.Nombre_Carpeta = Nom_Carpeta.Text;
        obj_E_Exp_Imagenes.Estado = "DESCARGADA";
        var Guardar_Datos = -1;
        Guardar_Datos = Obj_Neg_Imagenes.Abc_Exp_Imagenes("UPDATE", obj_E_Exp_Imagenes);

        if (Guardar_Datos != -1)
        {
            string script = "alert('Descarga Exitosa'); ";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);

            Nom_Carpeta.Text = "";
            Selecciona_Materiales();
            Selecciona_Servicios();
            Limpia_Controles();
            Selecciona_Carpetas_Imagenes();

        }

    }
}