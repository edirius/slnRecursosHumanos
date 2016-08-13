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
        string mensaje = "";
        decimal ingreso; //Gratificaciones, remuneraciones y otros ingresos del oficio
        decimal sueldo; //Remuneracion mensual
        int mes; // N° de meses que falta incluido el de retencion
        decimal uit;
        decimal tasa; // 8%, %14, %17, %20 y %30 
        decimal impuestoAnual; 
        decimal gratificaciones;
        #region Constructores
        public decimal Ingreso
        {
            get { return ingreso; }
            set { ingreso = value; }
        }

        public decimal Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }
        public decimal UIT
        {
            get { return uit; }
            set { uit = value; }
        }
        public decimal Gratificaciones
        {
            get { return gratificaciones; }
            set { gratificaciones = value; }
        }
        public decimal Tasa
        {
            get { return tasa; }
            set { tasa = value; }
        }
        public decimal ImpuestoAnual
        {
            get { return impuestoAnual; }
            set { impuestoAnual = value; }

        }
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        #endregion

        decimal remProyectada;  //Remuneración proyectada es la Remuneración básico por el nr0 de meses que tiene un año
        decimal rentaBruta;     //Es la suma de la remuneración proyectada + las gratificaciones
        decimal rentaNeta;      //Es la Resta de la Renta bruta - 7 UITS
        decimal irAnual;        //Impuesto a la renta anual
        decimal iR1;
        decimal iR2;
        decimal iR3;
        decimal iR4;
        decimal iR5;
        /// /////////////////////////////////////////////////////////////////////////////
        public void CalcularIR5()
        {
            remProyectada = ingreso * Convert.ToDecimal(mes);
            rentaBruta = remProyectada + gratificaciones;
            if (rentaBruta < (7 * uit))
            {
                mensaje = "NO SE APLICA RETENCIÓN";
            }
            else
            {
                rentaNeta = rentaBruta - (7 * uit);

                if (rentaNeta <= (5 * uit))
                {
                    irAnual = rentaNeta * 8 / 100;
                }

                if ((rentaNeta > (5 * uit)) && (rentaNeta <= (20 * uit)))
                {
                    iR1 = (5 * uit) * 8 / 100;
                    iR2 = (rentaNeta - (5 * uit)) * 14 / 100;
                    irAnual = iR1 + iR2;
                }
                if ((rentaNeta > (20 * uit)) && (rentaNeta <= (35 * uit)))
                {
                    iR1 = (5 * uit) * 8 / 100;
                    iR2 = ((20 * uit) - (5 * uit)) * 14 / 100;
                    iR3 = rentaNeta - (20 * uit) * 17 / 100;
                    irAnual = iR1 + iR2 + iR3;
                }
                if ((rentaNeta > (35 * uit)) && (rentaNeta <= (45 * uit)))
                {
                    iR1 = (5 * uit) * 8 / 100;
                    iR2 = ((20 * uit) - (5 * uit)) * 14 / 100;
                    iR3 = ((20 * uit) - (5 * uit)) * 17 / 100;
                    iR4 = (rentaNeta - (35 * uit)) * 20 / 100;
                    irAnual = iR1 + iR2 + iR3 + iR4;
                }

                if ((rentaNeta > (45 * uit)))
                {
                    iR1 = (5 * uit) * 8 / 100;
                    iR2 = ((20 * uit) - (5 * uit)) * 14 / 100;
                    iR3 = ((20 * uit) - (5 * uit)) * 17 / 100;
                    iR4 = ((45 * uit) - (35 * uit)) * 20 / 100;
                    iR5 = rentaNeta - (45 * uit) * 30 / 100;
                    irAnual = iR1 + iR2 + iR3 + iR4;
                }

            }

        }
    }
}
