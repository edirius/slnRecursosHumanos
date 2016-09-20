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
        public frmBajaTrabajador()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            sfechafin = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Regimen Trabajador
            CapaDeNegocios.DatosLaborales.cPeriodoTrabajador miPeriodoTrabajador = new CapaDeNegocios.DatosLaborales.cPeriodoTrabajador();
            miPeriodoTrabajador.BajaPeriodoTrabajador(sfechafin, sidtperiodotrabajador);

            //Regimen Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
            miRegimenTrabajador.BajaRegimenTrabajador(sfechafin, sidtperiodotrabajador);

            //Regimen Salud Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
            miRegimenSaludTrabajador.BajaRegimenSaludTrabajador(sfechafin, sidtperiodotrabajador);

            //Regimen Trabajador
            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
            miRegimenPensionarioTrabajador.BajaRegimenPensionarioTrabajador(sfechafin, sidtperiodotrabajador);

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void RecibirDatos(int pidtperiodotrabajador)
        {
            sidtperiodotrabajador = pidtperiodotrabajador;
        }
    }
}
