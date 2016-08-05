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
            cboTipo.SelectedIndex = 0;
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
            miMaestroIngresos.EliminarMaestroIngresos(sidtmaestroingresos);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.Text != "System.Data.DataRowView" && cboTipo.Text != "")
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
            sidtmaestroingresos = Convert.ToInt32(dgvMaestroIngresos.Rows[e.RowIndex].Cells[0].Value);
            scodigo = Convert.ToString(dgvMaestroIngresos.Rows[e.RowIndex].Cells[1].Value);
            sdescripcion = Convert.ToString(dgvMaestroIngresos.Rows[e.RowIndex].Cells[2].Value);
            sessalud_trabajador = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[3].Value);
            sessalud_cbssp = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[4].Value);
            sessalud_agrario = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[5].Value);
            sessalud_sctr = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[6].Value);
            simpuesto_extraord = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[7].Value);
            sderechos_sociales = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[8].Value);
            ssenati = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[9].Value);
            ssnp = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[10].Value);
            sspp = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[11].Value);
            srenta_5ta = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[12].Value);
            sessalud_pensionista = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[13].Value);
            scontrib_solidaria = Convert.ToBoolean(dgvMaestroIngresos.Rows[e.RowIndex].Cells[14].Value);
            scalculo = Convert.ToString(dgvMaestroIngresos.Rows[e.RowIndex].Cells[15].Value);
        }

        private void CargarDatos()
        {
            dgvMaestroIngresos.Rows.Clear();
            foreach (DataRow row in miMaestroIngresos.ListarMaestroIngresos(stipo).Rows)
            {
                dgvMaestroIngresos.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), Convert.ToBoolean(row[3]), Convert.ToBoolean(row[4]), Convert.ToBoolean(row[5]), Convert.ToBoolean(row[6]), Convert.ToBoolean(row[7]), Convert.ToBoolean(row[8]), Convert.ToBoolean(row[9]), Convert.ToBoolean(row[10]), Convert.ToBoolean(row[11]), Convert.ToBoolean(row[12]), Convert.ToBoolean(row[13]), Convert.ToBoolean(row[14]), row[15].ToString());
            }
            if (dgvMaestroIngresos.Rows.Count > 0)
            {
                dgvMaestroIngresos.Rows[0].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                dgvMaestroIngresos_CellClick(dgvMaestroIngresos, cea);
            }
        }
    }
}
