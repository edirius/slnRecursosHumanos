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
        public string cargo { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaInicioMeta { get; set; }
        public DateTime fechaFin { get; set; }
        public int diasLaborados { get; set; }
        public int diasSuspendidos { get; set; }
        public int diasMes { get; set; }
        public double totalIngreso { get; set; }
        public double totalAportacionesTrabajador { get; set; }
        public double totalDescuentos { get; set; }
        public double totalAportacionesEmpleador { get; set; }
        public double totalDescuentoAFP { get; set; }
        public double netoACobrar { get; set; }
        public cAFP afp { get; set; }
        public DatosLaborales.cRegimenPensionarioTrabajador regimenPensionario { get; set; }
        public string cuspp { get; set; }
        public string comision { get; set; }
        public string observacion { get; set; }
        public double sueldoPactado { get; set; }
        public double sueldoAfecto { get; set; }
        public double sueldoDiasLaborados { get; set; }
        public double sueldoDespuesFaltas { get; set; }
        public double sueldoMes { get; set; }

        public Boolean jornal { get; set; }

        public List<cnDetallePlanillaIngresos> ListaDetalleIngresos { get; set; }
        public List<cnDetallePlanillaEgresos > ListaDetalleEgresos { get; set; }
        public List<cnDetallePlanillaAportacionesTrabajador> ListaDetalleAportacionesTrabajador { get; set; }
        public List<cnDetallePlanillaAportacionesEmpleador> ListaDetalleAportacionesEmpleador { get; set; }

        public cnDetallePlanilla()
        {
            miTrabajador = new cTrabajador();
            ListaDetalleIngresos = new List<cnDetallePlanillaIngresos>();
            ListaDetalleEgresos = new List<cnDetallePlanillaEgresos>();
            ListaDetalleAportacionesEmpleador = new List<cnDetallePlanillaAportacionesEmpleador>();
            ListaDetalleAportacionesTrabajador = new List<cnDetallePlanillaAportacionesTrabajador>();
            
        }
    }
}
