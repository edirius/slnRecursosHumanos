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
    public partial class frmGrupoFuncional : Form
    {
        cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();
        cFuncion miFuncion = new cFuncion();
        cDivisionFuncional miDivisionFuncional = new cDivisionFuncional();
        cGrupoFuncional miGrupoFuncional;

        public frmGrupoFuncional()
        {
            InitializeComponent();
        }

        private void frmGrupoFuncional_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            cboFuncion.ValueMember = "idtFuncion";
            cboFuncion.DisplayMember = "nombre";
            cboFuncion.DataSource = miCadena.ListarFunciones();
        }

        private void cboFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            miFuncion.Codigo = Convert.ToInt16(cboFuncion.SelectedValue);
            miFuncion.Nombre = cboFuncion.Text;
            cboDivisionFuncional.ValueMember = "idtDivisionFuncional";
            cboDivisionFuncional.DisplayMember = "nombre";
            cboDivisionFuncional.DataSource = miCadena.ListarDivisionFuncional(miFuncion);
        }

        private void cboDivisionFuncional_SelectedIndexChanged(object sender, EventArgs e)
        {
            miDivisionFuncional.Codigo = Convert.ToInt16(cboDivisionFuncional.SelectedValue);
            miDivisionFuncional.Nombre = cboDivisionFuncional.Text;
            dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(miDivisionFuncional);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoGrupoFuncional fGrupoFuncional = new frmMantenimientoGrupoFuncional();
            fGrupoFuncional.miGrupoFuncional = new cGrupoFuncional();
            fGrupoFuncional.miGrupoFuncional.Año = DateTime.Now.Year;
            fGrupoFuncional.miGrupoFuncional.DivisionFuncional = miDivisionFuncional;
            fGrupoFuncional.miGrupoFuncional.DivisionFuncional.Funcion = miFuncion;
            if (fGrupoFuncional.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                miCadena.CrearGrupoFuncional(fGrupoFuncional.miGrupoFuncional);
                dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(miDivisionFuncional);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgGrupoFuncional.SelectedRows.Count > 0)
            {
                frmMantenimientoGrupoFuncional fGrupoFuncional = new frmMantenimientoGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional = new cGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional.Codigo = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[0].Value);
                fGrupoFuncional.miGrupoFuncional.Nombre = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[1].Value);
                fGrupoFuncional.miGrupoFuncional.GrupoFuncional = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[2].Value);
                fGrupoFuncional.miGrupoFuncional.Año = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[3].Value);
                fGrupoFuncional.miGrupoFuncional.DivisionFuncional = miDivisionFuncional;
                fGrupoFuncional.miGrupoFuncional.DivisionFuncional.Funcion = miFuncion;
                if (fGrupoFuncional.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    miCadena.ModificarGrupoFuncional(fGrupoFuncional.miGrupoFuncional);
                    dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(miDivisionFuncional);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Grupo Funcional.");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgGrupoFuncional.SelectedRows.Count > 0)
            {
                frmMantenimientoGrupoFuncional fGrupoFuncional = new frmMantenimientoGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional = new cGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional.Codigo = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[0].Value);
                fGrupoFuncional.miGrupoFuncional.Nombre = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[1].Value);
                fGrupoFuncional.miGrupoFuncional.GrupoFuncional = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[2].Value);
                fGrupoFuncional.miGrupoFuncional.Año = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[3].Value);
                fGrupoFuncional.miGrupoFuncional.DivisionFuncional = miDivisionFuncional;
                fGrupoFuncional.miGrupoFuncional.DivisionFuncional.Funcion = miFuncion;
                if (fGrupoFuncional.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miCadena.EliminarGrupoFuncional(fGrupoFuncional.miGrupoFuncional);
                    dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(miDivisionFuncional);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Grupo Funcional.");
            }
        }
    }
}
