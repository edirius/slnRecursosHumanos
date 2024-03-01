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

namespace CapaUsuario.Usuarios
{
    public partial class frmListaPrivilegios : Form
    {
        public frmListaPrivilegios()
        {
            InitializeComponent();
        }

        CapaDeNegocios.Usuario.cPrivilegio miPrivilegio = new CapaDeNegocios.Usuario.cPrivilegio();

        private void frmListaPrivilegios_Load(object sender, EventArgs e)
        {
            Iniciar(); 
        }

        private void Iniciar()
        {
            dtgPrivilegios.DataSource = miPrivilegio.ListaPrivilegios();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmCategoria fNuevoPrivilegio = new frmCategoria();
                fNuevoPrivilegio.miPrivilegio = new CapaDeNegocios.Usuario.cPrivilegio();

                if (fNuevoPrivilegio.ShowDialog() == DialogResult.OK)
                {
                    fNuevoPrivilegio.miPrivilegio.AgregarPrivilegio(fNuevoPrivilegio.miPrivilegio);
                    MessageBox.Show("Privilegio Agregado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgPrivilegios.DataSource = miPrivilegio.ListaPrivilegios();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear Privilegio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgPrivilegios.SelectedRows.Count > 0)
                {
                    frmCategoria fModificarPrivilegio = new frmCategoria();
                    fModificarPrivilegio.miPrivilegio = new CapaDeNegocios.Usuario.cPrivilegio();
                    fModificarPrivilegio.miPrivilegio.Codigo = Convert.ToInt16(dtgPrivilegios.SelectedRows[0].Cells[0].Value);
                    fModificarPrivilegio.miPrivilegio.Descripcion = Convert.ToString(dtgPrivilegios.SelectedRows[0].Cells[1].Value);
                    fModificarPrivilegio.miPrivilegio.MenuAFP = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[2].Value);
                    fModificarPrivilegio.miPrivilegio.MenuUsuario = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[3].Value);
                    fModificarPrivilegio.miPrivilegio.MenuTrabajadores = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[4].Value);
                    fModificarPrivilegio.miPrivilegio.MenuTareos = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[5].Value);
                    fModificarPrivilegio.miPrivilegio.MenuMetas = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[6].Value);
                    fModificarPrivilegio.miPrivilegio.MenuPlanillas = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[7].Value);
                    fModificarPrivilegio.miPrivilegio.MenuTablasParametricass = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[8].Value);
                    fModificarPrivilegio.miPrivilegio.MenuExportarDatos = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[9].Value);
                    fModificarPrivilegio.miPrivilegio.MenuReportes = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[10].Value);
                    fModificarPrivilegio.miPrivilegio.MenuBoletas = Convert.ToBoolean(dtgPrivilegios.SelectedRows[0].Cells[11].Value);

                    if (fModificarPrivilegio.ShowDialog() == DialogResult.OK)
                    {
                        fModificarPrivilegio.miPrivilegio.ModificarPrivilegio(fModificarPrivilegio.miPrivilegio);
                        MessageBox.Show("Privilegio modificado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtgPrivilegios.DataSource = miPrivilegio.ListaPrivilegios();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una categoria para poder modificar.", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar Privilegio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgPrivilegios.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Desea eliminar el privilegio '" + dtgPrivilegios.SelectedRows[0].Cells[1].Value.ToString() + "'", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CapaDeNegocios.Usuario.cPrivilegio miPrivilegio = new CapaDeNegocios.Usuario.cPrivilegio();
                        miPrivilegio.Codigo = Convert.ToInt16(dtgPrivilegios.SelectedRows[0].Cells[0].Value);
                        miPrivilegio.EliminarPrivilegio(miPrivilegio);
                        MessageBox.Show("Privilegio Eliminado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtgPrivilegios.DataSource = miPrivilegio.ListaPrivilegios();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una categoria para poder eliminar.", "Seleccionar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el Privilegio, esta asignado a un usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
