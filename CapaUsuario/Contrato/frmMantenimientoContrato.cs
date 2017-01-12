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
        int sidtcontrato = 0;
        DateTime sfecharegistro;
        string snumerodocumento = "";
        DateTime sfechainicio;
        DateTime sfechafin;
        decimal smontopago = 0;
        string sruc = "";
        int sidtplantillacontrato = 0;
        int sidtcargo = 0;
        int sidtmeta = 0;
        int sidttrabajador = 0;

        CapaDeNegocios.Contrato.cContrato miContrato = new CapaDeNegocios.Contrato.cContrato();
        CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
        string srutaarchivo = "";
        string scargo = "";
        string smeta = "";

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
            //if (dgvContratos.Rows.Count > 0)
            //{
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
            //}
            CapaUsuario.Contrato.frmContrato fContrato = new frmContrato();
            fContrato.RecibirDatos(0, DateTime.Now, "", DateTime.Now, DateTime.Now, 0, "", 0, 0, 0, sidttrabajador, 1);
            if (fContrato.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtcontrato == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Contrato.frmContrato fContrato = new frmContrato();
            fContrato.RecibirDatos(sidtcontrato, sfecharegistro, snumerodocumento, sfechainicio, sfechafin, smontopago, sruc, sidtplantillacontrato, sidtcargo, sidtmeta, sidttrabajador, 2);
            if (fContrato.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Contrato.cDocumentoWord cMiword = new CapaDeNegocios.Contrato.cDocumentoWord();
                miTrabajador.traerTrabajador(sidttrabajador);
                CargarPlanillaContrato();
                cMiword.trabajador = txtTrabajador.Text;
                cMiword.dni = miTrabajador.Dni;
                cMiword.direccion = miTrabajador.Direccion;
                cMiword.distrito = miTrabajador.MiDistrito.Descripcion;
                cMiword.provincia = miTrabajador.MiProvincia.Descripcion;
                cMiword.departamento = miTrabajador.MiDepartamento.Descripcion;
                cMiword.monto = smontopago.ToString();
                cMiword.fecharegistro = sfecharegistro.ToString();
                cMiword.fechainicio = sfechainicio.ToString();
                cMiword.fechafin = sfechafin.ToString();
                cMiword.cargo = scargo;
                cMiword.meta = smeta;
                cMiword.rutaarchivo = srutaarchivo;
                cMiword.Iniciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidtcontrato = Convert.ToInt32(dgvContratos.Rows[e.RowIndex].Cells[0].Value);
                sfecharegistro = Convert.ToDateTime(dgvContratos.Rows[e.RowIndex].Cells[1].Value);
                snumerodocumento = Convert.ToString(dgvContratos.Rows[e.RowIndex].Cells[2].Value);
                sfechainicio = Convert.ToDateTime(dgvContratos.Rows[e.RowIndex].Cells[3].Value);
                sfechafin = Convert.ToDateTime(dgvContratos.Rows[e.RowIndex].Cells[4].Value);
                smontopago = Convert.ToDecimal(dgvContratos.Rows[e.RowIndex].Cells[5].Value);
                sruc = Convert.ToString(dgvContratos.Rows[e.RowIndex].Cells[6].Value);
                sidtplantillacontrato = Convert.ToInt32(dgvContratos.Rows[e.RowIndex].Cells[7].Value);
                sidtcargo = Convert.ToInt32(dgvContratos.Rows[e.RowIndex].Cells[8].Value);
                sidtmeta = Convert.ToInt32(dgvContratos.Rows[e.RowIndex].Cells[9].Value);
                sidttrabajador = Convert.ToInt32(dgvContratos.Rows[e.RowIndex].Cells[10].Value);
            }
        }

        public void RecibirDatos(int pidttrabajador, string ptrabajador)
        {
            sidttrabajador = pidttrabajador;
            txtTrabajador.Text = ptrabajador;
        }

        public void CargarDatos()
        {
            //dgvContratos.Rows.Clear();
            dgvContratos.DataSource = miContrato.ListarContrato(sidttrabajador);
            dgvContratos.Columns[0].Visible = false;
            dgvContratos.Columns[1].Visible = false;
            dgvContratos.Columns[6].Visible = false;
            dgvContratos.Columns[7].Visible = false;
            dgvContratos.Columns[8].Visible = false;
            dgvContratos.Columns[9].Visible = false;
            dgvContratos.Columns[10].Visible = false;
            if (dgvContratos.Rows.Count > 0)
            {
                dgvContratos.Rows[dgvContratos.Rows.Count - 1].Cells[3].Selected = true;
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, dgvContratos.Rows.Count - 1);
                dgvContratos_CellClick(dgvContratos, cea);
            }
        }

        private void CargarPlanillaContrato()
        {
            DataTable oDataPlantillaContrato = new DataTable();
            CapaDeNegocios.Contrato.cPlantillaContrato miPlantillaContrato = new CapaDeNegocios.Contrato.cPlantillaContrato();
            oDataPlantillaContrato = miPlantillaContrato.ListarPlantillaContrato();
            foreach (DataRow row in oDataPlantillaContrato.Select("idtplantillacontrato = '" + sidtplantillacontrato + "'"))
            {
                srutaarchivo = row[2].ToString();
            }
        }

        private void CargarCargo()
        {
            DataTable oDataCargo = new DataTable();
            CapaDeNegocios.Contrato.cCargo miCargo = new CapaDeNegocios.Contrato.cCargo();
            oDataCargo = miCargo.ListaCargos();
            foreach (DataRow row in oDataCargo.Select("idtcargo = '" + sidtcargo + "'"))
            {
                scargo = row[1].ToString();
            }
        }

        private void CargarMeta()
        {
            DataTable oDataMeta = new DataTable();
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            oDataMeta = miMeta.ListarMetas();
            foreach (DataRow row in oDataMeta.Select("idtmeta = '" + sidtmeta + "'"))
            {
                smeta = row[2].ToString();
            }
        }
    }
}
