using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Solicitudes
    {
        #region Atributos
        private int _Id;
        private int _Num_Exp;
        private string _Poliza;
        private string _Asegurado;
        private string _Contacto;
        private string _Fact;
        private string _Tecnico;
        private string _Notas;
        private string _Direccion;
        private string _Estado_Caso;
        private int _Cedula_Usuario_Creacion;
        private string _Fecha_Cierre;
        private int _Cedula_Usuario_Cierre;
        private int _Usuario_Ultima_Actualizacion;
        #endregion
        #region Constructor
        public E_Solicitudes()
        {
            _Id = 0;
            _Num_Exp = 0;
            _Poliza = string.Empty;
            _Asegurado = string.Empty;
            _Contacto = string.Empty;
            _Fact = string.Empty;
            _Tecnico = string.Empty;
            _Notas = string.Empty;
            _Direccion = string.Empty;
            _Estado_Caso = string.Empty;
            _Cedula_Usuario_Creacion = 0;
            _Fecha_Cierre = string.Empty;
            _Cedula_Usuario_Cierre = 0;
            _Usuario_Ultima_Actualizacion = 0;
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

        public int Num_Exp
        {
            get
            {
                return _Num_Exp;
            }

            set
            {
                _Num_Exp = value;
            }
        }

        public string Poliza
        {
            get
            {
                return _Poliza;
            }

            set
            {
                _Poliza = value;
            }
        }

        public string Asegurado
        {
            get
            {
                return _Asegurado;
            }

            set
            {
                _Asegurado = value;
            }
        }

        public string Contacto
        {
            get
            {
                return _Contacto;
            }

            set
            {
                _Contacto = value;
            }
        }

        public string Fact
        {
            get
            {
                return _Fact;
            }

            set
            {
                _Fact = value;
            }
        }

        public string Tecnico
        {
            get
            {
                return _Tecnico;
            }

            set
            {
                _Tecnico = value;
            }
        }

        public string Notas
        {
            get
            {
                return _Notas;
            }

            set
            {
                _Notas = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }

        public string Estado_Caso
        {
            get
            {
                return _Estado_Caso;
            }

            set
            {
                _Estado_Caso = value;
            }
        }

        public int Cedula_Usuario_Creacion
        {
            get
            {
                return _Cedula_Usuario_Creacion;
            }

            set
            {
                _Cedula_Usuario_Creacion = value;
            }
        }

        public string Fecha_Cierre
        {
            get
            {
                return _Fecha_Cierre;
            }

            set
            {
                _Fecha_Cierre = value;
            }
        }

        public int Cedula_Usuario_Cierre
        {
            get
            {
                return _Cedula_Usuario_Cierre;
            }

            set
            {
                _Cedula_Usuario_Cierre = value;
            }
        }

        public int Usuario_Ultima_Actualizacion
        {
            get
            {
                return _Usuario_Ultima_Actualizacion;
            }

            set
            {
                _Usuario_Ultima_Actualizacion = value;
            }
        }


        #endregion
    }
}
