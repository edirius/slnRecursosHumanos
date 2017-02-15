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

        public frmMantenimientoResidenteMeta()
        {
            InitializeComponent();
        }

        private void frmMantenimientoResidenteMeta_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show("Debe seleccionar un trabjador", "Gestion del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CapaDeNegocios.ResidenteMeta.cResidenteMeta miResidenteMeta = new CapaDeNegocios.ResidenteMeta.cResidenteMeta();
            miTrabajador.IdTrabajador = sIdTTrabajador;
            oDataTable = miResidenteMeta.ListarResidenteMeta(miTrabajador);

            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            oDataTable1 = miCadena.ListarMetas();

            dgvResidenteMeta.Rows.Clear();
            foreach (DataRow row in oDataTable.Rows)
            {
                foreach (DataRow row1 in oDataTable1.Select("idtmeta = '" + row[1].ToString() + "'"))
                {
                    dgvResidenteMeta.Rows.Add(row[0].ToString(), row1[0].ToString(), row1[1].ToString(), row1[2].ToString());
                }
            }
        }
    }
}
