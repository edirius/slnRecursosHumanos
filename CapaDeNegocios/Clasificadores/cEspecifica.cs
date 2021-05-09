using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Clasificadores
{
    public class cEspecifica
    {
        cSubgenerica2 _Subgenerica2;
        int _Idtespecifica;
        string _Codigo;
        string _Nombre;
        string _Descripcion;
        string _CampoUnido;

        public cSubgenerica2 Subgenerica2
        {
            get
            {
                return _Subgenerica2;
            }

            set
            {
                _Subgenerica2 = value;
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

        public int Idtespecifica
        {
            get
            {
                return _Idtespecifica;
            }

            set
            {
                _Idtespecifica = value;
            }
        }

        public string CampoUnido
        {
            get
            {
                return _CampoUnido;
            }
        }

        public cEspecifica()
        {
            Subgenerica2 = new Clasificadores.cSubgenerica2();
        }


    }
}
