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
        cDivisionFuncional oDivisionFuncional = new cDivisionFuncional();
        cGrupoFuncional oGrupoFuncional = new cGrupoFuncional();
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

        private void dtgFuncion_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgFuncion.SelectedRows.Count > 0)
            {
                oFuncion.Codigo = Convert.ToInt16(dtgFuncion.SelectedRows[0].Cells[0].Value);
                oFuncion.Nombre = Convert.ToString(dtgFuncion.SelectedRows[0].Cells[1].Value);
                dtgDivisionFuncional.DataSource = miCadena.ListarDivisionFuncional(oFuncion);
            }

        }

        private void btnNuevoDivision_Click(object sender, EventArgs e)
        {
            Metas.frmMantenimientoDivisionFuncional fDivision = new frmMantenimientoDivisionFuncional();
            fDivision.miDivisionFuncional = new cDivisionFuncional();
            fDivision.miDivisionFuncional.Funcion = oFuncion;
            fDivision.miDivisionFuncional.Año = DateTime.Now.Year;
            if (fDivision.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miCadena.NuevaDivisionFuncional(fDivision.miDivisionFuncional);
                dtgDivisionFuncional.DataSource = miCadena.ListarDivisionFuncional(oFuncion);
            }
        }

        private void btnModificarDivision_Click(object sender, EventArgs e)
        {
            if (dtgDivisionFuncional.SelectedRows.Count > 0)
            {
                Metas.frmMantenimientoDivisionFuncional fDivision = new frmMantenimientoDivisionFuncional();
                fDivision.miDivisionFuncional = new cDivisionFuncional();
                fDivision.miDivisionFuncional.Funcion = oFuncion;
                fDivision.miDivisionFuncional.Codigo = Convert.ToInt16(dtgDivisionFuncional.SelectedRows[0].Cells[0].Value);
                fDivision.miDivisionFuncional.Nombre = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[1].Value);
                fDivision.miDivisionFuncional.CodigoFuncional = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[2].Value);
                fDivision.miDivisionFuncional.Año = Convert.ToInt16(dtgDivisionFuncional.SelectedRows[0].Cells[3].Value);

                if (fDivision.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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

        private void btnEliminarDivision_Click(object sender, EventArgs e)
        {
            if (dtgDivisionFuncional.SelectedRows.Count > 0)
            {
                oDivisionFuncional = new cDivisionFuncional();
                oDivisionFuncional.Funcion = oFuncion;
                oDivisionFuncional.Codigo = Convert.ToInt16(dtgDivisionFuncional.SelectedRows[0].Cells[0].Value);
                oDivisionFuncional.Nombre = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[1].Value);
                oDivisionFuncional.CodigoFuncional = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[2].Value);
                oDivisionFuncional.Año = Convert.ToInt16(dtgDivisionFuncional.SelectedRows[0].Cells[3].Value);

                if (MessageBox.Show("Desea eliminar la division funcional?", "Eliminar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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

        private void dtgGrupoFuncional_SelectionChanged(object sender, EventArgs e)
        {
            
    }

        private void dtgDivisionFuncional_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDivisionFuncional.SelectedRows.Count > 0)
            {
                oDivisionFuncional.Codigo = Convert.ToInt16(dtgDivisionFuncional.SelectedRows[0].Cells[0].Value);
                oDivisionFuncional.Nombre = Convert.ToString(dtgDivisionFuncional.SelectedRows[0].Cells[1].Value);
                dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(oDivisionFuncional);
            }
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            frmMantenimientoGrupoFuncional fGrupoFuncional = new frmMantenimientoGrupoFuncional();
            fGrupoFuncional.miGrupoFuncional = new cGrupoFuncional();
            fGrupoFuncional.miGrupoFuncional.Año = DateTime.Now.Year;
            fGrupoFuncional.miGrupoFuncional.DivisionFuncional = oDivisionFuncional;
            fGrupoFuncional.miGrupoFuncional.DivisionFuncional.Funcion = oFuncion;
            if (fGrupoFuncional.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miCadena.CrearGrupoFuncional(fGrupoFuncional.miGrupoFuncional);
                dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(oDivisionFuncional);
            }
        }

        private void btnModificarGrupo_Click(object sender, EventArgs e)
        {
            if (dtgGrupoFuncional.SelectedRows.Count > 0)
            {
                frmMantenimientoGrupoFuncional fGrupoFuncional = new frmMantenimientoGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional = new cGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional.Codigo = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[0].Value);
                fGrupoFuncional.miGrupoFuncional.Nombre = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[1].Value);
                fGrupoFuncional.miGrupoFuncional.GrupoFuncional = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[2].Value);
                fGrupoFuncional.miGrupoFuncional.Año = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[3].Value);
                fGrupoFuncional.miGrupoFuncional.DivisionFuncional = oDivisionFuncional;
                fGrupoFuncional.miGrupoFuncional.DivisionFuncional.Funcion = oFuncion;
                if (fGrupoFuncional.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miCadena.ModificarGrupoFuncional(fGrupoFuncional.miGrupoFuncional);
                    dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(oDivisionFuncional);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Grupo Funcional.");
            }
        }

        private void btnEliminarGrupo_Click(object sender, EventArgs e)
        {
            if (dtgGrupoFuncional.SelectedRows.Count > 0)
            {
                frmMantenimientoGrupoFuncional fGrupoFuncional = new frmMantenimientoGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional = new cGrupoFuncional();
                fGrupoFuncional.miGrupoFuncional.Codigo = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[0].Value);
                fGrupoFuncional.miGrupoFuncional.Nombre = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[1].Value);
                fGrupoFuncional.miGrupoFuncional.GrupoFuncional = Convert.ToString(dtgGrupoFuncional.SelectedRows[0].Cells[2].Value);
                fGrupoFuncional.miGrupoFuncional.Año = Convert.ToInt16(dtgGrupoFuncional.SelectedRows[0].Cells[3].Value);
                fGrupoFuncional.miGrupoFuncional.DivisionFuncional = oDivisionFuncional;
                fGrupoFuncional.miGrupoFuncional.DivisionFuncional.Funcion = oFuncion;
                if (fGrupoFuncional.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miCadena.EliminarGrupoFuncional(fGrupoFuncional.miGrupoFuncional);
                    dtgGrupoFuncional.DataSource = miCadena.ListarGrupoFuncional(oDivisionFuncional);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Grupo Funcional.");
            }
        }
    }
    }
