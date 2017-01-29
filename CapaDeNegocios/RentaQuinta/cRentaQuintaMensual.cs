using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.RentaQuinta
{
    public class cRentaQuintaMensual
    {
        public double remuneracion;
        public List<cRentaQuintaIngresos> ingresos = new List<cRentaQuintaIngresos>();
        public double xnumeromeses;
        public double remuneracionanteriores;
        public double rentanetaproyectada;
        public double uit7;
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

        public double sumatoriaingresosproyectables()
        {
            double suma = 0;
            foreach (cRentaQuintaIngresos item in ingresos)
            {
                if (item.proyectabletodoelaño == true)
                {
                    suma = item.monto + suma;
                }
            }
            return suma;
        }

        public double sumatoriaingresosnoproyectables()
        {
            double suma = 0;
            foreach (cRentaQuintaIngresos item in ingresos)
            {
                if (item.proyectabletodoelaño == false)
                {
                    suma = item.monto + suma;
                }
            }
            return suma;
        }
    }
}
