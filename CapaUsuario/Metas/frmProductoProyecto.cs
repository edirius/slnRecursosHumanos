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
    public partial class frmProductoProyecto : Form
    {
        cCadenaProgramaticaFuncional miCadena = new cCadenaProgramaticaFuncional();
        cProgramaPresupuestal miProgramaPresupuestal = new cProgramaPresupuestal();
        cProductoProyecto miProductoProyecto = new cProductoProyecto();


        public frmProductoProyecto()
        {
            InitializeComponent();
        }

        private void frmProductoProyecto_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            
            cboProgramaPresupuestal.DisplayMember = "nombre";
            cboProgramaPresupuestal.ValueMember = "idtProgramaPresupuestal";
            cboProgramaPresupuestal.DataSource = miCadena.ListarProgramaPresupuestal();
            if (miCadena.ListarProgramaPresupuestal().Rows.Count == 0)
            {
                MessageBox.Show("No existe ningun programa presupuestal creado, cree primero el programa presupuestal");
                this.Close();
            }
        }

        private void cboProgramaPresupuestal_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            miProgramaPresupuestal.Codigo = Convert.ToInt16(cboProgramaPresupuestal.SelectedValue);
            miProgramaPresupuestal.Nombre = cboProgramaPresupuestal.Text;
            dtgProductoProyecto.DataSource = miCadena.ListarProductoProyecto(miProgramaPresupuestal);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoProductoProyecto fProductoProyecto = new frmMantenimientoProductoProyecto();
            fProductoProyecto.miProductoProyecto = new cProductoProyecto();
            fProductoProyecto.miProductoProyecto.Año = DateTime.Now.Year;
            fProductoProyecto.miProductoProyecto.ProgramaPresupuestal = miProgramaPresupuestal;
            if (fProductoProyecto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                miCadena.CrearProductoProyecto(fProductoProyecto.miProductoProyecto);
                cboProgramaPresupuestal.DataSource = miCadena.ListarProgramaPresupuestal();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgProductoProyecto.SelectedRows.Count > 0)
            {
                frmMantenimientoProductoProyecto fProductoProyecto = new frmMantenimientoProductoProyecto();
                fProductoProyecto.miProductoProyecto = new cProductoProyecto();
                fProductoProyecto.miProductoProyecto.Codigo = Convert.ToInt16(dtgProductoProyecto.SelectedRows[0].Cells[0].Value);
                fProductoProyecto.miProductoProyecto.Nombre = Convert.ToString(dtgProductoProyecto.SelectedRows[0].Cells[1].Value);
                fProductoProyecto.miProductoProyecto.ProductoProyecto = Convert.ToString(dtgProductoProyecto.SelectedRows[0].Cells[2].Value); 
                fProductoProyecto.miProductoProyecto.Año = Convert.ToInt16( dtgProductoProyecto.SelectedRows[0].Cells[3].Value);
                fProductoProyecto.miProductoProyecto.ProgramaPresupuestal = miProgramaPresupuestal;
                if (fProductoProyecto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miCadena.ModificarProductoProyecto(fProductoProyecto.miProductoProyecto);
                    cboProgramaPresupuestal.DataSource = miCadena.ListarProgramaPresupuestal();
                }
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show ("¿Desea eliminar el Producto / Proyecto ?","Eliminar", MessageBoxButtons.YesNo ) == System.Windows.Forms.DialogResult.Yes )
            {
                if (dtgProductoProyecto.SelectedRows.Count > 0)
                {
                    miProductoProyecto = new cProductoProyecto();
                    miProductoProyecto.Codigo = Convert.ToInt16(dtgProductoProyecto.SelectedRows[0].Cells[0].Value);
                    miCadena.ModificarProductoProyecto(miProductoProyecto);
                    cboProgramaPresupuestal.DataSource = miCadena.ListarProgramaPresupuestal();
                    
                }               
            }
        }
    }

}
