using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Tipo_Servicio
    {
        #region Atributos
        private int _Id_Servicio;
        private string _Servicio;
        #endregion
        #region Constructor
        public E_Tipo_Servicio()
        {
            _Id_Servicio = 0;
            _Servicio = string.Empty;
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

        public string Servicio
        {
            get
            {
                return _Servicio;
            }

            set
            {
                _Servicio = value;
            }
        }
        #endregion
    }
}
