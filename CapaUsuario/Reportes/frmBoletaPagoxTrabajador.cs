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
            if (cDatosGeneralesEmpresa.RUC == "20200737211")
            {
                rdnBoletaDuplicada.Checked = true;
                rdnVertical.Checked = true;
            }
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
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (esValidoDNI(txtDNI.Text))
                {
                    oTrabajador = oTrabajador.BuscarTrabajadorXDNI(txtDNI.Text);
                    miReporte = new CapaDeNegocios.Reportes.cReporteBoletasXTrabajador(oTrabajador);
                    miReporte.TraerListaPLanillas(oTrabajador, Convert.ToInt16(cboAño.Text));
                    dtgBoletasPago.DataSource = miReporte.ListaBoletasXAño;
                }
                else
                {
                   
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el metodo buscar: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private bool esValidoDNI(string dni)
        {
            if (dni.Length != 8)
            {
                MessageBox.Show("El DNI ingresado debe contener 8 caractere", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            bool esErroneo = false;

            for (int i = 0; i < dni.Length; i++)
            {
                int check=0;
                
                if (!int.TryParse(dni.Substring(i, 1), out check))
                {
                    esErroneo = true;
                }  
            }

            if (esErroneo)
            {
                MessageBox.Show("Uno de los caracteres del dni no es numerico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
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
                        if (rdnBoletaDuplicada.Checked)
                        {
                            if (rdnHorizontal.Checked)
                            {
                                miReporte.ImprimirReporteBoleta(fichero.FileName, CapaDeNegocios.Reportes.OpcionesReporteBoleta.BoletaDuplicada, Convert.ToSingle(numTamañoLetra.Value));
                            }
                            else
                            {
                                miReporte.ImprimirReporteBoleta(fichero.FileName, CapaDeNegocios.Reportes.OpcionesReporteBoleta.BoletaDuplicada, Convert.ToSingle(numTamañoLetra.Value), CapaDeNegocios.Reportes.OpcionesPaginaReporteBoleta.Vertical);
                            }
                        }
                        else
                        {
                            if (rdnUnaBoleta.Checked)
                            {
                                if (rdnHorizontal.Checked)
                                {
                                    miReporte.ImprimirReporteBoleta(fichero.FileName, CapaDeNegocios.Reportes.OpcionesReporteBoleta.UnaBoletaxPagina, Convert.ToSingle(numTamañoLetra.Value));
                                }
                                else
                                {
                                    miReporte.ImprimirReporteBoleta(fichero.FileName, CapaDeNegocios.Reportes.OpcionesReporteBoleta.UnaBoletaxPagina, Convert.ToSingle(numTamañoLetra.Value), CapaDeNegocios.Reportes.OpcionesPaginaReporteBoleta.Vertical);
                                }
                            }
                            else
                            {
                                //miReporte.ImprimirReporteBoleta(fichero.FileName, CapaDeNegocios.Reportes.OpcionesReporteBoleta.UnaBoletaxPagina, Convert.ToSingle(numTamañoLetra.Value), CapaDeNegocios.Reportes.OpcionesPaginaReporteBoleta.Vertical);
                                if (rdnHorizontal.Checked)
                                {
                                    miReporte.ImprimirReporteBoleta(fichero.FileName, CapaDeNegocios.Reportes.OpcionesReporteBoleta.DosBoletaXPagina, Convert.ToSingle(numTamañoLetra.Value));
                                }
                                else
                                {
                                    miReporte.ImprimirReporteBoleta(fichero.FileName, CapaDeNegocios.Reportes.OpcionesReporteBoleta.DosBoletaXPagina, Convert.ToSingle(numTamañoLetra.Value), CapaDeNegocios.Reportes.OpcionesPaginaReporteBoleta.Vertical);
                                }
                            }
                            
                        }

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
