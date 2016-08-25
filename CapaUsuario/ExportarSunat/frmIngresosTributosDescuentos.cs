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

namespace CapaUsuario.ExportarSunat
{
    public partial class frmIngresosTributosDescuentos : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExportar = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        public frmIngresosTributosDescuentos()
        {
            InitializeComponent();
            cbTipo.Text = "INGRESOS (0100)";

        }
        public void CargarGrid()
        {
            dgvDescripcion.DataSource = oExportar.ListarMaestroIngresosxTipo(cbTipo.Text);
            dgvDescripcion.Columns[0].Width = 50;
            dgvDescripcion.Columns[1].Width = 250;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
