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
        private int _Cantidad_Imagenes;
        private string _Estado;
        private int _Usuario_Guardo_Imagenes;
        #endregion
        #region Constructor
        public E_Exp_Imagenes()
        {
            _Id = 0;
            _Fecha = string.Empty;
            _Nombre_Carpeta = string.Empty;
            _Cantidad_Imagenes = 0;
            _Estado = string.Empty;
            _Usuario_Guardo_Imagenes = 0;
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

        public int Cantidad_Imagenes
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

        public int Usuario_Guardo_Imagenes
        {
            get
            {
                return _Usuario_Guardo_Imagenes;
            }

            set
            {
                _Usuario_Guardo_Imagenes = value;
            }
        }
        #endregion
    }
}
