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
        string tipoDoc = "01";
        string dni = "";
        string paisDoc = "604";
        string fechainicio = "";
        string fechafin = "";
        string indicadorTipoRegistro = "";
        string EPS = "";
        string Periodos = "";
        string TipoTrabajador = "";
        string RegimenAseguramiento = "";
        string RegimenPensionario = "";
        string SCTR = "";
        string Ruta = "";
        string Titulo = "";
        string RUC = "20226560824";
        string tipoArchivo = ".PER";
        string rp = "RP_";
        string NroRegimenSalud = "";
        string Categoria = "1";
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
        private void ConvertiraNumero(string RegimenSalud)
        {
            switch (RegimenSalud)
            {
                case "ESSALUD REGULAR (Exclusivamente)":
                    {
                        NroRegimenSalud = "00";
                        break;
                    }
                case "ESSALUD REGULAR Y EPS/SERV. PROPIOS":
                    {
                        NroRegimenSalud = "01";
                        break;
                    }
                    
                        case "ESSALUD AGRARIO/ ACUÍCOLA":
                    {
                        NroRegimenSalud = "04";
                        break;
                    }
            }
        }
        public void concatenarDatos()
        {
            ArrayList milista = new ArrayList();
            try
            {
                for (int i = 0; i < dgv1.Rows.Count; i++)//Perido
                {

                    string tipoRegistro = "1";
                    dni = dgv1[0, i].Value.ToString();
                    fechainicio = dgv1[1, i].Value.ToString();
                    fechafin = dgv1[2, i].Value.ToString();
                    indicadorTipoRegistro = dgv1[3, i].Value.ToString();
                    Periodos = oexp.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro, fechainicio, fechafin, indicadorTipoRegistro, EPS);
                    milista.Add(Periodos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try {
                for (int j = 0; j < dgv2.Rows.Count; j++) //Tipo Trabajador
                {
                    string tipoRegistro = "2";
                    string dni2 = dgv2[0, j].Value.ToString();
                    string fechainicio2 = dgv2[1, j].Value.ToString();
                    string fechafin2 = dgv2[2, j].Value.ToString();
                    string indicadorTipoRegistro2 = dgv2[3, j].Value.ToString();
                    TipoTrabajador = oexp.ExportarPeriodos(tipoDoc, dni2, paisDoc, Categoria, tipoRegistro, fechainicio2, fechafin2, indicadorTipoRegistro2, EPS);
                    milista.Add(TipoTrabajador);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                for (int f = 0; f < dgv3.Rows.Count; f++) //Régimen de aseguramiento de Salud
                {
                    string tipoRegistro = "3";
                    string dni3 = dgv3[0, f].Value.ToString();
                    string fechainicio3 = dgv3[1, f].Value.ToString();
                    string fechafin3 = dgv3[2, f].Value.ToString();
                    string indicadorTipoRegistro3 = dgv3[3, f].Value.ToString();
                    ConvertiraNumero(indicadorTipoRegistro3);
                    RegimenAseguramiento = oexp.ExportarPeriodos(tipoDoc, dni3, paisDoc, Categoria, tipoRegistro, fechainicio3, fechafin3, NroRegimenSalud, EPS);
                    milista.Add(RegimenAseguramiento);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                for (int g = 0; g < dgv4.Rows.Count; g++) //Régimen Pensionario
                {
                    string tipoRegistro = "4";
                    string dni4 = dgv4[0, g].Value.ToString();
                    string fechainicio4 = dgv4[1, g].Value.ToString();
                    string fechafin4 = dgv4[2, g].Value.ToString();
                    string indicadorTipoRegistro4 = dgv4[3, g].Value.ToString();
                    RegimenPensionario = oexp.ExportarPeriodos(tipoDoc, dni4, paisDoc, Categoria, tipoRegistro, fechainicio4, fechafin4, indicadorTipoRegistro4, EPS);
                    milista.Add(RegimenPensionario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                for (int g = 0; g < dgv1.Rows.Count; g++) //Régimen Pensionario
                {
                    string tipoRegistro = "5";
                    string dni5 = dgv1[0, g].Value.ToString();
                    string fechainicio5 = dgv1[1, g].Value.ToString();
                    string fechafin5 = dgv1[2, g].Value.ToString();
                    string indicadorTipoRegistro5 = "1";
                    SCTR = oexp.ExportarPeriodos(tipoDoc, dni5, paisDoc, Categoria, tipoRegistro, fechainicio5, fechafin5, indicadorTipoRegistro5, EPS);
                    milista.Add(SCTR);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            Titulo = rp + RUC + tipoArchivo;
            Guardar.FileName = Titulo;
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
