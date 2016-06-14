using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Planillas
{
    public class cDescuentos
    {
        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        string codigoSunat;

        public string CodigoSunat
        {
            get { return codigoSunat; }
            set { codigoSunat = value; }
        }

        double monto;

        public double Monto
        {
            get { return monto; }
            set { monto = value; }
        }
        string formula;

        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }
    }
}
