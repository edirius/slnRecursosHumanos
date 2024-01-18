using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeNegocios.Planillas;

namespace CapaDeNegocios.Tareos
{
    public class cTareoPlanilla
    {
        private cPlanilla miPlanilla;
        private cTareo miTareo;

        public cPlanilla MiPlanilla
        {
            get
            {
                return miPlanilla;
            }

            set
            {
                miPlanilla = value;
            }
        }

        public cTareo MiTareo
        {
            get
            {
                return miTareo;
            }

            set
            {
                miTareo = value;
            }
        }
    }
}
