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
        public DateTime FechaNacimiento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public TablasParametricas.cSexo Sexo { get; set; }
        public TablasParametricas.cNacionalidad Nacionalidad { get;set;}
        public string TelefonoCodigoLargaDistancia { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public cDireccion Direccion01 { get; set; }
        public cDireccion Direccion02 { get; set; }
        public string IndicadorEssalud { get; set; }
        public Boolean SCRTSalud { get; set; }
        public Boolean SCRTPension { get; set; }

        public cDatosPersonales()
        {
            TipoDocumento = new TablasParametricas.cTipoDocumentoIdentidad();
            PaisEmisor = new TablasParametricas.cPaisEmisorDocumento();
            Sexo = new TablasParametricas.cSexo();
            Nacionalidad = new TablasParametricas.cNacionalidad();
            Direccion01 = new cDireccion();
            Direccion02 = new cDireccion();
        }
    }
}
