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
using CapaDeNegocios.Reportes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CapaUsuario.Reportes
{
    public partial class frmTrabajadores : Form
    {
        public frmTrabajadores()
        {
            InitializeComponent();
        }

       

        private void frmTrabajadores_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2020; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void CargarDatos()
        {
            try
            {
                CapaDeNegocios.Reportes.cReporteMensualTrabajadores oReporteMensualTrabajadores = new CapaDeNegocios.Reportes.cReporteMensualTrabajadores();

                dgvListaTrabajadores.DataSource = oReporteMensualTrabajadores.TraerListaTrabajadores(cboMes.Text, cboAño.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Reportes.cReporteMensualTrabajadores oReporteMensualTrabajadores = new CapaDeNegocios.Reportes.cReporteMensualTrabajadores();

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "PDF (*.pdf)|*.pdf";
                fichero.FileName = "ReporteMensualTrabajadores_" + cboMes.Text + "_" + cboAño.Text + ".pdf";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    oReporteMensualTrabajadores.ImprimirReporteMensualaPDF((DataTable)dgvListaTrabajadores.DataSource, fichero.FileName, cboMes.Text, cboAño.Text);
                    FileInfo file = new FileInfo(fichero.FileName);
                    bool estaAbierto = IsFileinUse(file, fichero.FileName);

                    if (!estaAbierto)
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.EnableRaisingEvents = false;
                        proc.StartInfo.FileName = fichero.FileName;
                        proc.Start();
                    }
                    else
                    {
                        MessageBox.Show("El archivo ya esta abierto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el metodo imprimir: " + ex.Message);
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

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Reportes.cReporteMensualTrabajadores oReporteMensualTrabajadores = new CapaDeNegocios.Reportes.cReporteMensualTrabajadores();

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "xls (*.xls)|*.xls";
                fichero.FileName = "ReporteMensualTrabajadores_" + cboMes.Text + "_" + cboAño.Text + ".xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    oReporteMensualTrabajadores.ImprimirReporteMensualaExcel((DataTable)dgvListaTrabajadores.DataSource, fichero.FileName, cboMes.Text, cboAño.Text, chkAutoAjustarColumnas.Checked);
                    FileInfo file = new FileInfo(fichero.FileName);
                    bool estaAbierto = IsFileinUse(file, fichero.FileName);

                    if (!estaAbierto)
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.EnableRaisingEvents = false;
                        proc.StartInfo.FileName = fichero.FileName;
                        proc.Start();
                    }
                    else
                    {
                        MessageBox.Show("El archivo ya esta abierto", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Exportar excel: Metodo btnExportarExcel. " + ex.Message);
            }
        }
    }
}
