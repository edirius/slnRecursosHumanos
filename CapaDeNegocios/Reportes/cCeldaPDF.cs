using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CapaDeNegocios.Reportes
{
    public class Borde
    {
        public float AnchoArriba;
        public float AnchoAbajo;
        public float AnchoIzquierda;
        public float AnchoDerecha;

        public Borde()
        {
            AnchoArriba = 1;
            AnchoAbajo = 1;
            AnchoDerecha = 1;
            AnchoIzquierda = 1;
        }
    }

    public enum enumAlineamiento
    {
        defecto = 1,
        derecha = 2,
        izquierda = 3,
        centro = 4,
        abajo= 5
    }

    public class cCeldaPDF
    {
        public string Contenido { get; set; }
        public Color ColorFondo { get; set; }
        public Boolean Negrita { get; set; }
        public cTablaPDF TablaPDF { get; set; }
        public Color ColorLetra { get; set; }
        public float AltoColumna { get; set; }
        public float AnchoBorde { get; set; }
        public Borde BordeAnchos { get; set; }
        public Boolean ImagenTranasparente { get; set; }
        public enumAlineamiento Alineamiento { get; set; }

        public cCeldaPDF()
        {
            Negrita = false;
            ColorFondo = Color.White;
            ColorLetra = Color.Black;
            AltoColumna = 20f;
            AnchoBorde = 1;
            BordeAnchos = new Borde();
            ImagenTranasparente = false;
            Alineamiento = enumAlineamiento.defecto;
        }

        public cCeldaPDF(string contenido)
        {
            Contenido = contenido;
            ColorFondo = Color.White;
            ColorLetra = Color.Black;
            AltoColumna = 20f;
            AnchoBorde = 1;
            BordeAnchos = new Borde();
        }

        public cCeldaPDF(Boolean negrita, Color color, string contenido)
        {
            Negrita = negrita;
            ColorFondo = color;
            Contenido = contenido;
            ColorLetra = Color.Black;
            AltoColumna = 20f;
            AnchoBorde = 1;
            BordeAnchos = new Borde();
        }

        public void QuitarBordes()
        {
            this.BordeAnchos.AnchoAbajo = 0;
            this.BordeAnchos.AnchoArriba = 0;
            this.BordeAnchos.AnchoDerecha = 0;
            this.BordeAnchos.AnchoIzquierda = 0;
        }
    }
}
