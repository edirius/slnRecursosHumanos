using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Clasificadores
{
    public class cEspecifica2
    {
        cEspecifica _Especifica;
        int _IdtEspecifica2;
        string _Codigo;
        string _Nombre;
        string _Descripcion;
        string _CampoUnido;

        public cEspecifica Especifica
        {
            get
            {
                return _Especifica;
            }

            set
            {
                _Especifica = value;
            }
        }

        public string Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
                _CampoUnido = _Codigo + " - " + _Nombre;
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
                _CampoUnido = _Codigo + " - " + _Nombre;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public int IdtEspecifica2
        {
            get
            {
                return _IdtEspecifica2;
            }

            set
            {
                _IdtEspecifica2 = value;
            }
        }

        public string CampoUnido
        {
            get
            {
                return _CampoUnido;
            }
        }

        public cEspecifica2()
        {
            Especifica = new cEspecifica();
        }
    }
}
