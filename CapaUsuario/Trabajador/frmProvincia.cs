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
    public partial class frmProvincia : Form
    {
        public cProvincia miProvincia;

        public frmProvincia()
        {
            InitializeComponent();
        }

        private void frmProvincia_Load(object sender, EventArgs e)
        {
            dtgListaProvincias.DataSource = miProvincia.ListarProvincias(miProvincia.MiDepartamento);

        }

        private void dtgListaProvincias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                miProvincia.Codigo = Convert.ToInt16(dtgListaProvincias.SelectedRows[0].Cells[1].Value.ToString());
                miProvincia.CodigoUbigeo = dtgListaProvincias.SelectedRows[0].Cells[3].Value.ToString();
                miProvincia.Descripcion = dtgListaProvincias.SelectedRows[0].Cells[4].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }


    }
}
