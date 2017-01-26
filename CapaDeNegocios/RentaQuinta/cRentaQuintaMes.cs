using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.RentaQuinta
{
    public class cRentaQuintaMes
    {
        public double remuneracion;
        public double ingresos;
        public List<cRentaQuintaOtrosIngresos> otrosingresos;
        public double xnumeromeses;
        public double ingresosmesesanteriores;
        public double rentanetaproyectada;
        public double rentanetaimponible;
        public double PrimeraDeduccion;
        public double SegundaDeduccion;
        public double TerceraDeduccion;
        public double CuartaDeduccion;
        public double QuintaDeduccion;
        public double impuestaanual;
        public double retencionesanteriores;
        public double impuestocalculado;
        public double impuestomensualapagar;

        public double HallarSumatoriaOtrosIngresos()
        {
            double suma = 0;
            foreach (cRentaQuintaOtrosIngresos item in otrosingresos)
            {
                if (item.proyectabletodoelaño == true)
                {
                    suma = item.monto + suma;
                }
            }
            return suma;
        }
    }
}
