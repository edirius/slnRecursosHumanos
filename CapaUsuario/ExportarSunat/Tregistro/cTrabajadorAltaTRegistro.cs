using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.ExportarSunat;
using CapaDeNegocios.DatosLaborales;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public enum enumTipoSCRTSalud
    {
        Essalud =1,
        EPS =2
    }

    public class cTrabajadorAltaTRegistro
    {
        public Boolean Marcado { get; set; }
        public int Numero { get; set; }
        public int Id_trabajador { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DNI { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Planilla { get; set; }
        public cPeriodoTrabajador PeriodoTrabajador { get; set; }
        public cDatosPersonales DatosPersonales { get; set; }
        public List<cDatosTrabajador> DatosTrabajador { get; set; }
        public List<cDatosPeriodo> DatosPeriodo { get; set; }
        public List<cRegimenPensionarioTrabajador> PeriodosRegimenPensionario { get; set; }
        public Boolean TieneScrt { get; set; }
        public enumTipoSCRTSalud TipoSCRTSalud { get; set; }
        public string Observaciones { get; set; }
        public cRegimenTrabajador RegimenTrabajador { get; set; }
        public cTrabajadorAltaTRegistro()
        {
            PeriodoTrabajador = new cPeriodoTrabajador();
            DatosPersonales = new cDatosPersonales();
            DatosTrabajador = new List<cDatosTrabajador>();
            PeriodosRegimenPensionario = new List<cRegimenPensionarioTrabajador>();
            RegimenTrabajador = new cRegimenTrabajador();
        }
    }
}
