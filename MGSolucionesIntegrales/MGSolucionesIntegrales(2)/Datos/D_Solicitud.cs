using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;
using Entidades;

namespace Datos
{
    public class D_Solicitud : D_Conexion_BD
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
        public int Abc_Solicitudes(string pAccion, E_Solicitudes Obj_Solicitudes)
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
            cmd.Parameters.AddWithValue("@DIRECCION", Obj_Solicitudes.Direccion);
            cmd.Parameters.AddWithValue("@ESTADO_CASO", Obj_Solicitudes.Estado_Caso);
            cmd.Parameters.AddWithValue("@CEDULA_USUARIO_CREACION", Obj_Solicitudes.Cedula_Usuario_Creacion);
            cmd.Parameters.AddWithValue("@FECHA_CIERRE", Obj_Solicitudes.Fecha_Cierre);
            cmd.Parameters.AddWithValue("@CEDULA_USUARIO_CIERRE", Obj_Solicitudes.Cedula_Usuario_Cierre);
            cmd.Parameters.AddWithValue("@USUARIO_ULTIMA_ACTUALIZACION", Obj_Solicitudes.Usuario_Ultima_Actualizacion);
            cmd.Parameters.AddWithValue("@VALOR_TRABAJO", Obj_Solicitudes.Valor_Trabajo);
            cmd.Parameters.AddWithValue("@VALOR_TOTAL", Obj_Solicitudes.Valor_Total);
            cmd.Parameters.AddWithValue("@USUARIO_GESTIONANDO", Obj_Solicitudes.Usuario_Gestionando);

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
            cmd.Parameters.AddWithValue("@ESTADO_CASO", Obj_Notas_Solicitudes.Estado_Caso);

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
        public DataSet Seleccionar_Turnos(int pId, int pCedulaTecnico)
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
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", pCedulaTecnico);
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
            cmd.Parameters.AddWithValue("@PRECIO_UNIDAD", Obj_Materiales_Solicitudes.Precio_Unidad); 
            cmd.Parameters.AddWithValue("@PRECIO_TOTAL", Obj_Materiales_Solicitudes.Precio_Total);

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
        public DataSet Seleccionar_Cantidad_Material(int pId)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_CANTIDAD_MATERIAL]";
                cmd.Parameters.AddWithValue("@ID", pId);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar la cantidad de materiales disponnibles", e); }
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
            SqlCommand cmd = new SqlCommand("ABC_MATERIALES", Conexion);
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
                throw new Exception("Error al Insertar o Actualizar la tabla Materiales", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Tecnicos()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_TECNICOS]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los tecnicos", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Solicitudes_Fecha(string pFecha_Inicial, string pFecha_Final)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_SOLICITUDES_FECHA]";
                cmd.Parameters.AddWithValue("@FECHA_INICIAL", pFecha_Inicial);
                cmd.Parameters.AddWithValue("@FECHA_FINAL", pFecha_Final);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar las solicitudes por fechas", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Solicitudes_Exp(long pExp)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_SOLICITUDES_EXP]";
                cmd.Parameters.AddWithValue("@NUM_EXP", pExp);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar las solicitudes por EXP", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Solicitudes_Tecnico(string pTecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_SOLICITUDES_TECNICO]";
                cmd.Parameters.AddWithValue("@TECNICO", pTecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar las solicitudes por Tecnico", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Actualiza_Estado_Tecnico(E_Usuarios Obj_Usuarios)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("ACTULIZA_ESTADO_TECNICO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@CEDULA", Obj_Usuarios.Cedula);
            cmd.Parameters.AddWithValue("@DISPONIBLE", Obj_Usuarios.Disponible);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al Actualizar la tabla por Disponibilidad de Usuarios", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public int Inserta_Tecnico_Solicitudes(E_Tecnicos_Solicitudes Obj_Tecnicos_Solicitudes)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("[INSERTA_TECNICO_SOLICITUDES]", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@ID_SOLICITUD", Obj_Tecnicos_Solicitudes.Id_Solicitud);
            cmd.Parameters.AddWithValue("@CEDULA_TECNICO", Obj_Tecnicos_Solicitudes.Cedula_Tecnico);
            cmd.Parameters.AddWithValue("@NOMBRE_TECNICO", Obj_Tecnicos_Solicitudes.Nombre_Tecnico);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar datos de la tabla Tecnicos Solicitudes", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Busca_Tecnicos_Solicitud(string pAccion, int pIdSolicitud, int pCedulaTecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONAR_TECNICOS_SOLICITUDES]"; 
                    cmd.Parameters.AddWithValue("@ACCION", pAccion);
                cmd.Parameters.AddWithValue("@ID_SOLICITUD", pIdSolicitud);
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", pCedulaTecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar el Tecnico por solicitud", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        
        public DataSet Busca_Historial_Solicitud( int pIdSolicitud)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_HISTORIAL_SOLICITUD]";
                cmd.Parameters.AddWithValue("@ID_SOLICITUD", pIdSolicitud);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar el Historial por solicitud de la tabla Notas solicitudes", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Selecciona_Tipo_Servicios()
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_TIPO_SERVICIOS]";
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los tipos de servicios", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Abc_Servicio_Solicitud(string pAccion, E_Servicio_Solicitud Obj_Servicio_Solicitud)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("[ABC_SERVICIO_SOLICITUD]", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ACCION", pAccion);
            cmd.Parameters.AddWithValue("@ID_SERVICIO", Obj_Servicio_Solicitud.Id_Servicio);
            cmd.Parameters.AddWithValue("@ID_SOLICITUD", Obj_Servicio_Solicitud.Id_Solicitud);
            cmd.Parameters.AddWithValue("@CEDULA_TECNICO", Obj_Servicio_Solicitud.Cedula_Tecnico);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar almacenar datos de la tabla Servicios Solicitudes", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Selecciona_Servicio_Solicitud(string pAccion, int pIdServicio, int pIdSolicitud, int pCedulaTecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONAR_SERVICIOS_SOLICITUDES]";
                cmd.Parameters.AddWithValue("@ACCION", pAccion);
                cmd.Parameters.AddWithValue("@ID_SERVICIO", pIdServicio);
                cmd.Parameters.AddWithValue("@ID_SOLICITUD", pIdSolicitud);
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", pCedulaTecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar el servicio de la solicitud", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Selecciona_Precio_Unitario(int pId)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_PRECIO_UNITARIO_MATERIALES]";
                cmd.Parameters.AddWithValue("@ID", pId);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los precios unitarios de Materiales a agregar", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Suma_Materiales_Solicitud(int pId)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SUMA_MATERIALES_SOLICITUD]";
                cmd.Parameters.AddWithValue("@ID", pId);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar la suma de materiales por Id", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Selecciona_Solicitud_Libre(int pId, string pUsuarioGestionando)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_SOLICITUD_LIBRE]";
                cmd.Parameters.AddWithValue("@ID", pId);
                cmd.Parameters.AddWithValue("@USUARIO_GESTIONANDO", pUsuarioGestionando  );
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar la solicitud libre por Id", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Usuario_Gestionando_Caso(int pId, string pUsuario_Gestionando)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("[USUARIO_GESTIONANDO_CASO]", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", pId);
            cmd.Parameters.AddWithValue("@USUARIO_GESTIONANDO", pUsuario_Gestionando);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar Actualizar datos de la tabla Solicitudes", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public int Usuario_Eliminar_Gestionando_Caso(string pUsuario_Gestionando)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("[USUARIO_ELIMINAR_GESTIONANDO_CASO]", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USUARIO_GESTIONANDO", pUsuario_Gestionando);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar Actualizar datos de la tabla Solicitudes", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public int Insertar_Log_Aplazamientos(E_Log_Aplazamientos Obj_Log_Aplazamientos)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("[INSERTA_LOG_APLAZAMIENTO]", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SOLICITUD", Obj_Log_Aplazamientos.Id_Solicitud);
            cmd.Parameters.AddWithValue("@CEDULA_TECNICO", Obj_Log_Aplazamientos.Cedula_Tecnico);
            cmd.Parameters.AddWithValue("@TRABAJO", Obj_Log_Aplazamientos.Trabajo);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar Insertar datos en la tabla Log Aplazamientos", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Consulta_Notas_Solicitudes_Exp(int pExp)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_NOTAS_SOLICITUDES_EXP]";
                cmd.Parameters.AddWithValue("@NUM_EXP", pExp);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar las notas solicitudes por EXP", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Notas_Solicitudes_Fecha(string pFecha_Inicial, string pFecha_Final)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_NOTAS_SOLICITUDES_FECHA]";
                cmd.Parameters.AddWithValue("@FECHA_INICIAL", pFecha_Inicial);
                cmd.Parameters.AddWithValue("@FECHA_FINAL", pFecha_Final);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar las notas de solicitudes por fechas", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Materiales_Solicitudes_Exp(int pExp)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_MATERIALES_SOLICITUDES_EXP]";
                cmd.Parameters.AddWithValue("@NUM_EXP", pExp);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los materiales de solicitudes por EXP", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Materiales_Solicitudes_Fecha(string pFecha_Inicial, string pFecha_Final)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_MATERIALES_SOLICITUDES_FECHA]";
                cmd.Parameters.AddWithValue("@FECHA_INICIAL", pFecha_Inicial);
                cmd.Parameters.AddWithValue("@FECHA_FINAL", pFecha_Final);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los materiales de solicitudes por fechas", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Materiales_Solicitudes_Tecnico(string pTecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_MATERIALES_SOLICITUDES_TECNICO]";
                cmd.Parameters.AddWithValue("@TECNICO", pTecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los materiales de solicitudes por Tecnico", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public int Actualiza_Estado_Caso(E_Solicitudes Obj_E_Solicitudes)
        {
            int Resultado = 0;
            SqlCommand cmd = new SqlCommand("[ACTULIZA_ESTADO_CASO]", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CASO", Obj_E_Solicitudes.Id);
            cmd.Parameters.AddWithValue("@ESTADO_CASO", Obj_E_Solicitudes.Estado_Caso);

            try
            {
                Abrir_Conexion();
                Resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar Actualizar el estado de la tabla Solicitudes", e);
            }
            finally
            {
                Cerrar_Conexion();
                cmd.Dispose();
            }
            return Resultado;
        }
        public DataSet Consulta_Solicitudes_Fecha_Tecnico(string pFecha_Inicial, string pFecha_Final, int pCedulaTecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_SOLICITUDES_FECHA_TECNICO]";
                cmd.Parameters.AddWithValue("@FECHA_INICIAL", pFecha_Inicial);
                cmd.Parameters.AddWithValue("@FECHA_FINAL", pFecha_Final);
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", pCedulaTecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar las solicitudes por fechas y tecnico", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Solicitudes_Exp_Tecnico(int pExp, int pCedulaTecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_SOLICITUDES_EXP_TECNICO]";
                cmd.Parameters.AddWithValue("@NUM_EXP", pExp);
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", pCedulaTecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar las solicitudes por EXP y Tecnico", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Materiales_Fecha_Tecnico(string pFecha_Inicial, string pFecha_Final, int pCedulaTecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_MATERIALES_FECHA_TECNICO]";
                cmd.Parameters.AddWithValue("@FECHA_INICIAL", pFecha_Inicial);
                cmd.Parameters.AddWithValue("@FECHA_FINAL", pFecha_Final);
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", pCedulaTecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Materiales por fechas y tecnico", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Materiales_Exp_Tecnico(int pExp, int pCedulaTecnico)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_MATERIALES_EXP_TECNICO]";
                cmd.Parameters.AddWithValue("@NUM_EXP", pExp);
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", pCedulaTecnico);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los Materiales por EXP y Tecnico", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Selecciona_Caso_Id(int pIdCaso)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONA_CASOS_ID]";
                cmd.Parameters.AddWithValue("@ID_CASO", pIdCaso);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar la solicitud por Id", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Selecciona_Ultimo_Trabajo_Cedula(int pIdSolicitud, int pCedula)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[SELECCIONAR_ULTIMO_TRABAJO_CEDULA]";
                cmd.Parameters.AddWithValue("@ID_SOLICITUD", pIdSolicitud);
                cmd.Parameters.AddWithValue("@CEDULA_TECNICO", pCedula);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar la el ultimo trabajo por Solicitud y Cedula de Log Aplazamientos", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Tecnicos_Solicitudes_Exp(int pExp)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_TECNICOS_EXP]";
                cmd.Parameters.AddWithValue("@NUM_EXP", pExp);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los tecnicos por Exp", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet Consulta_Tecnicos_Solicitudes_Fecha(string pFecha_Inicial, string pFecha_Final)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter dt = new SqlDataAdapter();
            try
            {
                Abrir_Conexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[CONSULTA_TECNICOS_FECHA]";
                cmd.Parameters.AddWithValue("@FECHA_INICIAL", pFecha_Inicial);
                cmd.Parameters.AddWithValue("@FECHA_FINAL", pFecha_Final);
                dt.SelectCommand = cmd;
                dt.Fill(ds);
            }
            catch (Exception e)
            { throw new Exception("Error al seleccionar los tecnicos por Fechas", e); }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }
    }
}
