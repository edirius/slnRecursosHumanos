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
    public partial class frmLocalSede : Form
    {

        CapaDeNegociosTramite.LocalSede.cLocalSede oLocalSede = new CapaDeNegociosTramite.LocalSede.cLocalSede();
        DataTable odtLocalSede = new DataTable();

        int codigo = 0;
        string descripcion = "";

        public frmLocalSede()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = (dgvLocalSede.Rows.Count + 1 ).ToString() ;
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }

        private void frmLocalSede_Load(object sender, EventArgs e)
        {
            dgvLocalSede.DataSource = oLocalSede.TramiteListarLocalSede();

            int cantidad_operaciones = dgvLocalSede.Rows.Count;

            if (cantidad_operaciones > 0)
            {
                dgvLocalSede.Rows[0].Cells[2].Selected = true;
                dgvLocalSede.Columns[1].Visible = false;
            
                txtCodigo.Text = dgvLocalSede.Rows[0].Cells[0].Value.ToString();
                txtDescripcion.Text = dgvLocalSede.Rows[0].Cells[2].Value.ToString();
                codigo = Convert.ToInt32(dgvLocalSede.Rows[0].Cells[1].Value.ToString());
                descripcion = dgvLocalSede.Rows[0].Cells[2].Value.ToString();
                dgvLocalSede.Columns[0].Width = 30;
                dgvLocalSede.Columns[2].Width = 150;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            descripcion = txtDescripcion.Text;

            if (codigo > 0 && descripcion != "")
            {
                odtLocalSede = oLocalSede.TramiteInsertarLocalSede(descripcion);
                string resultado_operacion = odtLocalSede.Rows[0][0].ToString();
                if (resultado_operacion == "1")
                {
                    resultado_operacion = odtLocalSede.Rows[0][1].ToString();
                    MessageBox.Show(resultado_operacion, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                    dgvLocalSede.DataSource = oLocalSede.TramiteListarLocalSede();
                }
                else if (resultado_operacion == "0")
                {
                    resultado_operacion = odtLocalSede.Rows[0][1].ToString();
                    MessageBox.Show(resultado_operacion, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Porfavor llene los datos de descripción.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescripcion.Text != "")
            {
                descripcion = txtDescripcion.Text;

                if (codigo > 0 && descripcion != "")
                {
                    
                    odtLocalSede = oLocalSede.TramiteModificarLocalSede(codigo, descripcion);
                    string exito_operacion = odtLocalSede.Rows[0][0].ToString();
                    string resultado = odtLocalSede.Rows[0][1].ToString();

                    if (exito_operacion == "1")
                    {
                        MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCodigo.Text = "";
                        txtDescripcion.Text = "";
                        dgvLocalSede.DataSource = oLocalSede.TramiteListarLocalSede();
                    }
                    else if (exito_operacion == "0")
                    {
                        MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Seleccionar un registro para modificar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text != "")
            {
 
                if (codigo > 0)
                {
                    DialogResult result = MessageBox.Show("¿Desea eliminar el local " + descripcion + " ?", "Mantención", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        odtLocalSede = oLocalSede.TramiteEliminarLocalSede(codigo,descripcion);
                        string exito_operacion = odtLocalSede.Rows[0][0].ToString();
                        string resultado = odtLocalSede.Rows[0][1].ToString();
                        if (exito_operacion == "1")
                        {

                            MessageBox.Show(resultado, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCodigo.Text = "";
                            txtDescripcion.Text = "";
                            dgvLocalSede.DataSource = oLocalSede.TramiteListarLocalSede();


                            int cantidad_operaciones = dgvLocalSede.Rows.Count;

                            if (cantidad_operaciones > 0)
                            {
                                dgvLocalSede.Rows[0].Cells[2].Selected = true;
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

        private void dgvLocalSede_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad_operaciones = dgvLocalSede.Rows.Count;

            if (cantidad_operaciones > 0)
            {
                txtCodigo.Text = dgvLocalSede.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDescripcion.Text = dgvLocalSede.Rows[e.RowIndex].Cells[2].Value.ToString();

                codigo = Convert.ToInt32(dgvLocalSede.Rows[e.RowIndex].Cells[1].Value.ToString()) ;
                descripcion = dgvLocalSede.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
        }

        private void dgvLocalSede_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad_operaciones = dgvLocalSede.Rows.Count;

            if (cantidad_operaciones > 0)
            {
                txtCodigo.Text = dgvLocalSede.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDescripcion.Text = dgvLocalSede.Rows[e.RowIndex].Cells[2].Value.ToString();
                codigo = Convert.ToInt32(dgvLocalSede.Rows[e.RowIndex].Cells[1].Value.ToString());
                descripcion = dgvLocalSede.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
    }
}
