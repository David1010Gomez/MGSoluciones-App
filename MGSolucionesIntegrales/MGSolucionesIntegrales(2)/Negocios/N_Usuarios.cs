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
    public class N_Usuarios
    {
        public D_Usuarios DN_Usuarios = new D_Usuarios();

        public DataSet Selecciona_Usuarios()
        {
            return DN_Usuarios.Selecciona_Usuarios();
        }
        public int Abc_Usuarios(string pAccion, E_Usuarios Obj_Uusarios)
        {
            return DN_Usuarios.Abc_Usuarios(pAccion, Obj_Uusarios);
        }
        public DataSet Selecciona_Rol_Usuario()
        {
            return DN_Usuarios.Selecciona_Rol_Usuario();
        }
    }
}
