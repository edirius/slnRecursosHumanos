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
using System.IO;
using System.Collections;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmExportarTributosDescuentosTrabajador : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExportar = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        public frmExportarTributosDescuentosTrabajador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtIdPlanilla.Text);
            dgvPlanilla.DataSource = oExportar.ListarTrabajadoresPorPlanilla(id);
        }

        private void frmExportarTributosDescuentosTrabajador_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
                ArrayList milista = new ArrayList();
                string Cuerpo = lblCuerpo.Text;
                string Titulo = lblTitulo.Text;
                Cuerpo = oExportar.ExportarTexto(txtTipoDoc.Text, txtDNI.Text, txtCodigo.Text, txtMD.Text, txtM.Text);
                Titulo = oExportar.ExportarTitulo(txtCodForm.Text, txtAño.Text, txtMes.Text, txtRuc.Text);
                milista.Add(Cuerpo);
                StreamWriter escribir = new StreamWriter(@"C:\Users\Usuario\Desktop\"+Titulo+"");//ruta del guardado
                //StreamWriter escribir = new StreamWriter(@"G:\Bryans.txt");//ruta del guardado
                escribir.WriteLine(Cuerpo);
                escribir.Close();
                MessageBox.Show("Hecho");
        }
    }
}
