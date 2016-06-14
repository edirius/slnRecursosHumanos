using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using CapaDeNegocios;

namespace CapaUsuario.Trabajador
{
    public partial class frmListaDistritos : Form
    {
        public cDistrito miDistrito;

        public frmListaDistritos()
        {
            InitializeComponent();
        }

        private void dtgListaDistritos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                miDistrito.Codigo = Convert.ToInt16(dtgListaDistritos.SelectedRows[0].Cells[0].Value.ToString());
                miDistrito.CodigoUbigeo = dtgListaDistritos.SelectedRows[0].Cells[2].Value.ToString();
                miDistrito.Descripcion = dtgListaDistritos.SelectedRows[0].Cells[3].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void frmListaDistritos_Load(object sender, EventArgs e)
        {
            dtgListaDistritos.DataSource = miDistrito.ListarDistritos(miDistrito.MiProvincia); 
        }
    }
}
