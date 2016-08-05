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
    public partial class frmMensajeIngreso : Form
    {
        public string sMensaje = "";
        public frmMensajeIngreso()
        {
            InitializeComponent();
        }

        private void frmMensajeIngreso_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void rbtMaestroIngresos_CheckedChanged(object sender, EventArgs e)
        {
            sMensaje = "INGRESOS";
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void rbtMaestroATrabajador_CheckedChanged(object sender, EventArgs e)
        {
            sMensaje = "A_TRABAJADOR";
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void rbtMaestroAEmpleador_CheckedChanged(object sender, EventArgs e)
        {
            sMensaje = "A_EMPLEADOR";
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void rbtMaestroDescuentos_CheckedChanged(object sender, EventArgs e)
        {
            sMensaje = "DESCUENTOS";
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
