using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reloj
{
    public class cReloj
    {
        string _IP;
        int _Puerto;
        int _NumeroMaquina;

        public string IP
        {
            get
            {
                return _IP;
            }

            set
            {
                _IP = value;
            }
        }

        public int Puerto
        {
            get
            {
                return _Puerto;
            }

            set
            {
                _Puerto = value;
            }
        }

        public int NumeroMaquina
        {
            get
            {
                return _NumeroMaquina;
            }

            set
            {
                _NumeroMaquina = value;
            }
        }
    }
}
