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
    public partial class frmDarDeBajaTrabajador : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExpo = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        ArrayList milista = new ArrayList();
        string FechaTexto = "";
        string Periodos="";
        public frmDarDeBajaTrabajador()
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
            dgvDarDeBaja.DataSource = oExpo.DarDeBajaTrabajador(cbMes.Text, cbAños.Text);
            DataGridViewCheckBoxColumn Check = new DataGridViewCheckBoxColumn();//creamos un objeto check
            {
                Check.Name = "☑";//le damos un nombre de cabecera
                dgvDarDeBaja.Columns.Add(Check);//agregamos los check a cada items

            }
            dgvDarDeBaja.Columns["☑"].DisplayIndex = 0;
            dgvDarDeBaja.Columns["☑"].ReadOnly = false;
            for (int i = 0; i < dgvDarDeBaja.Columns.Count; i++)
            {
                dgvDarDeBaja.Columns[i].Visible = false;
                dgvDarDeBaja.Columns["☑"].Visible = true;
                dgvDarDeBaja.Columns["☑"].Width = 30;
                dgvDarDeBaja.Columns["Nro"].Visible = true;
                dgvDarDeBaja.Columns["Nro"].Width = 40;
                dgvDarDeBaja.Columns["Nro"].ReadOnly = true;
                dgvDarDeBaja.Columns["Nombres"].Visible = true;
                dgvDarDeBaja.Columns["Nombres"].Width = 250;
                dgvDarDeBaja.Columns["Nombres"].DisplayIndex = 4;
                dgvDarDeBaja.Columns["Nombres"].ReadOnly = true;
                dgvDarDeBaja.Columns["DNI"].Visible = true;
                dgvDarDeBaja.Columns["DNI"].Width = 75;
                dgvDarDeBaja.Columns["DNI"].ReadOnly = true;
                dgvDarDeBaja.Columns["Sexo"].Visible = true;
                dgvDarDeBaja.Columns["Sexo"].Width = 50;
                dgvDarDeBaja.Columns["Sexo"].ReadOnly = true;
                dgvDarDeBaja.Columns["FechaFin"].Visible = true;
                dgvDarDeBaja.Columns["FechaFin"].Width = 78;
                dgvDarDeBaja.Columns["FechaFin"].ReadOnly = true;
                dgvDarDeBaja.Columns["DescripcionMotivoFin"].Visible = true;
                dgvDarDeBaja.Columns["DescripcionMotivoFin"].Width = 350;
                dgvDarDeBaja.Columns["DescripcionMotivoFin"].ReadOnly = true;
            }
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
            foreach (DataGridViewRow fila in dgvDarDeBaja.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["☑"].Value) == true)
                {
                    //Periodos
                    string tipoDoc = fila.Cells["@tipoDoc"].Value.ToString();
                    string dni = fila.Cells["DNI"].Value.ToString();
                    string paisDoc = fila.Cells["@PaisEmisor"].Value.ToString();
                    string Categoria = fila.Cells["@Categoria"].Value.ToString();
                    string TipoRegistro = fila.Cells["@TipoRegistro"].Value.ToString();
                    string fechainicio = "";
                    DateTime fechafin = Convert.ToDateTime(fila.Cells["FechaFin"].Value.ToString());
                    string indicadorTipoRegistro = fila.Cells["codigosunat"].Value.ToString();
                    string EPS = "";
                    Periodos = oExpo.ExportarPeriodos(tipoDoc, dni, paisDoc, Categoria, TipoRegistro, fechainicio, fechafin.ToShortDateString(), indicadorTipoRegistro, EPS);
                    milista.Add(Periodos);
                }
               
            }

            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            string RUC = Properties.Settings.Default.RUC;
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

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDarDeBaja.DataSource = oExpo.DarDeBajaTrabajador(cbMes.Text, cbAños.Text);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDarDeBaja.DataSource = oExpo.DarDeBajaTrabajador(cbMes.Text, cbAños.Text);
        }

        private void checkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSeleccionar.Checked == true)
            {
                for (int i = 0; i < dgvDarDeBaja.Rows.Count; i++)
                {
                    dgvDarDeBaja[0, i].Value = true;
                }
            }
            else
                for (int i = 0; i < dgvDarDeBaja.Rows.Count; i++)
                {
                    dgvDarDeBaja[0, i].Value = false;
                }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDarDeBaja.Rows.Count != 0)
            {
                concatenarDatos();
                milista.Clear();
            }
            else
            MessageBox.Show("No ha seleccionado ningún trabajador para dar de baja");
            
        }

        private void frmDarDeBajaTrabajador_Load(object sender, EventArgs e)
        {

        }
    }
}
