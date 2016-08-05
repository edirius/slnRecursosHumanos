using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Tareo
{
    public partial class frmMantenimientoTareo : Form
    {
        int sIdTTareo = 0;
        int sNumero = 0;
        DateTime sFechaInicio= DateTime.Now;
        DateTime sFechaFin= DateTime.Now;
        string sDescripcion = "";
        bool sEstado = false;
        int sIdTMeta = 0;

        CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
        CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();

        public frmMantenimientoTareo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCronogramaTareo_Load(object sender, EventArgs e)
        {
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Tareo.frmTareo fTareo = new CapaUsuario.Tareo.frmTareo();
            fTareo.RecibirDatos(0, 0, DateTime.Today, DateTime.Today, "", false, sIdTMeta, cboMeta.Text, 1);
            if (fTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sEstado == true)
            {
                MessageBox.Show("El Tareo ya no se puede Modificar.", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sIdTTareo == 0 && dgvTareo.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Tareo.frmTareo fTareo = new CapaUsuario.Tareo.frmTareo();


            fTareo.RecibirDatos(sIdTTareo, sNumero, sFechaInicio, sFechaFin, sDescripcion, sEstado, sIdTMeta, cboMeta.Text, 2);

            if (fTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sEstado == true)
            {
                MessageBox.Show("El Tareo no se puede Eliminar.", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sIdTTareo == 0 && dgvTareo.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar el Cronograma asignado a la Meta", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miTareo.IdTTareo = sIdTTareo;
            miTareo.EliminarTareo(miTareo);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalleTareo_Click(object sender, EventArgs e)
        {
            if (sEstado == true)
            {
                MessageBox.Show("El Detalle del Tareo ya no se puede Modificar.", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sIdTTareo == 0 && dgvTareo.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Tareo.frmMantenimientoDetalleTareo fDetalleTareo = new CapaUsuario.Tareo.frmMantenimientoDetalleTareo();
            fDetalleTareo.RecibirDatos(sIdTTareo, sNumero, sFechaInicio, sFechaFin, sDescripcion, cboMeta.Text, sIdTMeta);
            if (fDetalleTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "System.Data.DataRowView" && cboMeta.ValueMember != "")
            {
                sIdTMeta = Convert.ToInt32(cboMeta.SelectedValue);
                CargarDatos();
            }
        }

        private void dgvCronogramaTareo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCronogramaTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int iFila = this.dgvTareo.CurrentRow.Index;

            int iFila = Convert.ToInt32( e.RowIndex );

            if (iFila != -1){ 
                sIdTTareo = Convert.ToInt32(dgvTareo.Rows[iFila].Cells["idttareo"].Value);
                sNumero = Convert.ToInt32(dgvTareo.Rows[iFila].Cells["numero"].Value);
                sFechaInicio = Convert.ToDateTime(dgvTareo.Rows[iFila].Cells["fechainicio"].Value);
                sFechaFin = Convert.ToDateTime(dgvTareo.Rows[iFila].Cells["fechafin"].Value);
                sDescripcion = Convert.ToString(dgvTareo.Rows[iFila].Cells["descripcion"].Value);
                sEstado = Convert.ToBoolean(dgvTareo.Rows[iFila].Cells["estado"].Value);
            }
        }

        private void CargarMeta()
        {
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            cboMeta.DataSource = miCadena.ListarMetas();
            cboMeta.DisplayMember = "nombre";
            cboMeta.ValueMember = "idtmeta";
        }

        private void CargarDatos()
        {
            miMeta.Codigo = sIdTMeta;
            dgvTareo.DataSource = miTareo.ListarTareo(miMeta);
            dgvTareo.Columns[0].Visible = false;
            dgvTareo.Columns[6].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.MostrarReportes fMostrarReportes = new CapaUsuario.Reportes.MostrarReportes();
            fMostrarReportes.IdTMeta = sIdTMeta;
            fMostrarReportes.IdTTareo = sIdTTareo;
            fMostrarReportes.ShowDialog();
        }
    }
}
