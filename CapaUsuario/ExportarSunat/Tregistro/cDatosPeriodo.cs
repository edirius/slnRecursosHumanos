using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public enum enumTipoRegistro
    {
        Periodo = 1,
        TipoTrabajador = 2,
        RegimenSalud = 3,
        RegimenPensionario = 4,
        SCRTSalud = 5
    }

    public enum enumCategoria
    {
        Trabajador = 1,
        Pensionista = 2,
        PersonalTerceros = 3,
        PersonalFormacion = 4
    }

    public enum enumSCRTSalud
    {
        Essalud = 1,
        EPS = 2
    }

    public class cDatosPeriodo
    {
        public TablasParametricas.cTipoDocumentoIdentidad TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public TablasParametricas.cPaisEmisorDocumento PaisEmisor { get; set; }
        public enumCategoria Categoria { get; set; }
        public enumTipoRegistro TipoRegistro { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public TablasParametricas.cMotivoBaja MotivoFinPeriodo { get; set; }
        public TablasParametricas.cTipoTrabajador TipoTrabajador { get; set; }
        public TablasParametricas.cRegimenSalud RegimenSalud { get; set; }
        public TablasParametricas.cRegimenPensionario RegimenPensionario { get; set; }
        public enumSCRTSalud SCRTSalud { get; set; }
        public TablasParametricas.cEntidadesPrestadorasSalud EntidadesPrestadorasSalud { get; set; }

    }
}
