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
        public string snumerocontrato = "";
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

        private void dgvContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvContratos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContratos.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor != Color.Red)
            {
                snumerocontrato = dgvContratos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("El numero selecionado ya esta utilizado.", "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void RecibirDatos(int pidtplantillacontrato)
        {
            sidtplantillacontrato = pidtplantillacontrato;
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
            int ultimonro = 0;
            string nroactual = "";
            DataTable oDataNumeroContrato = new DataTable();
            oDataNumeroContrato = miContrato.ListarNumeroContrato(sidtplantillacontrato);
            ultimonro = 10;//oDataNumeroContrato.Select("").ToString();

            for (int i = 0; i <= (ultimonro / 10); i++)
            {
                dgvContratos.Rows.Add();
                for (int j = 0; j < 10; j++)
                {
                    if (j + 1 < 10)
                    {
                        nroactual = i.ToString() + (j + 1).ToString();
                    }
                    else
                    {
                        nroactual = (i + 1).ToString() + "0";
                    }

                    foreach (DataRow row in miContrato.ListarNumeroContrato(sidtplantillacontrato).Rows)
                    {
                        if (nroactual == row[2].ToString())
                        {
                            dgvContratos.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        }
                    }
                    dgvContratos.Rows[i].Cells[j].Value = nroactual;
                }
            }
            dgvContratos.ClearSelection();
        }
    }
}
