using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Obras;

namespace CapaDeNegocios.Planillas
{
    public class cPlanilla
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        cMeta meta;

        public cMeta Meta
        {
            get { return meta; }
            set { meta = value; }
        }
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

    }
}
