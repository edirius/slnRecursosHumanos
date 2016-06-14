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
    public partial class frmTipoVia : Form
    {
        public cTipoVia miTipoVia = new cTipoVia();

        public frmTipoVia()
        {
            InitializeComponent();
        }

        private void frmTipoVia_Load(object sender, EventArgs e)
        {
            dtgListaTipoVia.DataSource = miTipoVia.ListaTiposVia(); 
        }

        private void dtgListaTipoVia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                miTipoVia.Codigo = Convert.ToInt16(dtgListaTipoVia.SelectedRows[0].Cells[0].Value.ToString());
                miTipoVia.CodigoSunat = dtgListaTipoVia.SelectedRows[0].Cells[1].Value.ToString();
                miTipoVia.Descripcion = dtgListaTipoVia.SelectedRows[0].Cells[2].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
