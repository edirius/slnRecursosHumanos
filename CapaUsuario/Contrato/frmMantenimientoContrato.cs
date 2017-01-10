using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace CapaUsuario.Contrato
{
    public partial class frmMantenimientoContrato : Form
    {
        int sidttrabajador = 0;
        CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();

        public frmMantenimientoContrato()
        {
            InitializeComponent();
        }

        private void frmListaContratos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (dgvContratos.Rows.Count > 0)
            {
                //sfechainicio = Convert.ToString(dgvRegimenTrabajador.Rows[dgvRegimenTrabajador.Rows.Count - 1].Cells[7].Value);
                //sfechafin = Convert.ToString(dgvRegimenTrabajador.Rows[dgvRegimenTrabajador.Rows.Count - 1].Cells[8].Value);
                //if (sfechafin == "")
                //{
                //    MessageBox.Show("El ultimen regimen de trabajador debe tener una fecha final, no se puede agregar uno nuevo", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //if (sfechafin == sfechafinperiodo)
                //{
                //    MessageBox.Show("No quedan dias libres en el periodo, no se puede agregar uno nuevo", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }
            CapaUsuario.Contrato.frmContrato fContrato = new frmContrato();
            //fContratos.RecibirDatos(0, "", false, "", "", "", 0, "", "", "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", sidtperiodotrabajador, 1, sfechainicioperiodo, sfechafinperiodo);
            if (fContrato.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //if (sidtregimentrabajador == 0)
            //{
            //    MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //CapaUsuario.Trabajador.frmRegimenTrabajador fRegimenTrabajador = new frmRegimenTrabajador();
            //fRegimenTrabajador.RecibirDatos(sidtregimentrabajador, scondicion, sservidorconfianza, snumerodocumento, speriodicidad, stipopago, smontopago, sfechainicio, sfechafin, sruc, sidtregimenlaboral, sregimenlaboral, sidttipotrabajador, stipotrabajador, sidttipocontrato, stipocontrato, sidtcategoriaocupacional, scategoriaocupacional, sidtocupacion, socupacion, sidtcargo, scargo, sidtmeta, smeta, sidtperiodotrabajador, 2, sfechainicioperiodo, sfechafinperiodo);
            //if (fRegimenTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    CargarDatos();
            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        public void RecibirDatos(int pidttrabajador, string ptrabajador)
        {
            sidttrabajador = pidttrabajador;
            txtTrabajador.Text = ptrabajador;
        }

        public void CargarDatos()
        {
            DataTable oDataPeriodoTrabajador = new DataTable();
            DataTable oDataMotivoFinPeriodo = new DataTable();

            //dgvPeriodoTrabajador.Rows.Clear();
            //oDataPeriodoTrabajador = miPeriodoTrabajador.ListarPeriodoTrabajador(sidttrabajador);

            //CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo miMotivoFinPeriodo = new CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo();
            //oDataMotivoFinPeriodo = miMotivoFinPeriodo.ListaMotivosFinPeriodos();

            //foreach (DataRow row in oDataPeriodoTrabajador.Rows)
            //{
            //    string xxxx = row[3].ToString();
            //    foreach (DataRow row1 in oDataMotivoFinPeriodo.Select("idtmotivofinperiodo ='" + row[3].ToString() + "'"))
            //    {
            //        dgvPeriodoTrabajador.Rows.Add("", row[0].ToString(), row[1].ToString(), row[2].ToString(), row1[0].ToString(), row1[2].ToString());
            //    }
            //}
            //if (dgvPeriodoTrabajador.Rows.Count > 0)
            //{
            //    dgvPeriodoTrabajador.Rows[dgvPeriodoTrabajador.Rows.Count - 1].Cells[2].Selected = true;
            //    DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvPeriodoTrabajador.Rows.Count - 1);
            //    dgvPeriodoTrabajador_CellClick(dgvPeriodoTrabajador, cea);
            //}
        }

        private void dgvContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    sidtperiodotrabajador = Convert.ToInt32(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[1].Value);
            //    sfechainicio = Convert.ToString(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[2].Value);
            //    sfechafin = Convert.ToString(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[3].Value);
            //    sidtmotivofinperiodo = Convert.ToInt32(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[4].Value);
            //    smotivofinperiodo = Convert.ToString(dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[5].Value);
            //    if (dgvPeriodoTrabajador.Rows[e.RowIndex].Cells[0].Selected == true)
            //    {
            //        if (sidtperiodotrabajador == 0)
            //        {
            //            MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //        if (MessageBox.Show("Está seguro que desea eliminar el Periodo del Trabajador", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            //        {
            //            return;
            //        }
            //        miPeriodoTrabajador.EliminarPeriodoTrabajador(sidtperiodotrabajador);
            //        CargarDatos();
            //    }
            //}
        }
    }
}
