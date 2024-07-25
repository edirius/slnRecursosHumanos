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
using CapaDeNegocios.ExportarSunat;

namespace CapaUsuario.ExportarSunat.Tregistro
{
    public partial class frmDarAltaTregistro : Form
    {
        Tregistro.cCatalogoAltaTRegistro oCatalogo = new cCatalogoAltaTRegistro();
        List<Tregistro.cTrabajadorAltaTRegistro> ListaTrabajadoresAltaTRegistro = new List<cTrabajadorAltaTRegistro>();

        public frmDarAltaTregistro()
        {
            InitializeComponent();
        }

        private void frmDarAltaTregistro_Load(object sender, EventArgs e)
        {
            CargarAños();
        }

        private void CargarAños()
        {
            string años = "";
            for (int i = DateTime.Now.Year; i >= 2020; i--)
            {
                cbAños.Items.Add(i);
            }
            cbAños.Text = años;
            cbAños.Text = Convert.ToString(DateTime.Now.Year);
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                if (cbAños.SelectedIndex != -1 && cbMes.SelectedIndex != -1)
                {
                    ListaTrabajadoresAltaTRegistro = oCatalogo.TraerListaTrabajadoresTRegistro(cbMes.Text, cbAños.Text);
                    dtgListaTrabajadores.DataSource = ListaTrabajadoresAltaTRegistro;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en cargar datos: " + ex.Message);
            }
        }

        private void btnVerCodificacion_Click(object sender, EventArgs e)
        {
            Tregistro.frmVerCodificacion fVerCodificacion = new frmVerCodificacion();
            fVerCodificacion.ListaTrabajadores = ListaTrabajadoresAltaTRegistro;
            if (fVerCodificacion.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
