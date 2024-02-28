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

namespace CapaUsuario.Usuarios
{
    public partial class frmEscogerMeta : Form
    {
        CapaDeNegocios.Obras.cCadenaProgramaticaFuncional oCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
        public frmEscogerMeta()
        {
            InitializeComponent();
        }

        private void frmEscogerMeta_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            CargarAños();
        }

        private void CargarAños()
        {
            DateTime FechaActual = DateTime.Now;

            for (int i = 0; i < 5; i++)
            {
                cboAños.Items.Add(FechaActual.Year);
                FechaActual = FechaActual.AddYears(-1);
            }
        }

        private void cboAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMetas(Convert.ToInt16(cboAños.SelectedItem));
        }

        private void CargarMetas(int año)
        {
            try
            {
                CapaDeNegocios.Obras.cMeta oMeta = new CapaDeNegocios.Obras.cMeta();

                dtgListaMetas.DataSource = oCadena.ListarMetas(año);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error al cargar las metas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoResidente_Click(object sender, EventArgs e)
        {
            if (dtgListaMetas.SelectedRows.Count > 0)
            {
                Trabajador.frmNuevoTecnico fNuevoTecnico = new Trabajador.frmNuevoTecnico();
                fNuevoTecnico.RecibirDatos(Convert.ToInt32(dtgListaMetas.SelectedRows[0].Cells[0].Value));
                fNuevoTecnico.fechaInicio = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
                fNuevoTecnico.fechaFin = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1).AddMonths(1).AddDays(-1);
                if (fNuevoTecnico.ShowDialog() == DialogResult.OK)
                {

                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una meta para el nuevo residente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevaMeta_Click(object sender, EventArgs e)
        {
            try
            {
                Metas.frmMeta fMeta = new Metas.frmMeta();
                fMeta.miMeta = new CapaDeNegocios.Obras.cMeta();
                fMeta.miMeta.Año = DateTime.Now.Year;
                fMeta.miMeta.GrupoFuncional = new CapaDeNegocios.Obras.cGrupoFuncional();
                fMeta.miMeta.ActividadObra = new CapaDeNegocios.Obras.cActividadObra();
                if (fMeta.ShowDialog()== DialogResult.OK)
                {
                    oCadena.CrearMeta(fMeta.miMeta);
                    CargarMetas(Convert.ToInt32(cboAños.SelectedItem));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la meta: " + ex.Message, "Meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
