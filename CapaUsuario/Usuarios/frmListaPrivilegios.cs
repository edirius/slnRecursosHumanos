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
            frmCategoria fNuevoPrivilegio = new frmCategoria();
            fNuevoPrivilegio.miPrivilegio = new CapaDeNegocios.Usuario.cPrivilegio();

            if (fNuevoPrivilegio.ShowDialog() == DialogResult.OK )
            {
                fNuevoPrivilegio.miPrivilegio.AgregarPrivilegio(fNuevoPrivilegio.miPrivilegio);
                dtgPrivilegios.DataSource = miPrivilegio.ListaPrivilegios();
                
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
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

                if (fModificarPrivilegio.ShowDialog() == DialogResult.OK)
                {
                    fModificarPrivilegio.miPrivilegio.ModificarPrivilegio(fModificarPrivilegio.miPrivilegio);
                    dtgPrivilegios.DataSource = miPrivilegio.ListaPrivilegios();
                    
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoria para poder modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgPrivilegios.SelectedRows.Count > 0)
            {
                frmCategoria fEliminarPrivilegio = new frmCategoria();
                fEliminarPrivilegio.miPrivilegio = new CapaDeNegocios.Usuario.cPrivilegio();
                if (fEliminarPrivilegio.ShowDialog() == DialogResult.OK)
                {
                    
                    fEliminarPrivilegio.miPrivilegio.EliminarPrivilegio(fEliminarPrivilegio.miPrivilegio);
                    dtgPrivilegios.DataSource = miPrivilegio.ListaPrivilegios();
                   
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoria para poder eliminar.");
            }
        }
    }
}
