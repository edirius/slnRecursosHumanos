using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Asistencia;
using CapaDeNegocios.AsistenciaGeneral;

namespace CapaDeNegocios.Reportes
{
    public class cReporteMultipleAsistencia
    {
        private cTrabajador _Trabajador;
        private CapaDeNegocios.Asistencia.cAsistenciaMes _AsistenciaMes;
        private CapaDeNegocios.AsistenciaGeneral.cJornadaLaboral _JornadaLaboral;

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

        public cAsistenciaMes AsistenciaMes
        {
            get
            {
                return _AsistenciaMes;
            }

            set
            {
                _AsistenciaMes = value;
            }
        }

        public cJornadaLaboral JornadaLaboral
        {
            get
            {
                return _JornadaLaboral;
            }

            set
            {
                _JornadaLaboral = value;
            }
        }
    }
}
