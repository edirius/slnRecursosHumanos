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
    public partial class frmMantenimientoRenta5taAnt : Form
    {
        public cTrabajador oTrabajador;
        public CapaDeNegocios.RentaQuinta.cRenta5taAnteriores oRentaQuintaAnterior;

        public frmMantenimientoRenta5taAnt()
        {
            InitializeComponent();
        }

        private void frmMantenimientoRenta5taAnt_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            dtpFecha.Value = oRentaQuintaAnterior.Fecha;
            txtIngresos.Text = oRentaQuintaAnterior.Ingresos.ToString();
            txtRetencion.Text = oRentaQuintaAnterior.Retenciones.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIngresos.Text.Trim() == "" || txtRetencion.Text.Trim() == "")
                {
                    MessageBox.Show("Debe llenar los datos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    oRentaQuintaAnterior.Ingresos = Convert.ToDecimal(txtIngresos.Text);
                    oRentaQuintaAnterior.Retenciones = Convert.ToDecimal(txtRetencion.Text);
                    oRentaQuintaAnterior.Fecha = dtpFecha.Value;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
