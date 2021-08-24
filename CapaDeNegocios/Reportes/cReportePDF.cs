using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reportes
{
    public class cReportePDF
    {
        public enum enumFormatoHoja
        {
            Horizontal,
            Vertical
        }

        public List<cHojaPDF> ListaHojasPDF { get; set; }
        public string RutaArchivo { get; set; }
        public enumFormatoHoja FormatoHoja { get; set; }
        public cReportePDF()
        {
            FormatoHoja = enumFormatoHoja.Vertical;
            ListaHojasPDF = new List<cHojaPDF>();
        }
    }
}
