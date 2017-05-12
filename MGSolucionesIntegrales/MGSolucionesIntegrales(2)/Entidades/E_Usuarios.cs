using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Usuarios
    {
        #region Atributos
        private int _Id;
        private int _Cedula;
        private string _Nombre;
        private string _Contraseña;
        private string _Cargo;
        private int _Id_Rol;
        private string _Estado;
        private string _Disponible;
        #endregion
        #region Constructor
        public E_Usuarios()
        {
            _Id = 0;
            _Cedula = 0;
            _Nombre = string.Empty;
            _Contraseña = string.Empty;
            _Cargo = string.Empty;
            _Id_Rol = 0;
            _Estado = string.Empty;
            _Disponible = string.Empty;
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
        public int Cedula
        {
            get
            {
                return _Cedula;
            }

            set
            {
                _Cedula = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return _Contraseña;
            }

            set
            {
                _Contraseña = value;
            }
        }

        public string Cargo
        {
            get
            {
                return _Cargo;
            }

            set
            {
                _Cargo = value;
            }
        }

        public int Id_Rol
        {
            get
            {
                return _Id_Rol;
            }

            set
            {
                _Id_Rol = value;
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

        public string Disponible
        {
            get
            {
                return _Disponible;
            }

            set
            {
                _Disponible = value;
            }
        }
        #endregion
    }
}
