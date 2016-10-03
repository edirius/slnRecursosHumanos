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
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string existe = "@a";
            string user = "@b";
            try
            {
                int numero;
                numero = oUsuario.ValidarUsuarioContraseña(txtUsuario.Text, txtPass.Text, existe, user);
                //
                if (numero == 1)
                {
                    lblMensaje.Text = "Bienvenido al Sistema de Planillas";
                    frmPrincipal Principal = new frmPrincipal();
                    Principal.Show();
                    this.Hide();

                }
                else { lblMensaje.Text = "ERROR: El Usuario no existe o la contraseña es incorrecta"; }
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
    }
}
