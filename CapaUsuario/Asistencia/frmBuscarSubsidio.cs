using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Asistencia
{
    public partial class frmBuscarSubsidio : Form
    {
        public int sidttiposuspencionlaboral = 0;
        bool ssubsidio = false;
        public frmBuscarSubsidio()
        {
            InitializeComponent();
        }

        private void frmBuscarSubsidio_Load(object sender, EventArgs e)
        {
            CargarDatos();
            cboTipoSuspencionLaboral_SelectedIndexChanged(sender, e);
        }

        public void RecibirDatos(bool psubsidio)
        {
            ssubsidio = psubsidio;
        }

        private void CargarDatos()
        {
            DataTable oDataMeta = new DataTable();
            CapaDeNegocios.Sunat.cTipoSuspencionLaboral miTipoSuspencionLaboral= new CapaDeNegocios.Sunat.cTipoSuspencionLaboral();
            oDataMeta = miTipoSuspencionLaboral.ListarTipoSuspencionLaboral();

            Dictionary<string, string> test = new Dictionary<string, string>();
            foreach (DataRow row in oDataMeta.Select("subsidiado = '" + ssubsidio + "'"))
            {
                test.Add(row[0].ToString(), row[1].ToString() + " - " + row[3].ToString());
            }
            cboTipoSuspencionLaboral.DataSource = new BindingSource(test, null);
            cboTipoSuspencionLaboral.DisplayMember = "Value";
            cboTipoSuspencionLaboral.ValueMember = "Key";
        }

        private void cboTipoSuspencionLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoSuspencionLaboral.Text != "(Colección)" && cboTipoSuspencionLaboral.ValueMember != "")
            {
                sidttiposuspencionlaboral = Convert.ToInt32(cboTipoSuspencionLaboral.SelectedValue);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
