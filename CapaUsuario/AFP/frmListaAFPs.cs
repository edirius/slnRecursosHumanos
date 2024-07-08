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

namespace CapaUsuario.AFP
{
    public partial class frmListaAFPs : Form
    {
        public cListaAFP miListaAFP;

        public frmListaAFPs()
        {
            InitializeComponent();
            
        }

        private void Iniciar()
        {
            miListaAFP = new cListaAFP();
            dtgListaAFPs.DataSource = miListaAFP.ObtenerListaAFP();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                cAFP miNuevaAFP = new cAFP();
                frmAFP fAFP = new frmAFP();
                fAFP.Text = "Ingrese el nombre de la AFP";
                fAFP.miAFP = new cAFP();
                fAFP.miAFP.Tipo = "AFP";
                if (fAFP.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miNuevaAFP = fAFP.miAFP;

                    miListaAFP.AgregarAfp(miNuevaAFP);

                    dtgListaAFPs.DataSource = miListaAFP.ObtenerListaAFP();
                }
                else
                {
                    MessageBox.Show("Se canceló la operación", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message); 
            }
           

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Desea eliminar la AFP?", "Eliminar:", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dtgListaAFPs.SelectedRows.Count > 0)
                    {
                        cAFP miAFPaEliminar = new cAFP();
                        miAFPaEliminar.CodigoAFP = Convert.ToInt16(dtgListaAFPs.Rows[dtgListaAFPs.SelectedRows[0].Index].Cells[0].Value.ToString());
                        miAFPaEliminar.Nombre = dtgListaAFPs.Rows[dtgListaAFPs.SelectedRows[0].Index].Cells[1].Value.ToString();
                        if (miListaAFP.EliminarAfp(miAFPaEliminar) == true)
                        {
                            MessageBox.Show("Se elimino Correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar la AFP porque esta relacionada a otras tablas.");
                        }
                        dtgListaAFPs.DataSource = miListaAFP.ObtenerListaAFP();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una AFP en la Lista de AFP ");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

           
        }

        private void dtgListaAFPs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("indice " + dtgListaAFPs.RowCount.ToString()  ); 
        }

        private void frmListaAFPs_Load(object sender, EventArgs e)
        {
            Iniciar();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dtgListaAFPs.SelectedRows.Count > 0)
            {
                cAFP miAFPaModificar = new cAFP();
                miAFPaModificar.CodigoAFP = Convert.ToInt16(dtgListaAFPs.Rows[dtgListaAFPs.SelectedRows[0].Index].Cells[0].Value.ToString());
                miAFPaModificar.Nombre = dtgListaAFPs.Rows[dtgListaAFPs.SelectedRows[0].Index].Cells[1].Value.ToString();
                miAFPaModificar.Codigosunat = dtgListaAFPs.Rows[dtgListaAFPs.SelectedRows[0].Index].Cells[2].Value.ToString();
                miAFPaModificar.Tipo = "AFP";
                frmAFP fAFP = new frmAFP();
                fAFP.Text = "Modifique el nombre de la AFP";
                fAFP.miAFP = miAFPaModificar;
                if (fAFP.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    miAFPaModificar = fAFP.miAFP;
                    miListaAFP.ModificarAfp(miAFPaModificar);
                    dtgListaAFPs.DataSource = miListaAFP.ObtenerListaAFP();
                }
                else
                {
                    MessageBox.Show("Se canceló la operación", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una AFP en la Lista de AFP ");
            }

           
        }
    }
}
