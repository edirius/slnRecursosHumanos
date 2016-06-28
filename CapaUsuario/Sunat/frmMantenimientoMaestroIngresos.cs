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
    public partial class frmMantenimientoMaestroIngresos : Form
    {
        int sidtmaestroingresos = 0;
        string scodigo = "";
        string sdescripcion = "";
        bool sessalud_trabajador = false;
        bool sessalud_cbssp = false;
        bool sessalud_agrario = false;
        bool sessalud_sctr = false;
        bool simpuesto_extraord = false;
        bool sderechos_sociales = false;
        bool ssenati = false;
        bool ssnp = false;
        bool sspp = false;
        bool srenta_5ta = false;
        bool sessalud_pensionista = false;
        bool scontrib_solidaria = false;
        string scalculo = "";
        string stipo = "";

        CapaDeNegocios.Sunat.cMaestroIngresos miMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();

        public frmMantenimientoMaestroIngresos()
        {
            InitializeComponent();
        }

        private void frmMantenimientoMaestroIngresos_Load(object sender, EventArgs e)
        {
            cboTipo_SelectedIndexChanged(sender, e);
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Sunat.frmMaestroIngresos fMaestroIngresos = new CapaUsuario.Sunat.frmMaestroIngresos();
            fMaestroIngresos.RecibirDatos(0, "", "", false, false, false, false, false, false, false, false, false, false, false, false, "", stipo, 1);
            if (fMaestroIngresos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtmaestroingresos == 0 && dgvMaestroIngresos.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Sunat.frmMaestroIngresos fMaestroIngresos = new CapaUsuario.Sunat.frmMaestroIngresos();
            fMaestroIngresos.RecibirDatos(sidtmaestroingresos, scodigo, sdescripcion, sessalud_trabajador, sessalud_cbssp, sessalud_agrario, sessalud_sctr, simpuesto_extraord, sderechos_sociales, ssenati, ssnp, sspp, srenta_5ta, sessalud_pensionista, scontrib_solidaria, scalculo, stipo, 2);
            if (fMaestroIngresos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtmaestroingresos == 0 && dgvMaestroIngresos.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar el Maestro Ingresos", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miMaestroIngresos.IdtMaestroIngresos = sidtmaestroingresos;
            miMaestroIngresos.EliminarMaestroIngresos(miMaestroIngresos);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.Text != "System.Data.DataRowView")
            {
                stipo = cboTipo.Text;
                CargarDatos();
            }
        }

        private void dgvMaestroIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMaestroIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iFila = this.dgvMaestroIngresos.CurrentRow.Index;
            sidtmaestroingresos = Convert.ToInt32(dgvMaestroIngresos.Rows[iFila].Cells["idtmaestroingresos"].Value);
            scodigo = Convert.ToString(dgvMaestroIngresos.Rows[iFila].Cells["codigo"].Value);
            sdescripcion = Convert.ToString(dgvMaestroIngresos.Rows[iFila].Cells["descripcion"].Value);
            sessalud_trabajador = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["essalud_trabajador"].Value);
            sessalud_cbssp = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["essalud_cbssp"].Value);
            sessalud_agrario = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["essalud_agrario"].Value);
            sessalud_sctr = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["essalud_sctr"].Value);
            simpuesto_extraord = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["impuesto_extraord"].Value);
            sderechos_sociales = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["derechos_sociales"].Value);
            ssenati = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["senati"].Value);
            ssnp = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["snp"].Value);
            sspp = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["spp"].Value);
            srenta_5ta = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["renta_5ta"].Value);
            sessalud_pensionista = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["essalud_pensionista"].Value);
            scontrib_solidaria = Convert.ToBoolean(dgvMaestroIngresos.Rows[iFila].Cells["contrib_solidaria"].Value);
            scalculo = Convert.ToString(dgvMaestroIngresos.Rows[iFila].Cells["calculo"].Value);
        }

        private void CargarDatos()
        {
            miMaestroIngresos.Tipo = stipo;
            dgvMaestroIngresos.DataSource = miMaestroIngresos.ListarMaestroIngresos(miMaestroIngresos);
            dgvMaestroIngresos.Columns[0].Visible = false;
            dgvMaestroIngresos.Columns[15].Visible = false;
            dgvMaestroIngresos.Columns[16].Visible = false;
        }
    }
}
