﻿using System;
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
        int sidtregimenlaboral = 0;
        int sidttipotrabajador = 0;
        int sidttipocontrato = 0;
        int sidtcategoriaocupacional = 0;
        int sidtocupacion = 0;
        int sidtcargo = 0;
        int sidtmeta = 0;
        int sidtperiodotrabajador = 0;
        string sregimenlaboral = "";
        string stipotrabajador = "";
        string stipocontrato = "";
        string scategoriaocupacional = "";
        string socupacion = "";
        string scargo = "";
        string smeta = "";

        public frmRegimenTrabajador()
        {
            InitializeComponent();
        }

        private void frmRegimenTrabajador_Load(object sender, EventArgs e)
        {
            CargarRegimenLaboral();
            CargarTipoTrabajador();
            CargarTipoContrato();
            CargarCategoriaOcupacional();
            CargarOcupacion();
            CargarCargo();
            CargarMeta();
            cboRegimenLaboral_SelectedIndexChanged(sender, e);
            cboTipoTrabajador_SelectedIndexChanged(sender, e);
            cboTipoContrato_SelectedIndexChanged(sender, e);
            cboCategoriaOcupacional_SelectedIndexChanged(sender, e);
            cboOcupacion_SelectedIndexChanged(sender, e);
            cboCargo_SelectedIndexChanged(sender, e);
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            miRegimenTrabajador.IdtRegimenTrabajador = sidtregimentrabajador;
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
            miRegimenTrabajador.IdtRegimenLaboral = sidtregimenlaboral;
            miRegimenTrabajador.IdtTipoTrabajador = sidttipotrabajador;
            miRegimenTrabajador.IdtTipoContrato = sidttipocontrato;
            miRegimenTrabajador.IdtCategoriaOcupacional = sidtcategoriaocupacional;
            miRegimenTrabajador.IdtOcupacion = sidtocupacion;
            miRegimenTrabajador.IdtCargo = sidtcargo;
            miRegimenTrabajador.IdtMeta = sidtmeta;
            miRegimenTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;

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

        private void cboRegimenLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegimenLaboral.Text != "System.Data.DataRowView" && cboRegimenLaboral.ValueMember != "")
            {
                sidtregimenlaboral = Convert.ToInt32(cboRegimenLaboral.SelectedValue);
            }
        }

        private void cboTipoTrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoTrabajador.Text != "System.Data.DataRowView" && cboTipoTrabajador.ValueMember != "")
            {
                sidttipotrabajador = Convert.ToInt32(cboTipoTrabajador.SelectedValue);
            }
        }

        private void cboTipoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoContrato.Text != "System.Data.DataRowView" && cboTipoContrato.ValueMember != "")
            {
                sidttipocontrato = Convert.ToInt32(cboTipoContrato.SelectedValue);
            }
        }

        private void cboCategoriaOcupacional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoriaOcupacional.Text != "System.Data.DataRowView" && cboCategoriaOcupacional.ValueMember != "")
            {
                sidtcategoriaocupacional = Convert.ToInt32(cboCategoriaOcupacional.SelectedValue);
            }
        }

        private void cboOcupacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOcupacion.Text != "System.Data.DataRowView" && cboOcupacion.ValueMember != "")
            {
                sidtocupacion = Convert.ToInt32(cboOcupacion.SelectedValue);
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

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = " ";
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.Format = DateTimePickerFormat.Long;
        }

        public void RecibirDatos(int pidtregimentrabajador, string pcondicion, bool pservidorconfianza, string pnumerodocumento, string pperiodicidad, string ptipopago, int pmontopago, string pfechainicio, string pfechafin, string pruc, int pidtregimenlaboral, string pregimenlaboral, int pidttipotrabajador, string ptipotrabajador, int pidttipocontrato, string ptipocontrato, int pidtcategoriaocupacional, string pcategoriaocupacional, int pidtocupacion, string pocupacion, int pidtcargo, string pcargo, int pidtmeta, string pmeta, int pidtperiodotrabajador, int pAccion)
        {
            sidtregimentrabajador = pidtregimentrabajador;
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
            sidtregimenlaboral = pidtregimenlaboral;
            sregimenlaboral = pregimenlaboral;
            sidttipotrabajador = pidttipotrabajador;
            stipotrabajador = ptipotrabajador;
            sidttipocontrato = pidttipocontrato;
            stipocontrato = ptipocontrato;
            sidtcategoriaocupacional = pidtcategoriaocupacional;
            scategoriaocupacional = pcategoriaocupacional;
            sidtocupacion = pidtocupacion;
            socupacion = pocupacion;
            sidtcargo = pidtcargo;
            scargo = pcargo;
            sidtmeta = pidtmeta;
            smeta = pmeta;
            sidtperiodotrabajador = pidtperiodotrabajador;
            iAccion = pAccion;
        }

        private void CargarRegimenLaboral()
        {
            CapaDeNegocios.DatosLaborales.cRegimenLaboral miRegimenLaboral = new CapaDeNegocios.DatosLaborales.cRegimenLaboral();
            cboRegimenLaboral.DataSource = miRegimenLaboral.ListarRegimenLaboral();
            cboRegimenLaboral.DisplayMember = "descripcion";
            cboRegimenLaboral.ValueMember = "idtregimenlaboral";
            cboRegimenLaboral.Text = sregimenlaboral;
        }

        private void CargarTipoTrabajador()
        {
            CapaDeNegocios.cTipoTrabajador miTipoTrabajador = new CapaDeNegocios.cTipoTrabajador();
            cboTipoTrabajador.DataSource = miTipoTrabajador.ListarTiposDeTrabajadores();
            cboTipoTrabajador.DisplayMember = "descripcion";
            cboTipoTrabajador.ValueMember = "idtsunattipotrabajador";
            cboTipoTrabajador.Text = stipotrabajador;
        }

        private void CargarTipoContrato()
        {
            CapaDeNegocios.Contrato.cTipoContrato miTipoContrato = new CapaDeNegocios.Contrato.cTipoContrato();
            cboTipoContrato.DataSource = miTipoContrato.ListaTipoContratos();
            cboTipoContrato.DisplayMember = "descripcion";
            cboTipoContrato.ValueMember = "idttipocontrato";
            cboTipoContrato.Text = stipocontrato;
        }

        private void CargarCategoriaOcupacional()
        {
            CapaDeNegocios.DatosLaborales.cCategoriaOcupacional miCategoriaOcupacional = new CapaDeNegocios.DatosLaborales.cCategoriaOcupacional();
            cboCategoriaOcupacional.DataSource = miCategoriaOcupacional.ListarCategoriaOcupacional();
            cboCategoriaOcupacional.DisplayMember = "descripcion";
            cboCategoriaOcupacional.ValueMember = "idtcategoriaocupacional";
            cboCategoriaOcupacional.Text = scategoriaocupacional;
        }

        private void CargarOcupacion()
        {
            CapaDeNegocios.DatosLaborales.cOcupacion miOcupacion = new CapaDeNegocios.DatosLaborales.cOcupacion();
            cboOcupacion.DataSource = miOcupacion.ListarOcupacion();
            cboOcupacion.DisplayMember = "descripcion";
            cboOcupacion.ValueMember = "idtocupacion";
            cboOcupacion.Text = socupacion;
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