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
        public DataSet Selecciona_Solicitudes(int pId)
        {
            return DN_Solicitud.Seleccionar_Solicitudes(pId);
        }
        public int abc_Turnos(string pAccion, E_Turnos Obj_Turnos)
        {
            return DN_Solicitud.abc_Turnos(pAccion, Obj_Turnos);
        }
        public DataSet Casos_Asignados()
        {
            return DN_Solicitud.Casos_Asignados();
        }
        public DataSet Casos_Agendados()
        {
            return DN_Solicitud.Casos_Agendados();
        }
        public int Inserta_Notas_Solicitudes(string pAccion, E_Notas_Solicitudes Obj_Notas_Solicitudes)
        {
            return DN_Solicitud.Inserta_Notas_Solicitudes(pAccion, Obj_Notas_Solicitudes);
        }
        public DataSet Seleccionar_Turnos(int pId)
        {
            return DN_Solicitud.Seleccionar_Turnos(pId);
        }
        public DataSet Seleccionar_Maximo_ID(int pExp)
        {
            return DN_Solicitud.Seleccionar_Maximo_ID(pExp);
        }
        public DataSet Materiales_a_Agregar()
        {
            return DN_Solicitud.Materiales_a_Agregar();
        }
        public int Abc_Materiales_Solicitudes(string pAccion, E_Materiales_Solicitudes obj_Materiales_Solicitudes)
        {
            return DN_Solicitud.Abc_Materiales_Solicitudes(pAccion, obj_Materiales_Solicitudes);
        }
        public DataSet Seleccionar_Materiales_Solicitud(int pId_Solicitud, int PCedula_Tecnico)
        {
            return DN_Solicitud.Seleccionar_Materiales_Solicitud(pId_Solicitud, PCedula_Tecnico);
        }
        public DataSet Seleccionar_Cantidad_Material(int pId)
        {
            return DN_Solicitud.Seleccionar_Cantidad_Material(pId);
        }
        public int Abc_Materiales(string pAccion, E_Materiales obj_Materiales)
        {
            return DN_Solicitud.Abc_Materiales(pAccion, obj_Materiales);
        }
        public DataSet Tecnicos()
        {
            return DN_Solicitud.Tecnicos();
        }
        public DataSet Consulta_Solicitudes_Fecha(string pFecha_Inicial, string pFecha_Final)
        {
            return DN_Solicitud.Consulta_Solicitudes_Fecha(pFecha_Inicial, pFecha_Final);
        }
        public DataSet Consulta_Solicitudes_Exp(int pExp)
        {
            return DN_Solicitud.Consulta_Solicitudes_Exp(pExp);
        }
        public DataSet Consulta_Solicitudes_Tecnico(string pTecnico)
        {
            return DN_Solicitud.Consulta_Solicitudes_Tecnico(pTecnico);
        }
        


    }
}
