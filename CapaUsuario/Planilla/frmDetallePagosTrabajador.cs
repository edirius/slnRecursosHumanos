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

namespace CapaUsuario.Planilla
{
    public partial class frmDetallePagosTrabajador : Form
    {
        public CapaDeNegocios.Reportes.cReporteBoletasXTrabajador miReporte;
        public cTrabajador oTrabajador = new cTrabajador();

        public frmDetallePagosTrabajador()
        {
            InitializeComponent();
        }

        private void frmDetallePagosTrabajador_Load(object sender, EventArgs e)
        {
            BuscarTrabajador();
        }

        private void BuscarTrabajador()
        {
            try
            {
                oTrabajador = oTrabajador.BuscarTrabajadorXDNI(oTrabajador.Dni);
                
                if (oTrabajador != null)
                {
                    lblTrabajador.Text = oTrabajador.Nombres + " " + oTrabajador.ApellidoPaterno + " " + oTrabajador.ApellidoMaterno;
                    miReporte = new CapaDeNegocios.Reportes.cReporteBoletasXTrabajador(oTrabajador);
                    miReporte.TraerListaPLanillas(oTrabajador, 2024);
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
                        miReporte.ImprimirReporteBoleta(fichero.FileName, CapaDeNegocios.Reportes.OpcionesReporteBoleta.BoletaDuplicada, Convert.ToSingle(8), false);

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
