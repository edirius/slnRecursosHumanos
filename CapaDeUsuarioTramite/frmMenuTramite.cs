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
using CapaDeUsuarioTramite.Properties;
namespace CapaDeUsuarioTramite
{
    public partial class frmMenuTramite : Form
    {
        CapaDeNegociosTramite.Oficina.cOficinaTrabajador miTrabajador = new CapaDeNegociosTramite.Oficina.cOficinaTrabajador();
        public frmMenuTramite()
        {
            InitializeComponent();
        }
        private void HacerConeccion()
        {
            try
            {
                Conexion.IniciarSesion(Settings.Default.ConexionMySql, "bdPersonal", "root", "root");
                //MessageBox.Show(String.Format("{0}", "Se conecto exitosamente"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Dar privilegios al usuario según su cargo
        //CapaUsuario.Usuarios.frmLogin FrmLogin = new CapaUsuario.Usuarios.frmLogin();
        //CapaDeNegocios.Usuario.cUsuario oUsu = new CapaDeNegocios.Usuario.cUsuario();
        //bool menuAFP, menuUsuario, menuTrabajadores, menuTareos, menuMeta, menuPlanillas, menuSunatTablasParametricas, menuExportarDatosSunat, menuReportes, habilitado;
        bool habilitado;
        public string Usuario;
        public string usu;
        //CapaDeUsuarioTramite.Tramite.frmTramite miTramite = new Tramite.frmTramite();
        public void obtenerDatos(string LoginUsuario)
        {
            
            string Cargo = "";
            string Oficina = "";
            string Trabajador = "";
            dgvListar.DataSource = miTrabajador.DatosUsuario(LoginUsuario);
            
            foreach (DataGridViewRow fila in dgvListar.Rows)
            {
                Trabajador = "TRABAJADOR: " + fila.Cells["Nombres"].Value.ToString();
                Cargo = "CARGO: " + fila.Cells["Cargo"].Value.ToString();
                Oficina = "OFICINA: " + fila.Cells["Oficina"].Value.ToString();
                Usuario = "USUARIO: " + fila.Cells["nombre"].Value.ToString();
                usu = fila.Cells["nombre"].Value.ToString();
                //menuAFP = Convert.ToBoolean(fila.Cells["menuAFP"].Value);
                //menuUsuario = Convert.ToBoolean(fila.Cells["menuUsuario"].Value);
                //menuTrabajadores = Convert.ToBoolean(fila.Cells["menuTrabajadores"].Value);
                //menuTareos = Convert.ToBoolean(fila.Cells["menuTareos"].Value);
                //menuMeta = Convert.ToBoolean(fila.Cells["menuMeta"].Value);
                //menuPlanillas = Convert.ToBoolean(fila.Cells["menuPlanillas"].Value);
                //menuSunatTablasParametricas = Convert.ToBoolean(fila.Cells["menuSunatTablasParametricas"].Value);
                //menuExportarDatosSunat = Convert.ToBoolean(fila.Cells["menuExportarDatosSunat"].Value);
                //menuReportes = Convert.ToBoolean(fila.Cells["menuReportes"].Value);
                habilitado = Convert.ToBoolean(fila.Cells["habilitado"].Value);
                StripLabelUsuario.Text = Trabajador;
                StripLabelCargo.Text = Cargo;
                StripLabelOficina.Text = Oficina;
                toolStripUsuario.Text = Usuario;
                OcultarMenu();
            }
        }
        public void OcultarMenu()
        {
            if (habilitado == true)
            {
                //if (menuAFP == true) { fileMenu.Visible = true; }
                //else { fileMenu.Visible = false; newToolStripButton.Visible = false; }
                //if (menuUsuario == true) { editMenu.Visible = true; }
                //else { editMenu.Visible = false; }
                //if (menuTrabajadores == true) { viewMenu.Visible = true; }
                //else { viewMenu.Visible = false; helpToolStripButton.Visible = false; }
                //if (menuTareos == true) { toolsMenu.Visible = true; }
                //else { toolsMenu.Visible = false; }
                //if (menuMeta == true) { windowsMenu.Visible = true; }
                //else { windowsMenu.Visible = false; }
                //if (menuPlanillas == true) { planillasToolStripMenuItem.Visible = true; }
                //else { planillasToolStripMenuItem.Visible = false; printPreviewToolStripButton.Visible = false; }
                //if (menuSunatTablasParametricas == true) { sUNATToolStripMenuItem.Visible = true; }
                //else { sUNATToolStripMenuItem.Visible = false; }
                //if (menuExportarDatosSunat == true) { exportarTextoSUNATToolStripMenuItem.Visible = true; }
                //else { exportarTextoSUNATToolStripMenuItem.Visible = false; }
                //if (menuReportes == true) { reportesToolStripMenuItem1.Visible = true; }
                //else { reportesToolStripMenuItem1.Visible = false; printToolStripButton.Visible = false; }
            }
            else
            {
                const string message = "El usuario no se encuentra habilitado. Póngase en contacto con el administrador del sistema.";
                const string caption = "Usuario Deshabilitado";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }

        }
        private void mantenimientoOficinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Oficina.frmOficina frmOfi = new Oficina.frmOficina();
            frmOfi.MdiParent = this;
            frmOfi.Show();
        }

        private void frmMenuTramite_Load(object sender, EventArgs e)
        {
            HacerConeccion();
        }
        private void mantenimientoDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Documento.frmDocumento frmDocumento = new Documento.frmDocumento();
            frmDocumento.MdiParent = this;
            frmDocumento.Show();
        }

        private void mantenimientoOfincaTrabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Oficina.frmOficinaTrabajador frmOficinaTrabajador = new Oficina.frmOficinaTrabajador();
            frmOficinaTrabajador.MdiParent = this;
            frmOficinaTrabajador.Show();
        }

        private void registrarTramiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Tramite.frmTramite frmTramite = new Tramite.frmTramite(usu);
            frmTramite.MdiParent = this;
            frmTramite.Show();
        }

        private void mantenimientoRequisitosOficinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Solicitud_Oficina.frmRequisitos frmRequisito = new Solicitud_Oficina.frmRequisitos();
            frmRequisito.MdiParent = this;
            frmRequisito.Show();
        }

        private void mantenimientoLocalesSedesDeLaMunicipalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Local_Sede.frmLocalSede frmLocal = new Local_Sede.frmLocalSede();
            frmLocal.MdiParent = this;
            frmLocal.Show();
        }

        private void tipoDeDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Documento.frmTipoDocumento frmTipoDocumento = new Documento.frmTipoDocumento();
            frmTipoDocumento.MdiParent = this;
            frmTipoDocumento.Show();
        }

        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Operacion.frmOperacion frmOperaciones = new Operacion.frmOperacion();
            frmOperaciones.MdiParent = this;
            frmOperaciones.Show();
        }

        private void frmMenuTramite_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
