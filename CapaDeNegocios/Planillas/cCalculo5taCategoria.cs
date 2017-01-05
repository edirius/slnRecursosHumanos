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

        public decimal CalculoImpuestoAnual(decimal RentaNetaProyectada, decimal UIT)
        {
            decimal ImpuestoAnual = 0;
            decimal RentaNetaImponible = 0;
            decimal T8, T14, T17, T20, T30;
            decimal UIT5, UIT20, UIT35, UIT45;
            UIT5 = UIT * 5;
            UIT20 = UIT * 20;
            UIT35 = UIT * 35;
            UIT45 = UIT * 45;

            RentaNetaImponible = (RentaNetaProyectada - (7 * UIT));

            if (RentaNetaProyectada <= (7 * UIT))
            {
                ImpuestoAnual = 0;
            }
            else
            {
                if (RentaNetaImponible <= UIT5)
                {
                    T8 = ((RentaNetaImponible * 8) / 100);
                    ImpuestoAnual = T8;
                }
                else if (RentaNetaImponible > UIT5 && RentaNetaImponible <= UIT20)
                {
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((RentaNetaImponible - UIT5) * 14) / 100;
                    ImpuestoAnual = T8 + T14;
                }
                else if (RentaNetaImponible > UIT20 && RentaNetaImponible <= UIT35)
                {
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((RentaNetaImponible - UIT20) * 17) / 100;
                    ImpuestoAnual = T8 + T14 + T17;
                }
                else if (RentaNetaImponible > UIT35 && RentaNetaImponible <= UIT45)
                {
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((UIT35 - UIT20) * 17) / 100;
                    T20 = ((RentaNetaImponible - UIT35) * 20) / 100;
                    ImpuestoAnual = T8 + T14 + T17 + T20;
                }
                else if (RentaNetaImponible > UIT45)
                {
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((UIT35 - UIT20) * 17) / 100;
                    T20 = ((UIT45 - UIT35) * 20) / 100;
                    T30 = ((RentaNetaImponible - UIT45) * 30) / 100;
                    ImpuestoAnual = T8 + T14 + T17 + T20 + T30;
                }
            }
            return ImpuestoAnual;
        }

        public decimal CalculoRentaMensual(int NroMes, decimal Remuneracion, decimal Ingresos, decimal Gratificaciones, decimal RemuMesAnt, decimal RetMesAnteriores, decimal UIT)
        {
            decimal ImpuestoAnual = 0;
            decimal ImpuestoCalculado = 0;
            decimal ImpuestoAPagar = 0;
            decimal RentaNetaProyectada = ((13 - NroMes) * (Remuneracion + Ingresos)) + Gratificaciones + RemuMesAnt;

            ImpuestoAnual = CalculoImpuestoAnual(RentaNetaProyectada, UIT);
            ImpuestoCalculado = ImpuestoAnual - RetMesAnteriores;

            if (NroMes == 1 || NroMes == 2 || NroMes == 3)
            {
                ImpuestoAPagar = ImpuestoCalculado / 12;
            }
            else if (NroMes == 4)
            {
                ImpuestoAPagar = ImpuestoCalculado / 9;
            }
            else if (NroMes == 5 || NroMes == 6 || NroMes == 7)
            {
                ImpuestoAPagar = ImpuestoCalculado / 8;
            }
            else if (NroMes == 8)
            {
                ImpuestoAPagar = ImpuestoCalculado / 5;
            }
            else if(NroMes == 9 || NroMes == 10 || NroMes == 11)
            {
                ImpuestoAPagar = ImpuestoCalculado / 4;
            }
            else
            {
                ImpuestoAPagar = ImpuestoCalculado;
            }
            return ImpuestoAPagar;
        }

    }
}
