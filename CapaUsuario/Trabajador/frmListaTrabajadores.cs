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
    public partial class frmListaTrabajadores : Form
    {
        int pidttrabajador = 0;
        string trabajador = "";
        
        public frmListaTrabajadores()
        {
            InitializeComponent();
        }

        public cTrabajador miListaTrabajadores = new cTrabajador();

        private void Iniciar()
        {
            dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(true);
            if (dtgListaTrabajadores.Rows.Count > 0)
            {
                DataGridViewCellEventArgs cea = new DataGridViewCellEventArgs(0, 0);
                dtgListaTrabajadores.Rows[dtgListaTrabajadores.Rows.Count - 1].Selected = true;
                dtgListaTrabajadores_CellClick(dtgListaTrabajadores, cea);
            }
        }

          

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaTrabajadores_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void btnNuevoTrabajador_Click_1(object sender, EventArgs e)
        {
            try
            {
                Trabajador.frmNuevoTrabajador fNuevoTrabajador = new frmNuevoTrabajador();
                fNuevoTrabajador.miTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorServidorPersonal();
                fNuevoTrabajador.miTrabajador.FechaNacimiento = DateTime.Now;
                if (fNuevoTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miListaTrabajadores.AgregarTrabajador(fNuevoTrabajador.miTrabajador);
                    dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(true);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message); 
            }
           
        }

        private void btnModificarTrabajador_Click(object sender, EventArgs e)
        {
            try
            {
                Trabajador.frmNuevoTrabajador fModificarTrabajador = new frmNuevoTrabajador();
                fModificarTrabajador.miTrabajador = new CapaDeNegocios.Trabajadores.cTrabajadorServidorPersonal();
                fModificarTrabajador.miTrabajador = fModificarTrabajador.miTrabajador.traerTrabajador(Convert.ToInt16(dtgListaTrabajadores.SelectedRows[0].Cells[0].Value.ToString()));

                if (fModificarTrabajador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miListaTrabajadores.ModificarTrabajador(fModificarTrabajador.miTrabajador);
                    dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(true);
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message); 
                
            }
          
        }


       private void btnEliminarTrabajador_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Eliminar", "¿Desea eliminar al trabajador?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    cTrabajador miTrabajador = new cTrabajador();
                    miTrabajador.IdTrabajador = Convert.ToInt16(dtgListaTrabajadores.SelectedRows[0].Cells[0].Value.ToString());
                    miListaTrabajadores.EliminarTrabajador(miTrabajador);
                    dtgListaTrabajadores.DataSource = miListaTrabajadores.ObtenerListaTrabajadores(true);
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }
            
        }

        private void dtgListaTrabajadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgListaTrabajadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 ) { 
                pidttrabajador = Convert.ToInt32(dtgListaTrabajadores.Rows[e.RowIndex].Cells[0].Value);
                trabajador = Convert.ToString(dtgListaTrabajadores.Rows[e.RowIndex].Cells[2].Value) + " " + Convert.ToString(dtgListaTrabajadores.Rows[e.RowIndex].Cells[3].Value) + " " + Convert.ToString(dtgListaTrabajadores.Rows[e.RowIndex].Cells[4].Value);
            }
        }

        private void btnDatosLaborales_Click(object sender, EventArgs e)
        {
            CapaUsuario.Trabajador.frmMantenimientoPeriodoTrabajador fPeriodoTrabajador = new CapaUsuario.Trabajador.frmMantenimientoPeriodoTrabajador();
            fPeriodoTrabajador.RecibirDatos(pidttrabajador, trabajador);
            fPeriodoTrabajador.ShowDialog();
        }
    }
}
