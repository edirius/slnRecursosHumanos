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

namespace CapaUsuario.TablasParametricas
{
    public partial class frmTributosyDescuentosTrabajador : Form
    {
        CapaDeNegocios.TablasParametricas.cExportarTextoSunat oExportar = new CapaDeNegocios.TablasParametricas.cExportarTextoSunat();
        public frmTributosyDescuentosTrabajador()
        {
            InitializeComponent();
        }
    }
}
