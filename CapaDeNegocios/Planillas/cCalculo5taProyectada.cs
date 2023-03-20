using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDeDatos;

namespace CapaDeNegocios.Planillas
{
    public class cCalculo5taProyectada
    {
        public int sNroMes = 0;
        public int sAño = 0;
        public double sRemuneracion = 0;
        public double sIngreso = 0;
        public double sIngresoAnuales = 0;
        public double sGratificaciones = 0;
        public double sUIT = 0;
        public double sRemMesAnt = 0;
        public double sIngMesAnt = 0;
        public double sRetMesAnt = 0;
        public double sIngresosOtroLugar = 0;
        public double sRetencionesOtroLugar = 0;

        public double[,] srentas = new double[3, 12];

        CapaDeNegocios.Planillas.cCalculo5taCategoria miCalculo5ta = new CapaDeNegocios.Planillas.cCalculo5taCategoria();

        public void CalculoMensual()
        {
            sRemMesAnt = 0;
            sIngMesAnt = 0;

            for (int i = sNroMes - 1; i < 12; i++)
            {
                srentas[0, i] = sRemuneracion;
                srentas[1, i] = sIngreso;
            }

            for (int j = sNroMes - 1; j < 12; j++)
            {
                sRetMesAnt = 0;
                if (j > 0)
                {
                    sRemMesAnt += srentas[0, j - 1];
                    sIngMesAnt += srentas[1, j - 1];

                    if (j + 1 == 1 || j + 1 == 2 || j + 1 == 3)
                    {
                        sRetMesAnt = 0;
                    }
                    else if (j + 1 == 4)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            sRetMesAnt += srentas[2, k];
                        }
                    }
                    else if (j + 1 == 5 || j + 1 == 6 || j + 1 == 7)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            sRetMesAnt += srentas[2, k];
                        }
                    }
                    else if (j + 1 == 8)
                    {
                        for (int k = 0; k < 7; k++)
                        {
                            sRetMesAnt += srentas[2, k];
                        }
                    }
                    else if (j + 1 == 9 || j + 1 == 10 || j + 1 == 11)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            sRetMesAnt += srentas[2, k];
                        }
                    }
                    else if (j + 1 == 12)
                    {
                        for (int k = 0; k < 11; k++)
                        {
                            sRetMesAnt += srentas[2, k];
                        }
                    }
                }
                double CAL5TA = Convert.ToDouble(miCalculo5ta.CalculoRentaMensual(j + 1, Convert.ToDecimal(sRemuneracion), Convert.ToDecimal(sIngreso), Convert.ToDecimal(sRemMesAnt + sIngMesAnt), Convert.ToDecimal(sRetMesAnt), Convert.ToDecimal(sUIT), Convert.ToDecimal(sRetencionesOtroLugar), Convert.ToDecimal(sIngresosOtroLugar)));
                srentas[2, j] = Math.Round(CAL5TA, 2);
            }
        }
    }
}
