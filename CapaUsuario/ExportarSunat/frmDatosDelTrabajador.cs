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
            dgvListar.Columns[0].Width = 300;
            dgvListar.Columns[1].Width = 75;
            dgvListar.Columns[2].Visible = false;
            dgvListar.Columns[3].Width = 75;
            dgvListar.Columns[4].Visible = false;
            dgvListar.Columns[5].Visible = false;
            dgvListar.Columns[6].Visible = false;
            dgvListar.Columns[7].Visible = false;
            dgvListar.Columns[8].Visible = false;
            dgvListar.Columns[9].Visible = false;
            dgvListar.Columns[10].Visible = false;
            dgvListar.Columns[11].Visible = false;
            dgvListar.Columns[12].Visible = false;
            dgvListar.Columns[13].Visible = false;
            dgvListar.Columns[14].Visible = false;
            dgvListar.Columns[15].Visible = false;
            dgvListar.Columns[16].Visible = false;
            dgvListar.Columns[17].Visible = false;
            dgvListar.Columns[18].Visible = false;
            dgvListar.Columns[19].Visible = false;
            dgvListar.Columns[20].Visible = false;
            dgvListar.Columns[21].Visible = false;
            dgvListar.Columns[22].Visible = false;
            dgvListar.Columns[23].Visible = false;
            dgvListar.Columns[24].Visible = false;
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
                    string tipoDoc = dgvListar[2, i].Value.ToString();
                    string dni = dgvListar[3, i].Value.ToString();
                    string paisDoc = dgvListar[4, i].Value.ToString();
                    string RegimenLaboral = dgvListar[5, i].Value.ToString();
                    string SituacionEdu = dgvListar[6, i].Value.ToString();
                    string Ocupacion = dgvListar[7, i].Value.ToString();
                    string Discapacidad = dgvListar[8, i].Value.ToString();
                    string CUSPP = dgvListar[9, i].Value.ToString();
                    string SCTR = dgvListar[10, i].Value.ToString();
                    string tipoContrato = dgvListar[11, i].Value.ToString();
                    string regimenAlternativo = dgvListar[12, i].Value.ToString();
                    string jornadaTrabajo = dgvListar[13, i].Value.ToString();
                    string horarioNocturno = dgvListar[14, i].Value.ToString();
                    string sindicalizado = dgvListar[15, i].Value.ToString();
                    string periodicidad = dgvListar[16, i].Value.ToString();
                    ConvertiraNumero2(periodicidad);
                    string remBasica = dgvListar[17, i].Value.ToString();
                    string situacion = dgvListar[18, i].Value.ToString();
                    string Renta5ta = dgvListar[19, i].Value.ToString();
                    string situacionEsp = dgvListar[20, i].Value.ToString();
                    string tipoPago = dgvListar[21, i].Value.ToString();
                    ConvertiraNumero(tipoPago);
                    string catOcupacional = dgvListar[22, i].Value.ToString();
                    string convenio = dgvListar[23, i].Value.ToString(); ;
                    string RUC = dgvListar[24, i].Value.ToString(); ;
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
