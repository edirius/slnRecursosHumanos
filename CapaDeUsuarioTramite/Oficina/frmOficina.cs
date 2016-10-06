using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegociosTramite;

namespace CapaDeUsuarioTramite.Oficina
{
    public partial class frmOficina : Form
    {
        CapaDeNegociosTramite.Oficina.cOficina oOficina = new CapaDeNegociosTramite.Oficina.cOficina();
        public frmOficina()
        {
            InitializeComponent();
            CargarGrid();
        }
        public void CargarGrid()
        {
            dgvListarOficinas.DataSource =  oOficina.ListarOficina();
        }
    }
}
