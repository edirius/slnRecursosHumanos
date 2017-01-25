using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.RentaQuinta
{
    public class cQuintaCategoria
    {
        public int idttrabajador;
        public int mes;
        public int año;
        public double remuneracionactual;
        public double ingresoactual;
        public double gratificaciones;
        public double UIT;
        public List<cRentaQuintaMes> ListaRentaMeses = new List<cRentaQuintaMes>();

        public void RentaQuintaCategoria()
        {
            cRentaQuintaMes RentaEnero = new cRentaQuintaMes();
            cRentaQuintaMes RentaFebrero = new cRentaQuintaMes();
            cRentaQuintaMes RentaMarzo = new cRentaQuintaMes();
            cRentaQuintaMes RentaAbril = new cRentaQuintaMes();
            cRentaQuintaMes RentaMayo = new cRentaQuintaMes();
            cRentaQuintaMes RentaJunio = new cRentaQuintaMes();
            cRentaQuintaMes RentaJulio = new cRentaQuintaMes();
            cRentaQuintaMes RentaAgosto = new cRentaQuintaMes();
            cRentaQuintaMes RentaSetiembre = new cRentaQuintaMes();
            cRentaQuintaMes RentaOctubre = new cRentaQuintaMes();
            cRentaQuintaMes RentaNoviembre = new cRentaQuintaMes();
            cRentaQuintaMes RentaDiciembre = new cRentaQuintaMes();
            
            switch (mes)
            {
                case 1:
                    RentaEnero = AsignarDatosMesProyectado(1);
                    RentaFebrero = AsignarDatosMesProyectado(2);
                    RentaMarzo = AsignarDatosMesProyectado(3);
                    RentaAbril = AsignarDatosMesProyectado(4);
                    RentaMayo = AsignarDatosMesProyectado(5);
                    RentaJunio = AsignarDatosMesProyectado(6);
                    RentaJulio = AsignarDatosMesProyectado(7);
                    RentaAgosto = AsignarDatosMesProyectado(8);
                    RentaSetiembre = AsignarDatosMesProyectado(9);
                    RentaOctubre = AsignarDatosMesProyectado(10);
                    RentaNoviembre = AsignarDatosMesProyectado(11);
                    RentaDiciembre = AsignarDatosMesProyectado(12);
                    break;
                case 2:
                    RentaEnero = RecuperarDatosMesBD(1);
                    break;
                case 3:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    break;
                case 4:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    break;
                case 5:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    break;
                case 6:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    break;
                case 7:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = RecuperarDatosMesBD(6);
                    break;
                case 8:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = RecuperarDatosMesBD(6);
                    RentaJulio = RecuperarDatosMesBD(7);
                    break;
                case 9:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = RecuperarDatosMesBD(6);
                    RentaJulio = RecuperarDatosMesBD(7);
                    RentaAgosto = RecuperarDatosMesBD(8);
                    break;
                case 10:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = RecuperarDatosMesBD(6);
                    RentaJulio = RecuperarDatosMesBD(7);
                    RentaAgosto = RecuperarDatosMesBD(8);
                    RentaSetiembre = RecuperarDatosMesBD(9);
                    break;
                case 11:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = RecuperarDatosMesBD(6);
                    RentaJulio = RecuperarDatosMesBD(7);
                    RentaAgosto = RecuperarDatosMesBD(8);
                    RentaSetiembre = RecuperarDatosMesBD(9);
                    RentaOctubre = RecuperarDatosMesBD(10);
                    break;
                case 12:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = RecuperarDatosMesBD(6);
                    RentaJulio = RecuperarDatosMesBD(7);
                    RentaAgosto = RecuperarDatosMesBD(8);
                    RentaSetiembre = RecuperarDatosMesBD(9);
                    RentaOctubre = RecuperarDatosMesBD(10);
                    RentaNoviembre = RecuperarDatosMesBD(11);
                    break; 
                default:
                    break;
            }
            ListaRentaMeses.Add(RentaEnero);
            ListaRentaMeses.Add(RentaFebrero);
            ListaRentaMeses.Add(RentaMarzo);
            ListaRentaMeses.Add(RentaAbril);
            ListaRentaMeses.Add(RentaMayo);
            ListaRentaMeses.Add(RentaJunio);
            ListaRentaMeses.Add(RentaJulio);
            ListaRentaMeses.Add(RentaAgosto);
            ListaRentaMeses.Add(RentaSetiembre);
            ListaRentaMeses.Add(RentaOctubre);
            ListaRentaMeses.Add(RentaNoviembre);
            ListaRentaMeses.Add(RentaDiciembre);
            HallarRentaQuinta();
        }

        public cRentaQuintaMes RecuperarDatosMesBD(int mes)
        {
            cRentaQuintaMes mirenta = new cRentaQuintaMes();
            //mirenta.remuneracion = 2600;
            //mirenta.otrosingresos[0] = 400;
            return mirenta;
        }

        public cRentaQuintaMes AsignarDatosMesProyectado(int mes)
        {
            cRentaQuintaMes mirenta = new cRentaQuintaMes();
            cRentaQuintaOtrosIngresos miotrosingresos = new cRentaQuintaOtrosIngresos();
            mirenta.remuneracion = remuneracionactual;
            miotrosingresos.monto = ingresoactual;
            miotrosingresos.proyectabletodoelaño = true;
            //mirenta.ingresos = mirenta.HallarSumatoriaOtrosIngresos();
            mirenta.ingresos = ingresoactual;
            return mirenta;
        }

        public void HallarRentaQuinta()
        {
            double sumatoriaingresosmesesanteriores = 0;
            double sumatoriaretencionmesesanteriores = 0;

            for (int i = mes - 1; i < 12; i++)
            {
                sumatoriaingresosmesesanteriores = 0;
                sumatoriaretencionmesesanteriores = 0;
                for (int j = 0; j < i; j++)
                {
                    sumatoriaingresosmesesanteriores += ListaRentaMeses[j].remuneracion + ListaRentaMeses[j].ingresos;
                }
                if (i + 1 == 1 || i + 1 == 2 || i + 1 == 3)
                {
                    sumatoriaretencionmesesanteriores = 0;
                }
                else if (i + 1 == 4)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMeses[k].impuestomensualapagar;
                    }
                }
                else if (i + 1 == 5 || i + 1 == 6 || i + 1 == 7)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMeses[k].impuestomensualapagar;
                    }
                }
                else if (i + 1 == 8)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMeses[k].impuestomensualapagar;
                    }
                }
                else if (i + 1 == 9 || i + 1 == 10 || i + 1 == 11)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMeses[k].impuestomensualapagar;
                    }
                }
                else if (i + 1 == 12)
                {
                    for (int k = 0; k < 11; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMeses[k].impuestomensualapagar;
                    }
                }
                ListaRentaMeses[i].ingresosmesesanteriores = sumatoriaingresosmesesanteriores + gratificaciones;
                ListaRentaMeses[i].xnumeromeses = (ListaRentaMeses[i].remuneracion + ListaRentaMeses[i].ingresos) * (12 - i);
                ListaRentaMeses[i].rentanetaproyectada = ListaRentaMeses[i].ingresosmesesanteriores + ListaRentaMeses[i].xnumeromeses;
                ListaRentaMeses[i].rentanetaimponible = ListaRentaMeses[i].rentanetaproyectada - (7 * UIT);
                Deducciones(i, ListaRentaMeses[i].rentanetaimponible);
                ListaRentaMeses[i].impuestaanual = ListaRentaMeses[i].PrimeraDeduccion + ListaRentaMeses[i].SegundaDeduccion + ListaRentaMeses[i].TerceraDeduccion + ListaRentaMeses[i].CuartaDeduccion + ListaRentaMeses[i].QuintaDeduccion;
                ListaRentaMeses[i].retencionesanteriores = sumatoriaretencionmesesanteriores;
                ListaRentaMeses[i].impuestocalculado = ListaRentaMeses[i].impuestaanual - ListaRentaMeses[i].retencionesanteriores;
                if (i + 1 == 1 || i + 1 == 2 || i + 1 == 3)
                {
                    ListaRentaMeses[i].impuestomensualapagar = ListaRentaMeses[i].impuestocalculado / 12;
                }
                else if (i + 1 == 4)
                {
                    ListaRentaMeses[i].impuestomensualapagar = ListaRentaMeses[i].impuestocalculado / 9;
                }
                else if (i + 1 == 5 || i + 1 == 6 || i + 1 == 7)
                {
                    ListaRentaMeses[i].impuestomensualapagar = ListaRentaMeses[i].impuestocalculado / 8;
                }
                else if (i + 1 == 8)
                {
                    ListaRentaMeses[i].impuestomensualapagar = ListaRentaMeses[i].impuestocalculado / 5;
                }
                else if (i + 1 == 9 || i + 1 == 10 || i + 1 == 11)
                {
                    ListaRentaMeses[i].impuestomensualapagar = ListaRentaMeses[i].impuestocalculado / 4;
                }
                else
                {
                    ListaRentaMeses[i].impuestomensualapagar = ListaRentaMeses[i].impuestocalculado;
                }
            }
        }

        public void Deducciones(int mes, double rentanetaimponible)
        {
            double UIT5, UIT20, UIT35, UIT45;
            UIT5 = UIT * 5;
            UIT20 = UIT * 20;
            UIT35 = UIT * 35;
            UIT45 = UIT * 45;

            if (rentanetaimponible <= 0)
            {
                ListaRentaMeses[mes].PrimeraDeduccion = 0;
                ListaRentaMeses[mes].SegundaDeduccion = 0;
                ListaRentaMeses[mes].TerceraDeduccion = 0;
                ListaRentaMeses[mes].CuartaDeduccion = 0;
                ListaRentaMeses[mes].QuintaDeduccion = 0;
            }
            else
            {
                if (rentanetaimponible <= UIT5)
                {
                    ListaRentaMeses[mes].PrimeraDeduccion = ((rentanetaimponible * 8) / 100);
                    ListaRentaMeses[mes].SegundaDeduccion = 0;
                    ListaRentaMeses[mes].TerceraDeduccion = 0;
                    ListaRentaMeses[mes].CuartaDeduccion = 0;
                    ListaRentaMeses[mes].QuintaDeduccion = 0;
                }
                else if (rentanetaimponible > UIT5 && rentanetaimponible <= UIT20)
                {
                    ListaRentaMeses[mes].PrimeraDeduccion = (UIT5 * 8) / 100;
                    ListaRentaMeses[mes].SegundaDeduccion = ((rentanetaimponible - UIT5) * 14) / 100;
                    ListaRentaMeses[mes].TerceraDeduccion = 0;
                    ListaRentaMeses[mes].CuartaDeduccion = 0;
                    ListaRentaMeses[mes].QuintaDeduccion = 0;
                }
                else if (rentanetaimponible > UIT20 && rentanetaimponible <= UIT35)
                {
                    ListaRentaMeses[mes].PrimeraDeduccion = (UIT5 * 8) / 100;
                    ListaRentaMeses[mes].SegundaDeduccion = ((UIT20 - UIT5) * 14) / 100;
                    ListaRentaMeses[mes].TerceraDeduccion = ((rentanetaimponible - UIT20) * 17) / 100;
                    ListaRentaMeses[mes].CuartaDeduccion = 0;
                    ListaRentaMeses[mes].QuintaDeduccion = 0;
                }
                else if (rentanetaimponible > UIT35 && rentanetaimponible <= UIT45)
                {
                    ListaRentaMeses[mes].PrimeraDeduccion = (UIT5 * 8) / 100;
                    ListaRentaMeses[mes].SegundaDeduccion = ((UIT20 - UIT5) * 14) / 100;
                    ListaRentaMeses[mes].TerceraDeduccion = ((UIT35 - UIT20) * 17) / 100;
                    ListaRentaMeses[mes].CuartaDeduccion = ((rentanetaimponible - UIT35) * 20) / 100;
                    ListaRentaMeses[mes].QuintaDeduccion = 0;
                }
                else if (rentanetaimponible > UIT45)
                {
                    ListaRentaMeses[mes].PrimeraDeduccion = (UIT5 * 8) / 100;
                    ListaRentaMeses[mes].SegundaDeduccion = ((UIT20 - UIT5) * 14) / 100;
                    ListaRentaMeses[mes].TerceraDeduccion = ((UIT35 - UIT20) * 17) / 100;
                    ListaRentaMeses[mes].CuartaDeduccion = ((UIT45 - UIT35) * 20) / 100;
                    ListaRentaMeses[mes].QuintaDeduccion = ((rentanetaimponible - UIT45) * 30) / 100;
                }
            }
        }
    }
}
