using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Trabajador
{
    public partial class frmMantenimientoRegimenTrabajador : Form
    {
        DataTable oDataPeriodoTrabajador = new DataTable();
        int sidtregimentrabajador = 0;
        string stipo = "";
        string scondicion = "";
        bool sservidorconfianza = false;
        string snumerodocumento = "";
        string speriodicidad = "";
        string stipopago = "";
        int smontopago = 0;
        string sfechainicio = "";
        string sfechafin = "";
        string sruc = "";
        int sidttipocontrato = 0;
        int sidtcargo = 0;
        int sidtmeta = 0;
        int sidttrabajador = 0;
        string stipocontrato = "";
        string scargo = "";
        string smeta = "";

        CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();

        public frmMantenimientoRegimenTrabajador()
        {
            InitializeComponent();
        }

        private void frmMantenimientoRegimenTrabajador_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //if (dgvRegimenTrabajador.Rows.Count > 0 && (Convert.ToString(dgvRegimenTrabajador.Rows[dgvRegimenTrabajador.Rows.Count - 1].Cells[2].Value) == "" || Convert.ToString(dgvRegimenTrabajador.Rows[dgvRegimenTrabajador.Rows.Count - 1].Cells[4].Value) == ""))
            //{
            //    MessageBox.Show("No se puede agregar un nuevo periodo, hasta que el ultimo perido tenga un Fecha Fin y un Motivo de Fin de Periodo", "Mensaje Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //if (dgvRegimenTrabajador.Rows.Count == 0)
            //{ sfechainicio = ""; }
            //else
            //{ sfechainicio = Convert.ToString(dgvRegimenTrabajador.Rows[dgvRegimenTrabajador.Rows.Count - 1].Cells[2].Value); }
            CapaUsuario.Trabajador.frmRegimenTrabajador fRegimenTrabajador = new frmRegimenTrabajador();
            fRegimenTrabajador.RecibirDatos(0, "", "", false, "", "", "", 0, "", "", "", 0, "", 0, "", 0, "", sidttrabajador, 1);
            if (fRegimenTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtregimentrabajador == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Trabajador.frmRegimenTrabajador fRegimenTrabajador = new frmRegimenTrabajador();
            fRegimenTrabajador.RecibirDatos(sidtregimentrabajador, stipo, scondicion, sservidorconfianza, snumerodocumento, speriodicidad, stipopago, smontopago, sfechainicio, sfechafin, sruc, sidttipocontrato, stipocontrato, sidtcargo, scargo, sidtmeta, smeta, sidttrabajador, 2);
            if (fRegimenTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtregimentrabajador == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar el Periodo del Trabajador", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miRegimenTrabajador.EliminarRegimenTrabajador(sidtregimentrabajador);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dgvRegimenTrabajador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRegimenTrabajador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sidtregimentrabajador = Convert.ToInt32(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[0].Value);
            stipo = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[1].Value);
            scondicion = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[2].Value);
            if (dgvRegimenTrabajador.Rows[e.RowIndex].Cells[3].Value.ToString() == "0")
            { sservidorconfianza = false; }
            else { sservidorconfianza = true; }
            snumerodocumento = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[4].Value);
            speriodicidad = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[5].Value);
            stipopago = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[6].Value);
            smontopago = Convert.ToInt32(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[7].Value);
            sfechainicio = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[8].Value);
            sfechafin = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[9].Value);
            sruc = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[10].Value);
            sidttipocontrato = Convert.ToInt32(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[11].Value);
            stipocontrato = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[12].Value);
            sidtcargo = Convert.ToInt32(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[13].Value);
            scargo = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[14].Value);
            sidtmeta = Convert.ToInt32(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[15].Value);
            smeta = Convert.ToString(dgvRegimenTrabajador.Rows[e.RowIndex].Cells[16].Value);
        }

        public void RecibirDatos(int pidttrabajador, string ptrabajador)
        {
            sidttrabajador = pidttrabajador;
            txtTrabajador.Text = ptrabajador;
        }

        public void CargarDatos()
        {
            dgvRegimenTrabajador.Rows.Clear();
            oDataPeriodoTrabajador = miRegimenTrabajador.ListarRegimenTrabajador(sidttrabajador);

            DataTable oDataTipoContrato = new DataTable();
            CapaDeNegocios.Contrato.cTipoContrato miTipoContrato = new CapaDeNegocios.Contrato.cTipoContrato();
            oDataTipoContrato = miTipoContrato.ListaTipoContratos();
            DataTable oDataCargo = new DataTable();
            CapaDeNegocios.Contrato.cCargo miCargo = new CapaDeNegocios.Contrato.cCargo();
            oDataCargo = miCargo.ListaCargos();
            DataTable oDataMeta= new DataTable();
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            oDataMeta = miMeta.ListarMetas();

            foreach (DataRow row in oDataPeriodoTrabajador.Rows)
            {
                foreach (DataRow roww in oDataTipoContrato.Select("idttipocontrato ='" + row[11].ToString() + "'"))
                {
                    sidttipocontrato = Convert.ToInt32(roww[0]);
                    stipocontrato = roww[1].ToString();
                }
                foreach (DataRow roww in oDataCargo.Select("idtcargo ='" + row[12].ToString() + "'"))
                {
                    sidtcargo = Convert.ToInt32(roww[0]);
                    scargo = roww[1].ToString();
                }
                foreach (DataRow roww in oDataMeta.Select("idtmeta ='" + row[13].ToString() + "'"))
                {
                    sidtmeta = Convert.ToInt32(roww[0]);
                    smeta = roww[2].ToString();
                }
                dgvRegimenTrabajador.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), sidttipocontrato, stipocontrato, sidtcargo, scargo, sidtmeta, smeta);
            }
            if (dgvRegimenTrabajador.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvRegimenTrabajador.Rows.Count - 1);
                dgvRegimenTrabajador.Rows[dgvRegimenTrabajador.Rows.Count - 1].Selected = true;
                dgvRegimenTrabajador_CellClick(dgvRegimenTrabajador, cea);
            }
        }
    }
}
