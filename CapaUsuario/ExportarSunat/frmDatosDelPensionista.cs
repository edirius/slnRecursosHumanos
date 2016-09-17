using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmDatosDelPensionista : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExp = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        ArrayList milista = new ArrayList();
        string nroTipoPago = "";
        string nroPeriodicidad = "";
        public frmDatosDelPensionista()
        {
            InitializeComponent();
            CargarGrid();
        }
        private void CargarGrid()
        {
            dgvListarPensionistas.DataSource = oExp.ListarDatosDelPensionistaporFecha(DtDesde.Value, DtHasta.Value);
        }
        private void ConvertiraNumero(string tipoPago)
        {
            switch (tipoPago)
            {
                case "EFECTIVO":
                    {
                        nroTipoPago = "1";
                        break;
                    }
                case "DEPOSITO":
                    {
                        nroTipoPago = "2";
                        break;
                    }
                case "CHEQUE":
                    {
                        nroTipoPago = "3";
                        break;
                    }
            }
        }
        private void ConcatenarDatos()
        {
            string palo = "|";
            try
            {
                for (int i = 0; i <= dgvListarPensionistas.Rows.Count; i++)
                {
                    string tipoDoc = dgvListarPensionistas[2, i].Value.ToString();
                    string dni = dgvListarPensionistas[3, i].Value.ToString();
                    string paisDoc = dgvListarPensionistas[4, i].Value.ToString();
                    string tipoPen = dgvListarPensionistas[5, i].Value.ToString();
                    string RegPen = dgvListarPensionistas[8, i].Value.ToString();
                    string CUSPP = dgvListarPensionistas[7, i].Value.ToString();
                    string tipoPago = dgvListarPensionistas[10, i].Value.ToString();
                    ConvertiraNumero(tipoPago);
                    string Contenido = tipoDoc + palo + dni + palo + paisDoc + palo + tipoPen + palo + RegPen + palo + CUSPP + palo + nroTipoPago + palo;
                    //MessageBox.Show(Contenido);
                    milista.Add(Contenido);
                }
            }
            catch
            {
                MessageBox.Show("FATAL ERROR");
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string ruc = "20226560824";
            string tipoArchivo = ".PEN";
            string rp = "RP_";
            string Titulo = rp + ruc + tipoArchivo;
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (dgvListarPensionistas.Rows.Count != 0)
            {
                ConcatenarDatos();
                milista.Clear();
            }
            else MessageBox.Show("No se encontraron datos para la exportación.");
        }

        private void DtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvListarPensionistas.DataSource = oExp.ListarDatosDelPensionistaporFecha(DtDesde.Value, DtHasta.Value);
        }

        private void DtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvListarPensionistas.DataSource = oExp.ListarDatosDelPensionistaporFecha(DtDesde.Value, DtHasta.Value);
        }
    }
}
