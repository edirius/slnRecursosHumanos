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
            txtEmpresa.Text = Settings.Default.Empresa;
            txtRUC.Text = Settings.Default.RUC;
            txtLugar.Text = Settings.Default.Lugar;
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

                if (element.Name.Equals("applicationSettings"))
                {
                    foreach (XmlNode item in element.ChildNodes)
                    {
                        if (item.Name.Equals("CapaUsuario.Properties.Settings"))
                        {
                            foreach (XmlNode item2 in item.ChildNodes)
                            {
                                if (item2.Attributes[0].Value == "Empresa")
                                {
                                    item2.FirstChild.FirstChild.Value = txtEmpresa.Text;
                                }

                                if (item2.Attributes[0].Value == "RUC")
                                {
                                    item2.FirstChild.FirstChild.Value = txtRUC.Text;
                                }

                                if (item2.Attributes[0].Value == "Lugar")
                                {
                                    item2.FirstChild.FirstChild.Value = txtLugar.Text;
                                }
                            }
                            
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
