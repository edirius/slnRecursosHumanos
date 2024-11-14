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
    public partial class frmImportarPeriodo : Form
    {
        cCatalogoBusqueda oCatalogo = new cCatalogoBusqueda();

        public List<cPeriodoTrabajador> PeriodosBuscados = new List<cPeriodoTrabajador>();

        public frmImportarPeriodo()
        {
            InitializeComponent();
        }

        cTrabajadorBuscado oTrabajadorBuscado = new cTrabajadorBuscado();

        private void btnAgregarTrabajador_Click(object sender, EventArgs e)
        {
            frmBuscarTrabajador fBuscarTrabajador = new frmBuscarTrabajador();
            if (fBuscarTrabajador.ShowDialog() == DialogResult.OK)
            {
                oTrabajadorBuscado = fBuscarTrabajador.oTrabajadorBuscado;
                lblTrabajador.Text = "DNI: " + oTrabajadorBuscado.DNI + " " + oTrabajadorBuscado.NOMBRES + " " + oTrabajadorBuscado.APELLIDOPATERNO + " " + oTrabajadorBuscado.APELLIDOMATERNO;
                List<cPeriodoTrabajador> ListaPeriodos =  oCatalogo.TraerPeriodoTrabajador(oTrabajadorBuscado.CODIGOTRABAJADOR);
                CargarDatos(ListaPeriodos);
            }
            else
            {
                MessageBox.Show("Se canceló la informacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarDatos(List<cPeriodoTrabajador> Lista)
        {
            dtgListaPeriodos.DataSource = Lista;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dtgListaPeriodos.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtgListaPeriodos.Rows[i].Cells["check"].Value) == true)
                    {
                        PeriodosBuscados.Add((cPeriodoTrabajador)dtgListaPeriodos.Rows[i].DataBoundItem);
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
