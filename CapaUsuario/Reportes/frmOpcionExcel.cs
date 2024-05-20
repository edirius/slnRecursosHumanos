using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Reportes
{
    public partial class frmOpcionExcel : Form
    {
        public frmOpcionExcel()
        {
            InitializeComponent();
        }

        public enum enumTipoReporte
        {
            reporte1,
            reporte2,
            reporte3
        }

        public enumTipoReporte tipoReporte;

        private void frmOpcionExcel_Load(object sender, EventArgs e)
        {

        }

        private void btnTipo1_Click(object sender, EventArgs e)
        {
            tipoReporte = enumTipoReporte.reporte1;
            this.DialogResult = DialogResult.OK;
        }

        private void btnTipo2_Click(object sender, EventArgs e)
        {
            tipoReporte = enumTipoReporte.reporte2;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
