using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Log_Aplazamientos
    {
        #region Atributos
        private int _Id;
        private string _Fecha_Aplazamiento;
        private int _Id_Solicitud;
        private int _Cedula_Tecnico;
        private string _Trabajo;

        
        #endregion
        #region Constructor
        public E_Log_Aplazamientos()
        {
            _Id = 0;
            _Fecha_Aplazamiento = string.Empty;
            _Id_Solicitud = 0;
            _Cedula_Tecnico = 0;
            _Trabajo = string.Empty;
        }
        #endregion
        #region Encapsulamiento
        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string Fecha_Aplazamiento
        {
            get
            {
                return _Fecha_Aplazamiento;
            }

            set
            {
                _Fecha_Aplazamiento = value;
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

        public string Trabajo
        {
            get
            {
                return _Trabajo;
            }

            set
            {
                _Trabajo = value;
            }
        }
        #endregion
    }
}
