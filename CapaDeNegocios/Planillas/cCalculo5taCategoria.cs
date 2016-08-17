using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cCalculo5taCategoria
    {

        public decimal CalculoRentade5ta(decimal Remuneracion, decimal RemMesAnt, int NroMes, decimal Gratificaciones, decimal UIT)
        {
            decimal ImpuestoRentaAnual = 1;
            decimal T8, T14, T17, T20, T30;
            decimal UIT5, UIT7, UIT20, UIT35, UIT45;
            UIT5 = UIT * 5;
            UIT7 = UIT * 7;
            UIT20 = UIT * 20;
            UIT35 = UIT * 35;
            UIT45 = UIT * 45;
            decimal RentaBruta, RentaNeta;
            RentaBruta = ((Remuneracion * NroMes) + Gratificaciones + RemMesAnt);
            RentaNeta = (RentaBruta - UIT7);

            if (RentaBruta <= (UIT7))
            {
                ImpuestoRentaAnual = 0;
            }
            else if (RentaBruta > UIT7)
            {

                if (RentaNeta <= UIT5)
                {

                    ImpuestoRentaAnual = ((RentaNeta * 8) / 100);

                }
                else if (RentaNeta > UIT5 && RentaNeta <= UIT20)
                {

                    T8 = (UIT5 * 8) / 100;
                    T14 = ((RentaNeta - UIT5) * 14) / 100;
                    ImpuestoRentaAnual = T8 + T14;

                }
                else if (RentaNeta > UIT20 && RentaNeta <= UIT35)
                {

                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((RentaNeta - UIT20) * 17) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17;
                }
                else if (RentaNeta > UIT35 && RentaNeta <= UIT45)
                {

                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((UIT20 - UIT5) * 17) / 100;
                    T20 = ((RentaNeta - UIT35) * 20) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17 + T20;

                }
                else if (RentaNeta > UIT45)
                {

                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((UIT20 - UIT5) * 17) / 100;
                    T20 = ((UIT45 - UIT35) * 20) / 100;
                    T30 = ((RentaNeta - UIT35) * 30) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17 + T20 + T30;

                }
            }
            return ImpuestoRentaAnual;

        }

        public decimal CalculoRentaMensual(decimal Remuneracion, decimal RemMesAnt, int NroMes, decimal Gratificaciones, decimal UIT, decimal RetMesAnteriores)
        {
            decimal ImpuestoRentaMensual = 1;
            switch (NroMes)
            {

                case 12:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = ImpuestoRentaAnual / 12;
                        break;
                    }
                case 11:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = ImpuestoRentaAnual / 12;
                        break;
                    }
                case 10:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = ImpuestoRentaAnual / 12;
                        break;
                    }
                case 9:
                    {

                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = (ImpuestoRentaAnual - RetMesAnteriores) / 9;
                        break;
                    }
                case 8:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = (ImpuestoRentaAnual - RetMesAnteriores) / 8;
                        break;
                    }
                case 7:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = (ImpuestoRentaAnual - RetMesAnteriores) / 8;
                        break;
                    }
                case 6:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = (ImpuestoRentaAnual - RetMesAnteriores) / 8;
                        break;
                    }
                case 5:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = (ImpuestoRentaAnual - RetMesAnteriores) / 5;
                        break;
                    }
                case 4:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = (ImpuestoRentaAnual - RetMesAnteriores) / 4;
                        break;
                    }
                case 3:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = (ImpuestoRentaAnual - RetMesAnteriores) / 4;
                        break;
                    }
                case 2:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = (ImpuestoRentaAnual - RetMesAnteriores) / 4;
                        break;
                    }
                case 1:
                    {
                        decimal ImpuestoRentaAnual = CalculoRentade5ta(Remuneracion, RemMesAnt, NroMes, Gratificaciones, UIT);
                        ImpuestoRentaMensual = ImpuestoRentaAnual - RetMesAnteriores;
                        break;
                    }
                default:
                    {
                        //no se  encontró ese mes
                        break;
                    }
            }
            return ImpuestoRentaMensual;
        }

    }
}
