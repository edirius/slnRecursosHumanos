using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuarioTramite.Solicitud_Oficina
{
    public partial class frmRequisitos : Form
    {
        CapaDeNegociosTramite.Requisito_Oficina.cRequisitoOficina miRequisito = new CapaDeNegociosTramite.Requisito_Oficina.cRequisitoOficina();
        CapaDeNegociosTramite.Oficina.cOficina miOficina = new CapaDeNegociosTramite.Oficina.cOficina();
        DataTable Tabla = new DataTable();
        string mensaje = "";
        string respuesta = "";
        public frmRequisitos()
        {
            InitializeComponent();
            ActualizarLista();
            ConfiguracionInicial();
        }
        public void ActualizarLista()
        {
            cbOficinas.DisplayMember = "nombre_oficina";
            cbOficinas.ValueMember = "id_oficina";
            dgvListarRequisitos.DataSource = miRequisito.ListarRequisito();
            cbOficinas.DataSource = miOficina.ListarOficina();
            
        }
        public void ConfiguracionInicial()
        {
            txtRequisitos.Text = "";
            txtRequisitos.Focus();
            cbOficinas.Text = "Seleccione una oficina";
        }
        public void AgregarRequisito()
        {
            try
            {
                if (txtRequisitos.Text != "")
                {
                    miRequisito.NombreRequisito = txtRequisitos.Text;
                    miRequisito.CodigoOficina = int.Parse(cbOficinas.SelectedValue.ToString());
                    Tabla = miRequisito.AgregarRequisito();
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
            catch { MessageBox.Show("Seleccione un dato de la lista deplegable" + " oficina", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }
        public void ModificarRequisito()
        {
            if (txtRequisitos.Text != "")
            {
                int Valor = dgvListarRequisitos.CurrentCell.RowIndex;
                miRequisito.CodigoRequisitoOficina = int.Parse(dgvListarRequisitos[0, Valor].Value.ToString());
                miRequisito.NombreRequisito = txtRequisitos.Text;
                miRequisito.CodigoOficina = int.Parse(cbOficinas.SelectedValue.ToString());
                Tabla = miRequisito.ModificarRequisito();
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
        private void EliminarRequisito()
        {
            try
            {
                int Valor = dgvListarRequisitos.CurrentCell.RowIndex;
                miRequisito.CodigoRequisitoOficina = int.Parse(dgvListarRequisitos[0, Valor].Value.ToString());
                miRequisito.NombreRequisito = txtRequisitos.Text;
                Tabla = miRequisito.EliminarRequisito();
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
            catch
            {
                
                MessageBox.Show("No ha seleccionado ningún requisito para eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarRequisito();
        }

        private void dgvListarRequisitos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListarRequisitos.CurrentCell.RowIndex;
            miRequisito.CodigoRequisitoOficina= int.Parse(dgvListarRequisitos[0, valor].Value.ToString());
            txtRequisitos.Text = dgvListarRequisitos[2, valor].Value.ToString();
            cbOficinas.Text = dgvListarRequisitos[3, valor].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarRequisito();
            ActualizarLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRequisito();
            ActualizarLista();
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
