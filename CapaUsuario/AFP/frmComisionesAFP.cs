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
using CapaDeDatos;

namespace CapaUsuario.AFP
{
    public partial class frmComisionesAFP : Form
    {
        
        public frmComisionesAFP()
        {
            InitializeComponent();
        }
        public cListaAFP miListaAFP;
        cAFP miAFPSeleccionada = new cAFP();

        private void frmComisionesAFP_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                cboListaAFP.ValueMember = "idtAFP";
                cboListaAFP.DisplayMember = "Nombre";
                cboListaAFP.DataSource = miListaAFP.ObtenerListaAFP();
               
                miAFPSeleccionada.ComisionesAFP = new BindingList<cComisionesAFP>();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message ); 
            }
                
           
        }

        private void cboListaAFP_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (cboListaAFP.SelectedIndex != -1 & cboListaAFP.Items.Count >0 )
            {
                miAFPSeleccionada.Nombre = cboListaAFP.Text;
                miAFPSeleccionada.CodigoAFP = Convert.ToInt16(cboListaAFP.SelectedValue.ToString());
                try
                {
                    dtgComisiones.DataSource = Conexion.GDatos.TraerDataTable("spComisionesXAFP", miAFPSeleccionada.CodigoAFP);
                }
                catch (Exception d)
                {
                    MessageBox.Show(d.Message);
                }
            }

           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmComisiones fComisiones = new frmComisiones();
                fComisiones.miComisionAFP = new cComisionesAFP();
                fComisiones.miComisionAFP.Afp = miAFPSeleccionada;
                fComisiones.miComisionAFP.Mes = DateTime.Now;
                if (fComisiones.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    miListaAFP.AgregarComision(fComisiones.miComisionAFP);
                    dtgComisiones.DataSource = Conexion.GDatos.TraerDataTable("spComisionesXAFP", miAFPSeleccionada.CodigoAFP);
                }
                else
                {
                    MessageBox.Show("Se canceló la operación");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show( f.Message);  
                
            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                frmComisiones fComisionesAModificar = new frmComisiones();
                fComisionesAModificar.miComisionAFP = new cComisionesAFP();
                fComisionesAModificar.miComisionAFP.Afp = new cAFP();
                fComisionesAModificar.miComisionAFP.Afp = miAFPSeleccionada;

                if (dtgComisiones.SelectedRows.Count > 0)
                {
                    fComisionesAModificar.miComisionAFP.CodigoComision = Convert.ToInt16(dtgComisiones.SelectedRows[0].Cells[0].Value.ToString());
                    fComisionesAModificar.miComisionAFP.Afp.CodigoAFP = Convert.ToInt16(dtgComisiones.SelectedRows[0].Cells[1].Value.ToString());
                    fComisionesAModificar.miComisionAFP.Mes = Convert.ToDateTime(dtgComisiones.SelectedRows[0].Cells[2].Value.ToString());
                    fComisionesAModificar.miComisionAFP.PrimaSeguros = Convert.ToDecimal(dtgComisiones.SelectedRows[0].Cells[3].Value.ToString());
                    fComisionesAModificar.miComisionAFP.AporteObligatorio = Convert.ToDecimal(dtgComisiones.SelectedRows[0].Cells[4].Value.ToString());
                    fComisionesAModificar.miComisionAFP.RemuneracionAsegurable = Convert.ToDecimal(dtgComisiones.SelectedRows[0].Cells[5].Value.ToString());
                    fComisionesAModificar.miComisionAFP.ComisionFlujo = Convert.ToDecimal(dtgComisiones.SelectedRows[0].Cells[6].Value.ToString());
                    fComisionesAModificar.miComisionAFP.ComisionMixta = Convert.ToDecimal(dtgComisiones.SelectedRows[0].Cells[7].Value.ToString());


                    fComisionesAModificar.Text = "Comisiones AFP para modificar";
                    if (fComisionesAModificar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        miListaAFP.ModificarComision(fComisionesAModificar.miComisionAFP);
                        dtgComisiones.DataSource = Conexion.GDatos.TraerDataTable("spComisionesXAFP", miAFPSeleccionada.CodigoAFP);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una Comisión para modificar");
                }
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
                
            }
           

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar la comision?", "Eliminar Comision", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmComisiones fComisionesAModificar = new frmComisiones();
                    fComisionesAModificar.miComisionAFP = new cComisionesAFP();
                    fComisionesAModificar.miComisionAFP.Mes = DateTime.Now;
                    if (dtgComisiones.SelectedRows.Count > 0)
                    {
                        fComisionesAModificar.miComisionAFP.CodigoComision = Convert.ToInt16(dtgComisiones.SelectedRows[0].Cells[0].Value.ToString());
                        miListaAFP.ELiminarComision(fComisionesAModificar.miComisionAFP);
                        dtgComisiones.DataSource = Conexion.GDatos.TraerDataTable("spComisionesXAFP", miAFPSeleccionada.CodigoAFP);
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una Comisión para eliminar");
                    }
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
                
            }
           
        }

        private void dtgComisiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboListaAFP_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
        }
    }
}
