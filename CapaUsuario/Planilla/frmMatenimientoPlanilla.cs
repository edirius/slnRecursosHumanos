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
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;
//using iTextSharp.text.pdf.PdfWriter;

namespace CapaUsuario.Planilla
{
    public partial class frmMatenimientoPlanilla : Form
    {
        int sidtplanilla = 0;
        string snumero = "";
        string smes = "";
        string saño = "";
        DateTime sfecha;
        int sidtmeta = 0;
        int sidtfuentefinanciamiento = 0;
        int sidtregimenlaboral = 0;
        string smeta = "";
        string snumerometa = "";
        string sfuentefinanciamiento = "";
        string sdescripcion = "";
        string splantilla = "";
        string sobservaciones = "";

        string sRegimenLaboral = "";

        CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();
        CapaDeNegocios.Planillas.cPlanilla miPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
        CapaDeNegocios.PlanillaNueva.blPlanilla CatalogoPlanilla = new CapaDeNegocios.PlanillaNueva.blPlanilla();

        string FechaTexto = "";

        public frmMatenimientoPlanilla()
        {
            InitializeComponent();
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
        }

        private void frmMatenimientoPlanilla_Load(object sender, EventArgs e)
        {
            cboMes.Text = FechaTexto;
            CargarAños();
        }
        
        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            sidtplanilla = 0;
            CargarDatos();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            sidtplanilla = 0;
            CargarDatos();
        }

        private void btnTipoTrabajador_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Planilla.frmPlanilla fPlanilla = new frmPlanilla();
            fPlanilla.oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            fPlanilla.RecibirDatos(0, "", "", "", DateTime.Today, 0, "", 0, "", 0, "", "", "", 1, "");
            
