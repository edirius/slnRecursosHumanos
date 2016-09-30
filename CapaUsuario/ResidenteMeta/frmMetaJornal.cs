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
    public partial class frmMetaJornal : Form
    {
        DataTable oDataMetaJornal = new DataTable();
        int sidtmeta = 0;

        CapaDeNegocios.Obras.cMeta miMeta = new CapaDeNegocios.Obras.cMeta();
        CapaDeNegocios.Obras.cMetaJornal miMejaJornal = new CapaDeNegocios.Obras.cMetaJornal();

        public frmMetaJornal()
        {
            InitializeComponent();
        }

        private void frmMetaJornal_Load(object sender, EventArgs e)
        {
            CargarAños();
            cboAño_SelectedIndexChanged(sender, e);
        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            dgvMetaJornal.Rows.Clear();
            dgvMetaJornal.Rows.Add("I", "0", "MAESTRO DE OBRA", "0");
            dgvMetaJornal.Rows.Add("I", "0", "OPERARIO", "0");
            dgvMetaJornal.Rows.Add("I", "0", "OFICIAL", "0");
            dgvMetaJornal.Rows.Add("I", "0", "PEON", "0");
            dgvMetaJornal.Rows.Add("I", "0", "ALMACENERO", "0");
            dgvMetaJornal.Rows.Add("I", "0", "GUARDIAN", "0");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            foreach (DataGridViewRow row in dgvMetaJornal.Rows)
            {
                miMejaJornal.IdtMetaJornal = Convert.ToInt32(row.Cells[1].Value);
                miMejaJornal.Categoria = Convert.ToString(row.Cells[2].Value);
                miMejaJornal.Jornal = Convert.ToDouble(row.Cells[3].Value);
                miMeta.Codigo = sidtmeta;
                if (Convert.ToString(row.Cells[0].Value) == "I")
                {
                    miMejaJornal.CrearMetaJornal(miMejaJornal, miMeta);
                    oDataMetaJornal = miMejaJornal.ListarMetaJornal(miMeta.Codigo);
                    miMejaJornal.IdtMetaJornal = Convert.ToInt32(oDataMetaJornal.Compute("MAX(idtmetajornal)", ""));
                    row.Cells[1].Value = miMejaJornal.IdtMetaJornal.ToString();
                    row.Cells[0].Value = "M";
                    bOk = true;
                }
                if (Convert.ToString(row.Cells[0].Value) == "M")
                {
                    miMejaJornal.ModificarMetaJornal(miMejaJornal, miMeta);
                    bOk = true;
                }
            }
            if (bOk == false)
            {
                MessageBox.Show("No existen datos que se puedan registrar", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CargarDatos();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeta.Text != "System.Data.DataRowView" && cboMeta.ValueMember != "")
            {
                sidtmeta = Convert.ToInt32(cboMeta.SelectedValue);
                CargarDatos();
            }
        }

        private void CargarMeta()
        {
            if (cboAño.Text != "")
            {
                DataTable oDataMeta = new DataTable();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                oDataMeta = miMeta.ListarMetas();
                Dictionary<string, string> test = new Dictionary<string, string>();
                foreach (DataRow row in oDataMeta.Select("año = '" + cboAño.Text + "'"))
                {
                    test.Add(row[0].ToString(), row[3].ToString() + " - " + row[2].ToString());
                }
                cboMeta.DataSource = new BindingSource(test, null);
                cboMeta.DisplayMember = "Value";
                cboMeta.ValueMember = "Key";
            }
            if (sidtmeta == 0) { cboMeta.SelectedIndex = -1; }
            else { cboMeta.SelectedValue = sidtmeta.ToString(); }
        }

        private void CargarDatos()
        {
            dgvMetaJornal.Rows.Clear();
            oDataMetaJornal = miMejaJornal.ListarMetaJornal(sidtmeta);
            if (oDataMetaJornal.Rows.Count == 0)
            {
                btnCategorias.Enabled = true;
            }
            else
            {
                btnCategorias.Enabled = false;
                foreach (DataRow row in oDataMetaJornal.Rows)
                {
                    dgvMetaJornal.Rows.Add("M", row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
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
    }
}
