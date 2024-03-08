using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmDarDeAlta : Form
    {
        public frmDarDeAlta()
        {
            InitializeComponent();
        }

        private void frmDarDeAlta_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void CargarAños()
        {
            string años = "";
            for (int i = DateTime.Now.Year; i >= 2020; i--)
            {
                cbAños.Items.Add(i);
            }
            cbAños.Text = años;
            cbAños.Text = Convert.ToString(DateTime.Now.Year);
        }
    }
}
