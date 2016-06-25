using CapaDeNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Trabajador
{
    public partial class frmListaPeriodos : Form
    {
        public frmListaPeriodos()
        {
            InitializeComponent();
        }

        public  cTrabajador miTrabajador;
        cPeriodo miPeriodo;

        private void frmListaPeriodos_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            miPeriodo = new cPeriodo(miTrabajador);
            if (miTrabajador.IdTrabajador != 0)
            {
                dtgPeriodos.DataSource = miPeriodo.TraerPeriodos(miTrabajador.IdTrabajador);

            }
        }

        private void btnNuevoPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoPeriodo fNuevoPeriodo = new frmNuevoPeriodo();
                fNuevoPeriodo.miPeriodo = miPeriodo;
                fNuevoPeriodo.miPeriodo.FechaFin = new CapaDeNegocios.DatosLaborales.cFinPeriodo();
                fNuevoPeriodo.miPeriodo.FechaInicio = DateTime.Now;
                if (fNuevoPeriodo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fNuevoPeriodo.miPeriodo.CrearPeriodo(fNuevoPeriodo.miPeriodo);
                    dtgPeriodos.DataSource = miPeriodo.TraerPeriodos(miTrabajador.IdTrabajador);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void btnModificarPeriodo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoPeriodo fModificarPeriodo = new frmNuevoPeriodo();
                fModificarPeriodo.miPeriodo = miPeriodo;
                fModificarPeriodo.miPeriodo.FechaFin = new CapaDeNegocios.DatosLaborales.cFinPeriodo();

                if (dtgPeriodos.SelectedRows.Count > 0)
                {
                    fModificarPeriodo.miPeriodo.Codigo = Convert.ToInt16(dtgPeriodos.SelectedRows[0].Cells[0].Value);
                    fModificarPeriodo.miPeriodo.FechaInicio = Convert.ToDateTime(dtgPeriodos.SelectedRows[0].Cells[2].Value);

                    fModificarPeriodo.miPeriodo.MotivoFinPeriodo = new CapaDeNegocios.DatosLaborales.cMotivoFinPeriodo();

                    if (dtgPeriodos.SelectedRows[0].Cells[3].Value != Convert.DBNull)
                    {
                        fModificarPeriodo.miPeriodo.FechaFin.TieneFin = true;
                        fModificarPeriodo.miPeriodo.FechaFin.FechaFin = Convert.ToDateTime(dtgPeriodos.SelectedRows[0].Cells[3].Value);
                        fModificarPeriodo.miPeriodo.MotivoFinPeriodo.Codigo = Convert.ToInt16(dtgPeriodos.SelectedRows[0].Cells[4].Value);
                        fModificarPeriodo.miPeriodo.MotivoFinPeriodo.Descripcion = Convert.ToString(dtgPeriodos.SelectedRows[0].Cells[7].Value);
                    }
                    else
                    {
                        fModificarPeriodo.miPeriodo.FechaFin.TieneFin = false;
                    }

                }

                if (fModificarPeriodo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fModificarPeriodo.miPeriodo.ModificarPeriodo(fModificarPeriodo.miPeriodo);
                    dtgPeriodos.DataSource = miPeriodo.TraerPeriodos(miTrabajador.IdTrabajador);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void btnEliminarPeriodo_Click(object sender, EventArgs e)
        {

        }
    }
}
