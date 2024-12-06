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
        
        public enumTipoPlantilla TipoPlantilla { get; set; }
        public Sunat.cMaestroDescuentos MaestroDescuentos { get; set; }
        public Sunat.cMaestroIngresos MaestroIngresos { get; set; }
        public Sunat.cMaestroAportacionesEmpleador MaestroAportacionesEmpleador { get; set; }
        public Sunat.cMaestroAportacionesTrabajador MaestroAportacionTrabajador { get; set; }

        public cnDetallePlantilla()
        {
            MaestroIngresos = new Sunat.cMaestroIngresos();
            MaestroDescuentos = new Sunat.cMaestroDescuentos();
            MaestroAportacionesEmpleador = new Sunat.cMaestroAportacionesEmpleador();
            MaestroAportacionTrabajador = new Sunat.cMaestroAportacionesTrabajador();
        }
    }
}
