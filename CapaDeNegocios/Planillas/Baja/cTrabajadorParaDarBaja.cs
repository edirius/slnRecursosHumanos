using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Planillas.Baja
{
    public class cTrabajadorParaDarBaja
    {
        public Boolean Check { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaInicio { get; set; }
        public CapaDeNegocios.DatosLaborales.cPeriodoTrabajador PeriodoTrabajador { get; set; }

        public cTrabajadorParaDarBaja()
        {
            PeriodoTrabajador = new DatosLaborales.cPeriodoTrabajador();
        }
    }
}
