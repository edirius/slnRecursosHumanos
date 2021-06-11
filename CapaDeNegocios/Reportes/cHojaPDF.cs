using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reportes
{
    public class cHojaPDF
    {
        public List<cTablaPDF> ListaDeTablas { get; set; }

        public cHojaPDF()
        {
            ListaDeTablas = new List<cTablaPDF>();
        }
    }
}
