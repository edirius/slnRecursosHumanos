using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Asistencia.GrupoAsistencia;

namespace CapaUsuario.Asistencia.GrupoAsistencia
{
    public partial class frmMantenimientoGrupo : Form
    {
        public cGrupoAsistencia oGrupoAsistencia;

        public frmMantenimientoGrupo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoGrupo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtDescripcion.Text = oGrupoAsistencia.Descripcion;
            chkHabilitado.Checked = oGrupoAsistencia.Habilitado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            oGrupoAsistencia.Descripcion = txtDescripcion.Text;
            oGrupoAsistencia.Habilitado = chkHabilitado.Checked;
            DialogResult = DialogResult.OK;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            lblNumero.Text = txtDescripcion.TextLength.ToString() + "/45";
        }
    }
}
