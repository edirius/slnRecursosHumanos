using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaUsuario.Properties;
using System.Xml;
using System.Configuration;

namespace CapaUsuario.Usuarios
{
    public partial class frmModificarServidor : Form
    {
        public frmModificarServidor()
        {
            InitializeComponent();
        }

        private void frmModificarServidor_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtIP.Text = Settings.Default.ConexionMySql;
        }

        private void btnGuardarServidor_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach  (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("connectionStrings"))
                {
                    foreach (XmlNode item in element.ChildNodes)
                    {
                        if (item.Attributes[0].Value == "CapaUsuario.Properties.Settings.ConexionMySql")
                        {
                            item.Attributes[1].Value = txtIP.Text;
                        }
                    }
                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("Default");
            MessageBox.Show("Mensajes guardados.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
