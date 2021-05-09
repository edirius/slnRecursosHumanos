using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Clasificadores
{
    public class cSubgenerica2
    {
        cSubgenerica _Subgenerica;
        int _Idtsubgenerica2;
        string _Codigo;
        string _Nombre;
        string _Descripcion;
        string _CampoUnido;

        public cSubgenerica2()
        {
            _Subgenerica = new cSubgenerica();
        }
        public cSubgenerica Subgenerica
        {
            get
            {
                return _Subgenerica;
            }

            set
            {
                _Subgenerica = value;
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

        public int Idtsubgenerica2
        {
            get
            {
                return _Idtsubgenerica2;
            }

            set
            {
                _Idtsubgenerica2 = value;
            }
        }

        public string CampoUnido
        {
            get
            {
                return _CampoUnido;
            }
        }
    }
}
