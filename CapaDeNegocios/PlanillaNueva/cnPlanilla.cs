using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.PlanillaNueva
{
    public enum enumTipoCalculoMensual
    {
        DividirEntre30 = 1,
        DiasLaborados = 2
    }

    public enum enumTipoImpresionTardanzaFalta
    {
        AfectaALNeto = 0,
        AfectaAlSueldo = 1

    }

    public enum enumTipoPlanilla
    {
        NORMAL = 1,
        RACIONAMIENTO = 2,
        VACACIONES_TRUNCAS = 3,
        CTS = 4
    }

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
        public string Observaciones { get; set; }
        public Boolean Anulado { get; set; }
        public string Numerosiaf { get; set; }
        public bool Bloqueado { get; set; }
        public int Idtplantilla { get; set; }
        public enumTipoCalculoMensual Tipocalculomensual { get; set; }
        public CapaDeNegocios.Planillas.enumTipoImpresionTardanzaFalta TipoImpresionTardanzaFalta { get; set; }
        public enumTipoPlanilla TipoPlanilla { get; set; }
        public cnPlantilla Plantilla { get; set; }

        public cnPlanilla ()
        {
            Meta = new Obras.cMeta();
            FuenteFinanciamiento = new cFuenteFinanciamiento();
            RegimenLaboral = new DatosLaborales.cRegimenLaboral();
            Plantilla = new cnPlantilla();
            ListaDetalle = new List<cnDetallePlanilla>();
        }
    }
}
