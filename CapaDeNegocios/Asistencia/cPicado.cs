using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Asistencia
{
    public class cPicado
    {
        int _CodigoPicado;
        cTrabajadorReloj _TrabajadorReloj;
        DateTime _Picado;
       

        public cPicado()
        {
            _TrabajadorReloj = new cTrabajadorReloj();
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

        public cTrabajadorReloj TrabajadorReloj
        {
            get
            {
                return _TrabajadorReloj;
            }

            set
            {
                _TrabajadorReloj = value;
            }
        }

        public int CodigoPicado
        {
            get
            {
                return _CodigoPicado;
            }

            set
            {
                _CodigoPicado = value;
            }
        }

        public string DevolverNombreFoto()
        {
            return _TrabajadorReloj.CodigoReloj + _Picado.Day.ToString() + _Picado.Month.ToString() + _Picado.Year.ToString() + _Picado.Hour.ToString() + _Picado.Minute.ToString() + _Picado.Second.ToString(); 
        }
    }
}
