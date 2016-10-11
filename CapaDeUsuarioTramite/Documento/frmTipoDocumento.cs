using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Documento
{
    public partial class frmTipoDocumento : Form
    {
        CapaDeNegociosTramite.Documento.cTipoDocumento miTipoDocumento = new CapaDeNegociosTramite.Documento.cTipoDocumento();
        public frmTipoDocumento()
        {
            InitializeComponent();
        }
        public void ActualizarLista()
        {
            dgvListarTipoDoc.DataSource = miTipoDocumento.ListarTipoDocumento();
        }
    }
}
