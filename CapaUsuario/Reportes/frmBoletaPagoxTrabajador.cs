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


namespace CapaUsuario.Reportes
{
    public partial class frmBoletaPagoxTrabajador : Form
    {

        public CapaDeNegocios.Reportes.cReporteBoletasXTrabajador miReporte;

        public frmBoletaPagoxTrabajador()
        {
            InitializeComponent();
        }

        private void frmBoletaPagoxTrabajador_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        public void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2020; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar== (char)Keys.Delete)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDNI.Text.Length < 8)
                {
                    MessageBox.Show("El dni debe contener 8 caracteres.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cTrabajador oTrabajador = new cTrabajador();
                    oTrabajador=  oTrabajador.BuscarTrabajadorXDNI(txtDNI.Text);
                    miReporte = new CapaDeNegocios.Reportes.cReporteBoletasXTrabajador(oTrabajador);

                    miReporte.ListaBoletasXAño =  miReporte.TraerListaPLanillas(oTrabajador, Convert.ToInt16(cboAño.Text));
                    dtgBoletasPago.DataSource = miReporte.ListaBoletasXAño;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el metodo buscar: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
