using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Servicio_Solicitud
    {
        #region Atributos
        private int _Id_Servicio;
        private int _Id_Solicitud;
        private int _Cedula_Tecnico;
        #endregion
        #region Constructor
        public E_Servicio_Solicitud()
        {
            _Id_Servicio = 0;
            _Id_Solicitud = 0;
            _Cedula_Tecnico = 0;
        }
        #endregion
        #region Encapsulamiento
        public int Id_Servicio
        {
            get
            {
                return _Id_Servicio;
            }

            set
            {
                _Id_Servicio = value;
            }
        }

        public int Id_Solicitud
        {
            get
            {
                return _Id_Solicitud;
            }

            set
            {
                _Id_Solicitud = value;
            }
        }

        public int Cedula_Tecnico
        {
            get
            {
                return _Cedula_Tecnico;
            }

            set
            {
                _Cedula_Tecnico = value;
            }
        }
        #endregion
    }
}
