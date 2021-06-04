using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reloj
{
    public class cHuellaUsuarioReloj
    {
        cUsuarioReloj _UsuarioReloj;
        string _IdUsuario = "";
        int _IdwVerifyMode = 0;
        int _IdwInOutMode = 0;
        int _IdwYear = 0;
        int _IdwMonth = 0;
        int _IdwDay = 0;
        int _IdwHour = 0;
        int _IdwMinute = 0;
        int _IdwSecond = 0;
        int _IdwWorkcode = 0;
        DateTime _FechaYHora;

        public cUsuarioReloj UsuarioReloj
        {
            get
            {
                return _UsuarioReloj;
            }

            set
            {
                _UsuarioReloj = value;
            }
        }

        public string IdUsuario
        {
            get
            {
                return _IdUsuario;
            }

            set
            {
                _IdUsuario = value;
            }
        }

        public int IdwVerifyMode
        {
            get
            {
                return _IdwVerifyMode;
            }

            set
            {
                _IdwVerifyMode = value;
            }
        }

        public int IdwInOutMode
        {
            get
            {
                return _IdwInOutMode;
            }

            set
            {
                _IdwInOutMode = value;
            }
        }

        public int IdwYear
        {
            get
            {
                return _IdwYear;
            }

            set
            {
                _IdwYear = value;
            }
        }

        public int IdwMonth
        {
            get
            {
                return _IdwMonth;
            }

            set
            {
                _IdwMonth = value;
            }
        }

        public int IdwDay
        {
            get
            {
                return _IdwDay;
            }

            set
            {
                _IdwDay = value;
            }
        }

        public int IdwHour
        {
            get
            {
                return _IdwHour;
            }

            set
            {
                _IdwHour = value;
            }
        }

        public int IdwMinute
        {
            get
            {
                return _IdwMinute;
            }

            set
            {
                _IdwMinute = value;
            }
        }

        public int IdwSecond
        {
            get
            {
                return _IdwSecond;
            }

            set
            {
                _IdwSecond = value;
            }
        }

        public int IdwWorkcode
        {
            get
            {
                return _IdwWorkcode;
            }

            set
            {
                _IdwWorkcode = value;
            }
        }

        public DateTime FechaYHora
        {
            get
            {
                return _FechaYHora;
            }

            set
            {
                _FechaYHora = value;
            }
        }

        public void ActualizarFecha()
        {
            _FechaYHora = new DateTime(_IdwYear, _IdwMonth, _IdwDay, _IdwHour, _IdwMinute, _IdwSecond);
        }
    }
}
