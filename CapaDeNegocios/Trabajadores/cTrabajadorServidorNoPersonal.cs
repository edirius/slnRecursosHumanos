using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Trabajadores
{
    public class cTrabajadorServidorNoPersonal:cTrabajador 
    {
        private string ruc;

        public string Ruc
        {
            get
            {
                return ruc;
            }

            set
            {
                ruc = value;
            }
        }
    }
}
