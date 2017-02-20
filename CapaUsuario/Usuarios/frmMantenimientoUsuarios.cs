using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;


namespace CapaUsuario.Usuarios
{
    public partial class frmMantenimientoUsuarios : Form
    {
        public CapaDeNegocios.Usuario.cUsuario miUsuario;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        public frmMantenimientoUsuarios()
        {
            InitializeComponent();
        }

        private void frmMantenimientoUsuarios_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            lblNombre.Text = miUsuario.Trabajador.Nombres + " " + miUsuario.Trabajador.ApellidoPaterno + " " + miUsuario.Trabajador.ApellidoMaterno;
            txtUsuario.Text = miUsuario.Nombre;
           
            chkHabilitado.Checked = miUsuario.Habilitado1;
            cboCategoria.DisplayMember = "nombre";
            cboCategoria.ValueMember = "idtPrivilegios";
            cboCategoria.DataSource = miUsuario.Privilegio.ListaPrivilegios();
            cboCategoria.SelectedValue = miUsuario.Privilegio.Codigo;
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmListaPrivilegios fListaPrivilegios = new frmListaPrivilegios();
            if (fListaPrivilegios.ShowDialog () == DialogResult.OK )
            {

                
            }
            cboCategoria.DataSource = miUsuario.Privilegio.ListaPrivilegios();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty( txtPassword.Text) )
            {
                if (txtPassword.Text == txtPassword2.Text)
                {
                    miUsuario.Nombre = txtUsuario.Text;
                    miUsuario.Password = miUsuario.ObtenerSHA1(txtPassword.Text);
                    miUsuario.Privilegio.Codigo = Convert.ToInt16(cboCategoria.SelectedValue);
                    miUsuario.Habilitado1 = chkHabilitado.Checked;
                    this.DialogResult = DialogResult.OK;
                }

                else
                {
                    MessageBox.Show("El password no coincide:");
                }
            }
            else
            {
                MessageBox.Show("El password no puede estar vacio.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmMantenimientoUsuarios_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.SteelBlue, Color.LightSteelBlue, LinearGradientMode.ForwardDiagonal);
            gr.FillRectangle(brocha, rectangulo);
        }
    }
}
