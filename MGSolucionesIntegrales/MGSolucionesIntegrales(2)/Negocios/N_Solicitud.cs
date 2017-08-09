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
        public DataSet Seleccionar_Turnos(int pId, int pCedulaTecnico)
        {
            return DN_Solicitud.Seleccionar_Turnos(pId, pCedulaTecnico);
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
        public DataSet Consulta_Solicitudes_Exp(long pExp)
        {
            return DN_Solicitud.Consulta_Solicitudes_Exp(pExp);
        }
        public DataSet Consulta_Solicitudes_Tecnico(string pTecnico)
        {
            return DN_Solicitud.Consulta_Solicitudes_Tecnico(pTecnico);
        }
        public int Actualiza_Estado_Tecnico(E_Usuarios Obj_Usuarios)
        {
            return DN_Solicitud.Actualiza_Estado_Tecnico(Obj_Usuarios);
        }
        public int Inserta_Tecnico_Solicitudes(E_Tecnicos_Solicitudes Obj_Tecnicos_Solicitudes)
        {
            return DN_Solicitud.Inserta_Tecnico_Solicitudes(Obj_Tecnicos_Solicitudes);
        }
        public DataSet Busca_Tecnicos_Solicitud(string pAccion, int pIdSolicitud, int pCedulaTecnico)
        {
            return DN_Solicitud.Busca_Tecnicos_Solicitud(pAccion, pIdSolicitud, pCedulaTecnico);
        }
        public DataSet Busca_Historial_Solicitud(int pIdSolicitud)
        {
            return DN_Solicitud.Busca_Historial_Solicitud(pIdSolicitud);
        }
        public DataSet Selecciona_Tipo_Servicios()
        {
            return DN_Solicitud.Selecciona_Tipo_Servicios();
        }
        public int Abc_Servicio_Solicitud(string pAccion, E_Servicio_Solicitud Obj_Servicio_Solicitud)
        {
            return DN_Solicitud.Abc_Servicio_Solicitud(pAccion, Obj_Servicio_Solicitud);
        }
        public DataSet Selecciona_Servicio_Solicitud(string pAccion, int pIdServicio, int pIdSolicitud, int pCedulaTecnico)
        {
            return DN_Solicitud.Selecciona_Servicio_Solicitud(pAccion, pIdServicio, pIdSolicitud, pCedulaTecnico);
        }
        public DataSet Selecciona_Precio_Unitario(int pId)
        {
            return DN_Solicitud.Selecciona_Precio_Unitario(pId);
        }
        public DataSet Suma_Materiales_Solicitud(int pId)
        {
            return DN_Solicitud.Suma_Materiales_Solicitud(pId);
        }
        public DataSet Selecciona_Solicitud_Libre(int pId, string pUsuarioGestionando)
        {
            return DN_Solicitud.Selecciona_Solicitud_Libre(pId, pUsuarioGestionando);
        }
        public int Usuario_Gestionando_Caso(int pId, string pUsuario_Gestionando)
        {
            return DN_Solicitud.Usuario_Gestionando_Caso(pId,pUsuario_Gestionando);
        }
        public int Usuario_Eliminar_Gestionando_Caso(string pUsuario_Gestionando)
        {
            return DN_Solicitud.Usuario_Eliminar_Gestionando_Caso(pUsuario_Gestionando);
        }
        public int Insertar_Log_Aplazamientos(E_Log_Aplazamientos Obj_Log_Aplazamientos)
        {
            return DN_Solicitud.Insertar_Log_Aplazamientos(Obj_Log_Aplazamientos);
        }
        public DataSet Consulta_Notas_Solicitudes_Exp(int pExp)
        {
            return DN_Solicitud.Consulta_Notas_Solicitudes_Exp(pExp);
        }
        public DataSet Consulta_Notas_Solicitudes_Fecha(string pFecha_Inicial, string pFecha_Final)
        {
            return DN_Solicitud.Consulta_Notas_Solicitudes_Fecha(pFecha_Inicial, pFecha_Final);
        }
        public DataSet Consulta_Materiales_Solicitudes_Exp(int pExp)
        {
            return DN_Solicitud.Consulta_Materiales_Solicitudes_Exp(pExp);
        }
        public DataSet Consulta_Materiales_Solicitudes_Fecha(string pFecha_Inicial, string pFecha_Final)
        {
            return DN_Solicitud.Consulta_Materiales_Solicitudes_Fecha(pFecha_Inicial, pFecha_Final);
        }
        public DataSet Consulta_Materiales_Solicitudes_Tecnico(string pTecnico)
        {
            return DN_Solicitud.Consulta_Materiales_Solicitudes_Tecnico(pTecnico);
        }
        public int Actualiza_Estado_Caso(E_Solicitudes Obj_E_Solicitudes)
        {
            return DN_Solicitud.Actualiza_Estado_Caso(Obj_E_Solicitudes);
        }
        public DataSet Consulta_Solicitudes_Fecha_Tecnico(string pFecha_Inicial, string pFecha_Final, int pCedulaTecnico)
        {
            return DN_Solicitud.Consulta_Solicitudes_Fecha_Tecnico(pFecha_Inicial, pFecha_Final, pCedulaTecnico);
        }
        public DataSet Consulta_Solicitudes_Exp_Tecnico(int pExp, int pCedulaTecnico)
        {
            return DN_Solicitud.Consulta_Solicitudes_Exp_Tecnico(pExp, pCedulaTecnico);
        }
        public DataSet Consulta_Materiales_Fecha_Tecnico(string pFecha_Inicial, string pFecha_Final, int pCedulaTecnico)
        {
            return DN_Solicitud.Consulta_Materiales_Fecha_Tecnico(pFecha_Inicial, pFecha_Final, pCedulaTecnico);
        }
        public DataSet Consulta_Materiales_Exp_Tecnico(int pExp, int pCedulaTecnico)
        {
            return DN_Solicitud.Consulta_Materiales_Exp_Tecnico(pExp, pCedulaTecnico);
        }
        public DataSet Selecciona_Caso_Id(int pIdCaso)
        {
            return DN_Solicitud.Selecciona_Caso_Id(pIdCaso);
        }
    }
}
