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
    public partial class frmMantenimientoMaestroAportacionesTrabajador : Form
    {
        int sidtmaestroaportacionestrabajador = 0;
        string scodigo = "";
        string sdescripcion = "";
        string scalculo = "";

        CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador miMaestroAportacionesTrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();

        public frmMantenimientoMaestroAportacionesTrabajador()
        {
            InitializeComponent();
        }

        private void frmMantenimientoMaestroAportacionesTrabajador_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Sunat.frmMaestroAportacionesTrabajador fMaestroAportacionesTrabajador = new CapaUsuario.Sunat.frmMaestroAportacionesTrabajador();
            fMaestroAportacionesTrabajador.RecibirDatos(0, "", "", scalculo, 1);
            if (fMaestroAportacionesTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtmaestroaportacionestrabajador == 0 && dgvMaestroAportacionesTrabajador.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Sunat.frmMaestroAportacionesTrabajador fMaestroAportacionesTrabajador = new CapaUsuario.Sunat.frmMaestroAportacionesTrabajador();
            fMaestroAportacionesTrabajador.RecibirDatos(sidtmaestroaportacionestrabajador, scodigo, sdescripcion, scalculo, 2);
            if (fMaestroAportacionesTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtmaestroaportacionestrabajador == 0 && dgvMaestroAportacionesTrabajador.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar el Maestro Aportaciones Trabajador", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miMaestroAportacionesTrabajador.IdtMaestroAportacionesTrabajador = sidtmaestroaportacionestrabajador;
            miMaestroAportacionesTrabajador.EliminarMaestroAportacionesTrabajador(miMaestroAportacionesTrabajador);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMaestroAportacionesTrabajador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroAportacionesTrabajador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iFila = this.dgvMaestroAportacionesTrabajador.CurrentRow.Index;
            sidtmaestroaportacionestrabajador = Convert.ToInt32(dgvMaestroAportacionesTrabajador.Rows[iFila].Cells["idtmaestroaportacionestrabajador"].Value);
            scodigo = Convert.ToString(dgvMaestroAportacionesTrabajador.Rows[iFila].Cells["codigo"].Value);
            sdescripcion = Convert.ToString(dgvMaestroAportacionesTrabajador.Rows[iFila].Cells["descripcion"].Value);
            scalculo = Convert.ToString(dgvMaestroAportacionesTrabajador.Rows[iFila].Cells["calculo"].Value);
        }

        private void CargarDatos()
        {
            dgvMaestroAportacionesTrabajador.DataSource = miMaestroAportacionesTrabajador.ListarMaestroAportacionesTrabajador();
            dgvMaestroAportacionesTrabajador.Columns[0].Visible = false;
            dgvMaestroAportacionesTrabajador.Columns[3].Visible = false;
        }
    }
}
