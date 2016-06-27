using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Sunat
{
    public partial class frmMantenimientoMaestroDescuentos : Form
    {
        int sidtmaestrodescuentos = 0;
        string scodigo = "";
        string sdescripcion = "";
        string scalculo = "";

        CapaDeNegocios.Sunat.cMaestroDescuentos miMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();

        public frmMantenimientoMaestroDescuentos()
        {
            InitializeComponent();
        }

        private void frmMantenimientoMaestroDescuentos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Sunat.frmMaestroDescuentos fMaestroDescuentos = new CapaUsuario.Sunat.frmMaestroDescuentos();
            fMaestroDescuentos.RecibirDatos(0, "", "", scalculo, 1);
            if (fMaestroDescuentos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtmaestrodescuentos == 0 && dgvMaestroDescuentos.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Sunat.frmMaestroDescuentos fMaestroDescuentos = new CapaUsuario.Sunat.frmMaestroDescuentos();
            fMaestroDescuentos.RecibirDatos(sidtmaestrodescuentos, scodigo, sdescripcion, scalculo, 2);
            if (fMaestroDescuentos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtmaestrodescuentos == 0 && dgvMaestroDescuentos.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar el Maestro Descuentos", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miMaestroDescuentos.IdtMaestroDescuentos = sidtmaestrodescuentos;
            miMaestroDescuentos.EliminarMaestroDescuentos(miMaestroDescuentos);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMaestroDescuentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvMaestroDescuentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iFila = this.dgvMaestroDescuentos.CurrentRow.Index;
            sidtmaestrodescuentos = Convert.ToInt32(dgvMaestroDescuentos.Rows[iFila].Cells["idtmaestrodescuentos"].Value);
            scodigo = Convert.ToString(dgvMaestroDescuentos.Rows[iFila].Cells["codigo"].Value);
            sdescripcion = Convert.ToString(dgvMaestroDescuentos.Rows[iFila].Cells["descripcion"].Value);
            scalculo = Convert.ToString(dgvMaestroDescuentos.Rows[iFila].Cells["calculo"].Value);
        }

        private void CargarDatos()
        {
            dgvMaestroDescuentos.DataSource = miMaestroDescuentos.ListarMaestroDescuentos();
            dgvMaestroDescuentos.Columns[0].Visible = false;
            dgvMaestroDescuentos.Columns[3].Visible = false;
        }
    }
}
