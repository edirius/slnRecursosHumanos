using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Clasificadores
{
    public class cSubgenerica
    {
        cGenerica _Generica;
        int _Idtsubgenerica;
        string _Codigo;
        string _Nombre;
        string _Descripcion;
        string _CampoUnido;

        public cGenerica Generica
        {
            get
            {
                return _Generica;
            }

            set
            {
                _Generica = value;
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

        public int Idtsubgenerica       {
            get
            {
                return _Idtsubgenerica;
            }

            set
            {
                _Idtsubgenerica = value;
            }
        }

        public string CampoUnido
        {
            get
            {
                return _CampoUnido;
            }

        }

        public cSubgenerica()
        {
            Generica = new cGenerica();
        }
    }
}
