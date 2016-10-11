using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Tramite
{
    public partial class frmOperacion : Form
    {
        CapaDeNegociosTramite.Operacion.cOperacion oOperacion = new CapaDeNegociosTramite.Operacion.cOperacion();
        DataTable odtOperacion = new DataTable();
        int codigo = 0;
        string descripcion = "";

        public frmOperacion()
        {
            InitializeComponent();
        }

        private void frmOperacion_Load(object sender, EventArgs e)
        {


            dgvOperacion.DataSource = oOperacion.TramiteListarOperacion();

            int cantidad_operaciones = dgvOperacion.Rows.Count;

            if (cantidad_operaciones > 0)
            {
                dgvOperacion.Rows[0].Cells[1].Selected = true;
                
                txtCodigo.Text = dgvOperacion.Rows[0].Cells[0].Value.ToString();
                txtDescripcion.Text = dgvOperacion.Rows[0].Cells[2].Value.ToString();
                codigo = Convert.ToInt32(dgvOperacion.Rows[0].Cells[1].Value);
                descripcion = dgvOperacion.Rows[0].Cells[2].ToString();
                dgvOperacion.Columns[0].Width = 30;
                dgvOperacion.Columns[1].Visible = false;
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            codigo = Convert.ToInt32(dgvOperacion.Rows[0].Cells[1].Value);
            descripcion = txtDescripcion.Text;

            if ( codigo > 0 && descripcion != "")
            {
                odtOperacion = oOperacion.TramiteInsertarOperacion( descripcion );
                string resultado_operacion = odtOperacion.Rows[0][0].ToString();
                if (resultado_operacion == "1")
                {
                    resultado_operacion = odtOperacion.Rows[0][1].ToString();
                    MessageBox.Show(resultado_operacion, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                    dgvOperacion.DataSource = oOperacion.TramiteListarOperacion();
                }
                else if (resultado_operacion == "0")
                {
                    resultado_operacion = odtOperacion.Rows[0][1].ToString();
                    MessageBox.Show(resultado_operacion, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Porfavor llene los datos de descripción.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvOperacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad_operaciones = dgvOperacion.Rows.Count;

            if (cantidad_operaciones > 0 && e.RowIndex != -1)
            {
                codigo = Convert.ToInt32(dgvOperacion.Rows[e.RowIndex].Cells[1].Value);
                descripcion = dgvOperacion.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCodigo.Text = dgvOperacion.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDescripcion.Text = descripcion;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = (dgvOperacion.Rows.Count + 1).ToString();
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }

        private void dgvOperacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad_operaciones = dgvOperacion.Rows.Count;

            if (cantidad_operaciones > 0 && e.RowIndex != -1 )
            {
                codigo = Convert.ToInt32(dgvOperacion.Rows[e.RowIndex].Cells[1].Value);
                descripcion = dgvOperacion.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCodigo.Text = dgvOperacion.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDescripcion.Text = descripcion;
                
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescripcion.Text != "")
            {
               
                if (codigo > 0 && descripcion != "")
                {
                    descripcion = txtDescripcion.Text;
                    odtOperacion = oOperacion.TramiteModificarOperacion(codigo, descripcion);
                    string exito_operacion = odtOperacion.Rows[0][0].ToString();
                    string resultado = odtOperacion.Rows[0][1].ToString();

                    if (exito_operacion == "1")
                    {
                        MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCodigo.Text = "";
                        txtDescripcion.Text = "";
                        dgvOperacion.DataSource = oOperacion.TramiteListarOperacion();
                    }
                    else if (exito_operacion == "0")
                    {
                        MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }else
                MessageBox.Show("Seleccionar un registro para modificar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (txtCodigo.Text != "")
            {
                
                if (codigo > 0)
                {
                    DialogResult result = MessageBox.Show("¿Desea eliminar la operación " + descripcion + " ?", "Mantención", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        odtOperacion = oOperacion.TramiteEliminarOperacion(codigo,descripcion);
                        string exito_operacion = odtOperacion.Rows[0][0].ToString();
                        string resultado = odtOperacion.Rows[0][1].ToString();
                        if (exito_operacion == "1")
                        {

                            MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCodigo.Text = "";
                            txtDescripcion.Text = "";
                            dgvOperacion.DataSource = oOperacion.TramiteListarOperacion();


                            int cantidad_operaciones = dgvOperacion.Rows.Count;

                            if (cantidad_operaciones > 0)
                            {
                                dgvOperacion.Rows[0].Cells[2].Selected = true;
                                
                            }

                        }
                        else if (exito_operacion == "0")
                        {
                            MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                    
                }
                else
                    MessageBox.Show("Seleccionar un registro para borrar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Seleccionar un registro para borrar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }

}