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
        int sidmetavinculo = 0;
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

            txtActividadObra.Text = miMeta.ActividadObra.Nombre;
            txtGrupoFuncional.Text = miMeta.GrupoFuncional.Nombre;
            

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (miMeta.ActividadObra.Codigo == 0)
                {
                    MessageBox.Show("Seleccione una Actividad Obra", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (miMeta.GrupoFuncional.Codigo == 0)
                {
                    MessageBox.Show("Seleccione un Grupo Funcional", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                miMeta.Numero = Convert.ToInt16(txtCodigo.Text);
                miMeta.Nombre = txtNombre.Text;
                miMeta.Año = Convert.ToInt16(numAño.Value);
                miMeta.idtmetavinculo = sidmetavinculo;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnActividad_Click(object sender, EventArgs e)
        {
            frmListaActividadObra fActividadObra = new frmListaActividadObra();
            fActividadObra.oActividadObra = new cActividadObra();
            if (fActividadObra.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miMeta.ActividadObra = fActividadObra.oActividadObra;
                txtActividadObra.Text = miMeta.ActividadObra.Nombre;
            }
        }

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            frmListaGrupoFuncional fGrupoFuncional = new frmListaGrupoFuncional();
            fGrupoFuncional.miGrupoFuncional = new cGrupoFuncional();
            if (fGrupoFuncional.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miMeta.GrupoFuncional = fGrupoFuncional.miGrupoFuncional;
                txtGrupoFuncional.Text = miMeta.GrupoFuncional.Nombre;
            }
        }

        private void txtActividadObra_Enter(object sender, EventArgs e)
        {
            tipMeta.Show("Presione F2 para Seleccionar la Actividad / Obra.", txtActividadObra);
        }

        private void txtGrupoFuncional_Enter(object sender, EventArgs e)
        {
            tipMeta.Show("Presione F2 para Seleccionar la Actividad / Obra.", txtGrupoFuncional);
        }


        private void numAño_ValueChanged(object sender, EventArgs e)
        {
            sidmetavinculo = 0;
            txtMetaVinculo.Text = "";
        }

        private void btnVincularMetas_Click(object sender, EventArgs e)
        {
            CapaUsuario.Metas.frmVincularMetas fVincularMeta = new frmVincularMetas();
            fVincularMeta.RecibirDatos(Convert.ToInt32(numAño.Value));
            if (fVincularMeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sidmetavinculo = fVincularMeta.sidtmeta;
                txtMetaVinculo.Text = fVincularMeta.sdescripcion;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            lblContador.Text = txtNombre.TextLength.ToString() + "/299";
        }
    }
}
