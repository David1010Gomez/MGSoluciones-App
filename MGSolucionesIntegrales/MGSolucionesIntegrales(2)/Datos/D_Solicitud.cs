using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;

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
    }
}
