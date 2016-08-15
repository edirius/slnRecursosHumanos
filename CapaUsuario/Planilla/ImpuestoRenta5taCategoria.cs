using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;

namespace CapaUsuario.Planilla
{
    public partial class ImpuestoRenta5taCategoria : Form
    {
        CapaDeNegocios.Planillas.cCalculo5taCategoria Calculo = new CapaDeNegocios.Planillas.cCalculo5taCategoria();

        public ImpuestoRenta5taCategoria()
        {
            InitializeComponent();

        }


        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbMes.Text;
            switch (opcion)
            {
                case "Enero":
                    {
                        int mes = 12;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 12);
                        break;
                    }
                case "Febrero":
                    {
                        //
                        int mes = 11;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 12);
                        break;
                    }
                case "Marzo":
                    {
                        int mes = 10;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 12);
                        break;
                    }
                case "Abril":
                    {
                        //
                        int mes = 9;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 9);
                        break;
                    }
                case "Mayo":
                    {
                        //
                        int mes = 8;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 8);
                        break;
                    }
                case "Junio":
                    {
                        //
                        int mes = 7;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 8);
                        break;
                    }
                case "Julio":
                    {
                        //
                        int mes = 6;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 12);
                        break;
                    }
                case "Agosto":
                    {
                        //
                        int mes = 5;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 5);
                        break;
                    }
                case "Setiembre":
                    {
                        //
                        int mes = 4;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 4);
                        break;
                    }
                case "Octubre":
                    {
                        //
                        int mes = 3;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 4);
                        break;
                    }
                case "Noviembre":
                    {
                        //
                        int mes = 2;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 4);
                        break;
                    }
                case "Diciembre":
                    {
                        //
                        int mes = 1;
                        CalcularImpuesto5ta(int.Parse(txtIngresos.Text), mes);
                        txtIRM.Text = Convert.ToString(int.Parse(txtIRA.Text) / 12);
                        break;
                    }
                default:
                    {
                        //no se  encontró ese mes o algo asi
                        break;
                    }
            }
        }
        public void CalcularImpuesto5ta(int Ingresos, int NroMes)
        {
            int Gratificaciones = int.Parse(txtGrati.Text);
            //txtGrati.Text = Gratificaciones.ToString();
            //for (int i = 0; i <= NroMes; i++)
            //{
            //    txtReMesAnteriores.Text = Convert.ToString(Ingresos * i);
            //}
            int RentaBruta = Ingresos * NroMes + Gratificaciones + RMA;
            txtRb.Text = RentaBruta.ToString();
            int RentaNeta = RentaBruta - 27650;
            txtRN.Text = RentaNeta.ToString();
            int T8, T14, T17, T20, T30, IRA, IRM;
            if (RentaBruta < 27650)
            {
                MessageBox.Show("No se aplica Retención");

            }
            else if (RentaBruta > 27650)
            {

                if (RentaNeta <= 19750)
                {
                    txtT8.Text = RentaNeta.ToString();
                    IRA = RentaNeta * 8 / 100;
                    txtIRA.Text = IRA.ToString();
                    //IRM = IRA / 12;
                    //txtIRM.Text = IRM.ToString();

                }
                else if (RentaNeta > 19750 && RentaNeta <= 79000)
                {

                    T8 = 19750 * 8 / 100;
                    T14 = (RentaNeta - 19750) * 14 / 100;
                    IRA = T8 + T14;
                    txtIRA.Text = IRA.ToString();
                    txtT8.Text = T8.ToString();
                    txtT14.Text = T14.ToString();
                    //IRM = IRA / 12;
                    //txtIRM.Text = IRM.ToString();
                }
                else if (RentaNeta > 79000 && RentaNeta <= 138000)
                {
                    T8 = 19750 * 8 / 100;
                    T14 = (79000 - 19750) * 14 / 100;
                    T17 = (RentaNeta - 79000) * 17 / 100;
                    IRA = T8 + T14 + T17;
                    txtIRA.Text = IRA.ToString();
                    txtT8.Text = T8.ToString();
                    txtT14.Text = T14.ToString();
                    txtT17.Text = T17.ToString();
                    txtIRA.Text = IRA.ToString();
                    //IRM = IRA / 12;
                    //txtIRM.Text = IRM.ToString();
                }
                else if (RentaNeta > 138250 && RentaNeta <= 177750)
                {
                    T8 = 19750 * 8 / 100;
                    T14 = (79000 - 19750) * 14 / 100;
                    T17 = (79000 - 19750) * 17 / 100;
                    T20 = (RentaNeta - 138250) * 20 / 100;
                    IRA = T8 + T14 + T17 + T20;
                    txtIRA.Text = IRA.ToString();
                    txtT8.Text = T8.ToString();
                    txtT14.Text = T14.ToString();
                    txtT17.Text = T17.ToString();
                    txtT20.Text = T20.ToString();
                    txtIRA.Text = IRA.ToString();
                    //IRM = IRA / 12;
                    //txtIRM.Text = IRM.ToString();
                }
                else if (RentaNeta > 177750)
                {
                    T8 = 19750 * 8 / 100;
                    T14 = (79000 - 19750) * 14 / 100;
                    T17 = (79000 - 19750) * 17 / 100;
                    T20 = (177750 - 138250) * 20 / 100;
                    T30 = (RentaNeta - 177750) * 30 / 100;
                    IRA = T8 + T14 + T17 + T20 + T30;
                    txtIRA.Text = IRA.ToString();
                    txtT8.Text = T8.ToString();
                    txtT14.Text = T14.ToString();
                    txtT17.Text = T17.ToString();
                    txtT20.Text = T20.ToString();
                    txtT30.Text = T30.ToString();
                    txtIRA.Text = IRA.ToString();
                    //IRM = IRA / 12;
                    //txtIRM.Text = IRM.ToString();
                }
            }
        }

    }
}
