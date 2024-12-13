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

namespace CapaUsuario.Reportes.ReporteTrabaxAño
{
    public partial class frmReporteTrabajadorXAño : Form
    {
        cCatalogoReporteXAño oCatalogo = new cCatalogoReporteXAño();
        cReporteTrabajadoresXAño oReporte = new cReporteTrabajadoresXAño();
        CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
        public frmReporteTrabajadorXAño()
        {
            InitializeComponent();
        }

        private void frmReporteTrabajadorXAño_Load(object sender, EventArgs e)
        {
            cboAño.DataSource = oPlanilla.ListarAñosPlanilla();
            cboAño.DisplayMember = "añó";
            cboAño.ValueMember = "año";
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       private void LlenarReporte()
        {
            foreach (cDetallesReporteTrabajadores item in oReporte.Detalles)
            {
                dtgListaTrabajadores.Rows.Add();
                dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colNumero"].Value = item.NumeroOrden;
                dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colDNI"].Value = item.DNI;
                dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colNombres"].Value = item.Nombres;
                dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colApellidoPaterno"].Value = item.ApellidoPaterno;
                dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colApellidoMaterno"].Value = item.ApellidoMaterno;
                foreach (cDetalleMeses item2 in item.Meses)
                {
                    switch (item2.Mes.Month)
                    {
                        case 1:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colEnero"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 2:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colFebrero"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 3:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colMarzo"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 4:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colAbril"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 5:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colMayo"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 6:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colJunio"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 7:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colJulio"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 8:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colAgosto"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 9:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colSetiembre"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 10:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colOctubre"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 11:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colNoviembre"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        case 12:
                            dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Cells["colDiciembre"].Value = item2.Cargo + Environment.NewLine + "Dias Lab: " + item2.DiasLaborados;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboAño.SelectedIndex != -1)
            {
                oReporte = oCatalogo.LLenarReporteXAño(Convert.ToInt16(cboAño.Text));
                LlenarReporte();
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                CapaDeNegocios.Reportes.ReporteMensual.cReporteUnicoMonto oReporteMensualTrabajadores = new CapaDeNegocios.Reportes.ReporteMensual.cReporteUnicoMonto();

                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "xls (*.xls)|*.xls";
                fichero.FileName = "R_TrabajadoresXAño"  + "_" + cboAño.Text + ".xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    oCatalogo.ImprimirExcelTrabajadoresXAño(oReporte, Convert.ToInt16(cboAño.Text), fichero.FileName);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
