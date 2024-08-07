﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.ResidenteMeta
{
    public partial class frmModificarcategoriaJornal : Form
    {
        public frmModificarcategoriaJornal()
        {
            InitializeComponent();
        }

        public CapaDeNegocios.Obras.cMetaJornal oMetaJornal;

        private void frmModificarcategoriaJornal_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtNombreCategoria.Text = oMetaJornal.Categoria;
          txtMonto.Text = oMetaJornal.Jornal.ToString();
            txtMensual.Text = oMetaJornal.Mensual.ToString();
            if (oMetaJornal.Opcion)
            {
                cboOpcion.Text = "Mensual";
            }
            else
            {
                cboOpcion.Text = "Jornal";
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreCategoria.Text.Trim() == "" || txtMonto.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un nombre/ monto de la categoria.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oMetaJornal.Categoria = txtNombreCategoria.Text;
                    oMetaJornal.Jornal = Convert.ToDouble(txtMonto.Text);
                    oMetaJornal.Mensual = Convert.ToDouble(txtMensual.Text);
                    if (cboOpcion.Text == "Jornal")
                    {
                        oMetaJornal.Opcion = false;
                    }
                    else
                    {
                        oMetaJornal.Opcion = true;
                    }
                    DialogResult = DialogResult.OK;
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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMensual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMonto_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }
    }
}
