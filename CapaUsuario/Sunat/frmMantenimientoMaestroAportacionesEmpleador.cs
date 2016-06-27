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
    public partial class frmMantenimientoMaestroAportacionesEmpleador : Form
    {
        int sidtmaestroaportacionesempleador = 0;
        string scodigo = "";
        string sdescripcion = "";
        string scalculo = "";

        CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador miMaestroAportacionesEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();

        public frmMantenimientoMaestroAportacionesEmpleador()
        {
            InitializeComponent();
        }

        private void frmMantenimientoMaestroAportacionesEmpleador_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Sunat.frmMaestroAportacionesEmpleador fMaestroAportacionesEmpleador = new CapaUsuario.Sunat.frmMaestroAportacionesEmpleador();
            fMaestroAportacionesEmpleador.RecibirDatos(0, "", "", scalculo, 1);
            if (fMaestroAportacionesEmpleador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtmaestroaportacionesempleador == 0 && dgvMaestroAportacionesEmpleador.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Sunat.frmMaestroAportacionesEmpleador fMaestroAportacionesEmpleador = new CapaUsuario.Sunat.frmMaestroAportacionesEmpleador();
            fMaestroAportacionesEmpleador.RecibirDatos(sidtmaestroaportacionesempleador, scodigo, sdescripcion, scalculo, 2);
            if (fMaestroAportacionesEmpleador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtmaestroaportacionesempleador == 0 && dgvMaestroAportacionesEmpleador.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar el Maestro Aportaciones Empleador", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miMaestroAportacionesEmpleador.IdtMaestroAportacionesEmpleador = sidtmaestroaportacionesempleador;
            miMaestroAportacionesEmpleador.EliminarMaestroAportacionesEmpleador(miMaestroAportacionesEmpleador);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void dgvMaestroAportacionesEmpleador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
        }

        private void dgvMaestroAportacionesEmpleador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iFila = this.dgvMaestroAportacionesEmpleador.CurrentRow.Index;
            sidtmaestroaportacionesempleador = Convert.ToInt32(dgvMaestroAportacionesEmpleador.Rows[iFila].Cells["idtmaestroaportacionesempleador"].Value);
            scodigo = Convert.ToString(dgvMaestroAportacionesEmpleador.Rows[iFila].Cells["codigo"].Value);
            sdescripcion = Convert.ToString(dgvMaestroAportacionesEmpleador.Rows[iFila].Cells["descripcion"].Value);
            scalculo = Convert.ToString(dgvMaestroAportacionesEmpleador.Rows[iFila].Cells["calculo"].Value);
        }

        private void CargarDatos()
        {
            dgvMaestroAportacionesEmpleador.DataSource = miMaestroAportacionesEmpleador.ListarMaestroAportacionesEmpleador();
            dgvMaestroAportacionesEmpleador.Columns[0].Visible = false;
            dgvMaestroAportacionesEmpleador.Columns[3].Visible = false;
        }
    }
}
