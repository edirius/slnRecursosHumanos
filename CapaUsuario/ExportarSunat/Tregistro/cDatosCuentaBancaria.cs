using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cDatosCuentaBancaria
    {
        public TablasParametricas.cTipoDocumentoIdentidad TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }
        public TablasParametricas.cPaisEmisorDocumento PaisEmisor { get; set; }
        public TablasParametricas.cEntidadBancaria EntidadBancaria { get; set; }
        public string NumeroCuenta { get; set; }
    }
}
