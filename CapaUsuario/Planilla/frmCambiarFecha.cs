using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla
{
    public partial class frmCambiarFecha : Form
    {
        public DateTime FechaSeleccionada;

        public frmCambiarFecha()
        {
            InitializeComponent();
        }

        private void frmCambiarFecha_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtpFecha.Value = FechaSeleccionada;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            FechaSeleccionada = dtpFecha.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
