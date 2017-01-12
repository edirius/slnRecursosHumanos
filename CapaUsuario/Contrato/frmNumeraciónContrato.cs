using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace CapaUsuario.Contrato
{
    public partial class frmNumeracionContrato : Form
    {
        int sidtplantillacontrato = 0;
        CapaDeNegocios.Contrato.cContrato miContrato = new CapaDeNegocios.Contrato.cContrato();

        public frmNumeracionContrato()
        {
            InitializeComponent();
        }

        private void frmNumeracionContrato_Load(object sender, EventArgs e)
        {
            CargarPlanillaContrato();
        }

        private void cboPlantillaContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlantillaContrato.Text != "System.Data.DataRowView" && cboPlantillaContrato.ValueMember != "")
            {
                sidtplantillacontrato = Convert.ToInt32(cboPlantillaContrato.SelectedValue);
            }
            if (sidtplantillacontrato != 0)
            {
                CargarDatos();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void CargarPlanillaContrato()
        {
            CapaDeNegocios.Contrato.cPlantillaContrato miPlantillaContrato = new CapaDeNegocios.Contrato.cPlantillaContrato();
            cboPlantillaContrato.DataSource = miPlantillaContrato.ListarPlantillaContrato();
            cboPlantillaContrato.DisplayMember = "descripcion";
            cboPlantillaContrato.ValueMember = "idtplantillacontrato";
            if (sidtplantillacontrato == 0) { cboPlantillaContrato.SelectedIndex = -1; }
            else { cboPlantillaContrato.SelectedValue = sidtplantillacontrato.ToString(); }
        }

        private void CargarDatos()
        {
            DataTable oDataContrato = new DataTable();
            oDataContrato = miContrato.ListarContrato(0);
            foreach (DataRow row in oDataContrato.Select("idtplantillacontrato = '" + sidtplantillacontrato + "'"))
            {
                //srutaarchivo = row[2].ToString();
            }
        }
    }
}
