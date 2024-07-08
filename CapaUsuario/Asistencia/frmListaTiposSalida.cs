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
    public partial class frmListaTiposSalida : Form
    {
        private cTipoSalida TipoSalida = new cTipoSalida();

        public frmListaTiposSalida()
        {
            InitializeComponent();
        }

        private void frmListaTiposSalida_Load(object sender, EventArgs e)
        {
            Iniciar();
        }
        private void Iniciar()
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dtgTipoSalidas.DataSource = TipoSalida.TraerTiposSalida();
        }

        private void btnNuevoTipoSalida_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoTipoSalida fMantenimientoTipoSalida = new frmMantenimientoTipoSalida();
                fMantenimientoTipoSalida.TipoSalida = new cTipoSalida();
                if (fMantenimientoTipoSalida.ShowDialog() == DialogResult.OK)
                {
                    TipoSalida.IngresarTipoSalida(fMantenimientoTipoSalida.TipoSalida);
                    MessageBox.Show("Se creo el tipo de salida.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Se canceló la operación.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el tipo de salida:" + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModificarTipoSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgTipoSalidas.SelectedRows.Count > 0)
                {
                    frmMantenimientoTipoSalida fMantenimientoTipoSalida = new frmMantenimientoTipoSalida();
                    fMantenimientoTipoSalida.TipoSalida = new cTipoSalida();
                    fMantenimientoTipoSalida.TipoSalida.Descripcion = dtgTipoSalidas.SelectedRows[0].Cells[1].Value.ToString();
                    fMantenimientoTipoSalida.TipoSalida.Codigo = Convert.ToInt32(dtgTipoSalidas.SelectedRows[0].Cells[0].Value);
                    if (fMantenimientoTipoSalida.ShowDialog() == DialogResult.OK)
                    {
                        TipoSalida.ModificarTipoSalida(fMantenimientoTipoSalida.TipoSalida);
                        MessageBox.Show("Se modificó el tipo de salida.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operación.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Tipo de Salida para modificarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el tipo de salida:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarTipoSalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgTipoSalidas.SelectedRows.Count > 0)
                {
                    frmMantenimientoTipoSalida fMantenimientoTipoSalida = new frmMantenimientoTipoSalida();
                    fMantenimientoTipoSalida.TipoSalida = new cTipoSalida();
                    fMantenimientoTipoSalida.TipoSalida.Descripcion = dtgTipoSalidas.SelectedRows[0].Cells[1].Value.ToString();
                    fMantenimientoTipoSalida.TipoSalida.Codigo = Convert.ToInt32(dtgTipoSalidas.SelectedRows[0].Cells[0].Value);
                    if (MessageBox.Show("Desea eliminar el tipo de salida", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        TipoSalida.EliminarTipoSalida(fMantenimientoTipoSalida.TipoSalida);
                        MessageBox.Show("Se eliminó el tipo de salida.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operación.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Tipo de Salida para modificarlo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el tipo de salida:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
