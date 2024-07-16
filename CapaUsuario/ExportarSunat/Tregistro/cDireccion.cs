using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public class cDireccion
    {
        public TablasParametricas.cTipoVia TipoVia { get; set; }
        public string NombreVia { get; set; }
        public string NumeroVia { get; set; }
        public string Departamento { get; set; }
        public string Interior { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public string Kilometro { get; set; }
        public string Bloque { get; set; }
        public string Etapa { get; set; }
        public TablasParametricas.cTipoZona TipoZona { get; set; }
        public string NombreZona { get; set; }
        public string Referencia { get; set; }
        public cDistrito Distrito { get; set; }

    }
}
