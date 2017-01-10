using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Contrato
{
    public partial class frmPlantillaContrato : Form
    {
        int iAccion = 0;
        int sidtplantillacontrato = 0;
        CapaDeNegocios.Contrato.cPlantillaContrato miPlantillaContrato = new CapaDeNegocios.Contrato.cPlantillaContrato();

        public frmPlantillaContrato()
        {
            InitializeComponent();
        }

        private void frmPeriodoTrabajador_Load(object sender, EventArgs e)
        {
            CargarPlantillasContratos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            iAccion = 1;
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            miPlantillaContrato.IdTPlantillaContrato = sidtplantillacontrato;
            miPlantillaContrato.Descripcion = txtDescripcion.Text;
            miPlantillaContrato.Direccion = txtDireccion.Text; 

            if (iAccion == 1)
            {
                miPlantillaContrato.CrearPlantillaContrato(miPlantillaContrato);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miPlantillaContrato.ModificarPlantillaContrato(miPlantillaContrato);
                bOk = true;
            }
            if (bOk == true)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se puede registrar estos datos", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dgvPlantillaContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPlantillaContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                iAccion = 2;
                sidtplantillacontrato = Convert.ToInt32(dgvPlantillaContratos.Rows[e.RowIndex].Cells[0].Value);
                txtDescripcion.Text = Convert.ToString(dgvPlantillaContratos.Rows[e.RowIndex].Cells[1].Value);
                txtDireccion.Text = Convert.ToString(dgvPlantillaContratos.Rows[e.RowIndex].Cells[2].Value);
            }
        }

        private void CargarPlantillasContratos()
        {
            dgvPlantillaContratos.DataSource = miPlantillaContrato.ListarPlantillaContrato();
            dgvPlantillaContratos.Columns[0].Visible = false;
            if (dgvPlantillaContratos.Rows.Count > 0)
            {
                dgvPlantillaContratos.Rows[dgvPlantillaContratos.Rows.Count - 1].Cells[2].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvPlantillaContratos.Rows.Count - 1);
                dgvPlantillaContratos_CellClick(dgvPlantillaContratos, cea);
            }
        }
    }
}
