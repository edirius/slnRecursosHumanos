﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;
using CapaUsuario.Properties;
//using iTextSharp.text.pdf.PdfWriter;

namespace CapaUsuario.Reportes
{
    public partial class frmResumenPlanillas : Form
    {
        int sidtmeta = 0;
        string smeta = "";
        string snumerometa = "";
        int sidtfuentefinanciamiento = 0;
        string sfuentefinanciamiento = "";

        CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();
        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

        public frmResumenPlanillas()
        {
            InitializeComponent();
        }

        private void frmMatenimientoPlanilla_Load(object sender, EventArgs e)
        {
            cboMes.Text = Convert.ToString(DateTime.Now.ToString("MMMM"));
            CargarAños();
            AgregarColumnasDataGrig();
        }
        
        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Reportes.cResumenPlanillas miResumenPlanilla = new CapaDeNegocios.Reportes.cResumenPlanillas();
            try
            {
                foreach (DataGridViewRow row in dgvPlanilla.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["☑"].Value) == true)
                    {
                        miResumenPlanilla.ResumenPlanilla("ACTIVO", Convert.ToInt32(row.Cells["IdtPlanilla"].Value));
                    }
                }
            }
            catch (Exception m)
            { MessageBox.Show(m.Message); }

            CapaUsuario.Reportes.MostrarReportes Reportes = new MostrarReportes();
            Reportes.ResumenPlanillas("ResumenPlanillas", "DESACTIVO", 0, Settings.Default.Empresa.ToUpper());
            Reportes.MdiParent = this.MdiParent;
            Reportes.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.Text = Convert.ToString(DateTime.Now.Year);
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

        private void button1_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Reportes.cResumenPlanillas miResumenPlanilla = new CapaDeNegocios.Reportes.cResumenPlanillas();
            try
            {
                foreach (DataGridViewRow row in dgvPlanilla.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["☑"].Value) == true)
                    {
                        miResumenPlanilla.ResumenPlanillaDetallado("ACTIVO", Convert.ToInt32(row.Cells["IdtPlanilla"].Value));
                    }
                }
            }
            catch (Exception m)
            { MessageBox.Show(m.Message); }

            CapaUsuario.Reportes.MostrarReportes Reportes = new MostrarReportes();
            Reportes.ResumenPlanillas("ResumenPlanillasDetallado", "DESACTIVO", 0, Settings.Default.Empresa.ToUpper());
            Reportes.MdiParent = this.MdiParent;
            Reportes.Show();
        }

        private void chkSeleccionarTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionarTodo.Checked)
            {
                for (int i = 0; i < dgvPlanilla.Rows.Count; i++)
                {
                    dgvPlanilla.Rows[i].Cells["☑"].Value = true;
                }
            }
        }
    }
}
