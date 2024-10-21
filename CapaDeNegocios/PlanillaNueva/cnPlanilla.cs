using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.PlanillaNueva
{
    public class cnPlanilla
    {
        public List<cnDetallePlanilla> ListaDetalle { get; set; }
        public int codigo { get; set; }
        public string numeroPlanilla { get; set; }
        public string Mes { get; set; }
        public string Año { get; set; }
        public DateTime Fecha { get; set; }
        public Obras.cMeta Meta { get; set; }
        public cFuenteFinanciamiento FuenteFinanciamiento { get; set; }
        public DatosLaborales.cRegimenLaboral RegimenLaboral { get; set; }
        public string Descripcion { get; set; }
        public CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta TipoImpresionTardanzaFalta { get; set; }

        public cnPlanilla ()
        {
            Meta = new Obras.cMeta();
            FuenteFinanciamiento = new cFuenteFinanciamiento();
            RegimenLaboral = new DatosLaborales.cRegimenLaboral();
            ListaDetalle = new List<cnDetallePlanilla>();
        }
    }
}
