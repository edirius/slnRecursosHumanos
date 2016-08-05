using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.DatosLaborales
{
    public class cPeriodoSistemaPension
    {
        public cPeriodoSistemaPension()
        {
            fechaFinal = new cFinPeriodo();
            miSistemaPension = new cSistemaPension();
        }

        DateTime fechaInicio;

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        cFinPeriodo fechaFinal;
        
        cSistemaPension miSistemaPension;

        public cSistemaPension MiSistemaPension
        {
            get { return miSistemaPension; }
            set { miSistemaPension = value; }
        }

        public cFinPeriodo FechaFinal
        {
            get
            {
                return fechaFinal;
            }

            set
            {
                fechaFinal = value;
            }
        }
    }
}
