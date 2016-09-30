using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Obras;

namespace CapaUsuario.Metas
{
    public partial class frmMeta : Form
    {
        public frmMeta()
        {
            InitializeComponent();
        }

        public cMeta miMeta;

        private void txtGrupoFuncional_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtGrupoFuncional_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGrupoFuncional_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmListaGrupoFuncional fGrupoFuncional = new frmListaGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional = new cGrupoFuncional();
                if (fGrupoFuncional.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miMeta.GrupoFuncional = fGrupoFuncional.miGrupoFuncional;
                    txtGrupoFuncional.Text = miMeta.GrupoFuncional.Nombre;
                }
            }
        }

        private void txtActividadObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmListaActividadObra fActividadObra = new frmListaActividadObra();
                fActividadObra.oActividadObra = new cActividadObra();
                if (fActividadObra.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miMeta.ActividadObra = fActividadObra.oActividadObra;
                    txtActividadObra.Text = miMeta.ActividadObra.Nombre;
                }
            }
        }

        private void frmMeta_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtCodigo.Text = Convert.ToString(miMeta.Numero);
            txtNombre.Text = miMeta.Nombre;
            numAño.Value = miMeta.Año;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miMeta.Numero = Convert.ToInt16(txtCodigo.Text);
            miMeta.Nombre = txtNombre.Text;
            miMeta.Año = Convert.ToInt16(numAño.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
