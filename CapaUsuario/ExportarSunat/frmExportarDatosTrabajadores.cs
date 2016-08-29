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
    public partial class frmExportarDatosTrabajadores : Form
    {
        ArrayList milista = new ArrayList();
        int nroSexo = 0;
        int nroEssalud = 0;
        CapaDeNegocios.ExportarSunat.cExportarSunat oExportar = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        public frmExportarDatosTrabajadores()
        {
            InitializeComponent();
            Cargargrid();
        }
        public void Cargargrid()
        {
            dgvListarTrabajadores.DataSource = oExportar.ListarTrabajadores();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            if (dgvListarTrabajadores.Columns.Count != 0)
            {
                concatenarDatos();
            }
            else
                MessageBox.Show("No hay datos para Exportar");

        }
        private void Sexo(string Sexo)
        {
            switch (Sexo)
            {
                case "M":
                    {
                        nroSexo = 1;
                        break;
                    }
                case "F":
                    {
                        nroSexo = 2;
                        break;
                    }
            }
        }
        private void Essalud(string Essalud)
        {
            switch (Essalud)
            {
                case "TRUE":
                    {
                        nroEssalud = 1;
                        break;
                    }
                case "FALSE":
                    {
                        nroEssalud = 0;
                        break;
                    }
            }
        }
        public void concatenarDatos()
        {
            ArrayList milista = new ArrayList();
            
            try
            {
                for (int i = 0; i <= dgvListarTrabajadores.Rows.Count; i++)
                {
                    string tipoVia2 = "", nombreVia2 ="", nroVia2="", departamento2="", interior2="", manzana2="", lote2="",
                    kilometro2="", block2="", etapa2="", tipoZona2="", nombreZona2="", referencia2="",
                    ubigeo2="", indicadorAsistenciaESSALUD = "";
                    //obtenemos los datos de las columnas que queremos
                    string tipoDoc = "01";
                    string dni = dgvListarTrabajadores[0, i].Value.ToString();
                    string paisDoc = "604";
                    string apPaterno = dgvListarTrabajadores[1, i].Value.ToString();
                    string apMaterno = dgvListarTrabajadores[2, i].Value.ToString();
                    string nombres = dgvListarTrabajadores[3, i].Value.ToString();
                    DateTime fechaNac = Convert.ToDateTime(dgvListarTrabajadores[4, i].Value.ToString());

                    string sexo = dgvListarTrabajadores[5, i].Value.ToString();
                    Sexo(sexo);
                    string nacionalidad = dgvListarTrabajadores[6, i].Value.ToString();
                    string telLargaDistancia = "84";
                    string telefono = dgvListarTrabajadores[7, i].Value.ToString();
                    string correo = dgvListarTrabajadores[8, i].Value.ToString();
                    //string essalud = dgvListarTrabajadores[9, i].Value.ToString();
                    //Essalud(essalud);
                    string tipoVia = dgvListarTrabajadores[10, i].Value.ToString();
                    string nombreVia = dgvListarTrabajadores[11, i].Value.ToString();
                    string nroVia = dgvListarTrabajadores[12, i].Value.ToString();
                    string departamento = "";
                    string interior = dgvListarTrabajadores[13, i].Value.ToString();

                    string manzana = "";
                    string lote = "";
                    string kilometro = "";
                    string block = "";
                    string etapa = "";
                    string tipoZona = dgvListarTrabajadores[14, i].Value.ToString();
                    string nombreZona = dgvListarTrabajadores[15, i].Value.ToString();
                    string referencia = dgvListarTrabajadores[16, i].Value.ToString();
                    string ubigeo = dgvListarTrabajadores[17, i].Value.ToString();

                    string Contenido = "";
                    Contenido = oExportar.ExportarDatosTrabajador(tipoDoc, dni, paisDoc, fechaNac.ToShortDateString(), apPaterno, apMaterno, nombres,  nroSexo.ToString(), nacionalidad, telLargaDistancia, telefono, correo, tipoVia, nombreVia, nroVia, departamento, interior, manzana, lote, kilometro, block, etapa, tipoZona, nombreZona, referencia, ubigeo, tipoVia2, nombreVia2, nroVia2, departamento2, interior2, manzana2, lote2, kilometro2, block2, etapa2, tipoZona2, nombreZona2, referencia2, ubigeo2, indicadorAsistenciaESSALUD);
                    milista.Add(Contenido);
                    
                }
            }
            catch
            {
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = "20226560824";
            string tipoArchivo = ".IDE";
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
