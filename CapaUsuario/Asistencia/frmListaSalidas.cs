using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Asistencia;

namespace CapaUsuario.Asistencia
{
    public partial class frmListaSalidas : Form
    {
        public CapaDeNegocios.cTrabajador miTrabajador;

        private cCatalogoAsistencia oCatalogoAsistencia = new cCatalogoAsistencia();
  
        public frmListaSalidas()
        {
            InitializeComponent();
        }

        private void frmListaSalidas_Load(object sender, EventArgs e)
        {
            Iniciar();
            
        }

        private void Iniciar()
        {
            dtpMes.Value = DateTime.Now;
            CargarSalidas();
        }

        private void CargarSalidas()
        {
            List<cExcepcionesAsistencia> ListaSalidas = new List<cExcepcionesAsistencia>();

            ListaSalidas = oCatalogoAsistencia.ListaSalidasXMes(miTrabajador, dtpMes.Value);

            dtgListaSalidas.DataSource = ListaSalidas;
        }

        private void dtpMes_ValueChanged(object sender, EventArgs e)
        {
            CargarSalidas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                frmMantenimientoSalidas fMantenimientoSalidas = new frmMantenimientoSalidas();
                fMantenimientoSalidas.oSalidaTrabajador = new CapaDeNegocios.Asistencia.cExcepcionesAsistencia();
                fMantenimientoSalidas.oSalidaTrabajador.InicioExcepcion = DateTime.Now.Date.AddHours(8);
                fMantenimientoSalidas.oSalidaTrabajador.FinExcepcion = DateTime.Now;
                fMantenimientoSalidas.oSalidaTrabajador.Trabajador = miTrabajador;

                if (fMantenimientoSalidas.ShowDialog() == DialogResult.OK)
                {
                    oCatalogoAsistencia.IngresarNuevaSalida(fMantenimientoSalidas.oSalidaTrabajador);
                    CargarSalidas();
                    MessageBox.Show("Se ingreso correctamente.", "Ingreso salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Se canceló la operación.", "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la salida: " + ex.Message, "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaSalidas.SelectedRows.Count > 0)
                {
                    frmMantenimientoSalidas fMantenimientoSalidas = new frmMantenimientoSalidas();
                    fMantenimientoSalidas.oSalidaTrabajador = (CapaDeNegocios.Asistencia.cExcepcionesAsistencia)dtgListaSalidas.CurrentRow.DataBoundItem;
                    if (fMantenimientoSalidas.ShowDialog() == DialogResult.OK)
                    {
                        oCatalogoAsistencia.ModificarSalida(fMantenimientoSalidas.oSalidaTrabajador);
                        CargarSalidas();
                        MessageBox.Show("Se modificó correctamente la salida.", "Modificar salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operación.", "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una salida.", "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la salida: " + ex.Message, "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaSalidas.SelectedRows.Count > 0)
                {
                    CapaDeNegocios.Asistencia.cExcepcionesAsistencia osalida = (CapaDeNegocios.Asistencia.cExcepcionesAsistencia)dtgListaSalidas.CurrentRow.DataBoundItem;
                    if (MessageBox.Show("¿Dese eliminar la salida seleccionada?: Nro " + osalida.CodigoExcepcion, "Eliminar Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question)  == DialogResult.Yes)
                    {
                        oCatalogoAsistencia.EliminarSalida(osalida);
                        CargarSalidas();
                        MessageBox.Show("Se eliminó correctamente la salida.", "Eliminar salida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operación.", "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una salida.", "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la salida: " + ex.Message, "Mantenimiento Salidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
