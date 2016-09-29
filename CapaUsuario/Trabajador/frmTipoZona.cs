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

namespace CapaUsuario.Trabajador
{
    public partial class frmTipoZona : Form
    {
        public cTipoZona miTipoZona = new cTipoZona();

        public frmTipoZona()
        {
            InitializeComponent();
        }

        private void dtgListaTipoZonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgListaTipoZonas.SelectedRows.Count > 0)
            {
                miTipoZona.Codigo = Convert.ToInt16(dtgListaTipoZonas.SelectedRows[0].Cells[0].Value.ToString());
                miTipoZona.CodigoSunat = dtgListaTipoZonas.SelectedRows[0].Cells[1].Value.ToString();
                miTipoZona.Descripcion = dtgListaTipoZonas.SelectedRows[0].Cells[2].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Selecciona un tipo de zona");
            }
        }

        private void dtgListaTipoZonas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                miTipoZona.Codigo =Convert.ToInt16(dtgListaTipoZonas.SelectedRows[0].Cells[0].Value.ToString());
                miTipoZona.CodigoSunat = dtgListaTipoZonas.SelectedRows[0].Cells[1].Value.ToString();
                miTipoZona.Descripcion = dtgListaTipoZonas.SelectedRows[0].Cells[2].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void frmTipoZona_Load(object sender, EventArgs e)
        {
            dtgListaTipoZonas.DataSource = miTipoZona.ListarTiposZona(); 
        }
    }
}
