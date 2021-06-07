using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cTrabajadorReloj
    {
        cTrabajador _oTrabajador;
        int _CodigoReloj;


        public cTrabajadorReloj()
        {
            _oTrabajador = new cTrabajador();
        }
        public cTrabajador OTrabajador
        {
            get
            {
                return _oTrabajador;
            }

            set
            {
                _oTrabajador = value;
            }
        }

        public int CodigoReloj
        {
            get
            {
                return _CodigoReloj;
            }

            set
            {
                _CodigoReloj = value;
            }
        }
    }
}
