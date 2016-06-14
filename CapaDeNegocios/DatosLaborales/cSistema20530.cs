using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.DatosLaborales
{
    public class cSistema20530:cSistemaPension 
    {
        decimal comision;

        public decimal Comision
        {
            get { return comision; }
            set { comision = value; }
        }

        public Boolean TraerComision()
        {
            comision = Convert.ToDecimal(Conexion.GDatos.TraerValorEscalar("spTraerComision20530", Codigo));
            return true;
        }
    }
}
