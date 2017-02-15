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

namespace CapaUsuario.ResidenteMeta
{
    public partial class frmBuscarTrabajadores : Form
    {
        public int sidttrabajador = 0;
        public string strabajador = "";

        private DataTable tablaAuxiliar;

        public CapaDeNegocios.ResidenteMeta.cBuscarTrabajador miListaTrabajadores = new CapaDeNegocios.ResidenteMeta.cBuscarTrabajador();

        public frmBuscarTrabajadores()
        {
            InitializeComponent();
        }

        private void frmListaTrabajadores_Load(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.BuscarTrabajadores("", "");
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
            dtgListaTrabajadores.Columns["id_trabajador"].Width = 70;
            dtgListaTrabajadores.Columns["dni"].Width = 70;
            dtgListaTrabajadores.Columns["sexo"].Width = 30;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTrabajador_TextChanged(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.BuscarTrabajadores(txtTrabajador.Text, txtCargo.Text);
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
        }

        private void txtCargo_TextChanged(object sender, EventArgs e)
        {
            tablaAuxiliar = miListaTrabajadores.BuscarTrabajadores(txtTrabajador.Text, txtCargo.Text);
            dtgListaTrabajadores.DataSource = tablaAuxiliar;
        }

        private void dtgListaTrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgListaTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidttrabajador = Convert.ToInt32(dtgListaTrabajadores.Rows[e.RowIndex].Cells[0].Value);
                strabajador = dtgListaTrabajadores.Rows[e.RowIndex].Cells[2].Value.ToString() + " - " + dtgListaTrabajadores.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void dtgListaTrabajadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
