using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Local_Sede
{
    public partial class frmLocalSede : Form
    {
        CapaDeNegociosTramite.LocalSede.cSede miSede = new CapaDeNegociosTramite.LocalSede.cSede();
        string descripcion = "";
        DataTable odtLocalSede = new DataTable();
        string mensaje = "";
        string respuesta = "";
        
        public frmLocalSede()
        {
            InitializeComponent();
            ActualizarLista();
        }
        public void ActualizarLista()
        {
            dgvListarSede.DataSource = miSede.ListarSede();
        }
        private void ConfiguracionInicial()
        {
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }
        public void AgregarSede()
        {
            try
            {
                if (txtDescripcion.Text != "") {
                    descripcion = txtDescripcion.Text;
                    odtLocalSede = miSede.AgregarSede(descripcion);
                    respuesta = odtLocalSede.Rows[0][0].ToString();
                    mensaje = odtLocalSede.Rows[0][1].ToString();
                    if (respuesta == "1")
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDescripcion.Text = "";
                        dgvListarSede.DataSource = miSede.ListarSede() ;
                    }
                    else if (respuesta == "0") {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDescripcion.Focus();
                    }
                }else
                    MessageBox.Show("Porfavor llene el campo descripción.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);




            }
            catch
            {
                const string message = "gege";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ModificarSede()
        {
            try
            {
                int numero;
                int valor = dgvListarSede.CurrentCell.RowIndex;
                miSede.CodigoSede = int.Parse(dgvListarSede[0, valor].Value.ToString());
                miSede.Descripcion = txtDescripcion.Text;
                numero = miSede.ModificarSede();
                if (numero == 1)
                {
                    ActualizarLista();
                    MessageBox.Show("La Oficina fue modificada correctamente");
                }
                else
                {
                    const string message = "No ha seleccionado ninguna Oficina para modificar";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                const string message = "La oficina ya existe en la base de datos";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void EliminarSede()
        {
            try
            {
                int numero;
                int valor = dgvListarSede.CurrentCell.RowIndex;
                miSede.CodigoSede = int.Parse(dgvListarSede[0, valor].Value.ToString());
                numero = miSede.EliminarSede();
                if (numero == 1)
                {
                    ActualizarLista();
                    MessageBox.Show("La Oficina fue eliminada correctamente");
                }
                else
                {
                    const string message = "Debe Seleccionar una Oficina";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                const string message = "No existe la oficina";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarSede();
            ConfiguracionInicial();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarSede();
            ConfiguracionInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarSede();
            ConfiguracionInicial();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvListarSede_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListarSede.CurrentCell.RowIndex;
            txtDescripcion.Text = dgvListarSede[2, valor].Value.ToString();
            descripcion = dgvListarSede[2, e.RowIndex].Value.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }

        private void frmLocalSede_Load(object sender, EventArgs e)
        {
            dgvListarSede.Columns[1].Visible = false;
        }

        private void dgvListarSede_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            descripcion = dgvListarSede[2, e.RowIndex].Value.ToString();
        }
    }
}
