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
        DNI=0,
        NOMBRES=1,
        CARGO=2
    }

    public partial class frmBuscarTrabajador : Form
    {
        private cCatalogoBusqueda oCatalogo = new cCatalogoBusqueda();
        public cTrabajadorBuscado oTrabajadorBuscado;

        public frmBuscarTrabajador()
        {
            InitializeComponent();
        }

        private void frmBuscarTrabajador_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe escribir algun filtro para buscar");
            }
            else
            {
                switch (cboTipoBusqueda.SelectedIndex)
                {
                    case 0:
                        BuscarTrabajadores(enumTipoBusqueda.DNI, txtBusqueda.Text.Trim());
                        break;
                    case 1:
                        BuscarTrabajadores(enumTipoBusqueda.NOMBRES, txtBusqueda.Text.Trim());
                        break;
                    case 2:
                        BuscarTrabajadores(enumTipoBusqueda.CARGO, txtBusqueda.Text.Trim());
                        break;
                    default:
                        break;
                }
            }
        }

        private void CargaInicial()
        {
            cboTipoBusqueda.DataSource = Enum.GetValues(typeof(enumTipoBusqueda));
        }

        private void BuscarTrabajadores(enumTipoBusqueda tipo, string filtro)
        {
            dtgResultadosBusqueda.DataSource = oCatalogo.TraerTrabajadoresSegunFiltro(tipo, filtro);
            if (tipo == enumTipoBusqueda.CARGO)
            {
                dtgResultadosBusqueda.Columns["CARGO"].Visible = true;
            }
            else
            {
                dtgResultadosBusqueda.Columns["CARGO"].Visible = false;
            }
            
        }

        private void cboTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            dtgResultadosBusqueda.DataSource = null;
           
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cboTipoBusqueda.SelectedIndex)
            {
                case 0:
                    // Verifica si la tecla presionada no es un número o una tecla de control (como retroceso)
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        // Si no es un número, cancela el evento
                        e.Handled = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dtgResultadosBusqueda.SelectedRows.Count > 0)
            {
                oTrabajadorBuscado = (cTrabajadorBuscado)dtgResultadosBusqueda.SelectedRows[0].DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un trabajador", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
