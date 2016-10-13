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
        DataTable Tabla = new DataTable();
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
            if (txtDescripcion.Text != "")
            {
                miSede.Descripcion = txtDescripcion.Text;
                Tabla = miSede.AgregarSede();
                respuesta = Tabla.Rows[0][0].ToString();
                mensaje = Tabla.Rows[0][1].ToString();
                if (respuesta == "1")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfiguracionInicial();
                    ActualizarLista();
                }
                else if (respuesta == "0")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfiguracionInicial();
                }
            }
            else
                MessageBox.Show("Por favor llene los campos necesarios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void ModificarSede()
        {
            if (txtDescripcion.Text != "")
            {
                int valor = dgvListarSede.CurrentCell.RowIndex;
                miSede.CodigoSede = int.Parse(dgvListarSede[1, valor].Value.ToString());
                miSede.Descripcion = txtDescripcion.Text;
                Tabla = miSede.ModificarSede();
                respuesta = Tabla.Rows[0][0].ToString();
                mensaje = Tabla.Rows[0][1].ToString();
                if (respuesta == "1")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfiguracionInicial();
                    ActualizarLista();
                }
                else if (respuesta == "0")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfiguracionInicial();
                }
            }
            else
                MessageBox.Show("Por favor llene los campos necesarios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void EliminarSede()
        {
            int valor = dgvListarSede.CurrentCell.RowIndex;
            miSede.CodigoSede = int.Parse(dgvListarSede[1, valor].Value.ToString());
            miSede.Descripcion = txtDescripcion.Text;
            Tabla = miSede.EliminarSede();
            respuesta = Tabla.Rows[0][0].ToString();
            mensaje = Tabla.Rows[0][1].ToString();
            if (respuesta == "1")
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(mensaje);
                ConfiguracionInicial();
                ActualizarLista();
            }
            else if (respuesta == "0")
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConfiguracionInicial();
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
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }

        private void frmLocalSede_Load(object sender, EventArgs e)
        {
            dgvListarSede.Columns[1].Visible = false;
        }
    }
}
