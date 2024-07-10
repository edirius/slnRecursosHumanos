using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    

    public class cDatosPersonales
    {
        public TablasParametricas.cTipoDocumentoIdentidad TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public TablasParametricas.cPaisEmisorDocumento PaisEmisor { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public TablasParametricas.cSexo Sexo { get; set; }
    }
}
