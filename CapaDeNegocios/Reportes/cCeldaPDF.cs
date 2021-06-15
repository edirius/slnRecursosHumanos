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
        public cTablaPDF TablaPDF { get; set; }
        public Color ColorLetra { get; set; }
        public float AltoColumna { get; set; }

        public cCeldaPDF()
        {
            Negrita = false;
            ColorFondo = Color.White;
            ColorLetra = Color.Black;
            AltoColumna = 20f;
        }

        public cCeldaPDF(string contenido)
        {
            Contenido = contenido;
            ColorFondo = Color.White;
            ColorLetra = Color.Black;
            AltoColumna = 20f;
        }

        public cCeldaPDF(Boolean negrita, Color color, string contenido)
        {
            Negrita = negrita;
            ColorFondo = color;
            Contenido = contenido;
            ColorLetra = Color.Black;
            AltoColumna = 20f;
        }
    }
}
