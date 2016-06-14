using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.DatosLaborales
{
    public class cRegimenLaboral
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

    }
}
