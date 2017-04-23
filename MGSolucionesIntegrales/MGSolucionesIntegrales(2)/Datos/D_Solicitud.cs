﻿using System.Text;
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
            cmd.Parameters.AddWithValue("@ESTADO_CASO", Obj_Solicitudes.Estado_Caso);
            cmd.Parameters.AddWithValue("@CEDULA_USUARIO_CREACION", Obj_Solicitudes.Cedula_Usuario_Creacion);
            cmd.Parameters.AddWithValue("@FECHA_CIERRE", Obj_Solicitudes.Fecha_Cierre);
            cmd.Parameters.AddWithValue("@CEDULA_USUARIO_CIERRE", Obj_Solicitudes.Cedula_Usuario_Cierre);
            cmd.Parameters.AddWithValue("@USUARIO_ULTIMA_ACTUALIZACION", Obj_Solicitudes.Usuario_Ultima_Actualizacion);
            cmd.Parameters.AddWithValue("@CEDULA_TECNICO", Obj_Solicitudes.Cedula_Tecnico);

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
        public int Inserta_Notas_Solicitudes(string pAccion, E_Notas_Solicitudes Obj_Notas_Solicitudes)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("INSERTA_NOTAS_SOLICITUDES", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Accion", pAccion);
            cmd.Parameters.AddWithValue("@ID", Obj_Notas_Solicitudes.Id);
            cmd.Parameters.AddWithValue("@FECHA_NOTA", Obj_Notas_Solicitudes.Fecha_nota);
            cmd.Parameters.AddWithValue("@ID_SOLICITUD", Obj_Notas_Solicitudes.Num_Exp);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", Obj_Notas_Solicitudes.Observaciones);
            cmd.Parameters.AddWithValue("@CEDULA_USUARIO_INSERTO_NOTA", Obj_Notas_Solicitudes.Cedula_Usuario_Inserto_Nota);
            
            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar,modificar o eliminar datos de la tabla Notas Solicitudes", e);
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
        public DataSet Seleccionar_Solicitudes(int pId)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONAR_SOLICITUDES]";
                cmd.Parameters.AddWithValue("@Id", pId);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar las solicitudes", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public int abc_Turnos(string pAccion, E_Turnos Obj_Turnos)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("ABC_TURNO_TECNICO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Accion", pAccion);
            cmd.Parameters.AddWithValue("@ID", Obj_Turnos.Id);
            cmd.Parameters.AddWithValue("@ID_SOLICITUD", Obj_Turnos.Num_Exp);
            cmd.Parameters.AddWithValue("@CEDULA_TECNICO", Obj_Turnos.Cedula_Tecnico);
            cmd.Parameters.AddWithValue("@FECHA_TURNO", Obj_Turnos.Fecha_Turno);
            cmd.Parameters.AddWithValue("@TRABAJO", Obj_Turnos.Trabajo);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar,modificar o eliminar datos de la tabla Turnos", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Casos_Asignados()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_CASOS_ASIGNADOS]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los casos asignados", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Casos_Agendados()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_CASOS_AGENDADOS]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los casos agendados", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Seleccionar_Turnos(int pId)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONAR_TURNOS]";
                cmd.Parameters.AddWithValue("@Id", pId);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Turnos", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Seleccionar_Maximo_ID(int pExp)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_MAXIMO_ID]";
                cmd.Parameters.AddWithValue("@NUM_EXP", pExp);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar el maximo Id de la tabla Solicitudes", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Materiales_a_Agregar()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_MATERIALES_A_AGREGAR]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Materiales a agregar", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Abc_Materiales_Solicitudes(string pAccion, E_Materiales_Solicitudes Obj_Materiales_Solicitudes)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("ABC_MATERIALES_SOLICITUDES", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Accion", pAccion);
            cmd.Parameters.AddWithValue("@ID", Obj_Materiales_Solicitudes.Id);
            cmd.Parameters.AddWithValue("@FECHA_INGRESO", Obj_Materiales_Solicitudes.Fecha_Ingreso);
            cmd.Parameters.AddWithValue("@ID_SOLICITUD", Obj_Materiales_Solicitudes.Id_Solicitud);
            cmd.Parameters.AddWithValue("@ID_MATERIAL", Obj_Materiales_Solicitudes.Id_Material);
            cmd.Parameters.AddWithValue("@CANTIDAD", Obj_Materiales_Solicitudes.Cantidad); 
            cmd.Parameters.AddWithValue("@CEDULA_TECNICO", Obj_Materiales_Solicitudes.Cedula_Tecnico);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar,modificar o eliminar datos de la tabla Turnos", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Seleccionar_Materiales_Solicitud(int pId_Solicitud, int PCedula_Tecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONAR_MATERIALES_SOLICITUD]";
                cmd.Parameters.AddWithValue("@ID_SOLICITUD", pId_Solicitud); 
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", PCedula_Tecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los materiales de la solicitud", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
    }
}
