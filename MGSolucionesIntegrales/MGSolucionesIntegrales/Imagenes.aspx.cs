using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Imagenes : System.Web.UI.Page
{
    public N_Imagenes Obj_Neg_Imagenes = new N_Imagenes();
    public E_Exp_Imagenes obj_E_Exp_Imagenes = new E_Exp_Imagenes();

    protected void Page_Load(object sender, EventArgs e)
    {
        ////matiaslopezdev.wordpress.com/2014/08/29/subir-multiples-archivos-en-asp-net-4-5/
    }

    protected void Sube_Archivos_Click(object sender, EventArgs e)
    {
        Boolean Correcto = false;
        if (Nom_EXP.Text != "")
        {
            if (Carga_Archivos.HasFile)
            {
                var Accion = "INSERTAR";
                var pathCarpetaDestino = System.IO.Path.Combine(Server.MapPath("/Imagenes_Expedientes/"), "Caso_" + Nom_EXP.Text);
                var carpetaDestino = new System.IO.DirectoryInfo(pathCarpetaDestino);
                if (!carpetaDestino.Exists)
                {
                    carpetaDestino.Create();
                    
                }
                else
                {
                    Accion = "UPDATE";
                }

                foreach (var archivo in Carga_Archivos.PostedFiles)
                {
                    String Extencion_Archivo = System.IO.Path.GetExtension(archivo.FileName).ToLower();
                    String[] Extenciones_Permitidas = { ".png", ".jpg", ".jpeg" };
                    for (int i = 0; i < Extenciones_Permitidas.Length; i++)
                    {
                        if (Extencion_Archivo == Extenciones_Permitidas[i])
                        {
                            Correcto = true;

                        }
                    }

                    if (Correcto == true)
                    {
                        var nombreArchivo = System.IO.Path.GetFileName(archivo.FileName);
                        var pathArchivoDestino = System.IO.Path.Combine(pathCarpetaDestino, nombreArchivo);
                        archivo.SaveAs(pathArchivoDestino);

                        Nom_EXP.Text = "";
                        //ViewState["foto"] = System.IO.Path.GetFileName(archivo.FileName);
                        //archivo.SaveAs(MapPath("/Imagenes_Expedientes/") + ViewState["foto"]);
                    }
                    else
                    {
                        string script = "alert('El Archivo " + archivo.FileName + " NO se Guardo porque NO es Válido');";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", script, true);
                    }
                }

                Controles_Objetos();
                var Guardar_Datos = -1;
                Guardar_Datos = Obj_Neg_Imagenes.Abc_Exp_Imagenes(Accion, obj_E_Exp_Imagenes);

                if (Guardar_Datos != -1)
                {
                    string script = "alert('Registro Exitoso');";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", script, true);

                }

            }
            else
            {
                string script = "alert('No ha Seleccionado Ninguna Imágen');";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", script, true);
            }
        }
        else
        {
            string script = "alert('Digite un Numero de Exp.');";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", script, true);
        }
    }

    private void Controles_Objetos()
    {
        throw new NotImplementedException();
    }
}