            if (fPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Planilla.frmPlanilla fPlanilla = new frmPlanilla();
            fPlanilla.oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            fPlanilla.oPlanilla = fPlanilla.oPlanilla.TraerPlanilla(sidtplanilla);
            fPlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sfecha, sidtmeta, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, sRegimenLaboral, sdescripcion, splantilla, 2, sobservaciones);
            if (fPlanilla.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea eliminar la Planilla", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miPlanilla.EliminarPlanilla(sidtplanilla);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDetallePlanilla_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (splantilla == "REGIDORES")
            {
                CapaUsuario.Planilla.frmMantenimientoDetallePlanillaRegidores fMantenimientoDetallePlanillaRegidores = new frmMantenimientoDetallePlanillaRegidores();
                fMantenimientoDetallePlanillaRegidores.RecibirDatos(sidtplanilla, snumero, smes, saño, sidtmeta, snumerometa, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, sRegimenLaboral, splantilla);
                fMantenimientoDetallePlanillaRegidores.ShowDialog();
            }
            else
            {
                CapaUsuario.Planilla.frmMantenimientoDetallePlanilla fMantenimientoDetallePlanilla = new frmMantenimientoDetallePlanilla();
                fMantenimientoDetallePlanilla.oPlanilla = oPlanilla.TraerPlanilla(sidtplanilla);
                fMantenimientoDetallePlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sidtmeta, snumerometa, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, sRegimenLaboral, splantilla);
                fMantenimientoDetallePlanilla.ShowDialog();

                //if (oPlanilla.TraerPlanilla(sidtplanilla).TipoPlanilla == CapaDeNegocios.Planillas.enumTipoPlanilla.VACACIONES_TRUNCAS)
                //{
                //    VacacionesTruncas.frmMantenimientoDetalleVac fMantenimientoDetalleVac = new VacacionesTruncas.frmMantenimientoDetalleVac();
                //    fMantenimientoDetalleVac.oPlanilla = CatalogoPlanilla.TraerPlanilla(sidtplanilla);
                //    fMantenimientoDetalleVac.ShowDialog();
                //}
                //else
                //{
                   
                //}
                
            }
        }

        private void dgvPlanilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPlanilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();
            CapaDeNegocios.DatosLaborales.cRegimenLaboral oRegimenLaboral = new CapaDeNegocios.DatosLaborales.cRegimenLaboral();

            if (e.RowIndex != -1)
            {
                sidtplanilla = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[0].Value);
                snumero = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[1].Value);
                sdescripcion = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[2].Value);
                smes = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[3].Value);
                saño = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[4].Value);
                sfecha = Convert.ToDateTime(dgvPlanilla.Rows[e.RowIndex].Cells[5].Value);
                sidtmeta = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[6].Value);
                snumerometa = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[7].Value);
                smeta = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[8].Value);
                sidtfuentefinanciamiento = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[9].Value);
                sfuentefinanciamiento = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[10].Value);
                sidtregimenlaboral = Convert.ToInt32(dgvPlanilla.Rows[e.RowIndex].Cells[11].Value);
                splantilla = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[12].Value);
                sobservaciones = Convert.ToString(dgvPlanilla.Rows[e.RowIndex].Cells[13].Value);
                foreach (DataRow row in oRegimenLaboral.ListarRegimenLaboral().Select("idtregimenlaboral= '" + sidtregimenlaboral + "'"))
                {
                    sRegimenLaboral = row[2].ToString();
                }
            }
        }

        private void dgvPlanilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CapaDeNegocios.Planillas.cPlanilla oPlanilla = new CapaDeNegocios.Planillas.cPlanilla();

            if (sidtplanilla == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (splantilla == "REGIDORES")
            {
                CapaUsuario.Planilla.frmMantenimientoDetallePlanillaRegidores fMantenimientoDetallePlanillaRegidores = new frmMantenimientoDetallePlanillaRegidores();
                
                fMantenimientoDetallePlanillaRegidores.RecibirDatos(sidtplanilla, snumero, smes, saño, sidtmeta, snumerometa, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, sRegimenLaboral, splantilla);
                fMantenimientoDetallePlanillaRegidores.ShowDialog();
            }
            else
            {
                CapaUsuario.Planilla.frmMantenimientoDetallePlanilla fMantenimientoDetallePlanilla = new frmMantenimientoDetallePlanilla();
                fMantenimientoDetallePlanilla.oPlanilla = oPlanilla.TraerPlanilla(sidtplanilla);
                fMantenimientoDetallePlanilla.RecibirDatos(sidtplanilla, snumero, smes, saño, sidtmeta, snumerometa, smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, sidtregimenlaboral, sRegimenLaboral, splantilla);
                fMantenimientoDetallePlanilla.ShowDialog();
            }
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
                string cadenadaAnulado = "";
                if (!chkIncluirAnulados.Checked)
                {
                    cadenadaAnulado = " AND anulado = false";
                }
                else
                {
                    cadenadaAnulado = "";
                }
                foreach (DataRow row in oDataPlanilla.Select("año ='" + cboAño.Text + "' AND mes ='" + cboMes.Text + "'" + cadenadaAnulado))
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
                    dgvPlanilla.Rows.Add(row[0].ToString(), row[1].ToString(), row[8].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), sidtmeta, snumerometa, snumerometa + " - " + smeta, sidtfuentefinanciamiento, sfuentefinanciamiento, row[7].ToString(), row[9].ToString(), row[10].ToString(), Convert.ToBoolean(row[11]), Convert.ToInt32(row[17]));

                }
                if (dgvPlanilla.Rows.Count > 0)
                {
                    DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                    dgvPlanilla.Rows[0].Selected = true;
                    dgvPlanilla_CellClick(dgvPlanilla, cea);
                }

                foreach (DataGridViewRow row in dgvPlanilla.Rows)
                {
                    // Condición para cambiar el color de la fila
                    if (Convert.ToBoolean(row.Cells["colAnulado"].Value.ToString()))
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.DarkRed; // Cambia el color de fondo
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray; // Cambia el color de fondo
                    }

                    ///vACACIONES TRUNCAS
                    if (Convert.ToInt16(row.Cells["colTipoPlanilla"].Value)== 3)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightSeaGreen; // Cambia el color de fondo
                    }
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CapaUsuario.Reportes.frmPlanilla fPlanilla = new CapaUsuario.Reportes.frmPlanilla();
            fPlanilla.MdiParent = this.MdiParent;
            fPlanilla.Show();
        }

        public void CargarMes(DateTime FechaActual)
        {
            string Ahora = Convert.ToString(FechaActual.Date.Month);
            switch (Ahora)
            {
                case "1":
                    {
                        FechaTexto = "ENERO";
                        break;
                    }
                case "2":
                    {
                        FechaTexto = "FEBRERO";
                        break;
                    }
                case "3":
                    {
                        FechaTexto = "MARZO";
                        break;
                    }
                case "4":
                    {
                        FechaTexto = "ABRIL";
                        break;
                    }
                case "5":
                    {
                        FechaTexto = "MAYO";
                        break;
                    }
                case "6":
                    {
                        FechaTexto = "JUNIO";
                        break;
                    }
                case "7":
                    {
                        FechaTexto = "JULIO";
                        break;
                    }
                case "8":
                    {
                        FechaTexto = "AGOSTO";
                        break;
                    }
                case "9":
                    {
                        FechaTexto = "SETIEMBRE";
                        break;
                    }
                case "10":
                    {
                        FechaTexto = "OCTUBRE";
                        break;
                    }
                case "11":
                    {
                        FechaTexto = "NOVIEMBRE";
                        break;
                    }
                case "12":
                    {
                        FechaTexto = "DICIEMBRE";
                        break;
                    }
            }
        }

        private void btnHabilitarTareo_Click(object sender, EventArgs e)
        {
            Tareo.frmHabilitarTareo fTareo = new Tareo.frmHabilitarTareo();
            fTareo.MdiParent = this.MdiParent;
            fTareo.Show();
        }
    }
}
