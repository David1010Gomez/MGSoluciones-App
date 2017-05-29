using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Notas_Solicitudes
    {
        #region Atributos
        private int _Id;
        private string _Fecha_nota;
        private int _Num_Exp;
        private string _Observaciones;
        private int _Cedula_Usuario_Inserto_Nota;
        private string _Estado_Caso;
        #endregion
        #region Constructor
        public E_Notas_Solicitudes()
        {
            _Id = 0;
            _Fecha_nota = string.Empty;
            _Num_Exp = 0;
            _Observaciones = string.Empty;
            _Cedula_Usuario_Inserto_Nota = 0;
            _Estado_Caso = string.Empty;

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

        public string Fecha_nota
        {
            get
            {
                return _Fecha_nota;
            }

            set
            {
                _Fecha_nota = value;
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

        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }

            set
            {
                _Observaciones = value;
            }
        }

        public int Cedula_Usuario_Inserto_Nota
        {
            get
            {
                return _Cedula_Usuario_Inserto_Nota;
            }

            set
            {
                _Cedula_Usuario_Inserto_Nota = value;
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

        #endregion
    }
}
