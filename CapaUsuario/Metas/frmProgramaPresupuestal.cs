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
using CapaDeNegocios.Obras;

namespace CapaUsuario.Metas
{
    public partial class frmProgramaPresupuestal : Form
    {
        public frmProgramaPresupuestal()
        {
            InitializeComponent();
        }

        cCadenaProgramaticaFuncional miCadenaProgramatica = new cCadenaProgramaticaFuncional();

        cProgramaPresupuestal oProgramaPresupuestal = new cProgramaPresupuestal();
        cProductoProyecto oProductoProyecto = new cProductoProyecto();
        cActividadObra oActividadObra = new cActividadObra();
        
        private void frmProgramaPresupuestal_Load(object sender, EventArgs e)
        {
            Iniciar();
            
        }

        private void Iniciar()
        {
            dtgProgramaPresupuestal.DataSource = miCadenaProgramatica.ListarProgramaPresupuestal(); 
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoProgramaPresupuestal fMantenimiento = new frmMantenimientoProgramaPresupuestal();
            fMantenimiento.miProgramaPresupuestal = new cProgramaPresupuestal();
            fMantenimiento.miProgramaPresupuestal.Año = DateTime.Now.Year;
            if (fMantenimiento.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                miCadenaProgramatica.CrearProgramaPresupuestal(fMantenimiento.miProgramaPresupuestal);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgProgramaPresupuestal.SelectedRows.Count > 0)
            {
                frmMantenimientoProgramaPresupuestal fMantenimiento = new frmMantenimientoProgramaPresupuestal();
                fMantenimiento.miProgramaPresupuestal = new cProgramaPresupuestal();
                fMantenimiento.miProgramaPresupuestal.Codigo = Convert.ToInt16(dtgProgramaPresupuestal.SelectedRows[0].Cells[0].Value);
                fMantenimiento.miProgramaPresupuestal.Nombre = Convert.ToString(dtgProgramaPresupuestal.SelectedRows[0].Cells[1].Value);
                fMantenimiento.miProgramaPresupuestal.ProgramaPresupuestal = Convert.ToString(dtgProgramaPresupuestal.SelectedRows[0].Cells[2].Value);
                fMantenimiento.miProgramaPresupuestal.Año = Convert.ToInt16(dtgProgramaPresupuestal.SelectedRows[0].Cells[3].Value);

                if (fMantenimiento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miCadenaProgramatica.ModificarProgramaPresupuestal(fMantenimiento.miProgramaPresupuestal);
                    Iniciar();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado un programa presupuestal");
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el programa presupuestal","Elimar",MessageBoxButtons.OKCancel ) == System.Windows.Forms.DialogResult.OK )
            {
                if (dtgProgramaPresupuestal.SelectedRows.Count > 0)
                {
                    frmMantenimientoProgramaPresupuestal fMantenimiento = new frmMantenimientoProgramaPresupuestal();
                    fMantenimiento.miProgramaPresupuestal = new cProgramaPresupuestal();
                    fMantenimiento.miProgramaPresupuestal.Codigo = Convert.ToInt16(dtgProgramaPresupuestal.Rows[0].Cells[0].Value);
                    fMantenimiento.miProgramaPresupuestal.Nombre = Convert.ToString(dtgProgramaPresupuestal.Rows[0].Cells[1].Value);
                    fMantenimiento.miProgramaPresupuestal.ProgramaPresupuestal = Convert.ToString(dtgProgramaPresupuestal.Rows[0].Cells[2].Value);
                    fMantenimiento.miProgramaPresupuestal.Año = Convert.ToInt16(dtgProgramaPresupuestal.Rows[0].Cells[3].Value);

                    miCadenaProgramatica.EliminarProgramaPresupuestal(fMantenimiento.miProgramaPresupuestal);
                    Iniciar();

                }
                else
                {
                    MessageBox.Show("No ha seleccionado un programa presupuestal");
                }
            }
            
        }

        private void dtgProgramaPresupuestal_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgProgramaPresupuestal.SelectedRows.Count > 0)
            {
                oProgramaPresupuestal.Codigo = Convert.ToInt16(dtgProgramaPresupuestal.SelectedRows[0].Cells[0].Value);
                oProgramaPresupuestal.Nombre = Convert.ToString(dtgProgramaPresupuestal.SelectedRows[0].Cells[1].Value);
                dtgProductoProyecto.DataSource = miCadenaProgramatica.ListarProductoProyecto(oProgramaPresupuestal);
            }
            
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmMantenimientoProductoProyecto fProductoProyecto = new frmMantenimientoProductoProyecto();
            fProductoProyecto.miProductoProyecto = new cProductoProyecto();
            fProductoProyecto.miProductoProyecto.Año = DateTime.Now.Year;
            fProductoProyecto.miProductoProyecto.ProgramaPresupuestal = oProgramaPresupuestal;
            if (fProductoProyecto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miCadenaProgramatica.CrearProductoProyecto(fProductoProyecto.miProductoProyecto);
                dtgProductoProyecto.DataSource = miCadenaProgramatica.ListarProductoProyecto(oProgramaPresupuestal);
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (dtgProductoProyecto.SelectedRows.Count > 0)
            {
                frmMantenimientoProductoProyecto fProductoProyecto = new frmMantenimientoProductoProyecto();
                fProductoProyecto.miProductoProyecto = new cProductoProyecto();
                fProductoProyecto.miProductoProyecto.Codigo = Convert.ToInt16(dtgProductoProyecto.SelectedRows[0].Cells[0].Value);
                fProductoProyecto.miProductoProyecto.Nombre = Convert.ToString(dtgProductoProyecto.SelectedRows[0].Cells[1].Value);
                fProductoProyecto.miProductoProyecto.ProductoProyecto = Convert.ToString(dtgProductoProyecto.SelectedRows[0].Cells[2].Value);
                fProductoProyecto.miProductoProyecto.Año = Convert.ToInt16(dtgProductoProyecto.SelectedRows[0].Cells[3].Value);
                fProductoProyecto.miProductoProyecto.ProgramaPresupuestal = oProgramaPresupuestal;
                if (fProductoProyecto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miCadenaProgramatica.ModificarProductoProyecto(fProductoProyecto.miProductoProyecto);
                    dtgProductoProyecto.DataSource = miCadenaProgramatica.ListarProductoProyecto(oProgramaPresupuestal);
                }
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el Producto / Proyecto ?", "Eliminar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dtgProductoProyecto.SelectedRows.Count > 0)
                    {
                        oProductoProyecto = new cProductoProyecto();
                        oProductoProyecto.Codigo = Convert.ToInt16(dtgProductoProyecto.SelectedRows[0].Cells[0].Value);
                        miCadenaProgramatica.ELiminarProductoProyecto(oProductoProyecto);
                        dtgProductoProyecto.DataSource = miCadenaProgramatica.ListarProductoProyecto(oProgramaPresupuestal);

                    }
                }
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
            
        }

