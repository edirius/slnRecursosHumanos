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
    public partial class frmListaRenta5taAnteriores : Form
    {
        public cTrabajador oTrabajador;

        private CapaDeNegocios.RentaQuinta.cRenta5taAnteriores oRenta = new CapaDeNegocios.RentaQuinta.cRenta5taAnteriores();
        public frmListaRenta5taAnteriores()
        {
            InitializeComponent();
        }

        private void frmListaRenta5taAnteriores_Load(object sender, EventArgs e)
        {
            CargarAños();
            lblNombreTrabajador.Text = "Trabajador: " +  oTrabajador.Nombres + " " + oTrabajador.ApellidoPaterno + " " + oTrabajador.ApellidoMaterno;
        }

        private void CargarAños()
        {
            string años = "";
            for (int i = DateTime.Now.Year; i >= 2015; i--)
            {
                cboAnio.Items.Add(i);
            }
            cboAnio.Text = años;
            cboAnio.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoRenta5taAnt fNuevaRenta5ta = new frmMantenimientoRenta5taAnt();
                fNuevaRenta5ta.oTrabajador = oTrabajador;
                fNuevaRenta5ta.oRentaQuintaAnterior = new CapaDeNegocios.RentaQuinta.cRenta5taAnteriores();
                fNuevaRenta5ta.oRentaQuintaAnterior.Fecha = DateTime.Now;
                fNuevaRenta5ta.oRentaQuintaAnterior.Trabajador = oTrabajador;
                if (fNuevaRenta5ta.ShowDialog() == DialogResult.OK)
                {
                    fNuevaRenta5ta.oRentaQuintaAnterior.CrearRenta5taAnterior(fNuevaRenta5ta.oRentaQuintaAnterior);
                    MessageBox.Show("Datos guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarRentas();
                }
                else
                {
                    MessageBox.Show("Operacion cancelada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la renta de 5ta categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaRenta5ta.SelectedRows.Count > 0)
                {
                    frmMantenimientoRenta5taAnt fNuevaRenta5ta = new frmMantenimientoRenta5taAnt();
                    fNuevaRenta5ta.oTrabajador = oTrabajador;
                    fNuevaRenta5ta.oRentaQuintaAnterior = new CapaDeNegocios.RentaQuinta.cRenta5taAnteriores();
                    fNuevaRenta5ta.oRentaQuintaAnterior = fNuevaRenta5ta.oRentaQuintaAnterior.TraerRenta5taAnteriores(Convert.ToInt32(dtgListaRenta5ta.SelectedRows[0].Cells[0].Value));
                    fNuevaRenta5ta.oRentaQuintaAnterior.Trabajador = oTrabajador;
                    if (fNuevaRenta5ta.ShowDialog() == DialogResult.OK)
                    {
                        fNuevaRenta5ta.oRentaQuintaAnterior.ModificarRenta5taAnterior(fNuevaRenta5ta.oRentaQuintaAnterior);
                        MessageBox.Show("Datos guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarRentas();
                    }
                    else
                    {
                        MessageBox.Show("Operacion cancelada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una renta de 5ta para modificarla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la renta de 5ta categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaRenta5ta.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Desea eliminar la renta de 5ta categoria?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        oRenta.EliminarRenta5taAnterior( oRenta.TraerRenta5taAnteriores(Convert.ToInt32(dtgListaRenta5ta.SelectedRows[0].Cells[0].Value)));
                        cargarRentas();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una renta de 5ta para eliminarla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la renta de 5ta categoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarRentas();
            
        }

        private void cargarRentas()
        {
            dtgListaRenta5ta.DataSource = oRenta.ListarRenta5taAnteriores(oTrabajador, Convert.ToInt16(cboAnio.Text));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
