using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CapaUsuario.Reportes
{
    public partial class frmResumenDetallePlanilla : Form
    {
        int sidtmeta = 0;
        string smeta = "";
        string snumerometa = "";
        int sidtfuentefinanciamiento = 0;
        string sfuentefinanciamiento = "";
        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

        public frmResumenDetallePlanilla()
        {
            InitializeComponent();
        }

        private void frmResumenDetallePlanilla_Load(object sender, EventArgs e)
        {
            cboMes.Text = Convert.ToString(DateTime.Now.ToString("MMMM"));
            CargarAños();
            AgregarColumnasDataGrig();
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void AgregarColumnasDataGrig()
        {
            DataGridViewCheckBoxColumn Check = new DataGridViewCheckBoxColumn();//creamos un objeto check
            {
                Check.Name = "☑";//le damos un nombre de cabecera
                dgvPlanilla.Columns.Add(Check);//agregamos los check a cada items
            }
            dgvPlanilla.Columns["☑"].DisplayIndex = 0;
            dgvPlanilla.Columns["☑"].Width = 30;
        }

        private void CargarDatos()
        {
            try
            {
                dgvPlanilla.Rows.Clear();
                DataTable oDataPlanilla = new DataTable();
                oDataPlanilla = miPlanilla.ListarPlanilla();

                DataTable oDataMeta = new DataTable();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                oDataMeta = miMeta.ListarMetas();
                DataTable oDataFuenteFinanciamiento = new DataTable();
                CapaDeNegocios.cFuenteFinanciamiento miFuenteFinanciamietno = new CapaDeNegocios.cFuenteFinanciamiento();
                oDataFuenteFinanciamiento = miFuenteFinanciamietno.ListarFuenteFinanciamiento();

                foreach (DataRow row in oDataPlanilla.Select("año ='" + cboAño.Text + "' AND mes ='" + cboMes.Text + "'"))
                {
                    foreach (DataRow roww in oDataMeta.Select("idtmeta ='" + row[5].ToString() + "'"))
                    {
                        sidtmeta = Convert.ToInt32(roww[0]);
                        smeta = roww[2].ToString();
                        snumerometa = roww[3].ToString();
                    }
                    foreach (DataRow roww in oDataFuenteFinanciamiento.Select("idtfuentefinanciamiento ='" + row[6].ToString() + "'"))
                    {
                        sidtfuentefinanciamiento = Convert.ToInt32(roww[0]);
                        sfuentefinanciamiento = roww[2].ToString();
                    }
                    dgvPlanilla.Rows.Add(row[0].ToString(), row[1].ToString(), row[8].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), sidtmeta, snumerometa, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, row[7].ToString(), row[9].ToString());
                }
                if (dgvPlanilla.Rows.Count > 0)
                {
                    DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                    dgvPlanilla.Rows[0].Selected = true;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Reportes.cReporteNroTrabajadores miReporteTrabajadores;
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "PDF (*.pdf)|*.pdf";
                fichero.FileName = "ResumenNroTrabajadores_" + ".pdf";
                List<CapaDeNegocios.Planillas.cPlanilla> ListaPLanillas = new List<CapaDeNegocios.Planillas.cPlanilla>();

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvPlanilla.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["☑"].Value) == true)
                        {
                            CapaDeNegocios.Planillas.cPlanilla auxiliar = new CapaDeNegocios.Planillas.cPlanilla();
                            auxiliar = auxiliar.TraerPlanilla(Convert.ToInt32(row.Cells[0].Value));
                            ListaPLanillas.Add(auxiliar);
                        }
                    }

                    miReporteTrabajadores = new CapaDeNegocios.Reportes.cReporteNroTrabajadores(ListaPLanillas, fichero.FileName, chkIncluirCategorias.Checked);
                }

            }
            catch (Exception m)
            {
                MessageBox.Show("Error al imprimir: " + m.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
