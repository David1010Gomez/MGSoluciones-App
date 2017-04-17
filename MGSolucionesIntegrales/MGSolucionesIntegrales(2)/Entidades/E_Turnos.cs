using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Turnos
    {
        #region Atributos
        private int _Id;
        private int _Cedula_Tecnico;
        private int _Num_Exp;
        private string _Fecha_Turno;
        #endregion
        #region Constructor
        public E_Turnos()
        {
            _Id = 0;
            _Num_Exp = 0;
            _Cedula_Tecnico = 0;
            Fecha_Turno = string.Empty;
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

        public string Fecha_Turno
        {
            get
            {
                return _Fecha_Turno;
            }

            set
            {
                _Fecha_Turno = value;
            }
        }
        #endregion

    }
}
