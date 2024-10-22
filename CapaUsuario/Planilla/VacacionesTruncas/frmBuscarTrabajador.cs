using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Planilla.VacacionesTruncas
{
    public enum enumTipoBusqueda
    {
        porDni=0,
        porNombres=1,
        porCargo
    }
    public partial class frmBuscarTrabajador : Form
    {
        public frmBuscarTrabajador()
        {
            InitializeComponent();
        }

        private void frmBuscarTrabajador_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
