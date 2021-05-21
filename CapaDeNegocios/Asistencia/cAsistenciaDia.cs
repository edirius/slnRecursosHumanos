using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cAsistenciaDia
    {
        List<cPicado> _ListaPicados;
        DateTime _Dia;
        Boolean _Tarde;
        Boolean _Falta;
        TimeSpan _MinutosTarde;
        cHorario _HorarioTrabajador;
        List<cExcepcionesAsistencia> _ListaSalidas;

        public cAsistenciaDia()
        {
            _ListaPicados = new List<cPicado>();
            _HorarioTrabajador = new cHorario();
        }

        public List<cPicado> ListaPicados
        {
            get
            {
                return _ListaPicados;
            }

            set
            {
                _ListaPicados = value;
            }
        }

        public DateTime Dia
        {
            get
            {
                return _Dia;
            }

            set
            {
                _Dia = value;
            }
        }

        public bool Tarde
        {
            get
            {
                return _Tarde;
            }

            set
            {
                _Tarde = value;
            }
        }

        public bool Falta
        {
            get
            {
                return _Falta;
            }

            set
            {
                _Falta = value;
            }
        }

        public cHorario HorarioTrabajador
        {
            get
            {
                return _HorarioTrabajador;
            }

            set
            {
                _HorarioTrabajador = value;
            }
        }

        public TimeSpan MinutosTarde
        {
            get
            {
                return _MinutosTarde;
            }

            set
            {
                _MinutosTarde = value;
            }
        }

        public List<cExcepcionesAsistencia> ListaSalidas
        {
            get
            {
                return _ListaSalidas;
            }

            set
            {
                _ListaSalidas = value;
            }
        }
    }
}
