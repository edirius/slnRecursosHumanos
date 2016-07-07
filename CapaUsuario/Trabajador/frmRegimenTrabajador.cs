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
    public partial class frmRegimenTrabajador : Form
    {
        int iAccion = 0;
        int sidtregimentrabajador = 0;
        int sidttipocontrato = 0;
        int sidtcargo = 0;
        int sidtmeta = 0;
        int sidttrabajador = 0;
        string stipocontrato = "";
        string scargo = "";
        string smeta = "";

        public frmRegimenTrabajador()
        {
            InitializeComponent();
        }

        private void frmRegimenTrabajador_Load(object sender, EventArgs e)
        {
            CargarTipoContrato();
            CargarCargo();
            CargarMeta();
            cboTipoContrato_SelectedIndexChanged(sender, e);
            cboCargo_SelectedIndexChanged(sender, e);
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            miRegimenTrabajador.IdtRegimenTrabajador = sidtregimentrabajador;
            miRegimenTrabajador.Tipo = cboTipoRegimen.Text;
            miRegimenTrabajador.Condicion = cboCondicionLaboral.Text;
            miRegimenTrabajador.ServidorConfianza = chkServidorConfianza.Checked;
            miRegimenTrabajador.NumeroDocumento = txtNumero.Text;
            miRegimenTrabajador.Periodicidad = cboPeriodicidad.Text;
            miRegimenTrabajador.TipoPago = cboTipoPago.Text;
            miRegimenTrabajador.MontoPago = Convert.ToInt32(nupMontoPago.Value);
            miRegimenTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            if (dtpFechaFin.Format == DateTimePickerFormat.Custom) { miRegimenTrabajador.FechaFin = ""; }
            else { miRegimenTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString(); }
            miRegimenTrabajador.RUC = txtRUC.Text;
            miRegimenTrabajador.IdtTipoContrato = sidttipocontrato;
            miRegimenTrabajador.IdtCargo = sidtcargo;
            miRegimenTrabajador.IdtMeta = sidtmeta;
            miRegimenTrabajador.IdtTrabajador = sidttrabajador;

            if (iAccion == 1)
            {
                miRegimenTrabajador.CrearRegimenTrabajador(miRegimenTrabajador);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miRegimenTrabajador.ModificarRegimenTrabajador(miRegimenTrabajador);
                bOk = true;
            }
            if (bOk == true)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se puede registrar estos datos", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cboTipoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoContrato.Text != "System.Data.DataRowView" && cboTipoContrato.ValueMember != "")
            {
                sidttipocontrato = Convert.ToInt32(cboTipoContrato.SelectedValue);
            }
        }

        private void cboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCargo.Text != "System.Data.DataRowView" && cboCargo.ValueMember != "")
            {
                sidtcargo = Convert.ToInt32(cboCargo.SelectedValue);
            }
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "System.Data.DataRowView" && cboMeta.ValueMember != "")
            {
                sidtmeta = Convert.ToInt32(cboMeta.SelectedValue);
            }
        }

        public void RecibirDatos(int pidtregimentrabajador, string ptipo, string pcondicion, bool pservidorconfianza, string pnumerodocumento, string pperiodicidad, string ptipopago, int pmontopago, string pfechainicio, string pfechafin, string pruc, int pidttipocontrato, string ptipocontrato, int pidtcargo, string pcargo, int pidtmeta, string pmeta, int pidttrabajador, int pAccion)
        {
            sidtregimentrabajador = pidtregimentrabajador;
            cboTipoRegimen.Text = ptipo;
            cboCondicionLaboral.Text = pcondicion;
            chkServidorConfianza.Checked = pservidorconfianza;
            txtNumero.Text = pnumerodocumento;
            cboPeriodicidad.Text = pperiodicidad;
            cboTipoPago.Text = ptipopago;
            nupMontoPago.Value = pmontopago;
            if (pfechainicio == "") { dtpFechaInicio.Value = DateTime.Today; }
            else
            {
                if (pAccion == 1)
                {
                    dtpFechaInicio.MinDate = Convert.ToDateTime(pfechainicio).AddDays(1);
                    dtpFechaInicio.Value = DateTime.Today;
                }
                else { dtpFechaInicio.Value = Convert.ToDateTime(pfechainicio); }
            }
            if (pfechafin == "")
            {
                dtpFechaFin.Format = DateTimePickerFormat.Custom;
                dtpFechaFin.CustomFormat = " ";
            }
            else { dtpFechaFin.Value = Convert.ToDateTime(pfechafin); }
            txtRUC.Text = pruc;
            sidttipocontrato = pidttipocontrato;
            stipocontrato = ptipocontrato;
            sidtcargo = pidtcargo;
            scargo = pcargo;
            sidtmeta = pidtmeta;
            smeta = pmeta;
            sidttrabajador = pidttrabajador;
            iAccion = pAccion;
        }

        private void CargarTipoContrato()
        {
            CapaDeNegocios.Contrato.cTipoContrato miTipoContrato = new CapaDeNegocios.Contrato.cTipoContrato();
            cboTipoContrato.DataSource = miTipoContrato.ListaTipoContratos();
            cboTipoContrato.DisplayMember = "descripcion";
            cboTipoContrato.ValueMember = "idttipocontrato";
            cboTipoContrato.Text = stipocontrato;
        }

        private void CargarCargo()
        {
            CapaDeNegocios.Contrato.cCargo miCargo = new CapaDeNegocios.Contrato.cCargo();
            cboCargo.DataSource = miCargo.ListaCargos();
            cboCargo.DisplayMember = "descripcion";
            cboCargo.ValueMember = "idtcargo";
            cboCargo.Text = scargo;
        }

        private void CargarMeta()
        {
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            cboMeta.DataSource = miMeta.ListarMetas();
            cboMeta.DisplayMember = "nombre";
            cboMeta.ValueMember = "idtmeta";
            cboMeta.Text = smeta;
        }
    }
}
