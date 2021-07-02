using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat
{
    public class cDetalleComparativoAFP
    {
        int _Fila;
        bool _ErrorCUSPP;
        bool _ErrorAFP;
        bool _ErrorDNI;
        bool _ErrorComision;


        public bool ErrorGeneral()
        {
            return _ErrorAFP || _ErrorComision || _ErrorCUSPP || _ErrorDNI;
        }

        public int Fila
        {
            get
            {
                return _Fila;
            }

            set
            {
                _Fila = value;
            }
        }

        public bool ErrorCUSPP
        {
            get
            {
                return _ErrorCUSPP;
            }

            set
            {
                _ErrorCUSPP = value;
            }
        }

        public bool ErrorAFP
        {
            get
            {
                return _ErrorAFP;
            }

            set
            {
                _ErrorAFP = value;
            }
        }

        public bool ErrorDNI
        {
            get
            {
                return _ErrorDNI;
            }

            set
            {
                _ErrorDNI = value;
            }
        }

        public bool ErrorComision
        {
            get
            {
                return _ErrorComision;
            }

            set
            {
                _ErrorComision = value;
            }
        }
    }
}
