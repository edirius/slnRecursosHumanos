using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Planillas;

namespace CapaDeNegocios.PlanillaNueva
{
    public class cnDetallePlanilla
    {
        public int codigo { get; set; }
        public int numero { get; set; }
        public cTrabajador miTrabajador { get; set; }
        public List<cnDetallePlanillaIngresos> ListaDetalleIngresos { get; set; }
        public List<cnDetallePlanillaEgresos > ListaDetalleEgresos { get; set; }
        public List<cnDetallePlanillaAportacionesTrabajador> ListaDetalleAportacionesTrabajador { get; set; }
        public List<cnDetallePlanillaAportacionesEmpleador> ListaDetalleAportacionesEmpleador { get; set; }

    }
}
