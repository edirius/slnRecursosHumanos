using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.DatosLaborales
{
    public class cRegimenLaboralCas:cRegimenLaboral 
    {
        string ruc;

        public string Ruc
        {
            get { return ruc; }
            set { ruc = value; }
        }

    }
}
