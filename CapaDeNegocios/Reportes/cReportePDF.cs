using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reportes
{
    public class cReportePDF
    {
        public List<cHojaPDF> ListaHojasPDF { get; set; }
        public string RutaArchivo { get; set; }
        public cReportePDF()
        {
            ListaHojasPDF = new List<cHojaPDF>();
        }
    }
}
