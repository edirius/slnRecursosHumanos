using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegociosTramite;
using CapaDeNegociosTramite.Oficina;

namespace CapaDeUsuarioTramite.Oficina
{
    public partial class frmOficina : Form
    {
        cOficina miOficina = new cOficina();

        public frmOficina()
        {
            InitializeComponent();
            ActualizarLista();
        }
        public void ActualizarLista()
        {
            dgvListarOficinas.DataSource =  miOficina.ListarOficina();
        }
        public void ConfiguracionInicial()
        {
            txtDependencia.Text = "";
            txtDescripcion.Text = "";
            txtNombreOficina.Text = "";
            txtDependencia.Focus();
        }
        public void AgregarOficina()
        {
            try
            {
                int numero;
                miOficina.Dependencia = txtDependencia.Text;
                miOficina.NombreOficina = txtNombreOficina.Text;
                miOficina.DescripcionOficina = txtDescripcion.Text;
                numero = miOficina.AgregarOficina();
                //
                if (numero == 1)
                {
                    ActualizarLista();
                    MessageBox.Show("Oficina agregada correctamente");
                }
                else
                {
                    const string message = "No ha insertado ningun dato";
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
        public void Modificar()
        {
            try
            {
                int numero;
                int valor = dgvListarOficinas.CurrentCell.RowIndex;
                miOficina.CodigoOficina = int.Parse(dgvListarOficinas[0, valor].Value.ToString());
                miOficina.Dependencia = txtDependencia.Text;
                miOficina.NombreOficina = txtNombreOficina.Text;
                miOficina.DescripcionOficina = txtDescripcion.Text;
                numero = miOficina.ModificarOficina();
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
        private void Eliminar()
        {
            try
            {
                int numero;
                int valor = dgvListarOficinas.CurrentCell.RowIndex;
                miOficina.CodigoOficina = int.Parse(dgvListarOficinas[0, valor].Value.ToString());
                numero = miOficina.EliminarOficina();
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
            AgregarOficina();
            ConfiguracionInicial();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            ConfiguracionInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            ConfiguracionInicial();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }
        private void dgvListarOficinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListarOficinas.CurrentCell.RowIndex;
            miOficina.CodigoOficina = int.Parse(dgvListarOficinas[0, valor].Value.ToString());
            txtDependencia.Text = dgvListarOficinas[1, valor].Value.ToString();
            txtNombreOficina.Text = dgvListarOficinas[2, valor].Value.ToString();
            txtDescripcion.Text = dgvListarOficinas[3, valor].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOficina_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            AgregarOficina();
        }
    }
}
