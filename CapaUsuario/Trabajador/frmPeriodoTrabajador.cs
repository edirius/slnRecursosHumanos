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
        string smotivofinperiodo = "";
        int sidttrabajador = 0;

        public frmPeriodoTrabajador()
        {
            InitializeComponent();
        }

        private void frmPeriodoTrabajador_Load(object sender, EventArgs e)
        {
            CargarMotivoFinPeriodo();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo miMotivoFinPeriodo = new CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo();
            CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
            miPeriodoTrabajador.IdtPeriodoTrabajador = sidtperiodotrabajador;
            miPeriodoTrabajador.FechaInicio = dtpFechaInicio.Value;
            miPeriodoTrabajador.FechaFin = dtpFechaFin.Value;
            miMotivoFinPeriodo.Codigo = sidtmotivofinperiodo;
            miTrabajador.IdTrabajador = sidttrabajador;

            if (iAccion == 1)
            {
                miPeriodoTrabajador.CrearPeriodoTrabajador(miPeriodoTrabajador, miMotivoFinPeriodo, miTrabajador);
                bOk = true;
            }
            if (iAccion == 2)
            {
                miPeriodoTrabajador.ModificarPeriodoTrabajador(miPeriodoTrabajador, miMotivoFinPeriodo, miTrabajador);
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
            if (cboFinPeriodo.Text != "System.Data.DataRowView" && cboFinPeriodo.ValueMember != "")
            {
                sidtmotivofinperiodo = Convert.ToInt32(cboFinPeriodo.SelectedValue);
            }
        }

        public void RecibirDatos(int pidtperiodotrabajador, DateTime pfechainicio, DateTime pfechafin, int pidtmotivofinperiodo, string pmotivofinperiodo, int pidttrabajador, string ptrabajado, int pAccion)
        {
            sidtperiodotrabajador = pidtperiodotrabajador;
            dtpFechaInicio.Value = pfechainicio;
            dtpFechaFin.Value = pfechafin;
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
            if (smotivofinperiodo == "") { cboFinPeriodo.SelectedIndex = -1; }
            else { cboFinPeriodo.Text = smotivofinperiodo; }
        }
    }
}
