using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CapaDeNegocios.Reportes
{
    public class cCeldaPDF
    {
        public string Contenido { get; set; }
        public Color ColorFondo { get; set; }
        public Boolean Negrita { get; set; }

        public cCeldaPDF()
        {
            Negrita = false;
        }

        public cCeldaPDF(Boolean negrita, Color color, string contenido)
        {
            Negrita = negrita;
            ColorFondo = color;
            Contenido = contenido;
        }
    }
}
