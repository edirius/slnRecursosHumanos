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
        CapaDeNegocios.Planillas.cCalculo5taCategoria oCalculo = new CapaDeNegocios.Planillas.cCalculo5taCategoria();
        cVariables oVariables = new cVariables();
        string años = "";
        
        public frmImpuestoAlaRentaDe5taCategoria()
        {
            InitializeComponent();
            CargarAños();
        }
        public void CalcularIRM()
        {
            int NroMes = Convert.ToInt16(cbMes.Text);
            decimal Remuneracion = Convert.ToDecimal(txtIngresos.Text);
            decimal Ingresos = 0;
            decimal Gratificaciones = Convert.ToDecimal(txtGrati.Text);
            decimal RemuMesAnt = Convert.ToDecimal(txtRemAnteriores.Text);
            decimal RetMesAnteriores = Convert.ToDecimal(txtRetencionesAnteriores.Text);
            decimal UIT = Convert.ToDecimal(cbUIT.Text);
            decimal ImpuestoRentaMensual = oCalculo.CalculoRentaMensual(NroMes, Remuneracion, Ingresos, Gratificaciones, RemuMesAnt, RetMesAnteriores, UIT);
            txtIRM.Text = Convert.ToString(Decimal.Round(ImpuestoRentaMensual, 2));
        }

        private void txtIngresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            oValidar.SoloNumeros(e);
        }
        private void txtGrati_KeyPress(object sender, KeyPressEventArgs e)
        {
            oValidar.SoloNumeros(e);
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

        private void btncalcular_Click(object sender, EventArgs e)
        {
            CalcularIRM();
        }
    }
}