using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reloj
{
    public class cUsuarioReloj
    {
        string _NumeroInscripcion;
        string _Nombre;
        string _Password;
        cPrivilegioReloj _PrivilegioReloj;
        bool _Activo;
        string _NumeroTarjeta;
        List<cHuellaDedo> _HuellaDedos;

        public cUsuarioReloj()
        {
            _PrivilegioReloj = new cPrivilegioReloj();
            _HuellaDedos = new List<cHuellaDedo>();
        }

        public string NumeroInscripcion
        {
            get
            {
                return _NumeroInscripcion;
            }

            set
            {
                _NumeroInscripcion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public cPrivilegioReloj PrivilegioReloj
        {
            get
            {
                return _PrivilegioReloj;
            }

            set
            {
                _PrivilegioReloj = value;
            }
        }

        public bool Activo
        {
            get
            {
                return _Activo;
            }

            set
            {
                _Activo = value;
            }
        }

        public string NumeroTarjeta
        {
            get
            {
                return _NumeroTarjeta;
            }

            set
            {
                _NumeroTarjeta = value;
            }
        }

        public List<cHuellaDedo> HuellaDedos
        {
            get
            {
                return _HuellaDedos;
            }

            set
            {
                _HuellaDedos = value;
            }
        }
    }
}
