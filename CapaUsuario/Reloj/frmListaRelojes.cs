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

namespace CapaUsuario.Reloj
{
    public partial class frmListaRelojes : Form
    {
        public frmListaRelojes()
        {
            InitializeComponent();
        }

        CapaDeNegocios.Reloj.cCatalogoMaquinaReloj oCatalogo = new CapaDeNegocios.Reloj.cCatalogoMaquinaReloj();

        private void frmListaRelojes_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dtgListaRelojes.DataSource = oCatalogo.ListaRelojes(true);
        }

        private void btnNuevoReloj_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoReloj fMantenimientoReloj = new frmMantenimientoReloj();
                fMantenimientoReloj.oMaquinaReloj = new CapaDeNegocios.Reloj.cMaquinaReloj();

                if (fMantenimientoReloj.ShowDialog() == DialogResult.OK)
                {
                    oCatalogo.CrearMaquinaReloj(fMantenimientoReloj.oMaquinaReloj);
                    MessageBox.Show("Reloj Agregado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el nuevo reloj: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarReloj_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaRelojes.SelectedRows.Count > 0)
                {
                    frmMantenimientoReloj fMantenimientoReloj = new frmMantenimientoReloj();
                    fMantenimientoReloj.oMaquinaReloj = new CapaDeNegocios.Reloj.cMaquinaReloj();
                    fMantenimientoReloj.oMaquinaReloj.IdtReloj = Convert.ToInt32(dtgListaRelojes.SelectedRows[0].Cells[0].Value);
                    fMantenimientoReloj.oMaquinaReloj.Descripcion = dtgListaRelojes.SelectedRows[0].Cells[1].Value.ToString();
                    fMantenimientoReloj.oMaquinaReloj.Ip = dtgListaRelojes.SelectedRows[0].Cells[2].Value.ToString();
                    fMantenimientoReloj.oMaquinaReloj.Activo = Convert.ToBoolean(dtgListaRelojes.SelectedRows[0].Cells[3].Value);

                    if (fMantenimientoReloj.ShowDialog() == DialogResult.OK)
                    {
                        oCatalogo.ModificarMaquinaReloj(fMantenimientoReloj.oMaquinaReloj);
                        MessageBox.Show("Reloj Modificado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un reloj para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el nuevo reloj: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
