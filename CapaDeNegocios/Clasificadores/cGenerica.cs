using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Clasificadores
{
    public class cGenerica
    {
        int _Idtgenerica;
        string _Codigo;
        string _Nombre;
        string _Descripcion;
        string _CampoUnido;

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

        public int Idtgenerica
        {
            get
            {
                return _Idtgenerica;
            }

            set
            {
                _Idtgenerica = value;
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
