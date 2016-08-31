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
    public partial class frmDatosDelTrabajador : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExportar = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        string TP="";

        public frmDatosDelTrabajador()
        {
            InitializeComponent();
            Cargargrid();
        }
        public void Cargargrid()
        {
            dgvListarDatosTrabajadores.DataSource = oExportar.ListarDatosDelTrabajador();
        }
        public void ConvertiraNumero(string tipoPago)
        {
            switch (tipoPago)
            {
                case "EFECTIVO":
                    {
                        TP = "1";
                        break;
                    }
                case "DEPOSITO":
                    {
                        TP = "2";
                        break;
                    }
                case "OTROS":
                    {
                        TP = "3";
                        break;
                    }
            }
        }
        public void concatenarDatos()
        {
            ArrayList milista = new ArrayList();

            try
            {
                for (int i = 0; i <= dgvListarDatosTrabajadores.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string tipoDoc = "01";
                    string dni = dgvListarDatosTrabajadores[0, i].Value.ToString();
                    string paisDoc = "604";
                    string RegimenLaboral = dgvListarDatosTrabajadores[1, i].Value.ToString();
                    string SituacionEdu = "07";
                    string Ocupacion = dgvListarDatosTrabajadores[3, i].Value.ToString();
                    string Discapacidad = "0";
                    string CUSPP = "";
                    string SCTR = "0";
                    string tipoContrato = dgvListarDatosTrabajadores[4, i].Value.ToString();
                    string regimenAlternativo = "0";
                    string jornadaTrabajo = "0";
                    string horarioNocturno = "0";
                    string sindicalizado = "0"; 
                    string periodicidad = dgvListarDatosTrabajadores[5, i].Value.ToString();
                    string remBasica = dgvListarDatosTrabajadores[6, i].Value.ToString();
                    string situacion = "1";
                    string Renta5ta = "0";
                    string situacionEsp = "0";
                    string tipoPago = dgvListarDatosTrabajadores[7, i].Value.ToString();
                    ConvertiraNumero(tipoPago);
                    string catOcupacional = dgvListarDatosTrabajadores[8, i].Value.ToString();
                    string convenio = "";
                    string RUC = dgvListarDatosTrabajadores[9, i].Value.ToString();
                    string Contenido = "";
                    Contenido = oExportar.ExportarDatosTrabajador2( tipoDoc, dni, paisDoc, RegimenLaboral, SituacionEdu, Ocupacion, Discapacidad,  CUSPP,  SCTR, tipoContrato, regimenAlternativo, jornadaTrabajo, horarioNocturno, sindicalizado, periodicidad, remBasica, situacion, Renta5ta, situacionEsp, TP, catOcupacional, convenio, RUC);
                    milista.Add(Contenido);

                }
            }
            catch
            {
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string Ruc = "20226560824";
            string tipoArchivo = ".TRA";
            string rp = "RP_";
            string Titulo = rp + Ruc + tipoArchivo;
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
            if (dgvListarDatosTrabajadores.Columns.Count != 0)
            {
                concatenarDatos();
            }
            else
                
                MessageBox.Show("No hay datos para Exportar");
        }
    }
}
