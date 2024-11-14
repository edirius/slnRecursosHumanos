using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.Planilla.VacacionesTruncas
{
    public enum enumTipoAccion
    {
        nuevo = 0,
        modificado = 1
    }
    public class cDetallePlanillaImpresion
    {
        public int IdtPlanill { get; set; }
        public enumTipoAccion Accion { get; set; }
        public int Numero { get; set; }
        public int IdtTrabajador { get; set; }
        public string ApellidosyNombres { get; set; }
        public string DNI { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaInicioMeta { get; set; }
        public DateTime FechaFin { get; set; }
        public int DiasMes { get; set; }
        public int DiasSusp { get; set; }
        public int DiasLaborados { get; set; }
        public string AFP { get; set; }
        public int IdtAFP { get; set; }
        public string Comision { get; set; }
        public string CUSPP { get; set; }
        public double RemuneracionContrato { get; set; }
        public double RemuneracionXDiasLaborados { get; set; }
        public double Faltas { get; set; }
        public double Tardanzas { get; set; }
        public double SueldoDespuesFaltas { get; set; }


    }
}
