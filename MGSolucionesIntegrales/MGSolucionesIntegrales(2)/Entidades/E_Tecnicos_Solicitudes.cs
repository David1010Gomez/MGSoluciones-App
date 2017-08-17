using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Tecnicos_Solicitudes
    {
        #region Atributos
        private int _Id;
        private int _Id_Solicitud;
        private int _Cedula_Tecnico;
        private string _Nombre_Tecnico;
        private string _Liquidado;
        #endregion
        #region Constructor
        public E_Tecnicos_Solicitudes()
        {
            _Id = 0;
            _Id_Solicitud = 0;
            _Cedula_Tecnico = 0;
            _Nombre_Tecnico = string.Empty;
            _Liquidado = string.Empty;
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

        public string Nombre_Tecnico
        {
            get
            {
                return _Nombre_Tecnico;
            }

            set
            {
                _Nombre_Tecnico = value;
            }
        }

        public string Liquidado
        {
            get
            {
                return _Liquidado;
            }

            set
            {
                _Liquidado = value;
            }
        }
        #endregion
    }
}
