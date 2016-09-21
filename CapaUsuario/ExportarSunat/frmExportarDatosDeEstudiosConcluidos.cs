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
        ArrayList milista = new ArrayList();
        string FechaTexto = "";
        public frmExportarDatosDeEstudiosConcluidos()
        {
            InitializeComponent();
            CargarAños();
            CargarGrid();
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
            cbMes.Text = FechaTexto;
        }
        public void CargarGrid()
        {
            dgvDatosEstudios.DataSource = oexp.ListarEstablecimientos(cbMes.Text, cbAños.Text);
            dgvDatosEstudios.Columns[0].Width = 270;
            dgvDatosEstudios.Columns[1].Width = 75;
            dgvDatosEstudios.Columns[2].Width = 75;
        }
        private void CargarMes(DateTime FechaActual)
        {
            string Ahora = Convert.ToString(FechaActual.Date.Month);
            switch (Ahora)
            {
                case "1":
                    {
                        FechaTexto = "ENERO";
                        break;
                    }
                case "2":
                    {
                        FechaTexto = "FEBRERO";
                        break;
                    }
                case "3":
                    {
                        FechaTexto = "MARZO";
                        break;
                    }
                case "4":
                    {
                        FechaTexto = "ABRIL";
                        break;
                    }
                case "5":
                    {
                        FechaTexto = "MAYO";
                        break;
                    }
                case "6":
                    {
                        FechaTexto = "JUNIO";
                        break;
                    }
                case "7":
                    {
                        FechaTexto = "JULIO";
                        break;
                    }
                case "8":
                    {
                        FechaTexto = "AGOSTO";
                        break;
                    }
                case "9":
                    {
                        FechaTexto = "SEPTIEMBRE";
                        break;
                    }
                case "10":
                    {
                        FechaTexto = "OCTUBRE";
                        break;
                    }
                case "11":
                    {
                        FechaTexto = "NOVIEMBRE";
                        break;
                    }
                case "12":
                    {
                        FechaTexto = "DICIEMBRE";
                        break;
                    }

            }
        }
        private void CargarAños()
        {
            string años = "";
            for (int i = DateTime.Now.Year; i >= 2000; i--)
            {
                cbAños.Items.Add(i);
            }
            cbAños.Text = años;
            cbAños.Text = Convert.ToString(DateTime.Now.Year);
        }
        public void concatenarDatos()
        {
            
            try
            {
                for (int i = 0; i < dgvDatosEstudios.Rows.Count; i++)
                {
                    string tipoDoc = "01";
                    string dni = dgvDatosEstudios[2, i].Value.ToString();
                    string paisDoc = "604";
                    string situacionEdu = "11";
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
            if (dgvDatosEstudios.Rows.Count != 2)
            {
                concatenarDatos();
                milista.Clear();
            }
            else
                MessageBox.Show("No se encontraron datos para exportar");
            
        }
        
        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}
