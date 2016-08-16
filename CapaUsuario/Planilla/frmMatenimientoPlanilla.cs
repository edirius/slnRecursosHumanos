using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla
{
    public partial class frmMatenimientoPlanilla : Form
    {
        int sidtplanilla = 0;
        string snumero = "";
        string smes = "";
        string saño = "";
        DateTime sfecha;
        int sidtmeta = 0;
        int sidtfuentefinanciamiento = 0;
        int sidtregimenlaboral = 0;
        string smeta = "";
        string sfuentefinanciamiento = "";

        CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();

        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

        public frmMatenimientoPlanilla()
        {
            InitializeComponent();
        }

        private void frmMatenimientoPlanilla_Load(object sender, EventArgs e)
        {
            CargarRegimenLaboral();
            cboRegimenLaboral_SelectedIndexChanged(sender, e);
        }

        private void btnTipoTrabajador_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Planilla.frmPlanilla fPlanilla = new frmPlanilla();
            fPlanilla.RecibirDatos(0, "", "", "", DateTime.Today, 0, "", 0, "", sidtregimenlaboral, 1);
            if (fPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Planilla.frmPlanilla fPlanilla = new frmPlanilla();
            fPlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sfecha, sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, 2);
            if (fPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar la Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miPlanilla.EliminarPlanilla(sidtplanilla);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetallePlanilla_Click(object sender, EventArgs e)
        {
            CapaUsuario.frmPrincipal fPrincipal = new frmPrincipal();
            CapaUsuario.Planilla.frmMantenimientoDetallePlanilla fMantenimientoDetallePlanilla = new frmMantenimientoDetallePlanilla();
            fMantenimientoDetallePlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, cboRegimenLaboral.Text);
            //fMantenimientoDetallePlanilla.MdiParent = fPrincipal;
            if (fMantenimientoDetallePlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
            //fMantenimientoDetallePlanilla.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            fPlanilla.ShowDialog();

            //CapaUsuario.Reportes.fPrueba fPrueba = new CapaUsuario.Reportes.fPrueba();

            //fPrueba.ShowDialog();

        }

        private void cboRegimenLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegimenLaboral.Text != "System.Data.DataRowView" && cboRegimenLaboral.ValueMember != "")
            {
                sidtregimenlaboral = Convert.ToInt32(cboRegimenLaboral.SelectedValue);
                CargarDatos();
            }
        }

        private void dgvPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[0].Value);
                snumero = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value);
                smes = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[2].Value);
                saño = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[3].Value);
                sfecha = Convert.ToDateTime(dgvPlanilla.Rows[e.RowIndex].Cells[4].Value);
                sidtmeta = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[5].Value);
                smeta = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[6].Value);
                sidtfuentefinanciamiento = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[7].Value);
                sfuentefinanciamiento = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[8].Value);
                fPlanilla.RecibirDatos(Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value) );
            }
        }

        private void CargarRegimenLaboral()
        {
            CapaDeNegocios.DatosLaborales.cRegimenLaboral miRegimenLaboral = new CapaDeNegocios.DatosLaborales.cRegimenLaboral();
            cboRegimenLaboral.DataSource = miRegimenLaboral.ListarRegimenLaboral();
            cboRegimenLaboral.DisplayMember = "descripcion";
            cboRegimenLaboral.ValueMember = "idtregimenlaboral";
        }

        private void CargarDatos()
        {
            dgvPlanilla.Rows.Clear();
            DataTable oDataPlanilla = new DataTable();
            oDataPlanilla = miPlanilla.ListarPlanilla(sidtregimenlaboral);

            DataTable oDataMeta = new DataTable();
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            oDataMeta = miMeta.ListarMetas();
            DataTable oDataFuenteFinanciamiento = new DataTable();
            CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamietno = new CapaDeNegocios.cFuenteFinanciamiento();
            oDataFuenteFinanciamiento = miFuenteFinanciamietno.ListarFuenteFinanciamiento();

            foreach (DataRow row in oDataPlanilla.Rows)
            {
                foreach (DataRow roww in oDataMeta.Select("idtmeta ='" + row[5].ToString() + "'"))
                {
                    sidtmeta = Convert.ToInt32(roww[0]);
                    smeta = roww[2].ToString();
                }
                foreach (DataRow roww in oDataFuenteFinanciamiento.Select("idtfuentefinanciamiento ='" + row[6].ToString() + "'"))
                {
                    sidtfuentefinanciamiento = Convert.ToInt32(roww[0]);
                    sfuentefinanciamiento = roww[2].ToString();
                }
                dgvPlanilla.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento);
                
            }
            if (dgvPlanilla.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvPlanilla.Rows.Count - 1);
                dgvPlanilla.Rows[dgvPlanilla.Rows.Count - 1].Selected = true;
                dgvPlanilla_CellClick(dgvPlanilla, cea);
            }
        }
    }
}
