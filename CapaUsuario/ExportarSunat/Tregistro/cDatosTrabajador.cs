using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cDatosTrabajador
    {
        public TablasParametricas.cTipoDocumentoIdentidad TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public TablasParametricas.cPaisEmisorDocumento PaisEmisor { get; set; }
        public TablasParametricas.cRegimenLaboral RegimenLaboral { get; set; }
        public TablasParametricas.cOcupacion Ocupacion { get; set; }
        public TablasParametricas.cSituacionEducativa SituacionEducativa { get; set; }
        public string Discapacidad { get; set; }
        public string CUSPP { get; set; }
        public string SCRTPension { get; set; }
        public TablasParametricas.cTipoContrato TipoContrato { get; set; }
        public string SujetoARegimenAlternativo { get; set; }
        public string SujetoAJornadaMaxima { get; set; }
        public string SujetoAHorarioNocturno { get; set; }
        public string EsSindicalizado { get; set; }
        public TablasParametricas.cPeriodicidadIngreso PeriodicidadIngreso { get; set; }
        public double MontoBasico { get; set; }
        public TablasParametricas.cSituacion Situacion { get; set; }
        public string RentaQuintaExonerada { get; set; }
        public TablasParametricas.cSituacionEspecialTrabajador SituacionEspecialTrabajador { get; set; }
        public TablasParametricas.cTipoPago TipoPago { get; set; }
        public TablasParametricas.cCategoriaOcupacionalTrabajador CategoriaOcupacionalTrabajador { get; set; }
        public string ConvenioParaEvitarDobleTri { get; set; }
        public string RUC { get; set; }
        public TablasParametricas.cTipoTrabajador TipoTrabajador { get; set; }
        public TablasParametricas.cCargo Cargo { get; set; }
        public List<cDatosPeriodo> DatosPeriodo { get; set; }

        public cDatosTrabajador()
        {
            TipoDocumento = new TablasParametricas.cTipoDocumentoIdentidad();
            PaisEmisor = new TablasParametricas.cPaisEmisorDocumento();
            RegimenLaboral = new TablasParametricas.cRegimenLaboral();
            Ocupacion = new TablasParametricas.cOcupacion();
            TipoContrato = new TablasParametricas.cTipoContrato();
            PeriodicidadIngreso = new TablasParametricas.cPeriodicidadIngreso();
            Situacion = new TablasParametricas.cSituacion();
            SituacionEspecialTrabajador = new TablasParametricas.cSituacionEspecialTrabajador();
            CategoriaOcupacionalTrabajador = new TablasParametricas.cCategoriaOcupacionalTrabajador();
            SituacionEducativa = new TablasParametricas.cSituacionEducativa();
            DatosPeriodo = new List<cDatosPeriodo>();
        }
    }
}
