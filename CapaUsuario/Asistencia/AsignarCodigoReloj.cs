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
    public partial class AsignarCodigoReloj : Form
    {
        public AsignarCodigoReloj()
        {
            InitializeComponent();
        }

        public CapaDeNegocios.Asistencia.cTrabajadorReloj oTrabajadorReloj;

        public bool  modificado  = false;

        CapaDeNegocios.Asistencia.cCatalogoAsistencia oCatalogo = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        private void AsignarCodigoReloj_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            lblNombredelTrabajador.Text = oTrabajadorReloj.OTrabajador.Nombres + " " + oTrabajadorReloj.OTrabajador.ApellidoPaterno + " " + oTrabajadorReloj.OTrabajador.ApellidoMaterno;


            if (oTrabajadorReloj.CodigoReloj != -1)
            {
                MessageBox.Show("El trabajador ya tiene asignado un codigo en el reloj: " + oTrabajadorReloj.CodigoReloj.ToString(), "Codigo encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumero.Text = oTrabajadorReloj.CodigoReloj.ToString();
                modificado = true;
            }
            else
            {
                modificado = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text.Trim() != "")
                {
                    cTrabajador BuscarTrabajador = oCatalogo.TraerTrabajadorXCodigoReloj(Convert.ToInt32(txtNumero.Text));

                    if (BuscarTrabajador == null )
                    {
                        oTrabajadorReloj.CodigoReloj = Convert.ToInt32(txtNumero.Text);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("El numero " + txtNumero.Text + " ya esta asignado a " + BuscarTrabajador.Nombres + " " + BuscarTrabajador.ApellidoPaterno + BuscarTrabajador.ApellidoMaterno);
                    }
                }
                else
                {
                    MessageBox.Show("Debe escribir un numero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnIngresarDNI_Click(object sender, EventArgs e)
        {
            txtNumero.Text = oTrabajadorReloj.OTrabajador.Dni;
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
