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

namespace CapaUsuario.Planilla.TrabajadoresSinPlanilla
{
    public partial class frmTrabajadoresSinPlanilla : Form
    {
        CapaDeNegocios.Planillas.Baja.cCatalogoBaja oCatalogoBaja = new CapaDeNegocios.Planillas.Baja.cCatalogoBaja();
        List<CapaDeNegocios.Planillas.Baja.cTrabajadorParaDarBaja> ListaTrabajadoresBaja = new List<CapaDeNegocios.Planillas.Baja.cTrabajadorParaDarBaja>();
        CapaDeNegocios.Utilidades.cUtilidades oUtilidades = new CapaDeNegocios.Utilidades.cUtilidades();

        public frmTrabajadoresSinPlanilla()
        {
            InitializeComponent();
        }

        private void frmTrabajadoresSinPlanilla_Load(object sender, EventArgs e)
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

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                if (cboMes.Text != "")
                {
                    ListaTrabajadoresBaja = oCatalogoBaja.TraerListaTrabajadoresParaDarBaja(cboMes.Text, Convert.ToInt16(cboAño.Text));
                    dtgTrabajadores.DataSource = ListaTrabajadoresBaja;
                    dtpFechaFin.Value = new DateTime(Convert.ToInt16(cboAño.Text), oUtilidades.ConvertirMesANumero(cboMes.Text), 1).AddDays(-1);
                    lblContadorTrabajadores.Text = "Total Trabajadores: " + ListaTrabajadoresBaja.Count;                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
            
        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CapaDeNegocios.Planillas.Baja.cTrabajadorParaDarBaja item in ListaTrabajadoresBaja)
                {
                    if (item.Check == true)
                    {
                        if (Convert.ToDateTime(item.PeriodoTrabajador.FechaInicio).AddDays(1) > dtpFechaFin.Value  )
                        {
                            MessageBox.Show("La fecha de inicio: " + item.PeriodoTrabajador.FechaInicio + " es mayor a la fecha fin: " + dtpFechaFin.Value.ToShortDateString());
                        }
                        else
                        {
                            item.PeriodoTrabajador.FechaFin = dtpFechaFin.Value.ToShortDateString();
                            item.PeriodoTrabajador.IdtMotivoFinPeriodo = 8;
                            //Regimen Trabajador
                            CapaDeNegocios.DatosLaborales.cRegimenTrabajador miRegimenTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenTrabajador();
                            miRegimenTrabajador.BajaRegimenTrabajador(item.PeriodoTrabajador.FechaFin, item.PeriodoTrabajador.IdtPeriodoTrabajador);

                            //Regimen Salud Trabajador
                            CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador miRegimenSaludTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenSaludTrabajador();
                            miRegimenSaludTrabajador.BajaRegimenSaludTrabajador(item.PeriodoTrabajador.FechaFin, item.PeriodoTrabajador.IdtPeriodoTrabajador);

                            //Regimen Trabajador
                            CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador miRegimenPensionarioTrabajador = new CapaDeNegocios.DatosLaborales.cRegimenPensionarioTrabajador();
                            miRegimenPensionarioTrabajador.BajaRegimenPensionarioTrabajador(item.PeriodoTrabajador.FechaFin, item.PeriodoTrabajador.IdtPeriodoTrabajador);

                            item.PeriodoTrabajador.ModificarPeriodoTrabajador(item.PeriodoTrabajador);
                        }
                    }
                }

                MessageBox.Show("Trabajadores actualizados", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja: " + ex.Message);
            }
        }

        private void copiarDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgTrabajadores.SelectedCells.Count > 0)
                {
                    Clipboard.SetDataObject(dtgTrabajadores.Rows[dtgTrabajadores.SelectedCells[0].RowIndex].Cells["colNumeroDocumento"].Value.ToString());
                    MessageBox.Show("DNI " + dtgTrabajadores.Rows[dtgTrabajadores.SelectedCells[0].RowIndex].Cells["colNumeroDocumento"].Value.ToString() + " copiado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al copiar DNI: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
