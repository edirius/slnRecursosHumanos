using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.DatosLaborales
{
    public class cDatosLaborales
    {
        private cTrabajador miTrabajador;

        public cTrabajador MiTrabajador
        {
            get { return miTrabajador; }
            set { miTrabajador = value; }
        }

        private cPeriodo[] listaPeriodos;

        public cPeriodo[] ListaPeriodos
        {
            get { return listaPeriodos; }
            set { listaPeriodos = value; }
        }

        private cTipoTrabajador miTipoTrabajador;

        public cTipoTrabajador MiTipoTrabajador
        {
            get { return miTipoTrabajador; }
            set { miTipoTrabajador = value; }
        }


    }
}
