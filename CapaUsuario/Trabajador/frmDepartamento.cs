using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;
namespace CapaUsuario.Trabajador
{
    public partial class frmDepartamento : Form
    {
        public cDepartamento miDepartamento = new cDepartamento();
        
        public frmDepartamento()
        {
            InitializeComponent();
        }

        private void dtgListaDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                miDepartamento.Codigo =Convert.ToInt16(dtgListaDepartamento.SelectedRows[0].Cells[0].Value.ToString());
                miDepartamento.CodigoUbigeo = dtgListaDepartamento.SelectedRows[0].Cells[1].Value.ToString();
                miDepartamento.Descripcion = dtgListaDepartamento.SelectedRows[0].Cells[2].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void frmDepartamento_Load(object sender, EventArgs e)
        {
            dtgListaDepartamento.DataSource = miDepartamento.ListaDepartamentos();
        }

        private void dtgListaDepartamento_Enter(object sender, EventArgs e)
        {
            toolDepartamento.Show("Presione ENTER para seleccionar el Departamento", dtgListaDepartamento);
        }

        private void dtgListaDepartamento_MouseEnter(object sender, EventArgs e)
        {
            toolDepartamento.Show("Presione ENTER para seleccionar el Departamento", dtgListaDepartamento);
        }

        private void dtgListaDepartamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgListaDepartamento.SelectedRows.Count > 0)
            {
                miDepartamento.Codigo = Convert.ToInt16(dtgListaDepartamento.SelectedRows[0].Cells[0].Value.ToString());
                miDepartamento.CodigoUbigeo = dtgListaDepartamento.SelectedRows[0].Cells[1].Value.ToString();
                miDepartamento.Descripcion = dtgListaDepartamento.SelectedRows[0].Cells[2].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Seleccione un departamento de la lista.");
            }
        }

        private void dtgListaDepartamento_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
