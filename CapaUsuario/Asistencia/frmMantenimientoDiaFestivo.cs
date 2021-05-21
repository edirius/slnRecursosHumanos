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
    public partial class frmMantenimientoDiaFestivo : Form
    {
        public CapaDeNegocios.Asistencia.cDiaFestivo oDiaFestivo;

        public frmMantenimientoDiaFestivo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoDiaFestivo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtNombreDiaFestivo.Text = oDiaFestivo.Nombre;
            dtpDiaFestivo.Value = oDiaFestivo.DiaFestivo;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreDiaFestivo.Text != "")
                {
                    oDiaFestivo.Nombre = txtNombreDiaFestivo.Text;
                    oDiaFestivo.DiaFestivo = dtpDiaFestivo.Value;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre para el dia festivo.", "Dia Festivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar o modificar el dia festivo: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
