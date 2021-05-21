using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaDeNegocios;


namespace CapaUsuario.Asistencia
{
    public partial class frmMantenimientoHorario : Form
    {

        CapaDeNegocios.Asistencia.cHorario oHorario = new CapaDeNegocios.Asistencia.cHorario();

        public frmMantenimientoHorario()
        {
            InitializeComponent();
        }

        private void btnNuevoHorario_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoHorario fNuevoHorario = new frmNuevoHorario();
                fNuevoHorario.oHorario = new CapaDeNegocios.Asistencia.cHorario();
                if (fNuevoHorario.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(fNuevoHorario.oHorario.TurnoLunes.NombreTurnoDia);
                }
                else
                {
                    MessageBox.Show("Se cancelo el ingreso de nuevo horario.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el nuevo horario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Iniciar()
        {

        }
    }
}
