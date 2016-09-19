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
        ArrayList milista = new ArrayList();
        public frmExportarPeriodos()
        {
            InitializeComponent();
            Cargargrid();
        }
        public void Cargargrid()
        {
            dgvExportarPeriodos.DataSource = oexp.ListarPeriodos(DtDesde.Value, DtHasta.Value);
            //dgvExportarPeriodos.Columns[0].Width = 200;
            //dgvExportarPeriodos.Columns[1].Width = 75;
            //dgvExportarPeriodos.Columns[2].Width = 75;
            //dgvExportarPeriodos.Columns[3].Width = 75;
            //dgvExportarPeriodos.Columns[4].Visible = false;
            //dgvExportarPeriodos.Columns[5].Width = 350;
            //dgvExportarPeriodos.Columns[6].Visible = false;
            //dgvExportarPeriodos.Columns[7].Width = 150;
            //dgvExportarPeriodos.Columns[8].Width = 100;
            //dgvExportarPeriodos.Columns[9].Width = 100;
            //dgvExportarPeriodos.Columns[10].Width = 200;
            //dgvExportarPeriodos.Columns[11].Width = 150;
            //dgvExportarPeriodos.Columns[12].Width = 150;
            //dgvExportarPeriodos.Columns[13].Visible = false;
            //dgv1.Columns[0].Visible = false;

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvExportarPeriodos.Columns.Count != 0)
            {
                concatenarDatos();
                milista.Clear();
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
            
            try
            {
                for (int i = 0; i < dgvExportarPeriodos.Rows.Count; i++)//Perido
                {

                    string tipoRegistro = "1";
                    dni = dgvExportarPeriodos[3, i].Value.ToString();
                    DateTime fechainicio = Convert.ToDateTime(dgvExportarPeriodos[1, i].Value.ToString());
                    fechafin = dgvExportarPeriodos[2, i].Value.ToString();
                    indicadorTipoRegistro = dgvExportarPeriodos[4, i].Value.ToString();
                    Periodos = oexp.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, tipoRegistro, fechainicio.ToShortDateString(), fechafin, indicadorTipoRegistro, EPS);
                    milista.Add(Periodos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try {
                for (int j = 0; j < dgvExportarPeriodos.Rows.Count; j++) //Tipo Trabajador
                {
                    string tipoRegistro = "2";
                    string dni2 = dgvExportarPeriodos[3, j].Value.ToString();
                    DateTime fechainicio2 = Convert.ToDateTime(dgvExportarPeriodos[1, j].Value.ToString());
                    string fechafin2 = dgvExportarPeriodos[2, j].Value.ToString();
                    string indicadorTipoRegistro2 = dgvExportarPeriodos[6, j].Value.ToString();
                    TipoTrabajador = oexp.ExportarPeriodos(tipoDoc, dni2, paisDoc, Categoria, tipoRegistro, fechainicio2.ToShortDateString(), fechafin2, indicadorTipoRegistro2, EPS);
                    milista.Add(TipoTrabajador);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                for (int f = 0; f < dgvExportarPeriodos.Rows.Count; f++) //Régimen de aseguramiento de Salud
                {
                    string tipoRegistro = "3";
                    string dni3 = dgvExportarPeriodos[3, f].Value.ToString();
                    string fechainicio3 = dgvExportarPeriodos[7, f].Value.ToString();
                    string fechafin3 = dgvExportarPeriodos[8, f].Value.ToString();
                    string indicadorTipoRegistro3 = dgvExportarPeriodos[9, f].Value.ToString();
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
                for (int g = 0; g < dgvExportarPeriodos.Rows.Count; g++) //Régimen Pensionario
                {
                    string tipoRegistro = "4";
                    string dni4 = dgvExportarPeriodos[3, g].Value.ToString();
                    string fechainicio4 = dgvExportarPeriodos[10, g].Value.ToString();
                    string fechafin4 = dgvExportarPeriodos[11, g].Value.ToString();
                    string indicadorTipoRegistro4 = dgvExportarPeriodos[12, g].Value.ToString();
                    RegimenPensionario = oexp.ExportarPeriodos(tipoDoc, dni4, paisDoc, Categoria, tipoRegistro, fechainicio4, fechafin4, indicadorTipoRegistro4, EPS);
                    milista.Add(RegimenPensionario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //try
            //{
            //    for (int g = 0; g < dgvExportarPeriodos.Rows.Count; g++) //Régimen Pensionario
            //    {
            //        string tipoRegistro = "5";
            //        string dni5 = dgvExportarPeriodos[3, g].Value.ToString();
            //        DateTime fechainicio5 = Convert.ToDateTime(dgvExportarPeriodos[1, g].Value.ToString());
            //        string fechafin5 = dgvExportarPeriodos[2, g].Value.ToString();
            //        string indicadorTipoRegistro5 = "1";
            //        SCTR = oexp.ExportarPeriodos(tipoDoc, dni5, paisDoc, Categoria, tipoRegistro, fechainicio5.ToShortDateString(), fechafin5, indicadorTipoRegistro5, EPS);
            //        milista.Add(SCTR);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

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

        private void frmExportarPeriodos_Load(object sender, EventArgs e)
        {

        }

        private void DtDesde_ValueChanged(object sender, EventArgs e)
        {
            dgvExportarPeriodos.DataSource = oexp.ListarPeriodos(DtDesde.Value, DtHasta.Value);
        }

        private void DtHasta_ValueChanged(object sender, EventArgs e)
        {
            dgvExportarPeriodos.DataSource = oexp.ListarPeriodos(DtDesde.Value, DtHasta.Value);
        }
    }
}
