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
        public DataSet Selecciona_Usuario_Cedula(int pCedula)
        {
            return DN_Usuarios.Selecciona_Usuario_Cedula(pCedula);
        }
        public int Actualiza_Contrasena(int pCedula, string pContrasena)
        {
            return DN_Usuarios.Actualiza_Contrasena(pCedula, pContrasena);
        }
        public DataSet Inicio_Sesion(int pCedula, string pContrasena)
        {
            return DN_Usuarios.Inicio_Sesion(pCedula, pContrasena);
        }
    }
}
