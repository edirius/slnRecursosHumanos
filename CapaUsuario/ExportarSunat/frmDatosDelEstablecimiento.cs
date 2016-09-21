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
    public partial class frmDatosDelEstablecimiento : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExpo = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        ArrayList milista = new ArrayList();
        string FechaTexto = "";
        public frmDatosDelEstablecimiento()
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
            dgvDatosEstablecimiento.DataSource = oExpo.ListarEstablecimientos(cbMes.Text, cbAños.Text);
            DataGridViewCheckBoxColumn Check = new DataGridViewCheckBoxColumn();//creamos un objeto check
            {
                Check.Name = "Check";//le damos un nombre de cabecera
                dgvDatosEstablecimiento.Columns.Add(Check);//agregamos los check a cada items

            }
            dgvDatosEstablecimiento.Columns["Check"].DisplayIndex = 0;
            dgvDatosEstablecimiento.Columns["Check"].ReadOnly = false;
            dgvDatosEstablecimiento.Columns["Check"].Width = 75;
            dgvDatosEstablecimiento.Columns[0].Width = 270;
            dgvDatosEstablecimiento.Columns[1].Width = 75;
            dgvDatosEstablecimiento.Columns[2].Width = 75;
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
                for (int i = 0; i < dgvDatosEstablecimiento.Rows.Count; i++)
                {
                    string tipoDoc = "01";
                    string dni = dgvDatosEstablecimiento[2,i].Value.ToString();
                    string paisDoc = "604";
                    string ruc = "20226560824";
                    string Contenido = "";
                    string codEstab = "0000";
                    Contenido = oExpo.ExportarEstablecimiento(tipoDoc, dni, paisDoc, ruc, codEstab);
                    milista.Add(Contenido);

                }
            }
            catch
            {
                
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = "20226560824";
            string tipoArchivo = ".EST";
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
            if (dgvDatosEstablecimiento.Rows.Count != 0)
            {
                concatenarDatos();
                milista.Clear();
            }
            else
                MessageBox.Show("No hay datos para exportar");
            
        }

        private void DtDesde_ValueChanged(object sender, EventArgs e)
        {
            //dgvDatosEstablecimiento.DataSource = oExpo.ListarEstablecimientos(DtDesde.Value, DtHasta.Value);
        }

        private void DtHasta_ValueChanged(object sender, EventArgs e)
        {
            //dgvDatosEstablecimiento.DataSource = oExpo.ListarEstablecimientos(DtDesde.Value, DtHasta.Value);
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatosEstablecimiento.DataSource = oExpo.ListarEstablecimientos(cbMes.Text, cbAños.Text);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatosEstablecimiento.DataSource = oExpo.ListarEstablecimientos(cbMes.Text, cbAños.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            concatenarDatos2();
            milista.Clear();
        }
        public void concatenarDatos2()
        {
            foreach (DataGridViewRow fila in dgvDatosEstablecimiento.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["Check"].Value) == true)
                {
                    string tipoDoc = "01";
                    string DNI = fila.Cells["DNI"].Value.ToString();
                    string paisDoc = "604";
                    string ruc = "20226560824";
                    string Contenido = "";
                    string codEstab = "0000";
                    string Contenido2 = "";
                    Contenido2  = oExpo.ExportarEstablecimiento(tipoDoc, DNI, paisDoc, ruc, codEstab);
                    milista.Add(Contenido2);
                }
            }
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = "20226560824";
            string tipoArchivo = ".EST";
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

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void checkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSeleccionar.Checked == true)
            {
                for (int i = 0; i < dgvDatosEstablecimiento.Rows.Count; i++)
                {
                    dgvDatosEstablecimiento[0, i].Value = true;
                }
            }
            else
                for (int i = 0; i < dgvDatosEstablecimiento.Rows.Count; i++)
                {
                    dgvDatosEstablecimiento[0, i].Value = false;
                }
        }
    }
}
