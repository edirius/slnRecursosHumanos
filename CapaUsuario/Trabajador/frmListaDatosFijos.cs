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
    public partial class frmListaDatosFijos : Form
    {
        CapaDeNegocios.Trabajadores.cDatosFijo oDatosFijo;

        public cTrabajador oTrabajador;

        public frmListaDatosFijos()
        {
            InitializeComponent();
        }

        private void frmListaDatosFijos_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            if (oTrabajador == null)
            {
                MessageBox.Show("No se ha seleccionado ningun trabajador: frmListaDatosFijos ");
                DialogResult = DialogResult.Abort;
            }
            else
            {
                lblNombreTrabajador.Text = oTrabajador.Nombres + " " + oTrabajador.ApellidoPaterno + " " + oTrabajador.ApellidoMaterno;
            }
            oDatosFijo = new CapaDeNegocios.Trabajadores.cDatosFijo(oTrabajador.IdTrabajador);
            dtgListaDatosFijos.DataSource =  oDatosFijo.ListaDatosFijos();
           

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoDatoFijo fNuevoDatoFijo = new frmNuevoDatoFijo();
                fNuevoDatoFijo.oDatoFijo = oDatosFijo;
                if (fNuevoDatoFijo.ShowDialog() == DialogResult.OK)
                {
                    dtgListaDatosFijos.DataSource = oDatosFijo.ListaDatosFijos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar el formulario ingresar: frmListaDatosFijos.cs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaDatosFijos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar el concepto para eliminarlo.", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    oDatosFijo.EliminarDatosFijo(Convert.ToInt16(dtgListaDatosFijos.Rows[dtgListaDatosFijos.SelectedRows[0].Index].Cells["idt"].Value));
                    dtgListaDatosFijos.DataSource = oDatosFijo.ListaDatosFijos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el dato fijo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
