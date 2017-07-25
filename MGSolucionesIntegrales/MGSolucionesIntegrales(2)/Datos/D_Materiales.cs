using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;
using Entidades;

namespace Datos
{
    public class D_Materiales : D_Conexion_BD
    {
        public D_Materiales() { }

        public DataSet Selecciona_Materiales()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_MATERIALES]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Materiales", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Abc_Materiales(string pAccion, E_Materiales Obj_Materiales)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("[ABC_MATERIALES]", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Accion", pAccion);
            cmd.Parameters.AddWithValue("@ID", Obj_Materiales.Id);
            cmd.Parameters.AddWithValue("@MATERIAL", Obj_Materiales.Material);
            cmd.Parameters.AddWithValue("@CANTIDAD", Obj_Materiales.Cantidad);
            cmd.Parameters.AddWithValue("@PRECIO_UNIDAD", Obj_Materiales.Precio_Unidad);           

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar,modificar o eliminar datos de la tabla Materiales", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Selecciona_Materiales_Id(int pId)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_MATERIAL_ID]";
                cmd.Parameters.AddWithValue("@ID", pId);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Materiales por Id", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Abc_Tipo_Servicio(string pAccion, E_Tipo_Servicio Obj_Tipo_Servicio)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("[ABC_TIPO_SERVICIO]", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ACCION", pAccion);
            cmd.Parameters.AddWithValue("@ID", Obj_Tipo_Servicio.Id_Servicio);
            cmd.Parameters.AddWithValue("@SERVICIO", Obj_Tipo_Servicio.Servicio);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar,modificar o eliminar datos de la tabla Tipo Servicio", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Selecciona_Tipo_Servicio()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_TIPO_SERVICIO]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Servicios", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Selecciona_Tipo_Servicio_Id(int pId)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_TIPO_SERVICIO_ID]";
                cmd.Parameters.AddWithValue("@ID", pId);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Tipo Servicios por Id", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
    }
}
