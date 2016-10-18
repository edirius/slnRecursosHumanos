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
    public partial class frmLogin : Form
    {
        CapaDeNegociosTramite.cUsuario oUsuario = new CapaDeNegociosTramite.cUsuario();
        public frmLogin()
        {
            InitializeComponent();
        }
        public string Usuario;
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string existe = "@a";
            string user = "@b";
            
                int numero;
                string Contraseña = oUsuario.ObtenerSHA1(txtPass.Text);
                numero = oUsuario.ValidarUsuarioContraseña(txtUsuario.Text, Contraseña, existe, user);
                Usuario = txtUsuario.Text;
                //
                if (numero == 1)
                {
                    frmMenuTramite Principal = new frmMenuTramite();
                    MessageBox.Show("Bienvenido al sistema de planillas usuario " + Usuario + ".");
                    Principal.Show();
                    this.Hide();
                }
                else
                {
                    const string message = "El Usuario no existe o la contraseña es incorrecta.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = ""; txtPass.Text = ""; txtUsuario.Focus();
                }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion.IniciarSesion(Settings.Default.ConexionMySql, "bdPersonal", "root", "root");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string existe = "@a";
                string user = "@b";
                try
                {
                    int numero;
                    string Contraseña = oUsuario.ObtenerSHA1(txtPass.Text);
                    numero = oUsuario.ValidarUsuarioContraseña(txtUsuario.Text, Contraseña, existe, user);
                    Usuario = txtUsuario.Text;
                    //
                    if (numero == 1)
                    {
                        CapaDeUsuarioTramite.frmMenuTramite Principal = new frmMenuTramite();
                        MessageBox.Show("Bienvenido al sistema de planillas usuario " + Usuario + ".");
                        Principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        const string message = "El Usuario no existe o la contraseña es incorrecta.";
                        const string caption = "Error";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsuario.Text = ""; txtPass.Text = ""; txtUsuario.Focus();
                    }
                }
                catch { }
            }
        }
    }
}