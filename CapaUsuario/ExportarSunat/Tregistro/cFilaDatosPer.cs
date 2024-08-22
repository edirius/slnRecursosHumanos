using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cFilaDatosPer
    {
        public int Numero { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string PaisEmisorDocumento { get; set; }
        public string Categoría { get; set; }
        public string TipoDeRegistro { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string IndicadorTipoRegistro { get; set; }
        public string EPSServicios { get; set; }
    }
}
