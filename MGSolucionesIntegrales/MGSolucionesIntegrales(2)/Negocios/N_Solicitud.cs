﻿using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class N_Solicitud
    {
        public D_Solicitud DN_Solicitud = new D_Solicitud();
        public DataSet Tecnicos_Libres()
        {
            return DN_Solicitud.Tecnicos_Libres();
        }
        public int abc_Solicitudes(string pAccion, E_Solicitudes Obj_Solicitudes)
        {
            return DN_Solicitud.Abc_Solicitudes(pAccion, Obj_Solicitudes);
        }
        public DataSet Casos_Abiertos()
        {
            return DN_Solicitud.Casos_Abiertos();
        }
        
    }
}