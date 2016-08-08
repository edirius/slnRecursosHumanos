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
        string sabreviacion = "";

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
            fMaestroAportacionesEmpleador.RecibirDatos(0, "", "", "","", 1);
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
            fMaestroAportacionesEmpleador.RecibirDatos(sidtmaestroaportacionesempleador, scodigo, sdescripcion, scalculo, sabreviacion, 2);
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
            this.Close();
        }

        private void dgvMaestroAportacionesEmpleador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvMaestroAportacionesEmpleador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sidtmaestroaportacionesempleador = Convert.ToInt32(dgvMaestroAportacionesEmpleador.Rows[e.RowIndex].Cells[0].Value);
            scodigo = Convert.ToString(dgvMaestroAportacionesEmpleador.Rows[e.RowIndex].Cells[1].Value);
            sdescripcion = Convert.ToString(dgvMaestroAportacionesEmpleador.Rows[e.RowIndex].Cells[2].Value);
            scalculo = Convert.ToString(dgvMaestroAportacionesEmpleador.Rows[e.RowIndex].Cells[3].Value);
            sabreviacion = Convert.ToString(dgvMaestroAportacionesEmpleador.Rows[e.RowIndex].Cells[4].Value);
        }

        private void CargarDatos()
        {
            dgvMaestroAportacionesEmpleador.Rows.Clear();
            foreach (DataRow row in miMaestroAportacionesEmpleador.ListarMaestroAportacionesEmpleador().Rows)
            {
                dgvMaestroAportacionesEmpleador.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
            }
            if (dgvMaestroAportacionesEmpleador.Rows.Count > 0)
            {
                dgvMaestroAportacionesEmpleador.Rows[0].Selected = true;
                DataGridViewCellEventArgs ceo = new DataGridViewCellEventArgs(0, 0);
                dgvMaestroAportacionesEmpleador_CellClick(dgvMaestroAportacionesEmpleador, ceo);
            }
        }
    }
}
