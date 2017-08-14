using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Imagenes
    {
        public D_Imagenes DN_Imagenes = new D_Imagenes();

        public int Abc_Exp_Imagenes(string pAccion, E_Exp_Imagenes Obj_Exp_Imagenes)
        {
            return DN_Imagenes.Abc_Exp_Imagenes(pAccion, Obj_Exp_Imagenes);
        }
    }
}
