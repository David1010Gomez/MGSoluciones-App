using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Imagenes : D_Conexion_BD
    {
        public D_Imagenes() { }

        public int Abc_Exp_Imagenes(string pAccion, E_Exp_Imagenes Obj_Exp_Imagenes)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("ABC_EXP_IMAGENES", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Accion", pAccion);
            cmd.Parameters.AddWithValue("@ID", Obj_Exp_Imagenes.Id);
            cmd.Parameters.AddWithValue("@NOMBRE_CARPETA", Obj_Exp_Imagenes.Nombre_Carpeta);
            cmd.Parameters.AddWithValue("@CANTIDAD_IMAGENES", Obj_Exp_Imagenes.Cantidad_Imagenes);
            cmd.Parameters.AddWithValue("@ESTADO", Obj_Exp_Imagenes.Estado);
            
            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar,modificar o eliminar datos de la tabla exp_imagenes", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }

    }
}
