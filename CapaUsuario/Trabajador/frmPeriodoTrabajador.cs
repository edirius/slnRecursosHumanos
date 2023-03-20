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
    public partial class frmPeriodoTrabajador : Form
    {
        int iAccion = 0;
        int sidtperiodotrabajador = 0;
        int sidtmotivofinperiodo = 0;
        int sidttrabajador = 0;
        string smotivofinperiodo = "";

        public frmPeriodoTrabajador()
        {
            InitializeComponent();
        }

        private void frmPeriodoTrabajador_Load(object sender, EventArgs e)
        {
            CargarMotivoFinPeriodo();
            cboFinPeriodo_SelectedIndexChanged(sender, e);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            miPeriodoTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
            miPeriodoTrabajador.FechaInicio = dtpFechaInicio.Value.ToShortDateString();
            if (dtpFechaFin.Format == DateTimePickerFormat.Custom)
            {
                miPeriodoTrabajador.FechaFin = "";
            }
            else
            {
                miPeriodoTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString();
            }
            miPeriodoTrabajador.IdtMotivoFinPeriodo = sidtmotivofinperiodo;
            miPeriodoTrabajador.IdtTrabajador = sidttrabajador;

            if (iAccion == 1)
            {
                miPeriodoTrabajador.CrearPeriodoTrabajador(miPeriodoTrabajador);
                bOk = true;
            }
            if (iAccion == 2)
            {
                if (MessageBox.Show("Desea dar de baja ESSALUD - AFP/SNP.", "Gestión del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Regimen Trabajador
                    CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                    miRegimenTrabajador.BajaRegimenTrabajador(miPeriodoTrabajador.FechaFin, miPeriodoTrabajador.IdtPeriodoTrabajador);

                    //Regimen Salud Trabajador
                    CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
                    miRegimenSaludTrabajador.BajaRegimenSaludTrabajador(miPeriodoTrabajador.FechaFin, miPeriodoTrabajador.IdtPeriodoTrabajador);

                    //Regimen Trabajador
                    CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                    miRegimenPensionarioTrabajador.BajaRegimenPensionarioTrabajador(miPeriodoTrabajador.FechaFin, miPeriodoTrabajador.IdtPeriodoTrabajador);
                }
                miPeriodoTrabajador.ModificarPeriodoTrabajador(miPeriodoTrabajador);
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

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value.AddDays(1);
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = " ";
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            CapaDeNegocios.Planillas.cDetallePlanilla oDetalle = new CapaDeNegocios.Planillas.cDetallePlanilla();
            string sfechafin = dtpFechaFin.Value.ToShortDateString();

            DataTable auxiliar = oDetalle.EncontrarDetallesPosteriorFecha(dtpFechaFin.Value, sidttrabajador);

            if (auxiliar.Rows.Count > 0)
            {
                string mensaje = "";
                if (auxiliar.Rows.Count > 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        mensaje = mensaje + auxiliar.Rows[i][1].ToString() + " " + auxiliar.Rows[i][13].ToString() + " " + auxiliar.Rows[i][14].ToString() + Environment.NewLine;
                    }

                    mensaje = mensaje + "." + Environment.NewLine;
                    mensaje = mensaje + "." + Environment.NewLine;
                    mensaje = mensaje + "." + Environment.NewLine;
                }
                else
                {
                    for (int i = 0; i < auxiliar.Rows.Count; i++)
                    {
                        mensaje = mensaje + auxiliar.Rows[i][1].ToString() + " " + auxiliar.Rows[i][13].ToString() + " " + auxiliar.Rows[i][14].ToString() + Environment.NewLine;
                    }
                }

                MessageBox.Show("Error al dar de baja al trabajador con la fecha: " + sfechafin + ". Se encontró planillas posteriores al mes que quiere dar de baja:  " + Environment.NewLine + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaFin.Format = DateTimePickerFormat.Custom;
                dtpFechaFin.CustomFormat = " ";
                cboFinPeriodo.Text = "";
                return;
            }

            dtpFechaFin.Format = DateTimePickerFormat.Long;
        }

        private void cboFinPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFinPeriodo.Text != "System.Data.DataRowView" && cboFinPeriodo.ValueMember != "")
            {
                sidtmotivofinperiodo = Convert.ToInt32(cboFinPeriodo.SelectedValue);
            }
        }

        public void RecibirDatos(int pidtperiodotrabajador, string pfechainicio, string pfechafin, int pidtmotivofinperiodo, string pmotivofinperiodo, int pidttrabajador, string ptrabajado, int pAccion)
        {
            sidtperiodotrabajador = pidtperiodotrabajador;
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
            sidtmotivofinperiodo = pidtmotivofinperiodo;
            smotivofinperiodo = pmotivofinperiodo;
            sidttrabajador = pidttrabajador;
            txtTrabajador.Text = ptrabajado;
            iAccion = pAccion;
        }

        private void CargarMotivoFinPeriodo()
        {
            CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo miMotivoFinPeriodo = new CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo();
            cboFinPeriodo.DataSource = miMotivoFinPeriodo.ListaMotivosFinPeriodos();
            cboFinPeriodo.DisplayMember = "descripcion";
            cboFinPeriodo.ValueMember = "idtmotivofinperiodo";
            cboFinPeriodo.Text = smotivofinperiodo;
        }

        private void btnFechaFin_Click(object sender, EventArgs e)
        {
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = " ";
            cboFinPeriodo.Text = "";
        }
    }
}
