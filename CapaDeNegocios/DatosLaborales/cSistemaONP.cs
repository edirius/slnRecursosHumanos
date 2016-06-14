using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;

namespace CapaDeNegocios.DatosLaborales
{
    public class cSistemaONP:cSistemaPension
    {
        decimal comision;

        public decimal Comision
        {
            get { return comision; }
            set { comision = value; }
        }

        public Boolean TraerComisionONP()
        {
            Comision = Convert.ToDecimal(Conexion.GDatos.TraerValorEscalar("spTraerComisionONP", Codigo)); 
            return true;
        }
    }
}
