using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Metas
{
    public partial class frmVincularMetas : Form
    {
        int saño = 0;
        public int sidtmeta = 0;
        public string sdescripcion = "";

        public frmVincularMetas()
        {
            InitializeComponent();
        }

        private void frmVincularMetas_Load(object sender, EventArgs e)
        {
            CargarMeta();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (sidtmeta == 0)
            {
                MessageBox.Show("Debe seleccionar nuevamente los datos", "Gestión del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgvTareo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                sidtmeta = Convert.ToInt32(dgvMetas.Rows[e.RowIndex].Cells[0].Value);
                sdescripcion = Convert.ToString(dgvMetas.Rows[e.RowIndex].Cells[1].Value) + " - " + Convert.ToString(dgvMetas.Rows[e.RowIndex].Cells[2].Value);
            }
        }

        public void RecibirDatos(int paño)
        {
            saño = paño;
        }

        private void CargarMeta()
        {
            if (saño != 0)
            {
                dgvMetas.Rows.Clear();
                DataTable oDataMeta = new DataTable();
                CapaDeNegocios.Obras.cCadenaProgramaticaFuncional miMeta = new CapaDeNegocios.Obras.cCadenaProgramaticaFuncional();
                oDataMeta = miMeta.ListarMetas();
                foreach (DataRow row in oDataMeta.Select("año = '" + (saño - 1) + "'"))
                {
                    dgvMetas.Rows.Add(row[0].ToString(), row[3].ToString(), row[2].ToString());
                }
            }
            if (dgvMetas.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                dgvMetas.Rows[0].Selected = true;
                dgvTareo_CellClick(dgvMetas, cea);
            }
        }
    }
}
