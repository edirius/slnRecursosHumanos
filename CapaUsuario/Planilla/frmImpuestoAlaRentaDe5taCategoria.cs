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
        cValidaciones oValidar = new cValidaciones();
        cVariables oVariables = new cVariables();
        string años = "";
        
        public frmImpuestoAlaRentaDe5taCategoria()
        {
            InitializeComponent();
            ConfInicial();
            //ListarAños();
            CargarAños();
        }
        public void Limpiar()
        {
            txtIngresos.Text = "";
            txtGrati.Text = "";
            txtRb.Text = "";
            txtRN.Text = "";
            txtIRA.Text = "";
            txtIRM.Text = "";
            txtIngresos.Focus();
        }
        public void ConfInicial()
        {
            txtRb.Enabled = false;
            txtRN.Enabled = false;
            txtIRA.Enabled = false;
            txtIRM.Enabled = false;
        }
        public void CalcularImpuestoRenta5ta(decimal Remuneracion, decimal RemMesAnt, int NroMes, decimal Gratificaciones, decimal UIT)
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
            RentaBruta = ((Remuneracion * NroMes) + Gratificaciones + RemMesAnt);
            RentaNeta = (RentaBruta - UIT7);

            if (RentaBruta <= (UIT7))
            {
                MessageBox.Show("No está sujeto a Retención");
                Limpiar();
                txtIRA.Text = 0.ToString();
            }
            else if (RentaBruta > UIT7)
            {
                txtRb.Text = RentaBruta.ToString();

                if (RentaNeta <= UIT5)
                {
                    txtRN.Text = RentaNeta.ToString();
                    ImpuestoRentaAnual = ((RentaNeta * 8) / 100);
                    txtIRA.Text = decimal.Round(ImpuestoRentaAnual,2).ToString();
                }
                else if (RentaNeta > UIT5 && RentaNeta <= UIT20)
                {
                    txtRb.Text = RentaBruta.ToString();
                    txtRN.Text = RentaNeta.ToString();
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((RentaNeta - UIT5) * 14) / 100;
                    ImpuestoRentaAnual = T8 + T14;
                    txtIRA.Text = decimal.Round(ImpuestoRentaAnual,2).ToString();

                }
                else if (RentaNeta > UIT20 && RentaNeta <= UIT35)
                {
                    txtRb.Text = RentaBruta.ToString();
                    txtRN.Text = RentaNeta.ToString();
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((RentaNeta - UIT20) * 17) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17;
                    txtIRA.Text = decimal.Round(ImpuestoRentaAnual,2).ToString();
                }
                else if (RentaNeta > UIT35 && RentaNeta <= UIT45)
                {
                    txtRb.Text = RentaBruta.ToString();
                    txtRN.Text = RentaNeta.ToString();
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((UIT20 - UIT5) * 17) / 100;
                    T20 = ((RentaNeta - UIT35) * 20) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17 + T20;
                    txtIRA.Text = decimal.Round(ImpuestoRentaAnual,2).ToString();
                }
                else if (RentaNeta > UIT45)
                {
                    txtRb.Text = RentaBruta.ToString();
                    txtRN.Text = RentaNeta.ToString();
                    T8 = (UIT5 * 8) / 100;
                    T14 = ((UIT20 - UIT5) * 14) / 100;
                    T17 = ((UIT20 - UIT5) * 17) / 100;
                    T20 = ((UIT45 - UIT35) * 20) / 100;
                    T30 = ((RentaNeta - UIT35) * 30) / 100;
                    ImpuestoRentaAnual = T8 + T14 + T17 + T20 + T30;
                    txtIRA.Text = decimal.Round(ImpuestoRentaAnual,2).ToString();
                }
            }
        }
        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtIngresos.Text != "" && txtGrati.Text != "" && cbUIT.Text != "")
            {
                string opcion = cbMes.Text;
                decimal RemMesAnteriores = Convert.ToDecimal(txtRemAnteriores.Text);
                decimal RetMesAnteriores = Convert.ToDecimal(txtRetencionesAnteriores.Text);
                decimal Gratificaciones = Convert.ToDecimal(txtGrati.Text);
                decimal Remuneracion = Convert.ToDecimal(txtIngresos.Text);
                decimal UIT = Convert.ToDecimal(cbUIT.Text);
                switch (opcion)
                {

                    case "Enero":
                        {

                            int mes = 12;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = Convert.ToDecimal(txtIRA.Text);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 12), 2));
                            //txtIRM.Text = Convert.ToString(Convert.ToDecimal(txtIRA.Text) / 12);
                            break;
                        }
                    case "Febrero":
                        {
                            //
                            int mes = 11;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 12), 2));
                            break;
                        }
                    case "Marzo":
                        {
                            int mes = 10;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 12), 2));
                            break;
                        }
                    case "Abril":
                        {
                            //
                            int mes = 9;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 9), 2));
                            break;
                        }
                    case "Mayo":
                        {
                            //
                            int mes = 8;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 8), 2));
                            break;
                        }
                    case "Junio":
                        {
                            //
                            int mes = 7;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 8), 2));
                            break;
                        }
                    case "Julio":
                        {
                            //
                            int mes = 6;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 8), 2));
                            break;
                        }
                    case "Agosto":
                        {
                            //
                            int mes = 5;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 5), 2));
                            break;
                        }
                    case "Setiembre":
                        {
                            //
                            int mes = 4;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 4), 2));
                            break;
                        }
                    case "Octubre":
                        {
                            //
                            int mes = 3;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 4), 2));
                            break;
                        }
                    case "Noviembre":
                        {
                            //
                            int mes = 2;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM / 4), 2));
                            break;
                        }
                    case "Diciembre":
                        {
                            //
                            int mes = 1;
                            CalcularImpuestoRenta5ta(Remuneracion, RemMesAnteriores, mes, Gratificaciones, UIT);
                            decimal IRM = (Convert.ToDecimal(txtIRA.Text) - RetMesAnteriores);
                            txtIRM.Text = Convert.ToString(decimal.Round((IRM), 2));
                            break;
                        }
                    default:
                        {
                            //no se  encontró ese mes
                            break;
                        }
                }
            }
            else
                MessageBox.Show("Llene los datos necesarios para el calculo");
        }
        private void txtIngresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            oValidar.SoloNumeros(e);
        }
        private void txtGrati_KeyPress(object sender, KeyPressEventArgs e)
        {
            oValidar.SoloNumeros(e);
        }
        private void ListarAños()
        {
            cbAños.ValueMember = "idtvariables";
            cbAños.DisplayMember = "año";
            cbAños.DataSource = oVariables.ListarAños();
        }
        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cbAños.Items.Add(i);
            }
            cbAños.Text = años;
        }
        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAños.ValueMember = "año";
            cbUIT.DisplayMember = "UIT";
            cbUIT.DataSource = oVariables.ListarUIT(cbAños.Text);
        }
    }
}