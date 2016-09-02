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
using System.Collections;
using System.IO;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmExportarPeriodos : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oexp = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        ArrayList milista = new ArrayList();

        public frmExportarPeriodos()
        {
            InitializeComponent();
            Cargargrid();
        }
        public void Cargargrid()
        {
            dgv1.DataSource = oexp.ListarPeriodos1();
            dgv2.DataSource = oexp.ListarPeriodos2();
            dgv3.DataSource = oexp.ListarPeriodos3();
            dgv4.DataSource = oexp.ListarPeriodos4();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv1.Columns.Count != 0)
            {
                concatenarDatos();
            }
            else
                MessageBox.Show("No hay datos para Exportar");
        }
        public void concatenarDatos()
        {
            ArrayList milista = new ArrayList();

            try
            {
                for (int i = 0; i <= dgv1.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string tipoDoc = "01";
                    string dni = dgv1[0, i].Value.ToString();
                    string paisDoc = "604";
                    string fechainicio = dgv1[1, i].Value.ToString();
                    string fechafin = dgv1[2, i].Value.ToString();
                    string tipoRegistro = "";
                    string indicadorTipoRegistro = "";
                    string EPS = "";
                    string Contenido = "";
                    Contenido = oexp.ExportarPeriodos(tipoDoc, dni, paisDoc, tipoRegistro, fechainicio, fechafin, indicadorTipoRegistro, EPS);
                    milista.Add(Contenido);

                }
            }
            catch
            {
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = "20226560824";
            string tipoArchivo = ".PER";
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
    }
}
