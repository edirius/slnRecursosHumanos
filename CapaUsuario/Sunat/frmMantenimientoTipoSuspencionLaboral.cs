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
    public partial class frmMantenimientoTipoSuspencionLaboral : Form
    {
        int sidttiposuspencionlaboral = 0;
        string scodigo = "";
        string sdescripcion = "";
        string sabreviacion = "";
        bool ssubsidiado = false;

        CapaDeNegocios.Sunat.cTipoSuspencionLaboral miTipoSuspencionLaboral = new CapaDeNegocios.Sunat.cTipoSuspencionLaboral();

        public frmMantenimientoTipoSuspencionLaboral()
        {
            InitializeComponent();
        }

        private void frmMantenimientoMaestroDescuentos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Sunat.frmTipoSuspencionLaboral fTipoSuspencionLaboral = new CapaUsuario.Sunat.frmTipoSuspencionLaboral();
            fTipoSuspencionLaboral.RecibirDatos(0, "", "", "", false, 1);
            if (fTipoSuspencionLaboral.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidttiposuspencionlaboral == 0 && dgvTipoSuspencionLaboral.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Sunat.frmTipoSuspencionLaboral fTipoSuspencionLaboral = new CapaUsuario.Sunat.frmTipoSuspencionLaboral();
            fTipoSuspencionLaboral.RecibirDatos(sidttiposuspencionlaboral, scodigo, sdescripcion, sabreviacion, ssubsidiado, 2);
            if (fTipoSuspencionLaboral.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidttiposuspencionlaboral == 0 && dgvTipoSuspencionLaboral.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar el Maestro Descuentos", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miTipoSuspencionLaboral.EliminarTipoSuspencionLaboral(sidttiposuspencionlaboral);
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
            sidttiposuspencionlaboral = Convert.ToInt32(dgvTipoSuspencionLaboral.Rows[e.RowIndex].Cells[0].Value);
            scodigo = Convert.ToString(dgvTipoSuspencionLaboral.Rows[e.RowIndex].Cells[1].Value);
            sdescripcion = Convert.ToString(dgvTipoSuspencionLaboral.Rows[e.RowIndex].Cells[2].Value);
            sabreviacion = Convert.ToString(dgvTipoSuspencionLaboral.Rows[e.RowIndex].Cells[3].Value);
            ssubsidiado = Convert.ToBoolean(dgvTipoSuspencionLaboral.Rows[e.RowIndex].Cells[4].Value);
        }

        private void CargarDatos()
        {
            dgvTipoSuspencionLaboral.Rows.Clear();
            foreach (DataRow row in miTipoSuspencionLaboral.ListarTipoSuspencionLaboral().Rows)
            {
                dgvTipoSuspencionLaboral.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            }
            if (dgvTipoSuspencionLaboral.Rows.Count > 0)
            {
                dgvTipoSuspencionLaboral.Rows[0].Selected = true;
                DataGridViewCellEventArgs ceo = new DataGridViewCellEventArgs(0, 0);
                dgvMaestroDescuentos_CellClick(dgvTipoSuspencionLaboral, ceo);
            }
        }
    }
}
