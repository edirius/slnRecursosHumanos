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
        bool sAfectoDescuentos = false;
        bool sAfectoNeto = false;

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
            try
            {
                CapaUsuario.Sunat.frmMaestroDescuentos fMaestroDescuentos = new CapaUsuario.Sunat.frmMaestroDescuentos();
                fMaestroDescuentos.RecibirDatos(0, "", "", "", "", 1, false, true);
                if (fMaestroDescuentos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Se agrego el descuento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al crear el descuento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sidtmaestrodescuentos == 0 && dgvMaestroDescuentos.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CapaUsuario.Sunat.frmMaestroDescuentos fMaestroDescuentos = new CapaUsuario.Sunat.frmMaestroDescuentos();
                fMaestroDescuentos.RecibirDatos(sidtmaestrodescuentos, scodigo, sdescripcion, scalculo, sabreviacion, 2, sAfectoDescuentos, sAfectoNeto);
                if (fMaestroDescuentos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Se modificó el descuento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al modificar el descuento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sidtmaestrodescuentos == 0 && dgvMaestroDescuentos.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Está seguro que desea eliminar el Maestro Descuentos", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    miMaestroDescuentos.IdtMaestroDescuentos = sidtmaestrodescuentos;
                    miMaestroDescuentos.EliminarMaestroDescuentos(miMaestroDescuentos);
                    MessageBox.Show("Se eliminó el descuento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al eliminar el descuento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

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
            sAfectoDescuentos = Convert.ToBoolean(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[5].Value);
            sAfectoNeto = Convert.ToBoolean(dgvMaestroDescuentos.Rows[e.RowIndex].Cells[6].Value);
        }

        private void CargarDatos()
        {
            dgvMaestroDescuentos.Rows.Clear();
            foreach (DataRow row in miMaestroDescuentos.ListarMaestroDescuentos().Rows)
            {
                dgvMaestroDescuentos.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5], row[6]);
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
