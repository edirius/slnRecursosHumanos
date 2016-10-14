using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Documento
{
    public partial class frmTipoDocumento : Form
    {
        CapaDeNegociosTramite.Documento.cTipoDocumento miTipoDocumento = new CapaDeNegociosTramite.Documento.cTipoDocumento();
        DataTable Tabla = new DataTable();
        string mensaje = "";
        string respuesta = "";

        public frmTipoDocumento()
        {
            InitializeComponent();
            ActualizarLista();
        }
        public void ActualizarLista()
        {
            dgvListarTipoDoc.DataSource = miTipoDocumento.ListarTipoDocumento();
        }
        private void ConfiguracionInicial()
        {
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }
        public void AgregarTipoDocumento()
        {
            if (txtDescripcion.Text != "")
            {
                miTipoDocumento.Descripcion = txtDescripcion.Text;
                Tabla = miTipoDocumento.AgregarTipoDocumento();
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
        public void ModificarTipoDocumento()
        {
            if (txtDescripcion.Text != "")
            {
                int valor = dgvListarTipoDoc.CurrentCell.RowIndex;
                miTipoDocumento.CodigoTipoDocumento = int.Parse(dgvListarTipoDoc[1, valor].Value.ToString());
                miTipoDocumento.Descripcion = txtDescripcion.Text;
                Tabla = miTipoDocumento.ModificarTipoDocumento();
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
        private void EliminarTipoDocumento()
        {
            int valor = dgvListarTipoDoc.CurrentCell.RowIndex;
            miTipoDocumento.CodigoTipoDocumento = int.Parse(dgvListarTipoDoc[1, valor].Value.ToString());
            miTipoDocumento.Descripcion = txtDescripcion.Text;
            Tabla = miTipoDocumento.EliminarTipoDocumento();
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
            AgregarTipoDocumento();
            ConfiguracionInicial();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarTipoDocumento();
            ConfiguracionInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarTipoDocumento();
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

        private void dgvListarTipoDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListarTipoDoc.CurrentCell.RowIndex;
            txtDescripcion.Text = dgvListarTipoDoc[2, valor].Value.ToString();
        }

        private void frmTipoDocumento_Load(object sender, EventArgs e)
        {

        }
    }
}
