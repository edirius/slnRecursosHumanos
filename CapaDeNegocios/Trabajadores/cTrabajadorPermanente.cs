using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Trabajadores
{
    public class cTrabajadorPermanente:cTrabajadorServidorPersonal 
    {
        DateTime fechaInicioPermanente;

        public DateTime FechaInicioPermanente
        {
            get
            {
                return fechaInicioPermanente;
            }

            set
            {
                fechaInicioPermanente = value;
            }
        }
    }
}
