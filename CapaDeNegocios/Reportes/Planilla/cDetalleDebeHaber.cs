using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reportes.Planilla
{
    public enum enumTipoHaberDebe
    {
        haber,
        debe
    }
    public class cDetalleDebeHaber
    {
        public double Monto { get; set; }
        public string Concepto { get; set; }
        public enumTipoHaberDebe TipoHaberDebe { get; set; }
    }
}
