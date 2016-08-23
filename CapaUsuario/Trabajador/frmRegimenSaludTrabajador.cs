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
    public partial class frmRegimenSaludTrabajador : Form
    {
        int iAccion = 0;
        int sidtperiodotrabajador = 0;
        int sidtregimensaludtrabajador = 0;

        public frmRegimenSaludTrabajador()
        {
            InitializeComponent();
        }

        private void frmRegimenSaludTrabajador_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
            miRegimenSaludTrabajador.IdtRegimenSaludTrabajador = sidtregimensaludtrabajador;
            miRegimenSaludTrabajador.RegimenSalud = cboRegimenSalud.Text;
            miRegimenSaludTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            if (dtpFechaFin.Format == DateTimePickerFormat.Custom) { miRegimenSaludTrabajador.FechaFin = ""; }
            else { miRegimenSaludTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString(); }
            miRegimenSaludTrabajador.EntidadPrestadoraSalud = cboEntidadPrestadoraSalud.Text;
            miRegimenSaludTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;

            if (iAccion == 1)
            {
                miRegimenSaludTrabajador.CrearRegimenSaludTrabajador(miRegimenSaludTrabajador);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miRegimenSaludTrabajador.ModificarRegimenSaludTrabajador(miRegimenSaludTrabajador);
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

        private void cboRegimenSalud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegimenSalud.Text == "ESSALUD REGULAR Y EPS/SERV. PROPIOS")
            {
                label4.Visible = true;
                cboEntidadPrestadoraSalud.Visible = true;
            }
            else
            {
                label4.Visible = false;
                cboEntidadPrestadoraSalud.Visible = false;
            }
                cboEntidadPrestadoraSalud.SelectedIndex = -1;
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

        public void RecibirDatos(int pidtregimensaludtrabajador, string pregimensalud, string pfechainicio, string pfechafin, string pentidadprestadorasalud, int pidtperiodotrabajador, int pAccion, string pfechainicioperiodo, string pfechafinperiodo)
        {
            sidtregimensaludtrabajador = pidtregimensaludtrabajador;
            cboRegimenSalud.Text = pregimensalud;
            if (pfechainicio == "")
            {
                dtpFechaInicio.MinDate = Convert.ToDateTime(pfechainicioperiodo);
                dtpFechaInicio.MaxDate = Convert.ToDateTime(pfechainicioperiodo);
                dtpFechaInicio.Value = Convert.ToDateTime(pfechainicioperiodo);
            }
            else
            {
                if (pAccion == 1)
                {
                    dtpFechaInicio.MinDate = Convert.ToDateTime(pfechafin).AddDays(1);
                    dtpFechaInicio.MaxDate = Convert.ToDateTime(pfechafin).AddDays(1);
                    dtpFechaInicio.Value = Convert.ToDateTime(pfechafin).AddDays(1);
                }
                else
                {
                    dtpFechaInicio.MinDate = Convert.ToDateTime(pfechainicio);
                    //dtpFechaInicio.MaxDate = Convert.ToDateTime(pfechainicio);
                    dtpFechaInicio.Value = Convert.ToDateTime(pfechainicio);
                }
            }
            if (pfechafin == "")
            {
                dtpFechaFin.MinDate = Convert.ToDateTime(pfechainicioperiodo).AddDays(1);
                if (pfechafinperiodo != "") { dtpFechaFin.MaxDate = Convert.ToDateTime(pfechafinperiodo); }
                dtpFechaFin.Value = Convert.ToDateTime(pfechainicioperiodo).AddDays(1);
                dtpFechaFin.Format = DateTimePickerFormat.Custom;
                dtpFechaFin.CustomFormat = " ";
            }
            else
            {
                if (pAccion == 1)
                {
                    dtpFechaFin.MinDate = Convert.ToDateTime(pfechafin).AddDays(1);
                    if (pfechafinperiodo != "") { dtpFechaFin.MaxDate = Convert.ToDateTime(pfechafinperiodo); }
                    dtpFechaFin.Format = DateTimePickerFormat.Custom;
                    dtpFechaFin.CustomFormat = " ";
                }
                else
                {
                    dtpFechaFin.MinDate = Convert.ToDateTime(pfechainicio).AddDays(1);
                    if (pfechafinperiodo != "") { dtpFechaFin.MaxDate = Convert.ToDateTime(pfechafinperiodo); }
                    dtpFechaFin.Value = Convert.ToDateTime(pfechafin);
                }
            }
            cboEntidadPrestadoraSalud.Text = pentidadprestadorasalud;
            sidtperiodotrabajador = pidtperiodotrabajador;
            iAccion = pAccion;
        }
    }
}
