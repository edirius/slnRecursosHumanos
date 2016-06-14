using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios.Obras;

namespace CapaUsuario.Metas
{
    public partial class frmFuncion : Form
    {
        cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();
        cFuncion oFuncion = new cFuncion();
        public frmFuncion()
        {
            InitializeComponent();
        }

        private void frmFuncion_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgFuncion.DataSource = miCadena.ListarFunciones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoFuncion fFuncion = new frmMantenimientoFuncion();
            fFuncion.oFuncion = new cFuncion();
            fFuncion.oFuncion.Año = DateTime.Now.Year;
            if (fFuncion.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miCadena.NuevaFuncion(fFuncion.oFuncion);
                Iniciar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgFuncion.SelectedRows.Count > 0)
            {
                frmMantenimientoFuncion fFuncion = new frmMantenimientoFuncion();
                fFuncion.oFuncion = new cFuncion();
                fFuncion.oFuncion.Codigo = Convert.ToInt16(dtgFuncion.SelectedRows[0].Cells[0].Value);
                fFuncion.oFuncion.Nombre = Convert.ToString(dtgFuncion.SelectedRows[0].Cells[1].Value);
                fFuncion.oFuncion.Funcion = Convert.ToString(dtgFuncion.SelectedRows[0].Cells[2].Value);
                fFuncion.oFuncion.Año = Convert.ToInt16(dtgFuncion.SelectedRows[0].Cells[3].Value);

                if (fFuncion.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miCadena.ModificarFuncion(fFuncion.oFuncion);
                    Iniciar();
                }
            }
            else 
            {
                MessageBox.Show("Seleccione una funcion");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgFuncion.SelectedRows.Count > 0)
            {
                frmMantenimientoFuncion fFuncion = new frmMantenimientoFuncion();
                fFuncion.oFuncion = new cFuncion();
                fFuncion.oFuncion.Codigo = Convert.ToInt16(dtgFuncion.SelectedRows[0].Cells[0].Value);
                fFuncion.oFuncion.Nombre = Convert.ToString(dtgFuncion.SelectedRows[0].Cells[1].Value);
                fFuncion.oFuncion.Funcion = Convert.ToString(dtgFuncion.SelectedRows[0].Cells[2].Value);
                fFuncion.oFuncion.Año = Convert.ToInt16(dtgFuncion.SelectedRows[0].Cells[3].Value);

                if (MessageBox.Show("Desea eliminar la funcion?", "ELiminar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    miCadena.EliminarFuncion(fFuncion.oFuncion);
                    Iniciar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una funcion");
            }
        }

        
    }
}
