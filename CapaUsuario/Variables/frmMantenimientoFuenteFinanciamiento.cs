using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Variables
{
    public partial class frmMantenimientoFuenteFinanciamiento : Form
    {
        int sidtfuentefinanciamiento = 0;
        string scodigo = "";
        string sdescripcion = "";

        CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamiento = new CapaDeNegocios.cFuenteFinanciamiento();

        public frmMantenimientoFuenteFinanciamiento()
        {
            InitializeComponent();
        }

        private void frmMantenimientoFuenteFinanciamiento_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Variables.frmFuenteFinanciamiento fFuenteFinanciamiento = new frmFuenteFinanciamiento();
            fFuenteFinanciamiento.RecibirDatos(0, "", "", 1);
            if (fFuenteFinanciamiento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtfuentefinanciamiento == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Variables.frmFuenteFinanciamiento fFuenteFinanciamiento = new frmFuenteFinanciamiento();
            fFuenteFinanciamiento.RecibirDatos(sidtfuentefinanciamiento, scodigo, sdescripcion, 2);
            if (fFuenteFinanciamiento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtfuentefinanciamiento == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar la Fuente de Financiamiento", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miFuenteFinanciamiento.EliminarFuenteFinanciamiento(sidtfuentefinanciamiento);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvFuenteFinanciamiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvFuenteFinanciamiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sidtfuentefinanciamiento = Convert.ToInt32(dgvFuenteFinanciamiento.Rows[e.RowIndex].Cells[0].Value);
            scodigo = Convert.ToString(dgvFuenteFinanciamiento.Rows[e.RowIndex].Cells[1].Value);
            sdescripcion = Convert.ToString(dgvFuenteFinanciamiento.Rows[e.RowIndex].Cells[2].Value);
        }

        private void CargarDatos()
        {
            dgvFuenteFinanciamiento.DataSource = miFuenteFinanciamiento.ListarFuenteFinanciamiento();
            if (dgvFuenteFinanciamiento.Rows.Count > 0)
            {
                dgvFuenteFinanciamiento.Columns[0].Visible = false;
                dgvFuenteFinanciamiento.Rows[dgvFuenteFinanciamiento.Rows.Count - 1].Cells[1].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvFuenteFinanciamiento.Rows.Count - 1);
                dgvFuenteFinanciamiento_CellClick(dgvFuenteFinanciamiento, cea);
            }
        }
    }
}
