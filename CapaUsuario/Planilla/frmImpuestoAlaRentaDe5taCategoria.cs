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
    public partial class frmImpuestoAlaRentaDe5taCategoria : Form
    {
        cVariables oVariables = new cVariables();
        public frmImpuestoAlaRentaDe5taCategoria()
        {
            InitializeComponent();
            //ListarUITs();
        }
        public void Limpiar()
        {

        }
        public void ListarUITs()
        { 
            cbUIT.ValueMember = "idtvariables";
            cbUIT.DisplayMember = "UIT";
            cbUIT.DataSource = oVariables.ListarUIT();
        }
        //public void CalcularRenta(int Ingresos, int NroMes)
        //{

        //    int Gratificaciones = int.Parse(txtGrati.Text);
        //    int RentaBruta = ((Ingresos * NroMes) + Gratificaciones);//REMUNERACION DE MESES ANTERIORES
        //    txtRb.Text = RentaBruta.ToString();//renta bruta
        //    int RentaNeta = RentaBruta - 27650;//7 UIT ESO DEBERIA SER UNA VARIABLE PORQUE LA UIT CAMBIA CADA AÑO
        //    txtRN.Text = RentaNeta.ToString();
        //    int T8, T14, T17, T20, T30, IRA, IRM;
        //    if (RentaBruta <= 27650)
        //    {
        //        MessageBox.Show("No se aplica Retención");

        //    }
        //    else if (RentaBruta > 27650)
        //    {

        //        if (RentaNeta <= 19750)//SI LA RENTA NETA ES MENOR A 5 UITS SE MULTIPLICA POR LA TASA QUE ES 8%
        //        {
        //            txtT8.Text = RentaNeta.ToString();
        //            IRA = (RentaNeta * 8) / 100;
        //            txtIRA.Text = IRA.ToString();
        //            //IRM = IRA / 12;
        //            //txtIRM.Text = IRM.ToString();

        //        }
        //        else if (RentaNeta > 19750 && RentaNeta <= 79000)
        //        {

        //            T8 = (19750 * 8) / 100;//cuando hagas  operaciones de multip... y division encierra en parentesis la multip..
        //            T14 = ((RentaNeta - 19750) * 14) / 100;//creo jeje ley de visual studio
        //            IRA = T8 + T14;
        //            txtIRA.Text = IRA.ToString();
        //            txtT8.Text = T8.ToString();
        //            txtT14.Text = T14.ToString();
        //            //IRM = IRA / 12;
        //            //txtIRM.Text = IRM.ToString();
        //        }
        //        else if (RentaNeta > 79000 && RentaNeta <= 138000)//comentarios siempre usa
        //        {
        //            T8 = (19750 * 8) / 100;//ley de visual
        //            T14 = ((79000 - 19750) * 14) / 100;
        //            T17 = ((RentaNeta - 79000) * 17) / 100;
        //            IRA = T8 + T14 + T17;
        //            txtIRA.Text = IRA.ToString();
        //            txtT8.Text = T8.ToString();
        //            txtT14.Text = T14.ToString();
        //            txtT17.Text = T17.ToString();
        //            txtIRA.Text = IRA.ToString();
        //            //IRM = IRA / 12;
        //            //txtIRM.Text = IRM.ToString();
        //        }
        //        else if (RentaNeta > 138250 && RentaNeta <= 177750)
        //        {
        //            T8 = (19750 * 8) / 100;
        //            T14 = ((79000 - 19750) * 14) / 100;
        //            T17 = ((79000 - 19750) * 17) / 100;
        //            T20 = ((RentaNeta - 138250) * 20) / 100;
        //            IRA = T8 + T14 + T17 + T20;
        //            txtIRA.Text = IRA.ToString();
        //            txtT8.Text = T8.ToString();
        //            txtT14.Text = T14.ToString();
        //            txtT17.Text = T17.ToString();
        //            txtT20.Text = T20.ToString();
        //            txtIRA.Text = IRA.ToString();
        //            //IRM = IRA / 12;
        //            //txtIRM.Text = IRM.ToString();
        //        }
        //        else if (RentaNeta > 177750)
        //        {
        //            T8 = (19750 * 8) / 100;
        //            T14 = ((79000 - 19750) * 14) / 100;
        //            T17 = ((79000 - 19750) * 17) / 100;
        //            T20 = ((177750 - 138250) * 20) / 100;
        //            T30 = ((RentaNeta - 177750) * 30) / 100;
        //            IRA = T8 + T14 + T17 + T20 + T30;
        //            txtIRA.Text = IRA.ToString();
        //            txtT8.Text = T8.ToString();
        //            txtT14.Text = T14.ToString();
        //            txtT17.Text = T17.ToString();
        //            txtT20.Text = T20.ToString();
        //            txtT30.Text = T30.ToString();
        //            txtIRA.Text = IRA.ToString();
        //            //IRM = IRA / 12;EL 
        //            //txtIRM.Text = IRM.ToString();
        //        }
        //    }
        //}
        public void CalcularImpuestoRenta5ta(decimal Remuneracion, int NroMes, decimal Gratificaciones, decimal UIT)
        {
            decimal ImpuestoRentaAnual;
            decimal T8, T14, T17, T20, T30;
            decimal UIT5, UIT7, UIT20, UIT35, UIT45;
            UIT5 = UIT * 5;
            UIT7 = UIT * 7;
            UIT20 = UIT * 20;
            UIT35 = UIT * 35;
            UIT45 = UIT * 45;
            decimal RentaBruta, RentaNeta;
            RentaBruta = ((Remuneracion * NroMes) + Gratificaciones);
            RentaNeta = (RentaBruta - UIT7);

            if (RentaBruta <= (UIT7))
            {
                MessageBox.Show("No está sujeto a Retención");
            }
            else if (RentaBruta > UIT7)
            {
                if (RentaNeta <= UIT5)
                {
                    txtRb.Text = RentaBruta.ToString();
                    txtRN.Text = RentaNeta.ToString();
                    ImpuestoRentaAnual = (RentaNeta * 8) / 100;
                    txtIRA.Text = ImpuestoRentaAnual.ToString();
                }
                else if (RentaNeta > UIT5 && RentaNeta <= UIT20)
                {
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((RentaNeta - UIT5) * 14) / 100;
                    ImpuestoRentaAnual = T8 + T14;
                    txtIRA.Text = ImpuestoRentaAnual.ToString();

                }
                else if (RentaNeta > UIT20 && RentaNeta <= UIT35)
                {
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((RentaNeta - UIT20) * 17) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17;
                    txtIRA.Text = ImpuestoRentaAnual.ToString();
                }
                else if (RentaNeta > UIT35 && RentaNeta <= UIT45)
                {
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((UIT20 - UIT5) * 17) / 100;
                    T20 = ((RentaNeta - UIT35) * 20) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17 + T20;
                    txtIRA.Text = ImpuestoRentaAnual.ToString();
                }
                else if (RentaNeta > UIT45)
                {
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((UIT20 - UIT5) * 17) / 100;
                    T20 = ((UIT45 - UIT35) * 20) / 100;
                    T30 = ((RentaNeta - UIT35) * 30) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17 + T20 + T30;
                    txtIRA.Text = ImpuestoRentaAnual.ToString();
                }
            }
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbMes.Text;
            decimal Gratificaciones = Convert.ToDecimal(txtGrati.Text);
            decimal Remuneracion = Convert.ToDecimal(txtIngresos.Text);
            decimal UIT = Convert.ToDecimal(cbUIT.Text);
            switch (opcion)
            {

                case "Enero":
                    {

                        int mes = 12;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 12);
                        break;
                    }
                case "Febrero":
                    {
                        //
                        int mes = 11;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 12);
                        break;
                    }
                case "Marzo":
                    {
                        int mes = 10;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 12);
                        break;
                    }
                case "Abril":
                    {
                        //
                        int mes = 9;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 9);
                        break;
                    }
                case "Mayo":
                    {
                        //
                        int mes = 8;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 8);
                        break;
                    }
                case "Junio":
                    {
                        //
                        int mes = 7;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 8);
                        break;
                    }
                case "Julio":
                    {
                        //
                        int mes = 6;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 12);
                        break;
                    }
                case "Agosto":
                    {
                        //
                        int mes = 5;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 5);
                        break;
                    }
                case "Setiembre":
                    {
                        //
                        int mes = 4;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 4);
                        break;
                    }
                case "Octubre":
                    {
                        //
                        int mes = 3;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 4);
                        break;
                    }
                case "Noviembre":
                    {
                        //
                        int mes = 2;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 4);
                        break;
                    }
                case "Diciembre":
                    {
                        //
                        int mes = 1;
                        CalcularImpuestoRenta5ta(Remuneracion, mes, Gratificaciones, UIT);
                        txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 12);
                        break;
                    }
                default:
                    {
                        //no se  encontró ese mes
                        break;
                    }
            }
        }
    }
}
