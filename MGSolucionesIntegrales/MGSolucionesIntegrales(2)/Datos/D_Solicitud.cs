using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;
using Entidades;

namespace Datos
{
    public class D_Solicitud: D_Conexion_BD
    {
        public D_Solicitud() { }
        public DataSet Tecnicos_Libres()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_TECNICOS_LIBRES]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los tecnicos libres", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Abc_Solicitudes (string pAccion, E_Solicitudes Obj_Solicitudes)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("ABC_SOLICITUDES", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Accion", pAccion);
            cmd.Parameters.AddWithValue("@ID", Obj_Solicitudes.Id);
            cmd.Parameters.AddWithValue("@NUM_EXP", Obj_Solicitudes.Num_Exp);
            cmd.Parameters.AddWithValue("@POLIZA", Obj_Solicitudes.Poliza);
            cmd.Parameters.AddWithValue("@ASEGURADO", Obj_Solicitudes.Asegurado);
            cmd.Parameters.AddWithValue("@CONTACTO", Obj_Solicitudes.Contacto);
            cmd.Parameters.AddWithValue("@FACT", Obj_Solicitudes.Fact);
            cmd.Parameters.AddWithValue("@TECNICO", Obj_Solicitudes.Tecnico);
            cmd.Parameters.AddWithValue("@DIRECCION", Obj_Solicitudes.Direccion);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", Obj_Solicitudes.Observaciones);
            cmd.Parameters.AddWithValue("@ESTADO_CASO", Obj_Solicitudes.Estado_Caso);
            cmd.Parameters.AddWithValue("@CEDULA_USUARIO_CREACION", Obj_Solicitudes.Cedula_Usuario_Creacion);
            
            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar,modificar o eliminar datos de la tabla Solicitudes", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Casos_Abiertos()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_CASOS_ABIERTOS]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los casos abiertos", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
    }
}
