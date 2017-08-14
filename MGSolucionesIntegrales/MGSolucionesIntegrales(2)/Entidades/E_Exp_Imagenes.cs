using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Exp_Imagenes
    {
        #region Atributos
        private int _Id;
        private string _Fecha;
        private string _Nombre_Carpeta;
        private string _Cantidad_Imagenes;
        private string _Estado;
        #endregion
        #region Constructor
        public E_Exp_Imagenes()
        {
            _Id = 0;
            _Fecha = string.Empty;
            _Nombre_Carpeta = string.Empty;
            _Cantidad_Imagenes = string.Empty;
            _Estado = string.Empty;
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

        public string Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public string Nombre_Carpeta
        {
            get
            {
                return _Nombre_Carpeta;
            }

            set
            {
                _Nombre_Carpeta = value;
            }
        }

        public string Cantidad_Imagenes
        {
            get
            {
                return _Cantidad_Imagenes;
            }

            set
            {
                _Cantidad_Imagenes = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }
        #endregion
    }
}
