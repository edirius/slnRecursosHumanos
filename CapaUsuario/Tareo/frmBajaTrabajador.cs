using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Tareo
{
    public partial class frmBajaTrabajador : Form
    {
        string sfechafin = "";
        int sidtperiodotrabajador = 0;
        int sidtmotivofinperiodo = 0;
        public frmBajaTrabajador()
        {
            InitializeComponent();
        }

        private void frmBajaTrabajador_Load(object sender, EventArgs e)
        {
            CargarMotivoFinPeriodo();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea Dar de Baja al Trabajador, este ya no aparecera en proximos tareos", "Gestion de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            sfechafin = monthCalendar1.SelectionRange.Start.ToShortDateString();
            //Periodo Trabajador
            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            miPeriodoTrabajador.BajaPeriodoTrabajador(sfechafin, sidtmotivofinperiodo, sidtperiodotrabajador);

            //Regimen Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            miRegimenTrabajador.BajaRegimenTrabajador(sfechafin, sidtperiodotrabajador);

            //Regimen Salud Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
            miRegimenSaludTrabajador.BajaRegimenSaludTrabajador(sfechafin, sidtperiodotrabajador);

            //Regimen Pensionario Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
            miRegimenPensionarioTrabajador.BajaRegimenPensionarioTrabajador(sfechafin, sidtperiodotrabajador);

            DialogResult = System.Windows.Forms.DialogResult.OK;
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

        public void RecibirDatos(DateTime fechainicio, int pidtperiodotrabajador)
        {
            sidtperiodotrabajador = pidtperiodotrabajador;
            int AñoInicio = fechainicio.Year;
            int MesInicio = fechainicio.Month;
            int DiasMes = DateTime.DaysInMonth(AñoInicio, MesInicio);
            string fechafin = DiasMes + "/" + MesInicio + "/" + AñoInicio;
            monthCalendar1.MaxDate = Convert.ToDateTime(fechafin);
        }

        private void CargarMotivoFinPeriodo()
        {
            CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo miMotivoFinPeriodo = new CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo();
            cboFinPeriodo.DataSource = miMotivoFinPeriodo.ListaMotivosFinPeriodos();
            cboFinPeriodo.DisplayMember = "descripcion";
            cboFinPeriodo.ValueMember = "idtmotivofinperiodo";
            cboFinPeriodo.SelectedIndex = 0;
        }
    }
}
