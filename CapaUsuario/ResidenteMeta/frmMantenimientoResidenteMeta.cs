using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.ResidenteMeta
{
    public partial class frmMantenimientoResidenteMeta : Form
    {
        int sIdTResidenteMeta = 0;
        int sIdTMeta = 0;
        int sIdTTrabajador = 0;
        private Utilidades.cUtilidades misUtilidades = new Utilidades.cUtilidades();
        CapaDeNegocios.ResidenteMeta.cResidenteMeta miResidenteMeta = new CapaDeNegocios.ResidenteMeta.cResidenteMeta();
        private List<CapaDeNegocios.ResidenteMeta.cResidenteMeta> ListaResidentesMeta = new List<CapaDeNegocios.ResidenteMeta.cResidenteMeta>();

        public frmMantenimientoResidenteMeta()
        {
            InitializeComponent();
        }

        private void frmMantenimientoResidenteMeta_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            cboAños.DataSource = misUtilidades.ListaAños();
        }

        private void btnResidente_Click(object sender, EventArgs e)
        {
            ResidenteMeta.frmBuscarTrabajadores fBuscarTrabajador = new ResidenteMeta.frmBuscarTrabajadores();
            if (fBuscarTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sIdTTrabajador = fBuscarTrabajador.sidttrabajador;
                txtTrabajador.Text = fBuscarTrabajador.strabajador;
                CargarDatos();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (sIdTTrabajador == 0)
            {
                MessageBox.Show("Debe seleccionar un trabajador", "Gestion del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ResidenteMeta.frmResidenteMeta fResidenteMeta = new ResidenteMeta.frmResidenteMeta();
            fResidenteMeta.RecibirDatos(0, sIdTTrabajador, txtTrabajador.Text, 1);
            if (fResidenteMeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sIdTResidenteMeta == 0 && dgvResidenteMeta.SelectedRows.Count > 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Está seguro que desea Desasignar la Meta del Residente", "Confirmar Desasignar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            CapaDeNegocios.ResidenteMeta.cResidenteMeta miResidenteMeta = new CapaDeNegocios.ResidenteMeta.cResidenteMeta();
            miResidenteMeta.IdtResidenteMeta = sIdTResidenteMeta;
            miResidenteMeta.EliminarResidenteMeta(miResidenteMeta);
            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvResidenteMeta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvResidenteMeta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) { 
                int iFila = this.dgvResidenteMeta.CurrentRow.Index;
                sIdTResidenteMeta = Convert.ToInt32(dgvResidenteMeta.Rows[iFila].Cells["IdTResidenteMeta"].Value);
                sIdTMeta = Convert.ToInt32(dgvResidenteMeta.Rows[iFila].Cells["IdTMeta"].Value);
            }
        }

        private void CargarDatos()
        {
            DataTable oDataTable, oDataTable1 = new DataTable();
            CapaDeNegocios.cTrabajador miTrabajador = new CapaDeNegocios.cTrabajador();
            
            miTrabajador.IdTrabajador = sIdTTrabajador;
            oDataTable = miResidenteMeta.ListarResidenteMeta(miTrabajador);

            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            oDataTable1 = miCadena.ListarMetas();

            dgvResidenteMeta.Rows.Clear();
            foreach (DataRow row in oDataTable.Rows)
            {
                foreach (DataRow row1 in oDataTable1.Select("idtmeta = '" + row[1].ToString() + "'"))
                {
                    dgvResidenteMeta.Rows.Add(row[0].ToString(), row1[0].ToString(), row1[1].ToString(), row1[3].ToString() + " - " + row1[2].ToString());
                }
            }
        }

        private void CargarResidentesMetas()
        {
            ListaResidentesMeta = miResidenteMeta.TraerResidenteMeta(Convert.ToInt16(cboAños.Text), chkMostrarTodasLasMetas.Checked);
            dtgResidenteMeta.DataSource = ListaResidentesMeta;
        }
        private void chkMostrarTodasLasMetas_CheckedChanged(object sender, EventArgs e)
        {
            CargarResidentesMetas();
        }

        private void cboAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarResidentesMetas();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            CapaDeNegocios.Reportes.General.cExcelGeneral miExcel = new CapaDeNegocios.Reportes.General.cExcelGeneral();

            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "xls (*.xls)|*.xls";
                fichero.FileName = "ReporteMetasAsignadas_" + cboAños.Text +".xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    miExcel.ExportarExcelResidenteMeta(ListaResidentesMeta, fichero.FileName);
                    bool estaAbierto = misUtilidades.ArchivoEstaAbierto(fichero.FileName);

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
                MessageBox.Show("Error al exportar Excel: " + ex.Message);
            }
        }

        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgResidenteMeta.SelectedRows.Count > 0)
                {
                    if (((CapaDeNegocios.cTrabajador)dtgResidenteMeta.SelectedRows[0].Cells["colMiTrabajador"].Value).IdTrabajador == 0)
                    {
                        ResidenteMeta.frmBuscarTrabajadores fBuscarTrabajador = new ResidenteMeta.frmBuscarTrabajadores();
                        if (fBuscarTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            CapaDeNegocios.Obras.cMeta oMeta = (CapaDeNegocios.Obras.cMeta)dtgResidenteMeta.SelectedRows[0].Cells["colMiMeta"].Value;
                            CapaDeNegocios.cTrabajador oTrabajador = new CapaDeNegocios.cTrabajador();
                            oTrabajador.IdTrabajador = fBuscarTrabajador.sidttrabajador;
                            miResidenteMeta.CrearResidenteMeta(oMeta, oTrabajador);
                            MessageBox.Show("Trabajador asignado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarResidentesMetas();
                        }
                        else
                        {
                            MessageBox.Show("Se cancelo la operacion", "Operacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("La meta ya esta asignada: ¿Desea asignar otro residente?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                        {
                            ResidenteMeta.frmBuscarTrabajadores fBuscarTrabajador = new ResidenteMeta.frmBuscarTrabajadores();
                            if (fBuscarTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                CapaDeNegocios.Obras.cMeta oMeta = (CapaDeNegocios.Obras.cMeta)dtgResidenteMeta.SelectedRows[0].Cells["colMiMeta"].Value;
                                CapaDeNegocios.cTrabajador oTrabajador = new CapaDeNegocios.cTrabajador();
                                oTrabajador.IdTrabajador = fBuscarTrabajador.sidttrabajador;
                                miResidenteMeta.CrearResidenteMeta(oMeta, oTrabajador);
                                MessageBox.Show("Trabajador asignado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarResidentesMetas();
                            }
                            else
                            {
                                MessageBox.Show("Se cancelo la operacion", "Operacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Se cancelo la operacion", "Operacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una meta", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar al trabajador: " + ex.Message);
            }
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgResidenteMeta.SelectedRows.Count > 0)
                {
                    if (((CapaDeNegocios.cTrabajador)dtgResidenteMeta.SelectedRows[0].Cells["colMiTrabajador"].Value).IdTrabajador == 0)
                    {
                        MessageBox.Show("No esta asignado ningun trabajador", "Operacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        CapaDeNegocios.Obras.cMeta oMeta = (CapaDeNegocios.Obras.cMeta)dtgResidenteMeta.SelectedRows[0].Cells["colMiMeta"].Value;
                        CapaDeNegocios.cTrabajador oTrabajador = (CapaDeNegocios.cTrabajador)dtgResidenteMeta.SelectedRows[0].Cells["colMiTrabajador"].Value;
                        CapaDeNegocios.ResidenteMeta.cResidenteMeta oResidenteMeta = new CapaDeNegocios.ResidenteMeta.cResidenteMeta();
                        
                        if (MessageBox.Show("Desea desasignar al trabajador: " + oTrabajador.Nombres + " " + oTrabajador.ApellidoPaterno + " " + oTrabajador.ApellidoMaterno + " a la meta: " + oMeta.Numero, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            oResidenteMeta.IdtResidenteMeta = Convert.ToInt32(dtgResidenteMeta.SelectedRows[0].Cells["colidtresidentemeta"].Value);
                            oResidenteMeta.MiMeta = oMeta;
                            oResidenteMeta.MiTrabajador = oTrabajador;
                            miResidenteMeta.EliminarResidenteMeta(oResidenteMeta);
                            MessageBox.Show("Trabajador desasignado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarResidentesMetas();
                        }
                        else
                        {
                            MessageBox.Show("Se cancelo la operacion", "Operacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una meta", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desasignar al trabajador: " + ex.Message);
            }
        }

        private void dtgResidenteMeta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dtgResidenteMeta.Rows[e.RowIndex];
            if (((CapaDeNegocios.cTrabajador)row.Cells["colMiTrabajador"].Value).IdTrabajador == 0 && e.ColumnIndex ==4 )
            {
                e.CellStyle.ForeColor = Color.Blue;
                //DataGridViewCellStyle miestilo = new DataGridViewCellStyle();
                //miestilo.ForeColor = Color.Blue;
                //row.Cells["colMiTrabajador"].Style = miestilo;
            }
        }
    }
}
