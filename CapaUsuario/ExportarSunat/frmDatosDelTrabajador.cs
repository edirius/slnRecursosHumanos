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
using CapaDeNegocios;

namespace CapaUsuario.ExportarSunat
{
    public partial class frmDatosDelTrabajador : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExp = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        ArrayList milista = new ArrayList();
        string nroTipoPago = "";
        string nroPeriodicidad = "";

        public frmDatosDelTrabajador()
        {
            InitializeComponent();
            CargarGrid();
        }
        private void CargarGrid()
        {
            dgvListar.DataSource = oExp.ListarDatosDelTrabajadorporFecha(DtDesde.Value, DtHasta.Value);
            dgvListar.Columns[0].Width = 230;
            dgvListar.Columns[1].Width = 70;
            dgvListar.Columns[2].Width = 70;
            dgvListar.Columns[3].Visible = false;
            dgvListar.Columns[4].Width = 110;
            dgvListar.Columns[5].Visible = false;
            dgvListar.Columns[6].Width = 100;
            dgvListar.Columns[7].Visible = false;
            dgvListar.Columns[8].Width = 150;
            dgvListar.Columns[9].Width = 75;
            dgvListar.Columns[10].Width = 75;
            dgvListar.Columns[11].Visible = false;
            dgvListar.Columns[12].Width = 120;



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
        private void ConvertiraNumero2(string periodicidad)
        {
            switch (periodicidad)
            {
                case "MENSUAL":
                    {
                        nroPeriodicidad = "1";
                        break;
                    }
                case "QUINCENAL":
                    {
                        nroPeriodicidad = "2";
                        break;
                    }
                case "SEMANAL":
                    {
                        nroPeriodicidad = "3";
                        break;
                    }
                case "DIARIA":
                    {
                        nroPeriodicidad = "4";
                        break;
                    }
                case "OTROS":
                    {
                        nroPeriodicidad = "5";
                        break;
                    }
            }
        }
        private void ConcatenarDatos()
        {
            
            try
            {
                for (int i = 0; i <= dgvListar.Rows.Count; i++)
                {
                    string tipoDoc = "01";
                    string dni = dgvListar[2, i].Value.ToString();
                    string paisDoc = "604";
                    string RegimenLaboral = dgvListar[3, i].Value.ToString();
                    string SituacionEdu = "07";
                    string Ocupacion = dgvListar[5, i].Value.ToString();
                    string Discapacidad = "0";
                    string CUSPP = "";
                    string SCTR = "";
                    string tipoContrato = dgvListar[7, i].Value.ToString();
                    string regimenAlternativo = "0";
                    string jornadaTrabajo = "0";
                    string horarioNocturno = "0";
                    string sindicalizado = "0";
                    string periodicidad = dgvListar[9, i].Value.ToString();
                    ConvertiraNumero2(periodicidad);
                    string remBasica = "";
                    string situacion = "1";
                    string Renta5ta = "0";
                    string situacionEsp = "0";
                    string tipoPago = dgvListar[10, i].Value.ToString();
                    ConvertiraNumero(tipoPago);
                    string catOcupacional = dgvListar[11, i].Value.ToString();
                    string convenio = "";
                    string RUC = "";
                    //dgvListarDatosTrabajadores[9, i].Value.ToString();
                    string Contenido = oExp.ExportarDatosTrabajador2(tipoDoc, dni, paisDoc, RegimenLaboral, SituacionEdu, Ocupacion, Discapacidad, CUSPP, SCTR, tipoContrato, regimenAlternativo, jornadaTrabajo, horarioNocturno, sindicalizado, nroPeriodicidad, remBasica, situacion, Renta5ta, situacionEsp, nroTipoPago, catOcupacional, convenio, RUC);
                    //MessageBox.Show(Contenido);
                    milista.Add(Contenido);
                }
            }
            catch
            {
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string ruc = "20226560824";
            string tipoArchivo = ".TRA";
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
            if (dgvListar.Rows.Count != 0)
            {
                ConcatenarDatos();
                milista.Clear();
            }
            else MessageBox.Show("No se encontraron datos para la exportación.");
            
        }

        private void DtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvListar.DataSource = oExp.ListarDatosDelTrabajadorporFecha(DtDesde.Value, DtHasta.Value);
        }

        private void DtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvListar.DataSource = oExp.ListarDatosDelTrabajadorporFecha(DtDesde.Value, DtHasta.Value);
        }
    }
}
