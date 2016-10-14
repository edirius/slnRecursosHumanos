using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Operacion
{ 
    public partial class frmOperacion : Form
    {
        CapaDeNegociosTramite.Operaciones.cOperaciones miOperacion = new CapaDeNegociosTramite.Operaciones.cOperaciones();
        DataTable Tabla = new DataTable();
        string mensaje = "";
        string respuesta = "";

        public frmOperacion()
        {
            InitializeComponent();
            ActualizarLista();
            ConfiguracionInicial();
        }
        public void ActualizarLista()
        {
            dgvListarOperaciones.DataSource = miOperacion.ListarOperacion();
        }
        private void ConfiguracionInicial()
        {
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }
        public void Agregar()
        {
            if (txtDescripcion.Text != "")
            {
                miOperacion.Descripcion = txtDescripcion.Text;
                Tabla = miOperacion.AgregarOperacion();
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
        public void Modificar()
        {
            if (txtDescripcion.Text != "")
            {
                int valor = dgvListarOperaciones.CurrentCell.RowIndex;
                miOperacion.CodigoOperacion = int.Parse(dgvListarOperaciones[0, valor].Value.ToString());
                miOperacion.Descripcion = txtDescripcion.Text;
                Tabla = miOperacion.ModificarOperacion();
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
        private void Eliminar()
        {
            try
            {
                int valor = dgvListarOperaciones.CurrentCell.RowIndex;
                miOperacion.CodigoOperacion = int.Parse(dgvListarOperaciones[0, valor].Value.ToString());
                miOperacion.Descripcion = txtDescripcion.Text;
                Tabla = miOperacion.EliminarOperacion();
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
            catch
            {
                MessageBox.Show("La operación no puede ser eliminada porque esta siendo usada en el formulario de tramites", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConfiguracionInicial();
            }
        }
        private void dgvListarOperaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListarOperaciones.CurrentCell.RowIndex;
            miOperacion.CodigoOperacion = int.Parse(dgvListarOperaciones[0, valor].Value.ToString());
            txtDescripcion.Text = dgvListarOperaciones[2, valor].Value.ToString();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Agregar();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
