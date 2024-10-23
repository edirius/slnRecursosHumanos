using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Tareos;

namespace CapaUsuario.Tareo
{
    public partial class frmDatosHojaInformativa : Form
    {
        public frmDatosHojaInformativa()
        {
            InitializeComponent();
        }

        public cExcelHojaInformativa HojaInformativa;

        private void frmDatosHojaInformativa_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            HojaInformativa.ColumnaCuentaBancaria = txtColumnaCuentaBancaria.Text;
            HojaInformativa.NombreHoja = txtHojaExcel.Text;
            HojaInformativa.InicioFila = Convert.ToInt16(txtComienzoFila.Text);
            HojaInformativa.FinFila = Convert.ToInt16(txtFinFila.Text);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
