using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Tareo
{
    public partial class frmMantenimientoTareo : Form
    {
        int sIdTTareo = 0;
        int sNumero = 0;
        DateTime sFechaInicio= DateTime.Now;
        DateTime sFechaFin= DateTime.Now;
        string sDescripcion = "";
        bool sEstado = false;
        int sIdTMeta = 0;

        CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
        CapaDeNegocios.Tareos.cTareo miTareo = new CapaDeNegocios.Tareos.cTareo();

        public frmMantenimientoTareo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCronogramaTareo_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CapaUsuario.Tareo.frmTareo fTareo = new CapaUsuario.Tareo.frmTareo();
            fTareo.RecibirDatos(0, 0, DateTime.Today, DateTime.Today, "", false, sIdTMeta, cboMeta.Text, 1);
            if (fTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (sEstado == true)
            {
                MessageBox.Show("El Tareo ya no se puede Modificar.", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sIdTTareo == 0 && dgvTareo.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Tareo.frmTareo fTareo = new CapaUsuario.Tareo.frmTareo();


            fTareo.RecibirDatos(sIdTTareo, sNumero, sFechaInicio, sFechaFin, sDescripcion, sEstado, sIdTMeta, cboMeta.Text, 2);

            if (fTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sEstado == true)
                {
                    MessageBox.Show("El Tareo no se puede Eliminar.", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (sIdTTareo == 0 && dgvTareo.SelectedRows.Count > 0)
                {
                    MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Está seguro que desea el tareo", "Confirmar Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                CapaDeNegocios.Tareos.cTareoHorasAcumuladas miTareoHorasAcumuladas = new CapaDeNegocios.Tareos.cTareoHorasAcumuladas();
                miTareoHorasAcumuladas.EliminarTareoHorasAcumuladas(sIdTTareo);
                miTareo.EliminarTareo(sIdTTareo);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El tareo no se puede eliminar, porque ya ha asido usado en una planilla, o contiene datos:" + ex.Message);
            }
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalleTareo_Click(object sender, EventArgs e)
        {
            
            if (sIdTTareo == 0 || dgvTareo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CapaUsuario.Tareo.frmMantenimientoDetalleTareo fDetalleTareo = new CapaUsuario.Tareo.frmMantenimientoDetalleTareo();
            fDetalleTareo.RecibirDatos(sIdTTareo, sNumero, sFechaInicio, sFechaFin, sDescripcion, cboMeta.Text, sIdTMeta);
            if (fDetalleTareo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "(Colección)" && cboMeta.ValueMember != "")
            {
                sIdTMeta = Convert.ToInt32(cboMeta.SelectedValue);
                CargarDatos();
            }
        }

        private void dgvTareo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            { 
                sIdTTareo = Convert.ToInt32(dgvTareo.Rows[e.RowIndex].Cells[0].Value);
                sNumero = Convert.ToInt32(dgvTareo.Rows[e.RowIndex].Cells[1].Value);
                sDescripcion = Convert.ToString(dgvTareo.Rows[e.RowIndex].Cells[2].Value);
                sFechaInicio = Convert.ToDateTime(dgvTareo.Rows[e.RowIndex].Cells[3].Value);
                sFechaFin = Convert.ToDateTime(dgvTareo.Rows[e.RowIndex].Cells[4].Value);
                sEstado = Convert.ToBoolean(dgvTareo.Rows[e.RowIndex].Cells[5].Value);
            }
        }

        private void CargarAños()
        {
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cboAño.Items.Add(i);
            }
            cboAño.SelectedIndex = 0;
        }

        private void CargarMeta()
        {
            try
            {
                dgvTareo.Rows.Clear();
                CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
                CapaDeNegocios.ResidenteMeta.cResidenteMeta miResidenteMeta = new CapaDeNegocios.ResidenteMeta.cResidenteMeta();
                miTrabajador.IdTrabajador = Convert.ToInt32(cVariablesUsuario.v_idtrabajador);
                DataTable oDataMeta = new DataTable();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                oDataMeta = miCadena.ListarMetas();
                Dictionary<string, string> test = new Dictionary<string, string>();
                if (cVariablesUsuario.v_cargo == "ADMINISTRADOR")
                {
                    foreach (DataRow row in oDataMeta.Select("año = '" + cboAño.Text + "'"))
                    {
                        test.Add(row[0].ToString(), row[3].ToString() + " - " + row[2].ToString());
                    }
                }
                else
                {
                    foreach (DataRow rowResidenteMeta in miResidenteMeta.ListarResidenteMeta(miTrabajador).Rows)
                    {
                        string xx = rowResidenteMeta[1].ToString();
                        foreach (DataRow row in oDataMeta.Select("idtmeta = '" + rowResidenteMeta[1].ToString() + "' and año = '" + cboAño.Text + "'"))
                        {
                            test.Add(row[0].ToString(), row[3].ToString() + " - " + row[2].ToString());
                        }
                    }
                }
                cboMeta.DataSource = new BindingSource(test, null);
                cboMeta.DisplayMember = "Value";
                cboMeta.ValueMember = "Key";
            }
            catch
            { }
        }

        private void CargarDatos()
        {
            dgvTareo.Rows.Clear();
            foreach (DataRow row in miTareo.ListarTareo(sIdTMeta).Rows)
            {
                dgvTareo.Rows.Add(row[0].ToString(), row[1].ToString(), row[4].ToString(), row[2].ToString(), row[3].ToString(), Convert.ToBoolean(row[5]));
            }
            if (dgvTareo.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                dgvTareo.Rows[0].Selected = true;
                dgvTareo_CellClick(dgvTareo, cea);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //CapaUsuario.Reportes.MostrarReportes fMostrarReportes = new CapaUsuario.Reportes.MostrarReportes();
                //fMostrarReportes.ReporteTareos("ReporteTareos", sIdTMeta, sIdTTareo);
                //fMostrarReportes.MdiParent = this.MdiParent;
                //fMostrarReportes.Show();

                //CapaUsuario.Reportes.MostrarReportes fMostrarReporte = new CapaUsuario.Reportes.MostrarReportes();
                //fMostrarReporte.ReporteTareos("ReporteTareosResumen", sIdTMeta, sIdTTareo);
                //fMostrarReporte.MdiParent = this.MdiParent;
                //fMostrarReporte.Show();

                CapaDeNegocios.Tareos.cImprimirTareo cImprimirTareo = new CapaDeNegocios.Tareos.cImprimirTareo();
                cImprimirTareo.oImprimirTareo = miTareo.ImprimirTareo(sIdTMeta, sIdTTareo);
                if (cImprimirTareo.oImprimirTareo.Rows.Count == 0)
                {
                    MessageBox.Show("El tareo esta vacio o no se encuentra el residente responsable de la meta: ");
                }
                else
                {
                    cImprimirTareo.fechainicio = sFechaInicio;
                    cImprimirTareo.Iniciar();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
