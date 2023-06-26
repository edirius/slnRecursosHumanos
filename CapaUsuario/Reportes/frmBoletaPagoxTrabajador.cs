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
using System.IO;

namespace CapaUsuario.Reportes
{
    public partial class frmBoletaPagoxTrabajador : Form
    {

        public CapaDeNegocios.Reportes.cReporteBoletasXTrabajador miReporte;
        private cTrabajador oTrabajador = new cTrabajador();

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
                   
                    oTrabajador=  oTrabajador.BuscarTrabajadorXDNI(txtDNI.Text);
                    miReporte = new CapaDeNegocios.Reportes.cReporteBoletasXTrabajador(oTrabajador);
                    miReporte.TraerListaPLanillas(oTrabajador, Convert.ToInt16(cboAño.Text));
                    dtgBoletasPago.DataSource = miReporte.ListaBoletasXAño;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el metodo buscar: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnImprimirBoleta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgBoletasPago.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe escoger una mes para imprimir la boleta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.Filter = "PDF (*.pdf)|*.pdf";
                    fichero.FileName = "BoletaPago_" + oTrabajador.Dni + DateTime.Now.Month + ".pdf";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        miReporte.ImprimirReporteBoleta(fichero.FileName);
                        FileInfo file = new FileInfo(fichero.FileName);
                        bool estaAbierto = false;
                        estaAbierto = IsFileinUse(file, fichero.FileName);

                        if (!estaAbierto)
                        {
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.EnableRaisingEvents = false;
                            proc.StartInfo.FileName = fichero.FileName;
                            proc.Start();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual bool IsFileinUse(FileInfo file, string path)
        {
            FileStream stream = null;

            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                try
                {
                    stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    return true;

                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
                return false;
            }
        }
    }
}
