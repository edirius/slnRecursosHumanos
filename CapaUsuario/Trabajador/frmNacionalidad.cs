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
    public partial class frmNacionalidad : Form
    {

        public cNacionalidad miNacionalidad = new cNacionalidad();
        public frmNacionalidad()
        {
            InitializeComponent();
        }

        private void frmNacionalidad_Load(object sender, EventArgs e)
        {
            dtgNacionalidad.DataSource = miNacionalidad.listaNacionalidades();
        }

        private void dtgNacionalidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                miNacionalidad.Codigo = Convert.ToInt16 ( dtgNacionalidad.SelectedRows[0].Cells[0].Value.ToString());
                miNacionalidad.CodigoSunat = dtgNacionalidad.SelectedRows[0].Cells[1].Value.ToString();
                miNacionalidad.Descripcion = dtgNacionalidad.SelectedRows[0].Cells[2].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
