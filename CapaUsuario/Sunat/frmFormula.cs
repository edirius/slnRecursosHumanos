using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Sunat
{
    public partial class frmFormula : Form
    {
        public frmFormula()
        {
            InitializeComponent();
        }

        private void frmFormula_Load(object sender, EventArgs e)
        {

        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txtFormula.Text != "")
            {
                if (txtFormula.Text.Length >= 2)
                {
                    string x = txtFormula.Text.Substring(txtFormula.Text.Length - 2);
                    if (x == "ao" || x == "ps")
                    {
                        i = txtFormula.Text.Length - 2;
                    }
                    else
                    {
                        i = txtFormula.Text.Length - 1;
                    }
                }
                else
                {
                    i = txtFormula.Text.Length - 1;
                }
                txtFormula.Text = txtFormula.Text.Substring(0, i);
            }
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "+";
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "-";
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "*";
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "/";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + ".";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "9";
        }

        private void btnAObligatorio_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "ao";
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "c";
        }

        private void btnPSeguro_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "ps";
        }

        private void btnSueldo_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "s";
        }

        private void btnParentesis1_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "(";
        }

        private void btnParentesis2_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + ")";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
 
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public void RecibirDatos(string pFormula)
        {
            txtFormula.Text = pFormula;
        }

        public String Formula()
        {
           
            return txtFormula.Text;
        }

        private void btnDias_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "dd";
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "mm";
        }

        private void chkTipoRegimen_Click(object sender, EventArgs e)
        {
            string miFormula = txtFormula.Text;

            if (chkTipoRegimen.Checked)
            {
                txtFormula.Text = txtFormula.Text + "&&p";
            }
            else
            {
                 int index = miFormula.IndexOf("&&p");
                if (index != -1)
                {
                    miFormula = miFormula.Substring(0, index);
                }
                txtFormula.Text = miFormula;
            }
        }

        private void btnDiasInicio_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "zz";
        }

        private void btnMesesInicio_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "yy";
        }

        private void btnSueldoXdiasmes_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "rt";
        }

        private void btnSueldoAfecto_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "ra";
        }
    
    }
}
