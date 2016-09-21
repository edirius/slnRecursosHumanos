using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using CapaDeNegocios;

namespace CapaUsuario.Trabajador
{
    public partial class frmProvincia : Form
    {
        public cProvincia miProvincia;

        public frmProvincia()
        {
            InitializeComponent();
        }

        private void frmProvincia_Load(object sender, EventArgs e)
        {
            dtgListaProvincias.DataSource = miProvincia.ListarProvincias(miProvincia.MiDepartamento);

        }

        private void dtgListaProvincias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                miProvincia.Codigo = Convert.ToInt16(dtgListaProvincias.SelectedRows[0].Cells[0].Value.ToString());
                miProvincia.CodigoUbigeo = dtgListaProvincias.SelectedRows[0].Cells[2].Value.ToString();
                miProvincia.Descripcion = dtgListaProvincias.SelectedRows[0].Cells[3].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void dtgListaProvincias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgListaProvincias.SelectedRows.Count > 0)
            {
                miProvincia.Codigo = Convert.ToInt16(dtgListaProvincias.SelectedRows[0].Cells[0].Value.ToString());
                miProvincia.CodigoUbigeo = dtgListaProvincias.SelectedRows[0].Cells[2].Value.ToString();
                miProvincia.Descripcion = dtgListaProvincias.SelectedRows[0].Cells[3].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Seleccione una provincia de la lista.");
            }
        }

        private void dtgListaProvincias_MouseEnter(object sender, EventArgs e)
        {
            toolProvincia.Show("Presione ENTER para seleccionar la provincia.", dtgListaProvincias);
        }
    }
}
