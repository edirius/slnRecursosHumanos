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
    }
}
