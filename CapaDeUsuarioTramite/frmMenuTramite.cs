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

        private void mantenimientoRequisitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaDeUsuarioTramite.Solicitud_Oficina.frmRequisitos frmRequisito = new Solicitud_Oficina.frmRequisitos();
            frmRequisito.MdiParent = this;
            frmRequisito.Show();
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
            CapaDeUsuarioTramite.Tramite.frmTramite frmTramite = new Tramite.frmTramite();
            frmTramite.MdiParent = this;
            frmTramite.Show();
        }
    }
}
