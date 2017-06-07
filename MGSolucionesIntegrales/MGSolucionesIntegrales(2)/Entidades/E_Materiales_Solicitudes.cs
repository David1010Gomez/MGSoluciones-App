using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Materiales_Solicitudes
    {
        #region Atributos
        private int _Id;
        private string _Fecha_Ingreso;
        private int _Id_Solicitud;
        private int _Id_Material;
        private string _Cantidad;
        private int _Cedula_Tecnico;
        private int _Precio_Unidad;
        private int _Precio_Total;
        #endregion
        #region Constructor
        public E_Materiales_Solicitudes()
        {
            _Id = 0;
            _Fecha_Ingreso = string.Empty;
            _Id_Solicitud = 0;
            _Id_Material = 0;
            _Cantidad = string.Empty;
            _Cedula_Tecnico = 0;
            _Precio_Unidad = 0;
            _Precio_Total = 0;
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

        public string Fecha_Ingreso
        {
            get
            {
                return _Fecha_Ingreso;
            }

            set
            {
                _Fecha_Ingreso = value;
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

        public int Id_Material
        {
            get
            {
                return _Id_Material;
            }

            set
            {
                _Id_Material = value;
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

        public int Precio_Unidad
        {
            get
            {
                return _Precio_Unidad;
            }

            set
            {
                _Precio_Unidad = value;
            }
        }

        public int Precio_Total
        {
            get
            {
                return _Precio_Total;
            }

            set
            {
                _Precio_Total = value;
            }
        }
        #endregion
    }
}
