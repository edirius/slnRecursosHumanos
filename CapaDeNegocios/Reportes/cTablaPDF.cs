using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reportes
{
    public class cTablaPDF
    {
        public List<cFilasPDF> ListaFilas { get; set; }
        public int columnas { get; set; }
        public float[] anchoColumnas { get; set; }
        public cTablaPDF()
        {
            ListaFilas = new List<cFilasPDF>();
        }
    }
}
