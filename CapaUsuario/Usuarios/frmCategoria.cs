using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;
using CapaDeNegocios.Usuario;

namespace CapaUsuario.Usuarios
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        public cPrivilegio miPrivilegio;


        private void frmCategoria_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtDescripcion.Text = miPrivilegio.Descripcion;
            checkMenuAFP.Checked = miPrivilegio.MenuAFP;
            checkUsuarios.Checked = miPrivilegio.MenuUsuario;
            CheckTrabadores.Checked = miPrivilegio.MenuTrabajadores;
            CheckTareos.Checked = miPrivilegio.MenuTareos;
            CheckMeta.Checked = miPrivilegio.MenuMetas;
            CheckPlanillas.Checked = miPrivilegio.MenuPlanillas;
            CheckTablas.Checked = miPrivilegio.MenuTablasParametricass;
            CheckExportar.Checked = miPrivilegio.MenuExportarDatos;
            CheckReportes.Checked = miPrivilegio.MenuReportes;
            chkMenuBoletas.Checked = miPrivilegio.MenuBoletas;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            miPrivilegio.Descripcion = txtDescripcion.Text;
            miPrivilegio.MenuAFP = checkMenuAFP.Checked;
            miPrivilegio.MenuUsuario = checkUsuarios.Checked;
            miPrivilegio.MenuTrabajadores = CheckTrabadores.Checked;
            miPrivilegio.MenuTareos = CheckTareos.Checked;
            miPrivilegio.MenuMetas = CheckMeta.Checked;
            miPrivilegio.MenuPlanillas = CheckPlanillas.Checked;
            miPrivilegio.MenuTablasParametricass = CheckTablas.Checked;
            miPrivilegio.MenuExportarDatos = CheckExportar.Checked;
            miPrivilegio.MenuReportes = CheckReportes.Checked;
            miPrivilegio.MenuBoletas = chkMenuBoletas.Checked;
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
