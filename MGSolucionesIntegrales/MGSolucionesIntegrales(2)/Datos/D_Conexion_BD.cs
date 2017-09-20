using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Datos
{
    public class D_Conexion_BD
    {
        public SqlConnection Conexion;

        public D_Conexion_BD()
        {
            Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MG_PRUEBA"].ConnectionString);
        }
        public void Abrir_Conexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Broken || Conexion.State == ConnectionState.Closed)
                {
                    Conexion.Open();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar conectar con el servidor", e);
            }
        }
        public void Cerrar_Conexion()
        {
            try
            {

                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar terminar la conexion con el servidor", e);
            }

        }
    }
}
