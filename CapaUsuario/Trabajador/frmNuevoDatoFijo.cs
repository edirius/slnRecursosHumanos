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
    public partial class frmNuevoDatoFijo : Form
    {

        public CapaDeNegocios.Trabajadores.cDatosFijo oDatoFijo;

        public frmNuevoDatoFijo()
        {
            InitializeComponent();
        }

        private void frmNuevoDatoFijo_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            
        }

        private void cboTipoConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(cboTipoConcepto.Text == ""))
                {
                    dtgListaConceptos.DataSource = oDatoFijo.ListarConceptos(cboTipoConcepto.Text); ;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgListaConceptos.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un concepto para llenar su monto fijo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (txtMonto.Text=="")
                    {
                        MessageBox.Show("Debe seleccionar un monto para llenar su monto fijo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMonto.Focus();
                    }
                    else
                    {
                        switch (cboTipoConcepto.Text)
                        {
                            case "INGRESOS":
                                oDatoFijo.CodigoMaestro = Convert.ToInt16(dtgListaConceptos.Rows[dtgListaConceptos.SelectedRows[0].Index].Cells["idtmaestroingresos"].Value);
                                break;
                            case "DESCUENTOS":
                                oDatoFijo.CodigoMaestro = Convert.ToInt16(dtgListaConceptos.Rows[dtgListaConceptos.SelectedRows[0].Index].Cells["idtmaestrodescuentos"].Value);
                                break;
                            case "Aportacion Empleador":
                                oDatoFijo.CodigoMaestro = Convert.ToInt16(dtgListaConceptos.Rows[dtgListaConceptos.SelectedRows[0].Index].Cells["idtmaestroaportacionesempleador"].Value);
                                break;
                            case "Aportacion Trabajador":
                                oDatoFijo.CodigoMaestro = Convert.ToInt16(dtgListaConceptos.Rows[dtgListaConceptos.SelectedRows[0].Index].Cells["idtmaestroaportacionestrabajador"].Value);
                                break;
                            default:
                                break;
                        }
                       
                        oDatoFijo.Monto = Convert.ToDouble(txtMonto.Text);
                        oDatoFijo.TipoMaestro = cboTipoConcepto.Text;
                        oDatoFijo.AgregarDatosFijos(oDatoFijo);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar un dato fijo: frmNuevoDatoDijo.cs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar) )
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
