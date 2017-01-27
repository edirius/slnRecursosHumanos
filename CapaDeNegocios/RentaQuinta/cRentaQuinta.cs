using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.RentaQuinta
{
    public class cRentaQuinta
    {
        public int idttrabajador;
        public int mes;
        public int año;
        public double remuneracion;
        public double ingresos;
        public double gratificacion = 300;
        public double UIT;
        public List<cRentaQuintaMensual> ListaRentaMensual = new List<cRentaQuintaMensual>();

        public void RentaQuintaCategoria()
        {
            cRentaQuintaMensual RentaEnero = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaFebrero = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaMarzo = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaAbril = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaMayo = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaJunio = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaJulio = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaAgosto = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaSetiembre = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaOctubre = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaNoviembre = new cRentaQuintaMensual();
            cRentaQuintaMensual RentaDiciembre = new cRentaQuintaMensual();

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
                case 3:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
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
                case 4:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
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
                case 5:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = AsignarDatosMesProyectado(5);
                    RentaJunio = AsignarDatosMesProyectado(6);
                    RentaJulio = AsignarDatosMesProyectado(7);
                    RentaAgosto = AsignarDatosMesProyectado(8);
                    RentaSetiembre = AsignarDatosMesProyectado(9);
                    RentaOctubre = AsignarDatosMesProyectado(10);
                    RentaNoviembre = AsignarDatosMesProyectado(11);
                    RentaDiciembre = AsignarDatosMesProyectado(12);
                    break;
                case 6:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = AsignarDatosMesProyectado(6);
                    RentaJulio = AsignarDatosMesProyectado(7);
                    RentaAgosto = AsignarDatosMesProyectado(8);
                    RentaSetiembre = AsignarDatosMesProyectado(9);
                    RentaOctubre = AsignarDatosMesProyectado(10);
                    RentaNoviembre = AsignarDatosMesProyectado(11);
                    RentaDiciembre = AsignarDatosMesProyectado(12);
                    break;
                case 7:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = RecuperarDatosMesBD(6);
                    RentaJulio = AsignarDatosMesProyectado(7);
                    RentaAgosto = AsignarDatosMesProyectado(8);
                    RentaSetiembre = AsignarDatosMesProyectado(9);
                    RentaOctubre = AsignarDatosMesProyectado(10);
                    RentaNoviembre = AsignarDatosMesProyectado(11);
                    RentaDiciembre = AsignarDatosMesProyectado(12);
                    break;
                case 8:
                    RentaEnero = RecuperarDatosMesBD(1);
                    RentaFebrero = RecuperarDatosMesBD(2);
                    RentaMarzo = RecuperarDatosMesBD(3);
                    RentaAbril = RecuperarDatosMesBD(4);
                    RentaMayo = RecuperarDatosMesBD(5);
                    RentaJunio = RecuperarDatosMesBD(6);
                    RentaJulio = RecuperarDatosMesBD(7);
                    RentaAgosto = AsignarDatosMesProyectado(8);
                    RentaSetiembre = AsignarDatosMesProyectado(9);
                    RentaOctubre = AsignarDatosMesProyectado(10);
                    RentaNoviembre = AsignarDatosMesProyectado(11);
                    RentaDiciembre = AsignarDatosMesProyectado(12);
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
                    RentaSetiembre = AsignarDatosMesProyectado(9);
                    RentaOctubre = AsignarDatosMesProyectado(10);
                    RentaNoviembre = AsignarDatosMesProyectado(11);
                    RentaDiciembre = AsignarDatosMesProyectado(12);
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
                    RentaOctubre = AsignarDatosMesProyectado(10);
                    RentaNoviembre = AsignarDatosMesProyectado(11);
                    RentaDiciembre = AsignarDatosMesProyectado(12);
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
                    RentaNoviembre = AsignarDatosMesProyectado(11);
                    RentaDiciembre = AsignarDatosMesProyectado(12);
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
                    RentaDiciembre = AsignarDatosMesProyectado(12);
                    break; 
                default:
                    break;
            }
            ListaRentaMensual.Add(RentaEnero);
            ListaRentaMensual.Add(RentaFebrero);
            ListaRentaMensual.Add(RentaMarzo);
            ListaRentaMensual.Add(RentaAbril);
            ListaRentaMensual.Add(RentaMayo);
            ListaRentaMensual.Add(RentaJunio);
            ListaRentaMensual.Add(RentaJulio);
            ListaRentaMensual.Add(RentaAgosto);
            ListaRentaMensual.Add(RentaSetiembre);
            ListaRentaMensual.Add(RentaOctubre);
            ListaRentaMensual.Add(RentaNoviembre);
            ListaRentaMensual.Add(RentaDiciembre);
            HallarRentaQuinta();
        }

        public cRentaQuintaMensual RecuperarDatosMesBD(int mes)
        {
            cRentaQuintaMensual mirenta = new cRentaQuintaMensual();
            mirenta.remuneracion = 0;
            //for (int i = 0; i < 1; i++)
            //{
            //    cRentaQuintaIngresos miingresos = new cRentaQuintaIngresos();
            //    miingresos.codigo = "";
            //    miingresos.monto = ingresos;
            //    miingresos.proyectabletodoelaño = true;
            //    mirentamensual.ingresos.Add(miingresos);
            //}
            //if (mes == 7 || mes == 12)
            //{
            //    cRentaQuintaIngresos miingresos = new cRentaQuintaIngresos();
            //    miingresos.codigo = "";
            //    miingresos.monto = gratificacion;
            //    miingresos.proyectabletodoelaño = false;
            //    mirentamensual.ingresos.Add(miingresos);
            //}
            return mirenta;
        }

        public cRentaQuintaMensual AsignarDatosMesProyectado(int mes)
        {
            cRentaQuintaMensual mirentamensual = new cRentaQuintaMensual();
            mirentamensual.remuneracion = remuneracion;
            for (int i = 0; i < 1; i++)
            {
                cRentaQuintaIngresos miingresos = new cRentaQuintaIngresos();
                miingresos.codigo = "";
                miingresos.monto = ingresos;
                miingresos.proyectabletodoelaño = true;
                mirentamensual.ingresos.Add(miingresos);
            }
            if (mes == 7 || mes == 12)
            {
                cRentaQuintaIngresos miingresos = new cRentaQuintaIngresos();
                miingresos.codigo = "";
                miingresos.monto = gratificacion;
                miingresos.proyectabletodoelaño = false;
                mirentamensual.ingresos.Add(miingresos);
            }
            return mirentamensual;
        }

        public void HallarRentaQuinta()
        {
            double sumatoriaremuneracionmesesanteriores = 0;
            double sumatoriaingresosnoproyectables = 0;
            double sumatoriaretencionmesesanteriores = 0;

            for (int i = mes - 1; i < 12; i++)
            {
                sumatoriaremuneracionmesesanteriores = 0;
                sumatoriaingresosnoproyectables = 0;
                sumatoriaretencionmesesanteriores = 0;

                for (int j = 0; j < i; j++)
                {
                    sumatoriaremuneracionmesesanteriores += ListaRentaMensual[j].remuneracion + ListaRentaMensual[j].sumatoriaingresosproyectables();
                }

                for (int j = 0; j < 12; j++)
                {
                    sumatoriaingresosnoproyectables += ListaRentaMensual[j].sumatoriaingresosnoproyectables();
                }

                if (i + 1 == 1 || i + 1 == 2 || i + 1 == 3)
                {
                    sumatoriaretencionmesesanteriores = 0;
                }
                else if (i + 1 == 4)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMensual[k].impuestomensualapagar;
                    }
                }
                else if (i + 1 == 5 || i + 1 == 6 || i + 1 == 7)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMensual[k].impuestomensualapagar;
                    }
                }
                else if (i + 1 == 8)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMensual[k].impuestomensualapagar;
                    }
                }
                else if (i + 1 == 9 || i + 1 == 10 || i + 1 == 11)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMensual[k].impuestomensualapagar;
                    }
                }
                else if (i + 1 == 12)
                {
                    for (int k = 0; k < 11; k++)
                    {
                        sumatoriaretencionmesesanteriores += ListaRentaMensual[k].impuestomensualapagar;
                    }
                }
                ListaRentaMensual[i].xnumeromeses = (ListaRentaMensual[i].remuneracion + ListaRentaMensual[i].sumatoriaingresosproyectables()) * (12 - i);
                ListaRentaMensual[i].remuneracionanteriores = sumatoriaremuneracionmesesanteriores;
                ListaRentaMensual[i].rentanetaproyectada = sumatoriaremuneracionmesesanteriores + sumatoriaingresosnoproyectables + ListaRentaMensual[i].xnumeromeses;
                ListaRentaMensual[i].uit7 = (7 * UIT);
                ListaRentaMensual[i].rentanetaimponible = ListaRentaMensual[i].rentanetaproyectada - ListaRentaMensual[i].uit7;
                Deducciones(i, ListaRentaMensual[i].rentanetaimponible);
                ListaRentaMensual[i].impuestaanual = ListaRentaMensual[i].PrimeraDeduccion + ListaRentaMensual[i].SegundaDeduccion + ListaRentaMensual[i].TerceraDeduccion + ListaRentaMensual[i].CuartaDeduccion + ListaRentaMensual[i].QuintaDeduccion;
                ListaRentaMensual[i].retencionesanteriores = sumatoriaretencionmesesanteriores;
                ListaRentaMensual[i].impuestocalculado = ListaRentaMensual[i].impuestaanual - ListaRentaMensual[i].retencionesanteriores;
                if (i + 1 == 1 || i + 1 == 2 || i + 1 == 3)
                {
                    ListaRentaMensual[i].impuestomensualapagar = ListaRentaMensual[i].impuestocalculado / 12;
                }
                else if (i + 1 == 4)
                {
                    ListaRentaMensual[i].impuestomensualapagar = ListaRentaMensual[i].impuestocalculado / 9;
                }
                else if (i + 1 == 5 || i + 1 == 6 || i + 1 == 7)
                {
                    ListaRentaMensual[i].impuestomensualapagar = ListaRentaMensual[i].impuestocalculado / 8;
                }
                else if (i + 1 == 8)
                {
                    ListaRentaMensual[i].impuestomensualapagar = ListaRentaMensual[i].impuestocalculado / 5;
                }
                else if (i + 1 == 9 || i + 1 == 10 || i + 1 == 11)
                {
                    ListaRentaMensual[i].impuestomensualapagar = ListaRentaMensual[i].impuestocalculado / 4;
                }
                else
                {
                    ListaRentaMensual[i].impuestomensualapagar = ListaRentaMensual[i].impuestocalculado;
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
                ListaRentaMensual[mes].PrimeraDeduccion = 0;
                ListaRentaMensual[mes].SegundaDeduccion = 0;
                ListaRentaMensual[mes].TerceraDeduccion = 0;
                ListaRentaMensual[mes].CuartaDeduccion = 0;
                ListaRentaMensual[mes].QuintaDeduccion = 0;
            }
            else
            {
                if (rentanetaimponible <= UIT5)
                {
                    ListaRentaMensual[mes].PrimeraDeduccion = ((rentanetaimponible * 8) / 100);
                    ListaRentaMensual[mes].SegundaDeduccion = 0;
                    ListaRentaMensual[mes].TerceraDeduccion = 0;
                    ListaRentaMensual[mes].CuartaDeduccion = 0;
                    ListaRentaMensual[mes].QuintaDeduccion = 0;
                }
                else if (rentanetaimponible > UIT5 && rentanetaimponible <= UIT20)
                {
                    ListaRentaMensual[mes].PrimeraDeduccion = (UIT5 * 8) / 100;
                    ListaRentaMensual[mes].SegundaDeduccion = ((rentanetaimponible - UIT5) * 14) / 100;
                    ListaRentaMensual[mes].TerceraDeduccion = 0;
                    ListaRentaMensual[mes].CuartaDeduccion = 0;
                    ListaRentaMensual[mes].QuintaDeduccion = 0;
                }
                else if (rentanetaimponible > UIT20 && rentanetaimponible <= UIT35)
                {
                    ListaRentaMensual[mes].PrimeraDeduccion = (UIT5 * 8) / 100;
                    ListaRentaMensual[mes].SegundaDeduccion = ((UIT20 - UIT5) * 14) / 100;
                    ListaRentaMensual[mes].TerceraDeduccion = ((rentanetaimponible - UIT20) * 17) / 100;
                    ListaRentaMensual[mes].CuartaDeduccion = 0;
                    ListaRentaMensual[mes].QuintaDeduccion = 0;
                }
                else if (rentanetaimponible > UIT35 && rentanetaimponible <= UIT45)
                {
                    ListaRentaMensual[mes].PrimeraDeduccion = (UIT5 * 8) / 100;
                    ListaRentaMensual[mes].SegundaDeduccion = ((UIT20 - UIT5) * 14) / 100;
                    ListaRentaMensual[mes].TerceraDeduccion = ((UIT35 - UIT20) * 17) / 100;
                    ListaRentaMensual[mes].CuartaDeduccion = ((rentanetaimponible - UIT35) * 20) / 100;
                    ListaRentaMensual[mes].QuintaDeduccion = 0;
                }
                else if (rentanetaimponible > UIT45)
                {
                    ListaRentaMensual[mes].PrimeraDeduccion = (UIT5 * 8) / 100;
                    ListaRentaMensual[mes].SegundaDeduccion = ((UIT20 - UIT5) * 14) / 100;
                    ListaRentaMensual[mes].TerceraDeduccion = ((UIT35 - UIT20) * 17) / 100;
                    ListaRentaMensual[mes].CuartaDeduccion = ((UIT45 - UIT35) * 20) / 100;
                    ListaRentaMensual[mes].QuintaDeduccion = ((rentanetaimponible - UIT45) * 30) / 100;
                }
            }
        }
    }
}
