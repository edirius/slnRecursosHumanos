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
            dgvContratos.Rows.Clear();
            int columna = 0;
            int fila = 0;
            int ultimonro = 0;
            if (miContrato.ListarNumeroContrato(sidtplantillacontrato).Rows.Count <= 10)
            {
                dgvContratos.Rows.Add();
            }
            else if (miContrato.ListarNumeroContrato(sidtplantillacontrato).Rows.Count <= 20)
            {
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
            }
            else if (miContrato.ListarNumeroContrato(sidtplantillacontrato).Rows.Count <= 30)
            {
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
            }
            else if (miContrato.ListarNumeroContrato(sidtplantillacontrato).Rows.Count <= 40)
            {
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
            }
            else if (miContrato.ListarNumeroContrato(sidtplantillacontrato).Rows.Count <= 50)
            {
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
                dgvContratos.Rows.Add();
            }

            foreach (DataRow row in miContrato.ListarNumeroContrato(sidtplantillacontrato).Rows)
            {
                ultimonro = Convert.ToInt32(row[2]);
                dgvContratos.Rows[fila].Cells[columna].Style.BackColor = Color.Red;
                dgvContratos.Rows[fila].Cells[columna].Value = row[2].ToString();
                columna += 1;
                if (columna == 10)
                {
                    fila += 1;
                }
            }
            if (ultimonro < 10)
            {
                dgvContratos.Rows[fila].Cells[columna].Value = "0" + (ultimonro + 1);
            }
            else
            {
                dgvContratos.Rows[fila].Cells[columna].Value = ultimonro + 1;
            }
            dgvContratos.ClearSelection();
        }
    }
}
