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
    public partial class frmRegimenPensionarioTrabajador : Form
    {
        int iAccion = 0;
        int sidtperiodotrabajador = 0;
        int sidtregimenpensionariotrabajador = 0;
        int sidtafp = 0;
        string safp = "";

        public frmRegimenPensionarioTrabajador()
        {
            InitializeComponent();
        }

        private void frmRegimenPensionarioTrabajador_Load(object sender, EventArgs e)
        {
            CargarAFP();
            cboFinPeriodo_SelectedIndexChanged(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
            miRegimenPensionarioTrabajador.IdtRegimenPensionarioTrabajador = sidtregimenpensionariotrabajador;
            miRegimenPensionarioTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            if (dtpFechaFin.Format == DateTimePickerFormat.Custom) { miRegimenPensionarioTrabajador.FechaFin = ""; }
            else { miRegimenPensionarioTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString(); }
            miRegimenPensionarioTrabajador.CUSPP = txtCUSPP.Text;
            miRegimenPensionarioTrabajador.IdtAFP = sidtafp;
            miRegimenPensionarioTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;

            if (iAccion == 1)
            {
                miRegimenPensionarioTrabajador.CrearRegimenPensionarioTrabajador(miRegimenPensionarioTrabajador);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miRegimenPensionarioTrabajador.ModificarRegimenPensionarioTrabajador(miRegimenPensionarioTrabajador);
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

        private void cboFinPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAFP.Text != "System.Data.DataRowView" && cboAFP.ValueMember != "")
            {
                sidtafp = Convert.ToInt32(cboAFP.SelectedValue);
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value.AddDays(1);
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = " ";
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.Format = DateTimePickerFormat.Long;
        }

        public void RecibirDatos(int pidtregimenpensionariotrabajador, string pfechainicio, string pfechafin, string pcuspp, int pidtafp, string pafp, int pidtperiodotrabajador, int pAccion)
        {
            sidtregimenpensionariotrabajador = pidtregimenpensionariotrabajador;
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
            txtCUSPP.Text = pcuspp;
            sidtafp = pidtafp;
            safp = pafp;
            sidtperiodotrabajador = pidtperiodotrabajador;
            iAccion = pAccion;
        }

        private void CargarAFP()
        {
            CapaDeNegocios.cListaAFP miAFP = new CapaDeNegocios.cListaAFP();
            cboAFP.DataSource = miAFP.ObtenerListaAFP();
            cboAFP.DisplayMember = "nombre";
            cboAFP.ValueMember = "idtafp";
            cboAFP.Text = safp;
        }
    }
}
