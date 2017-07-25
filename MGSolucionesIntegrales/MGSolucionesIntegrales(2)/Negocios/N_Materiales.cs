using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Materiales
    {
        public D_Materiales DN_Materiales = new D_Materiales();

        public DataSet Selecciona_Materiales()
        {
            return DN_Materiales.Selecciona_Materiales();
        }
        public int Abc_Materiales(string pAccion, E_Materiales Obj_Materiales)
        {
            return DN_Materiales.Abc_Materiales(pAccion, Obj_Materiales);
        }
        public DataSet Selecciona_Materiales_Id(int pId)
        {
            return DN_Materiales.Selecciona_Materiales_Id(pId);
        }
        public int Abc_Tipo_Servicio(string pAccion, E_Tipo_Servicio Obj_Tipo_Servicio)
        {
            return DN_Materiales.Abc_Tipo_Servicio(pAccion, Obj_Tipo_Servicio);
        }
        public DataSet Selecciona_Tipo_Servicio()
        {
            return DN_Materiales.Selecciona_Tipo_Servicio();
        }
        public DataSet Selecciona_Tipo_Servicio_Id(int pId)
        {
            return DN_Materiales.Selecciona_Tipo_Servicio_Id(pId);
        }
    }
}
