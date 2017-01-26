using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.RentaQuinta
{
    public class cQuintaCategoria2017
    {
        public List<cRentaQuintaMes> ListaRentaMeses;

        public double UIT;
        public double PrimeraDeduccion = 0.08;
        public double SegundaDeduccion = 0.14;
        public double TerceraDeduccion = 0.21;

        public void CargarDatos(int mes)
        {
            cRentaQuintaMes RentaEnero = new cRentaQuintaMes();
            cRentaQuintaMes RentaFebrero = new cRentaQuintaMes();
            cRentaQuintaMes RentaMarzo = new cRentaQuintaMes();
            cRentaQuintaMes RentaAbril = new cRentaQuintaMes();
            cRentaQuintaMes RentaDiciembre = new cRentaQuintaMes();
            cRentaQuintaMes RentaNoviembre = new cRentaQuintaMes();
            cRentaQuintaMes RentaOctubre = new cRentaQuintaMes();
            
            switch (mes)
            {
                case 1:
                    RentaEnero = RecuperarDatosMesBD(1);

                    break;
                case 2:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    break;

                case 12:
                    RentaNoviembre = RecuperarDatosMesBD(11);
                    RentaOctubre = RecuperarDatosMesBD(10);
                    break; 
                default:
                    break;
            }
        }


        public cRentaQuintaMes RecuperarDatosMesBD(int mes)
        {
            cRentaQuintaMes miRenta = new cRentaQuintaMes();
            miRenta.Remuneracion = 2600;
            miRenta.OtrosIngresos[0].monto  = 400;
            return miRenta; 
        }



        public decimal HallarRentaQUinta(int mes)
        {
            double sumatoriaRemuneracionesMesesAnteriores = 0;
            double sumatoriaOtrosINgresos = 0;
            double sumatoriaTotal = 0;

            switch (mes)
            {
                case 1:
                    for (int i = 0; i < mes; i++)
                    {
                        sumatoriaRemuneracionesMesesAnteriores = sumatoriaRemuneracionesMesesAnteriores +  ListaRentaMeses[i].Remuneracion;
                        sumatoriaOtrosINgresos = sumatoriaOtrosINgresos + ListaRentaMeses[11].OtrosIngresos[0].monto;
                        sumatoriaTotal = sumatoriaRemuneracionesMesesAnteriores + sumatoriaOtrosINgresos;

                    }


                    break;
               
                default:
                    break;
            }

            return 0;
        }
    }
}
