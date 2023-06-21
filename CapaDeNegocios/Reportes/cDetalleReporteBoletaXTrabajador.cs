using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Planillas;

namespace CapaDeNegocios.Reportes
{
    public class cDetalleReporteBoletaXTrabajador
    {
        private cDetallePlanilla detallePlanilla;
        private cPlanilla planilla;

        public cDetallePlanilla DetallePlanilla
        {
            get
            {
                return detallePlanilla;
            }

            set
            {
                detallePlanilla = value;
            }
        }

        public cPlanilla Planilla
        {
            get
            {
                return planilla;
            }

            set
            {
                planilla = value;
            }
        }
    }
}
