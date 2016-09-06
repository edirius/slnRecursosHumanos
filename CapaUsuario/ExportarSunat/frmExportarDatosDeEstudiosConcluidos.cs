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
    public partial class frmExportarDatosDeEstudiosConcluidos : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oexp = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        public frmExportarDatosDeEstudiosConcluidos()
        {
            InitializeComponent();
            CargarGrid();
        }
        public void CargarGrid()
        {
            dgvDatosEstudios.DataSource = oexp.ListarTrabajadores();
        }
        public void concatenarDatos()
        {
            ArrayList milista = new ArrayList();
            try
            {
                for (int i = 0; i < dgvDatosEstudios.Rows.Count; i++)
                {
                    string tipoDoc = "01";
                    string dni = dgvDatosEstudios[0, i].Value.ToString();
                    string paisDoc = "604";
                    string situacionEdu = "13";
                    string indicador = "0";
                    string Contenido = "";
                    string palo = "|";
                    Contenido = tipoDoc + palo + dni + palo + paisDoc + palo + situacionEdu + palo + indicador + palo + palo + palo + palo;
                    milista.Add(Contenido);

                }
            }
            catch
            {

            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = "20226560824";
            string tipoArchivo = ".EDU";
            string rp = "RP_";
            string Titulo = rp + RUC + tipoArchivo;
            Guardar.FileName = Titulo;
            string Ruta = "";
            if (Guardar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (File.Exists(Guardar.FileName))
                {
                    File.Delete(Guardar.FileName);
                }
                if (Guardar.FileName.Contains(Titulo))
                {
                    Ruta = Guardar.FileName;
                    StreamWriter escribir = new StreamWriter(Ruta);//ruta del guardado
                                                                   //StreamWriter escribir = new StreamWriter(@"C:\Users\Usuario\Desktop\Textos SUNAT\" + Titulo + "");//ruta del guardado
                    for (int k = 0; k < milista.Count; k++)//mientras sea menor al contenido del arreglo(arraylist) guardará cada items k
                    {
                        escribir.WriteLine(milista[k]);//guarda en el bloc de notas 
                    }
                    escribir.Close();//cierra la escritura para que eje manejar por separado el bloc de notas
                    MessageBox.Show("Datos Exportados Exitosamente");//mensaje de cierre exitoso

                }
            }


        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            concatenarDatos();
        }
    }
}
