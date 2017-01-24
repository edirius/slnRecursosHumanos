using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.RentaQuinta
{
    public class cRentaQuintaMes
    {
        public decimal Remuneracion;
        public  List<cRentaQuintaOtrosIngresos> OtrosIngresos;

        public double HallarSumatoriaOtrosIngresos()
        {
            double suma = 0;

            foreach (cRentaQuintaOtrosIngresos  item in OtrosIngresos )
            {
                if (item.ProyectableTodoElAño = true)
                {
                    suma = item.monto + suma;
                }
                
            }
            return suma;
        }

    }
}
