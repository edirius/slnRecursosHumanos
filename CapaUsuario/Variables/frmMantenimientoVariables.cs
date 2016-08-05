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
    public partial class frmMantenimientoVariables : Form
    {
        int sidtvariables = 0;
        string saño = "";
        int ssueldominimo = 0;
        int suit = 0;

        CapaDeNegocios.cVariables miVariables = new CapaDeNegocios.cVariables();

        public frmMantenimientoVariables()
        {
            InitializeComponent();
        }

        private void frmMantenimientoVariables_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Variables.frmVariables fVariables = new frmVariables();
            fVariables.RecibirDatos(0, "", 0, 0, 1);
            if (fVariables.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtvariables == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Variables.frmVariables fVariables = new frmVariables();
            fVariables.RecibirDatos(sidtvariables, saño, ssueldominimo, suit, 2);
            if (fVariables.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtvariables == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar la Variable", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miVariables.EliminarVariables(sidtvariables);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvVariables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVariables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sidtvariables = Convert.ToInt32(dgvVariables.Rows[e.RowIndex].Cells[0].Value);
            saño = Convert.ToString(dgvVariables.Rows[e.RowIndex].Cells[1].Value);
            ssueldominimo = Convert.ToInt32(dgvVariables.Rows[e.RowIndex].Cells[2].Value);
            suit = Convert.ToInt32(dgvVariables.Rows[e.RowIndex].Cells[3].Value);
        }

        private void CargarDatos()
        {
            CapaDeNegocios.cVariables miVariables = new CapaDeNegocios.cVariables();
            dgvVariables.DataSource = miVariables.ListarVariables();
            if (dgvVariables.Rows.Count > 0)
            {
                dgvVariables.Columns[0].Visible = false;
                dgvVariables.Rows[dgvVariables.Rows.Count - 1].Cells[1].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvVariables.Rows.Count - 1);
                dgvVariables_CellClick(dgvVariables, cea);
            }
        }
    }
}
