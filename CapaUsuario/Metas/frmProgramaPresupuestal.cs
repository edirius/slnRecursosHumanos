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
                fMantenimiento.miProgramaPresupuestal.Codigo = Convert.ToInt16(dtgProgramaPresupuestal.Rows[0].Cells[0].Value);
                fMantenimiento.miProgramaPresupuestal.Nombre = Convert.ToString(dtgProgramaPresupuestal.Rows[0].Cells[1].Value);
                fMantenimiento.miProgramaPresupuestal.ProgramaPresupuestal = Convert.ToString(dtgProgramaPresupuestal.Rows[0].Cells[2].Value);
                fMantenimiento.miProgramaPresupuestal.Año = Convert.ToInt16(dtgProgramaPresupuestal.Rows[0].Cells[3].Value);

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
    }
}
