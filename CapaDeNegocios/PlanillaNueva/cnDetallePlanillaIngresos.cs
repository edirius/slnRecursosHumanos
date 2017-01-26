using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.PlanillaNueva
{
    public class cnDetallePlanillaIngresos
    {
        public double Monto { get; set; }
        public Planillas.cMaestroIngresos MaestroIngresos { get; set; }
        public int Codigo { get; set; }
    }
}
