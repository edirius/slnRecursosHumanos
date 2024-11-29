using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.PlanillaNueva
{
    public enum enumTipoPlantilla
    {
        Ingreso,
        AporteTrabajador,
        AporteEmpleador,
        Descuento
    }
    public class cnDetallePlantilla
    {
        public int Orden { get; set; }

    }
}
