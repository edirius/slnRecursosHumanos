using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cAsistenciaMes
    {
        cTrabajador _Trabajador;
        List<cAsistenciaDia> _ListaAsistenciaDia;
        DateTime _InicioMes;
        DateTime _FinMes;
        cHorario _HorarioTrabajador;


        public cAsistenciaMes()
        {
            _Trabajador = new cTrabajador();
            _ListaAsistenciaDia = new List<cAsistenciaDia>();
            _HorarioTrabajador = new cHorario();
        }

        public cTrabajador Trabajador
        {
            get
            {
                return _Trabajador;
            }

            set
            {
                _Trabajador = value;
            }
        }

        public List<cAsistenciaDia> ListaAsistenciaDia
        {
            get
            {
                return _ListaAsistenciaDia;
            }

            set
            {
                _ListaAsistenciaDia = value;
            }
        }

        public DateTime InicioMes
        {
            get
            {
                return _InicioMes;
            }

            set
            {
                _InicioMes = value;
            }
        }

        public DateTime FinMes
        {
            get
            {
                return _FinMes;
            }

            set
            {
                _FinMes = value;
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
    }
}
