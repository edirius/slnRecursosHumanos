using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cPicado
    {
        cTrabajador _Trabajador;
        DateTime _Picado;
        string _DireccionFoto;

        public cTrabajador Trabajador
        {
            get
            {
                return _Trabajador;
            }

            set
            {
                _Trabajador = value;
            }
        }

        public DateTime Picado
        {
            get
            {
                return _Picado;
            }

            set
            {
                _Picado = value;
            }
        }

        public string DireccionFoto
        {
            get
            {
                return _DireccionFoto;
            }

            set
            {
                _DireccionFoto = value;
            }
        }
    }
}
