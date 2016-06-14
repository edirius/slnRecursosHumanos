using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Contrato
{
    public class cTipoContratoPermanente:cTipoContrato 
    {
        enumTipoServidor tipoServidor;

        public enumTipoServidor TipoServidor
        {
            get
            {
                return tipoServidor;
            }

            set
            {
                tipoServidor = value;
            }
        }
    }
}
