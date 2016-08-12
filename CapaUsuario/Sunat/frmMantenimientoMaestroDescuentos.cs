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
        string sabreviacion = "";

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
            fMaestroDescuentos.RecibirDatos(0, "", "", "","", 1);
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
            fMaestroDescuentos.RecibirDatos(sidtmaestrodescuentos, scodigo, sdescripcion, scalculo,sabreviacion, 2);
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
            sidtmaestrodescuentos = Convert.ToInt32(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[0].Value);
            scodigo = Convert.ToString(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[1].Value);
            sdescripcion = Convert.ToString(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[2].Value);
            scalculo = Convert.ToString(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[3].Value);
            sabreviacion = Convert.ToString(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[4].Value);
        }

        private void CargarDatos()
        {
            dgvMaestroDescuentos.Rows.Clear();
            foreach (DataRow row in miMaestroDescuentos.ListarMaestroDescuentos().Rows)
            {
                dgvMaestroDescuentos.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            }
            if (dgvMaestroDescuentos.Rows.Count > 0)
            {
                dgvMaestroDescuentos.Rows[0].Selected = true;
                DataGridViewCellEventArgs ceo = new DataGridViewCellEventArgs(0, 0);
                dgvMaestroDescuentos_CellClick(dgvMaestroDescuentos, ceo);
            }
        }
    }
}
