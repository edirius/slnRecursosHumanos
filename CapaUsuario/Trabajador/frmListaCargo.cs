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
using CapaDeNegocios.Contrato;

namespace CapaUsuario.Trabajador
{
    public partial class frmListaCargo : Form
    {
        public cCargo miCargo;

        public frmListaCargo()
        {
            InitializeComponent();
        }

        private void frmListaCargo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            miCargo = new cCargo();
            dtgListaCargos.DataSource = miCargo.ListaCargos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frnNuevoCargo fCargo = new frnNuevoCargo();
                fCargo.miCargo = new cCargo();
                if (fCargo.ShowDialog() == DialogResult.OK)
                {
                    miCargo.AgregarCargo(fCargo.miCargo);
                    dtgListaCargos.DataSource = miCargo.ListaCargos();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("Error al agregar cargo: " + f.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                frnNuevoCargo fCargo = new frnNuevoCargo();
                fCargo.miCargo = new cCargo();
                if (dtgListaCargos.SelectedRows.Count > 0)
                {
                    fCargo.miCargo.Codigo = Convert.ToInt16(dtgListaCargos.SelectedRows[0].Cells[0].Value);
                    fCargo.miCargo.Descripcion = Convert.ToString(dtgListaCargos.SelectedRows[0].Cells[1].Value);
                    if (fCargo.ShowDialog() == DialogResult.OK)
                    {
                        miCargo.ModificarCargo(fCargo.miCargo);
                        dtgListaCargos.DataSource = miCargo.ListaCargos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un Cargo para Modificar");
                }
               
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaCargos.SelectedRows.Count > 0 )
                {
                    if (MessageBox.Show("¿Desea eliminar el cargo?", "Eliminar", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        miCargo.Codigo = Convert.ToInt16(dtgListaCargos.SelectedRows[0].Cells[0].Value);
                        miCargo.EliminarCargo(miCargo);
                        dtgListaCargos.DataSource = miCargo.ListaCargos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un cargo para eliminar");
                }
              
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgListaCargos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
