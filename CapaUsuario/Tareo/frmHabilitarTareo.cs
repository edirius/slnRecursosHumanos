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
    public partial class frmHabilitarTareo : Form
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

        public frmHabilitarTareo()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCronogramaTareo_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de habilitar el Tareo de Obra, se podra Modificar e incluso Eliminar.", "Gestión de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            miMeta.Codigo = sIdTMeta;
            miTareo.Estado = false;
            miTareo.ModificarTareo(miTareo, miMeta);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTareo.Rows.Clear();
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
                miTareo.IdTTareo = Convert.ToInt32(dgvTareo.Rows[e.RowIndex].Cells[0].Value);
                miTareo.Numero = Convert.ToInt32(dgvTareo.Rows[e.RowIndex].Cells[1].Value);
                miTareo.Descripcion = Convert.ToString(dgvTareo.Rows[e.RowIndex].Cells[2].Value);
                miTareo.FechaInicio = Convert.ToDateTime(dgvTareo.Rows[e.RowIndex].Cells[3].Value);
                miTareo.FechaFin = Convert.ToDateTime(dgvTareo.Rows[e.RowIndex].Cells[4].Value);
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
                DataTable oDataMeta = new DataTable();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                oDataMeta = miCadena.ListarMetas();
                Dictionary<string, string> test = new Dictionary<string, string>();
                foreach (DataRow row in oDataMeta.Select("año = '" + cboAño.Text + "'"))
                {
                    test.Add(row[0].ToString(), row[3].ToString() + " - " + row[2].ToString());
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

            foreach (DataGridViewRow item in dgvTareo.Rows)
            {
                if (Convert.ToBoolean(item.Cells[5].Value) == true)
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
            if (dgvTareo.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                dgvTareo.Rows[0].Selected = true;
                dgvTareo_CellClick(dgvTareo, cea);
            }
            dgvTareo.ClearSelection();
        }
    }
}
