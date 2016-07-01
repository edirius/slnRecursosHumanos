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
            CargarMeta();
            cboMeta_SelectedIndexChanged(sender, e);
        }

        private void btnMeta_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            foreach (DataGridViewRow row in dgvMetaJornal.Rows)
            {
                miMejaJornal.IdtMetaJornal = Convert.ToInt32(row.Cells[1].Value);
                miMejaJornal.Categoria = Convert.ToString(row.Cells[2].Value);
                miMejaJornal.Jornal = Convert.ToInt32(row.Cells[3].Value);
                if (Convert.ToString(row.Cells[0].Value) == "I")
                {
                    miMejaJornal.CrearMetaJornal(miMejaJornal, miMeta);
                    oDataMetaJornal = miMejaJornal.ListarMetaJornal(miMeta);
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
            CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miCadena = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
            cboMeta.DataSource = miCadena.ListarMetas();
            cboMeta.DisplayMember = "nombre";
            cboMeta.ValueMember = "idtmeta";
        }

        private void CargarDatos()
        {
            dgvMetaJornal.Rows.Clear();
            miMeta.Codigo = sidtmeta;
            oDataMetaJornal = miMejaJornal.ListarMetaJornal(miMeta);
            int x = oDataMetaJornal.Rows.Count;
            if (oDataMetaJornal.Rows.Count == 0)
            {
                dgvMetaJornal.Rows.Add("I", "0", "MAESTRO DE OBRA", "0");
                dgvMetaJornal.Rows.Add("I", "0", "OPERARIO", "0");
                dgvMetaJornal.Rows.Add("I", "0", "OFICIAL", "0");
                dgvMetaJornal.Rows.Add("I", "0", "PEON", "0");
            }
            else
            {
                foreach (DataRow row in oDataMetaJornal.Rows)
                {
                    dgvMetaJornal.Rows.Add("M", row[0].ToString(), row[1].ToString(), row[2].ToString());
                }
            }
        }
    }
}
