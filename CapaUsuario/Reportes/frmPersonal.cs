using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Reportes
{
    public partial class frmPersonal : Form
    {
        public string tipo = "i";

        public frmPersonal()
        {
            InitializeComponent();
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            CargarAños();
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
                if (cboConceptos.SelectedIndex != -1 || cboTipo.SelectedIndex != -1)
                {
                    CapaDeNegocios.Reportes.ReporteMensual.cReporteUnicoMonto oReporteUnicoMonto = new CapaDeNegocios.Reportes.ReporteMensual.cReporteUnicoMonto();

                    if (chkDatosAdicionales.Checked)
                    {
                        dgvListaTrabajadores.DataSource = oReporteUnicoMonto.TraerListaTrabajadoresLargo(cboMes.Text, cboAño.Text, Convert.ToInt32(cboConceptos.SelectedValue), tipo);
                    }
                    else
                    {
                        dgvListaTrabajadores.DataSource = oReporteUnicoMonto.TraerListaTrabajadores(cboMes.Text, cboAño.Text, Convert.ToInt32(cboConceptos.SelectedValue), tipo);
                    }
                }
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

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarTipos();
        }

        private void BuscarTipos()
        {
            switch (cboTipo.SelectedIndex)
            {
                case 0:
                    tipo = "i";
                    CapaDeNegocios.Sunat.cMaestroIngresos oMaestroIngresos = new CapaDeNegocios.Sunat.cMaestroIngresos();
                    cboConceptos.DisplayMember = "descripcion";
                    cboConceptos.ValueMember = "idtmaestroingresos";
                    cboConceptos.DataSource = oMaestroIngresos.ListarMaestroIngresos("");
                    break;
                case 1:
                    tipo = "d";
                    CapaDeNegocios.Sunat.cMaestroDescuentos oMaestroDescuentos = new CapaDeNegocios.Sunat.cMaestroDescuentos();
                    cboConceptos.DisplayMember = "descripcion";
                    cboConceptos.ValueMember = "idtmaestrodescuentos";
                    cboConceptos.DataSource = oMaestroDescuentos.ListarMaestroDescuentos();
                    break;
                case 2:
                    tipo = "t";
                    CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador oMaestroAportacionesTrabajador = new CapaDeNegocios.Sunat.cMaestroAportacionesTrabajador();
                    cboConceptos.DisplayMember = "descripcion";
                    cboConceptos.ValueMember = "idtmaestroaportacionestrabajador";
                    cboConceptos.DataSource = oMaestroAportacionesTrabajador.ListarMaestroAportacionesTrabajador();
                    
                    break;
                case 3:
                    tipo = "a";
                    CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador oMaestroAportacionesEmpleador = new CapaDeNegocios.Sunat.cMaestroAportacionesEmpleador();
                    cboConceptos.DisplayMember = "descripcion";
                    cboConceptos.ValueMember = "idtmaestroaportacionesempleador";
                    cboConceptos.DataSource = oMaestroAportacionesEmpleador.ListarMaestroAportacionesEmpleador();
                   
                    break;
                default:
                    tipo = "i";
                    break;
            }
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cboConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Reportes.ReporteMensual.cReporteUnicoMonto oReporteMensualTrabajadores = new CapaDeNegocios.Reportes.ReporteMensual.cReporteUnicoMonto();

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "PDF (*.pdf)|*.pdf";
                fichero.FileName = "R_" + cboConceptos.Text + "_" + cboMes.Text + "_" + cboAño.Text + ".pdf";
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

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Reportes.ReporteMensual.cReporteUnicoMonto oReporteMensualTrabajadores = new CapaDeNegocios.Reportes.ReporteMensual.cReporteUnicoMonto();

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "xls (*.xls)|*.xls";
                fichero.FileName = "R_" + cboConceptos.Text + "_" + cboMes.Text + "_" + cboAño.Text + ".xls";
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