        private void btnNuevoActividad_Click(object sender, EventArgs e)
        {
            frmMantenimientoActividadObra oActividadObra = new frmMantenimientoActividadObra();
            oActividadObra.oActividadObra = new cActividadObra();
            oActividadObra.oActividadObra.ProductoProyecto = oProductoProyecto;
            oActividadObra.oActividadObra.ProductoProyecto.ProgramaPresupuestal = oProgramaPresupuestal;
            oActividadObra.oActividadObra.Año = DateTime.Now.Year; 
            if (oActividadObra.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miCadenaProgramatica.CrearActividadObra(oActividadObra.oActividadObra);
                dtgActividadObra.DataSource = miCadenaProgramatica.ListarActividadObra(oProductoProyecto);
            }
        }

        private void btnModificarActividad_Click(object sender, EventArgs e)
        {
            if (dtgActividadObra.SelectedRows.Count > 0)
            {
                frmMantenimientoActividadObra oActividadObra = new frmMantenimientoActividadObra();
                oActividadObra.oActividadObra = new cActividadObra();
                oActividadObra.oActividadObra.ProductoProyecto = oProductoProyecto;
                oActividadObra.oActividadObra.ProductoProyecto.ProgramaPresupuestal = oProgramaPresupuestal;
                oActividadObra.oActividadObra.Codigo = Convert.ToInt16(dtgActividadObra.SelectedRows[0].Cells[0].Value);
                oActividadObra.oActividadObra.Nombre = Convert.ToString(dtgActividadObra.SelectedRows[0].Cells[1].Value);
                oActividadObra.oActividadObra.ActividadObra = Convert.ToString(dtgActividadObra.SelectedRows[0].Cells[2].Value);
                oActividadObra.oActividadObra.Año = Convert.ToInt16(dtgActividadObra.SelectedRows[0].Cells[3].Value);

                if (oActividadObra.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miCadenaProgramatica.ModificarActividadObra(oActividadObra.oActividadObra);
                    dtgActividadObra.DataSource = miCadenaProgramatica.ListarActividadObra(oProductoProyecto);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una actividad / obra .");
            }
        }

        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar la Actividad / Obra ?", "Eliminar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {

                if (dtgActividadObra.SelectedRows.Count > 0)
                {
                    oActividadObra.Codigo = Convert.ToInt16(dtgActividadObra.SelectedRows[0].Cells[0].Value);
                    miCadenaProgramatica.EliminarActividadObra(oActividadObra);
                    dtgActividadObra.DataSource = miCadenaProgramatica.ListarActividadObra(oProductoProyecto);

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una actividad / obra .");
                }
            }
        }

        private void dtgProductoProyecto_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgProductoProyecto.SelectedRows.Count > 0)
            {
                oProductoProyecto.Codigo = Convert.ToInt16(dtgProductoProyecto.SelectedRows[0].Cells[0].Value); ;
                oProductoProyecto.Nombre = Convert.ToString(dtgProductoProyecto.SelectedRows[0].Cells[1].Value); ;
                dtgActividadObra.DataSource = miCadenaProgramatica.ListarActividadObra(oProductoProyecto);
            }
        }

        private void dtgProductoProyecto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
