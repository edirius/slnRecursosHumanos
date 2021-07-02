using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaUsuario.ExportarSunat
{
    public class cComparativoAFP
    {
        List<cDetalleComparativoAFP> _ListaDetalles;

        public cComparativoAFP()
        {
            _ListaDetalles = new List<cDetalleComparativoAFP>();
        }

        public List<cDetalleComparativoAFP> ListaDetalles
        {
            get
            {
                return _ListaDetalles;
            }

            set
            {
                _ListaDetalles = value;
            }
        }
    }
}
