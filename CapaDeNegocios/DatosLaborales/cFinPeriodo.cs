using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.DatosLaborales
{
    public class cFinPeriodo
    {
        private DateTime fechaFin;

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        private Boolean tieneFin;

        public Boolean TieneFin
        {
            get { return tieneFin; }
            set { tieneFin = value; }
        }

    }
}
