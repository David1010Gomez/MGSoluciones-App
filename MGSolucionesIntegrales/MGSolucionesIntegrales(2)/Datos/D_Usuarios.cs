using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Usuarios : D_Conexion_BD
    {
        public D_Usuarios() { }

        public DataSet Selecciona_Usuarios()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_USUARIOS]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Uusuarios", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Abc_Usuarios(string pAccion, E_Usuarios Obj_Uusarios)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("ABC_USUARIOS", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Accion", pAccion);
            cmd.Parameters.AddWithValue("@CEDULA", Obj_Uusarios.Cedula);
            cmd.Parameters.AddWithValue("@NOMBRE", Obj_Uusarios.Nombre);
            cmd.Parameters.AddWithValue("@CONTRASENA", Obj_Uusarios.Contraseña);
            cmd.Parameters.AddWithValue("@CARGO", Obj_Uusarios.Cargo);
            cmd.Parameters.AddWithValue("@ID_ROL", Obj_Uusarios.Id_Rol);
            cmd.Parameters.AddWithValue("@ESTADO", Obj_Uusarios.Estado);
            cmd.Parameters.AddWithValue("@DISPONIBLE", Obj_Uusarios.Disponible);
            
            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar,modificar o eliminar datos de la tabla Usuarios", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Selecciona_Rol_Usuario()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_ROL_USUARIO]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Rol Usuarios", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Selecciona_Usuario_Cedula(int pCedula)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_USUARIO_CEDULA]";
                cmd.Parameters.AddWithValue("@CEDULA", pCedula);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Usuarios por cedula", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Actualiza_Contrasena(int pCedula, string pContrasena)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("ACTULIZA_CONTRASENA", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@CEDULA", pCedula);
            cmd.Parameters.AddWithValue("@CONTRASENA", pContrasena);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar actulizar contraseñas de la tabla Usuarios", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Inicio_Sesion(int pCedula, string pContrasena)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[INICIO_SESION]";
                cmd.Parameters.AddWithValue("@CEDULA", pCedula);
                cmd.Parameters.AddWithValue("@CONTRASENA", pContrasena);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al autenticar los Usuarios por cedula", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

    }
}
