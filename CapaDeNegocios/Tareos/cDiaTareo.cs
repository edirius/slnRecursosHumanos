using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Tareos
{
    public class cDiaTareo
    {

        int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


      
        cEnumTipoDia tipoDia;

        public cEnumTipoDia TipoDia
        {
            get { return tipoDia; }
            set { tipoDia = value; }
        }

      
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        

    }
}
