using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.PlanillaNueva
{
    public class cnDetallePlanillaAportacionesTrabajador
    {
        public double Monto { get; set; }
        public Sunat.cMaestroAportacionesTrabajador MaestroAportacionTrabajador { get; set; }
        public int Codigo { get; set; }

    }
}
