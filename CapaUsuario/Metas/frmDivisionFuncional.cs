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
    public partial class frmDivisionFuncional : Form
    {
        cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();
        cFuncion oFuncion = new cFuncion();
        cDivisionFuncional oDivisionFuncional = new cDivisionFuncional();

        public frmDivisionFuncional()
        {
            InitializeComponent();
        }

        private void frmDivisionFuncional_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            cboDivisionFuncional.DisplayMember = "nombre";
            cboDivisionFuncional.ValueMember = "idtfuncion";
            cboDivisionFuncional.DataSource = miCadena.ListarFunciones();
        }

        private void cboDivisionFuncional_SelectedIndexChanged(object sender, EventArgs e)
        {
            oFuncion.Codigo = Convert.ToInt16(cboDivisionFuncional.SelectedValue);
            oFuncion.Nombre = Convert.ToString(cboDivisionFuncional.Text);
            dtgDivisionFuncional.DataSource = miCadena.ListarDivisionFuncional(oFuncion);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Metas.frmMantenimientoDivisionFuncional fDivision = new frmMantenimientoDivisionFuncional();
            fDivision.miDivisionFuncional = new cDivisionFuncional();
            fDivision.miDivisionFuncional.Funcion = oFuncion;
            fDivision.miDivisionFuncional.Año = DateTime.Now.Year;
            if (fDivision.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                miCadena.NuevaDivisionFuncional(fDivision.miDivisionFuncional);
                dtgDivisionFuncional.DataSource = miCadena.ListarDivisionFuncional(oFuncion);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgDivisionFuncional.SelectedRows.Count > 0)
            {
                Metas.frmMantenimientoDivisionFuncional fDivision = new frmMantenimientoDivisionFuncional();
                fDivision.miDivisionFuncional = new cDivisionFuncional();
                fDivision.miDivisionFuncional.Funcion = oFuncion;
                fDivision.miDivisionFuncional.Codigo = Convert.ToInt16 (dtgDivisionFuncional.SelectedRows[0].Cells[0].Value);
                fDivision.miDivisionFuncional.Nombre = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[1].Value);
                fDivision.miDivisionFuncional.CodigoFuncional = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[2].Value);
                fDivision.miDivisionFuncional.Año = Convert.ToInt16(dtgDivisionFuncional.SelectedRows[0].Cells[3].Value);

                if (fDivision.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                {
                    miCadena.ModificarDivisionFuncional(fDivision.miDivisionFuncional);
                    dtgDivisionFuncional.DataSource = miCadena.ListarDivisionFuncional(oFuncion);
                }
            }
            else
            {
                MessageBox.Show("Seleccion una division funcional.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgDivisionFuncional.SelectedRows.Count > 0)
            {
                oDivisionFuncional = new cDivisionFuncional();
                oDivisionFuncional.Funcion = oFuncion;
                oDivisionFuncional.Codigo = Convert.ToInt16(dtgDivisionFuncional.SelectedRows[0].Cells[0].Value);
                oDivisionFuncional.Nombre = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[1].Value);
                oDivisionFuncional.CodigoFuncional = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[2].Value);
                oDivisionFuncional.Año = Convert.ToInt16(dtgDivisionFuncional.SelectedRows[0].Cells[3].Value);

                if (MessageBox.Show("Desea eliminar la division funcional?", "Eliminar", MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.Yes ) 
                {
                    miCadena.EliminarDivisionFuncional(oDivisionFuncional);
                    dtgDivisionFuncional.DataSource = miCadena.ListarDivisionFuncional(oFuncion);
                }
            }
            else
            {
                MessageBox.Show("Seleccion una division funcional.");
            }
        }
    }
}
