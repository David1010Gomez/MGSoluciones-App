using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Materiales
    {
        #region Atributos
        private int _Id;
        private string _Material;
        private string _Cantidad;
        #endregion
        #region Constructor
        public E_Materiales()
        {
            _Id = 0;
            Material = string.Empty;
            _Cantidad = string.Empty;
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

        public string Material
        {
            get
            {
                return _Material;
            }

            set
            {
                _Material = value;
            }
        }

        public string Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }
        #endregion
    }
}
