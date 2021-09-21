using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;
using CapaDeNegocios.Asistencia;
using CapaDeNegocios.AsistenciaGeneral;

namespace CapaUsuario.AsistenciaGen
{
    public class DetalleViewJornadaLaboral
    {
        private int _NumeroDia;
        private DateTime _Dia;
        private CapaDeNegocios.Asistencia.cAsistenciaDia _AsistenciaDia;
        private cTurnoDia _TurnoDia;
        private CapaDeNegocios.AsistenciaGeneral.cDetalleJornadaLaboral _DetalleJornadaLaboral;
        private CapaDeNegocios.Asistencia.cExcepcionesAsistencia _ExcepcionAsistencia;

        public int NumeroDia
        {
            get
            {
                return _NumeroDia;
            }

            set
            {
                _NumeroDia = value;
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

        public cAsistenciaDia AsistenciaDia
        {
            get
            {
                return _AsistenciaDia;
            }

            set
            {
                _AsistenciaDia = value;
            }
        }

        public cDetalleJornadaLaboral DetalleJornadaLaboral
        {
            get
            {
                return _DetalleJornadaLaboral;
            }

            set
            {
                _DetalleJornadaLaboral = value;
            }
        }

        public cExcepcionesAsistencia ExcepcionAsistencia
        {
            get
            {
                return _ExcepcionAsistencia;
            }

            set
            {
                _ExcepcionAsistencia = value;
            }
        }

        public cTurnoDia TurnoDia
        {
            get
            {
                return _TurnoDia;
            }

            set
            {
                _TurnoDia = value;
            }
        }
    }
}
