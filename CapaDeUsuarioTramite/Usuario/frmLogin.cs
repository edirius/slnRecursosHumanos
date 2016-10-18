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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CapaDeUsuarioTramite.Usuario
{
    public partial class frmLogin : Form
    {
        CapaDeNegocios.Usuario.cUsuario oUsuario = new CapaDeNegocios.Usuario.cUsuario();
        public frmLogin()
        {
            InitializeComponent();

        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            linkLabel1.Links.Add(0, 20, "https://www.facebook.com/ediriussoft");
            try
            {
                Conexion.IniciarSesion(Settings.Default.ConexionMySql, "bdPersonal", "root", "root");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVerContraseña.Checked)
            {
                txtcontraseña.PasswordChar = '\0';
            }
            else
            {
                txtcontraseña.PasswordChar = '●';
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
        public string Usuario;
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string existe = "@a";
            string user = "@b";
            try
            {
                int numero;
                string Contraseña = oUsuario.ObtenerSHA1(txtcontraseña.Text);
                numero = oUsuario.ValidarUsuarioContraseña(txtusuario.Text, Contraseña, existe, user);
                Usuario = txtusuario.Text;
                //
                if (numero == 1)
                {
                    frmMenuTramite MenuTramite = new frmMenuTramite();
                    MessageBox.Show("Bienvenido al Sistema de Tramite Documentario usuario " + Usuario + ".", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MenuTramite.Show();
                    this.Hide();
                    MenuTramite.obtenerDatos(Usuario);
                }
                else
                {
                    const string message = "El Usuario no existe o la contraseña es incorrecta.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtusuario.Text = ""; txtcontraseña.Text = ""; txtusuario.Focus();
                }
            }
            catch { }
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string existe = "@a";
                string user = "@b";
                try
                {
                    int numero;
                    string Contraseña = oUsuario.ObtenerSHA1(txtcontraseña.Text);
                    numero = oUsuario.ValidarUsuarioContraseña(txtusuario.Text, Contraseña, existe, user);
                    Usuario = txtusuario.Text;
                    //
                    if (numero == 1)
                    {
                        frmMenuTramite MenuTramite = new frmMenuTramite();
                        MessageBox.Show("Bienvenido al Sistema de Planillas usuario " + Usuario + ".", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MenuTramite.Show();
                        this.Hide();
                        MenuTramite.obtenerDatos(Usuario);
                    }
                    else
                    {
                        const string message = "El Usuario no existe o la contraseña es incorrecta.";
                        const string caption = "Error";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtusuario.Text = ""; txtcontraseña.Text = ""; txtusuario.Focus();
                    }
                }
                catch { }

            }
        }

        private void frmLogin_Paint(object sender, PaintEventArgs e)
        {
            //Graphics gr = this.CreateGraphics();
            //Rectangle rectangulo = new Rectangle(0, 0, this.Width, this.Height);
            //LinearGradientBrush brocha = new LinearGradientBrush(rectangulo, Color.SteelBlue, Color.LightSteelBlue, LinearGradientMode.ForwardDiagonal);
            //gr.FillRectangle(brocha, rectangulo);
        }
    }
}
