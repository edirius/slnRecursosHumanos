using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.DatosLaborales
{
    public class cPeriodoTipoTrabajador
    {
        private DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        private cFinPeriodo fechaFinal;

        public cFinPeriodo FechaFinal
        {
            get { return fechaFinal; }
            set { fechaFinal = value; }
        }

        
        private cTipoTrabajador tipoTrabajador;

        public cTipoTrabajador TipoTrabajador
        {
            get { return tipoTrabajador; }
            set { tipoTrabajador = value; }
        }
    }
}
