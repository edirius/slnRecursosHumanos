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
using CapaDeNegocios.Obras;
using cWord;
using CapaUsuario.Properties;
using MySql.Data;
using MySql.Data.MySqlClient;
using CapaDeNegocios;

namespace CapaUsuario.Usuarios
{
    public partial class frmLogin : Form
    {
        CapaDeNegocios.Usuario.cUsuario oUsuario = new CapaDeNegocios.Usuario.cUsuario();
        ////MySqlConnection Con = new MySqlConnection(Settings.Default.ConexionMySql, "bdPersonal", "root", "root");
        //MySqlConnection cn = new MySqlConnection("Server =  192.168.1.60; Uid = root; Password = root; Database = bdPersonal");
        //MySqlCommand cmd = new MySqlCommand();
        public frmLogin()
        {
            
            InitializeComponent();
            pbImagen.Image = Resources.MUNICIPALIDAD_DISTRITAL_DE_CCATCCA_2;

        }
        public string Usuario;
        private void btnAceptar_Click(object sender, EventArgs e)
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
                    frmPrincipal Principal = new frmPrincipal();
                    MessageBox.Show("Bienvenido al sistema de planillas usuario " + Usuario+ ".");
                    Principal.Show();
                    this.Hide();
                    Principal.DarPrivilegios(Usuario);
                }
                else {
                    const string message = "El Usuario no existe o la contraseña es incorrecta.";
                    const string caption = "Error";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = ""; txtPass.Text = ""; txtUsuario.Focus(); }
            }
            catch { }
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
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
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
                        frmPrincipal Principal = new frmPrincipal();
                        MessageBox.Show("Bienvenido al sistema de planillas usuario " + Usuario +".");
                        Principal.Show();
                        this.Hide();
                        Principal.DarPrivilegios(Usuario);
                    }
                    else {
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
