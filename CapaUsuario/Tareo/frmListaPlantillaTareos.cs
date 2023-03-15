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

namespace CapaUsuario.Tareo
{
    public partial class frmListaPlantillaTareos : Form
    {
        public CapaDeNegocios.Tareos.cPlantillaTareo oPlantillaTareo = new CapaDeNegocios.Tareos.cPlantillaTareo();

        public frmListaPlantillaTareos()
        {
            InitializeComponent();
        }

        private void frmListaPlantillaTareos_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos()
        {
            dtgPlantillaTareo.DataSource = oPlantillaTareo.ListarPlantillaTareos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Tareo.frmMantenimientoPlantillaTareo fNuevoPlantillaTareo = new frmMantenimientoPlantillaTareo();
                fNuevoPlantillaTareo.oPlantillaTareo = new CapaDeNegocios.Tareos.cPlantillaTareo();
                if (fNuevoPlantillaTareo.ShowDialog() == DialogResult.OK)
                {
                    oPlantillaTareo.CrearPlantillaTareo(fNuevoPlantillaTareo.oPlantillaTareo);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("Se cancelo la operacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la Plantilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgPlantillaTareo.SelectedRows.Count > 0)
                {
                    Tareo.frmMantenimientoPlantillaTareo fModificarPlantillaTareo = new frmMantenimientoPlantillaTareo();
                    fModificarPlantillaTareo.oPlantillaTareo = oPlantillaTareo.TraerPlantillaTareo(Convert.ToInt32(dtgPlantillaTareo.SelectedRows[0].Cells[0].Value));
                    if (fModificarPlantillaTareo.ShowDialog() == DialogResult.OK)
                    {
                        oPlantillaTareo.ModificarPlantillaTareo(fModificarPlantillaTareo.oPlantillaTareo);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Se cancelo la operacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Plantilla", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la Plantilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgPlantillaTareo.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Desea eliminar la plantilla de tareo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oPlantillaTareo.EliminarPlantillaTareo(Convert.ToInt32(dtgPlantillaTareo.SelectedRows[0].Cells[0].ToString()));
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Se cancelo la operacion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Plantilla", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la Plantilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
