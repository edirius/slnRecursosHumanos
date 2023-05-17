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

namespace CapaUsuario.Tareo
{
    public partial class frmNuevaJornal : Form
    {
        public CapaDeNegocios.Obras.cMetaJornal oMetaJornal;

        public frmNuevaJornal()
        {
            InitializeComponent();
        }

        private void frmNuevaJornal_Load(object sender, EventArgs e)
        {


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreCategoria.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un nombre de la categoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    List<CapaDeNegocios.Obras.cMetaJornal> Lista = oMetaJornal.TraerMetasJornalesPorMeta(oMetaJornal.Meta.Codigo);

                    bool Encontrado = false;
                    foreach (cMetaJornal  item in Lista)
                    {
                        if (txtNombreCategoria.Text.Trim() == item.Categoria)
                        {
                            Encontrado = true;
                        }
                    }

                    if (Encontrado)
                    {
                        MessageBox.Show("La categoria " + txtNombreCategoria.Text.Trim() + " ya existe para la meta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        oMetaJornal.Categoria = txtNombreCategoria.Text;
                        oMetaJornal.Jornal = 0;
                        oMetaJornal.Mensual = 0;
                        oMetaJornal.Opcion = false;
                        DialogResult = DialogResult.OK;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en crear/ modificar la categoria: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
