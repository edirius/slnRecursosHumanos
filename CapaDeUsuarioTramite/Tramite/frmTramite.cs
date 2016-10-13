using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegociosTramite.Operaciones;

namespace CapaDeUsuarioTramite.Tramite
{
    public partial class frmTramite : Form
    {
        CapaDeNegociosTramite.Tramite.cTramite miTramite = new CapaDeNegociosTramite.Tramite.cTramite();
        CapaDeNegociosTramite.Oficina.cOficina miOficina = new CapaDeNegociosTramite.Oficina.cOficina();
        CapaDeNegociosTramite.Documento.cDocumento miDocumento = new CapaDeNegociosTramite.Documento.cDocumento();
        CapaDeNegociosTramite.LocalSede.cSede miSede = new CapaDeNegociosTramite.LocalSede.cSede();
        CapaDeNegociosTramite.Oficina.cOficinaTrabajador miOficinaTrabajador = new CapaDeNegociosTramite.Oficina.cOficinaTrabajador();
        cOperaciones miOperacion = new cOperaciones();
        DataTable Tabla = new DataTable();
        string mensaje = "";
        string respuesta = "";
        public frmTramite()
        {
            
            InitializeComponent();
            ActualizarLista();
            CargarCombos();
            ConfiguracionInicial();
        }
        public void ActualizarLista()
        {
            dgvListarTramites.DataSource = miTramite.ListarTramite();
        }
        public void CargarCombos()
        {
            cbSede.ValueMember = "ID";
            cbSede.DisplayMember = "DESCRIPCION";
            cbSede.DataSource = miSede.ListarSede();

            cboOperacion.ValueMember = "id_operacion";
            cboOperacion.DisplayMember = "descripcion";
            cboOperacion.DataSource = miOperacion.ListarOperacion();

            cbOficina.ValueMember = "id_oficina";
            cbOficina.DisplayMember = "Oficina";
            cbOficina.DataSource = miOficinaTrabajador.ListarOficinaTrabajador();

            cbTrabajador.ValueMember = "id_oficina_trabajador";
            cbTrabajador.DisplayMember = "Nombres";
            cbTrabajador.DataSource = miOficinaTrabajador.ListarOficinaTrabajador();

            cbUnidadDestino.ValueMember = "id_oficina";
            cbUnidadDestino.DisplayMember = "Oficina";
            cbUnidadDestino.DataSource = miOficinaTrabajador.ListarOficinaTrabajador();

            cboUsuarioDestino.ValueMember = "id_oficina_trabajador";
            cboUsuarioDestino.DisplayMember = "nombres";
            cboUsuarioDestino.DataSource = miTramite.ListarTrabajadoresPorOficina(cbUnidadDestino.Text);

            cbDocumento.ValueMember = "id_documento";
            cbDocumento.DisplayMember = "expediente";
            cbDocumento.DataSource = miDocumento.ListarDocumento();
        }
        public void ConfiguracionInicial()
        {
            cbSede.Text = "Seleccione aqui la Sede";
            cboOperacion.Text = "Seleccione aqui la operación";
            cbOficina.Text = "Seleccione aqui la oficina";
            cbTrabajador.Text = "Seleccione aqui el trabajador";
            cbUnidadDestino.Text = "Seleccione aqui la unidad de destino";
            cboUsuarioDestino.Text = "Seleccione aqui el usuario de destino";
            cbDocumento.Text = "Seleccione aqui el documento";
        }
        public void AgregarTramite()
        {
            try
            {
                miTramite.CodigoLocalSede = int.Parse(cbSede.SelectedValue.ToString());
                miTramite.FechaHora = dtpFechaHora.Value;
                miTramite.CodigoOperacion = int.Parse(cboOperacion.SelectedValue.ToString());
                miTramite.CodigoOficina = int.Parse(cbOficina.SelectedValue.ToString());
                miTramite.CodigoOficinaTrabajador = int.Parse(cbTrabajador.SelectedValue.ToString());
                miTramite.UnidadDestino = int.Parse(cbUnidadDestino.SelectedValue.ToString());
                miTramite.UsuarioDestino = int.Parse(cboUsuarioDestino.SelectedValue.ToString());
                miTramite.Proveido = txtProveido.Text;
                miTramite.CodigoDocumento = int.Parse(cbDocumento.SelectedValue.ToString());
                Tabla = miTramite.AgregarTramite();
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
                MessageBox.Show("Seleccione los campos necesarios para agregar el tramite", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConfiguracionInicial();
            }
        }
        public void Modificar()
        {
            try
            {
                int Valor = dgvListarTramites.CurrentCell.RowIndex;
                miTramite.CodigoTramite = int.Parse(dgvListarTramites[0, Valor].Value.ToString());
                miTramite.CodigoLocalSede = int.Parse(cbSede.SelectedValue.ToString());
                miTramite.FechaHora = dtpFechaHora.Value;
                miTramite.CodigoOperacion = int.Parse(cboOperacion.SelectedValue.ToString());
                miTramite.CodigoOficina = int.Parse(cbOficina.SelectedValue.ToString());
                miTramite.CodigoOficinaTrabajador = int.Parse(cbTrabajador.SelectedValue.ToString());
                miTramite.UnidadDestino = int.Parse(cbUnidadDestino.SelectedValue.ToString());
                miTramite.UsuarioDestino = int.Parse(cboUsuarioDestino.SelectedValue.ToString());
                miTramite.Proveido = txtProveido.Text;
                miTramite.CodigoDocumento = int.Parse(cbDocumento.SelectedValue.ToString());
                Tabla = miTramite.ModificarTramite();
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
                MessageBox.Show("Seleccione los campos necesarios para modificar el tramite", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConfiguracionInicial();
            }
                
            
        }
        public void Eliminar()
        {
            try
            {
                int Valor = dgvListarTramites.CurrentCell.RowIndex;
                miTramite.CodigoTramite = int.Parse(dgvListarTramites[0, Valor].Value.ToString());
                Tabla = miTramite.EliminarTramite();
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
            catch{}
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarTramite();
        }

        private void cbUnidadDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboUsuarioDestino.ValueMember = "id_trabajador";
            cboUsuarioDestino.DisplayMember = "nombres";
            cboUsuarioDestino.DataSource = miTramite.ListarTrabajadoresPorOficina(cbUnidadDestino.Text);
        }

        private void dgvListarTramites_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListarTramites.CurrentCell.RowIndex;
            cbSede.Text = dgvListarTramites[1, valor].Value.ToString();
            dtpFechaHora.Text = dgvListarTramites[2,valor].Value.ToString();
            cboOperacion.Text = dgvListarTramites[3, valor].Value.ToString();
            cbOficina.Text = dgvListarTramites[4, valor].Value.ToString();
            cbTrabajador.Text = dgvListarTramites[5, valor].Value.ToString();
            cbUnidadDestino.Text = dgvListarTramites[6, valor].Value.ToString();
            cboUsuarioDestino.Text = dgvListarTramites[7, valor].Value.ToString();
            txtProveido.Text = dgvListarTramites[8, valor].Value.ToString();
            cbDocumento.Text = dgvListarTramites[9, valor].Value.ToString();

        }

        private void cbOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbTrabajador.ValueMember = "id_oficina_trabajador";
            //cbTrabajador.DisplayMember = "nombres";
            //cbTrabajador.DataSource = miTramite.ListarTrabajadoresPorOficina(int.Parse(cbOficina.SelectedValue.ToString()));
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
