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
    public partial class frmExportarTributosDescuentosTrabajador : Form
    {
        CapaDeNegocios.ExportarSunat.cExportarSunat oExportar = new CapaDeNegocios.ExportarSunat.cExportarSunat();
        
        string Ingresos, Descuentos, Aportaciones = ""; 
        string Titulo = "";
        string Nromes = "";
        string FechaTexto = "";
        ArrayList milista = new ArrayList();
        public frmExportarTributosDescuentosTrabajador()
        {
            InitializeComponent();
            DateTime Ahora = DateTime.Today;
            CargarMes(Ahora);
            cbMes.Text = FechaTexto;
            CargarAños();
            CargarPlanillas();
            //dgvPlanilla.Visible = false;
            label2.Visible = false;
            label5.Visible = false;
            txtCodForm.Visible = false;
            txtRuc.Visible = false;
            dgvListaPlanillas.Columns[0].Width = 50;
            dgvListaPlanillas.Columns[1].Width = 75;
            dgvListaPlanillas.Columns[2].Width = 50;
            dgvListaPlanillas.Columns[3].Width = 500;
            dgvListaPlanillas.Columns[4].Width = 330;
            dgvListaPlanillas.Columns[5].Width = 217;
        }
        private void ConvertirMes(string MES)
        {
            switch (MES)
            {
                case "ENERO":
                    {
                        Nromes = "01";
                        break;
                    }
                case "FEBRERO":
                    {
                        Nromes = "02";
                        break;
                    }
                case "MARZO":
                    {
                        Nromes = "03";
                        break;
                    }
                case "ABRIL":
                    {
                        Nromes = "04";
                        break;
                    }
                case "MAYO":
                    {
                        Nromes = "05";
                        break;
                    }
                case "JUNIO":
                    {
                        Nromes = "06";
                        break;
                    }
                case "JULIO":
                    {
                        Nromes = "07";
                        break;
                    }
                case "AGOSTO":
                    {
                        Nromes = "08";
                        break;
                    }
                case "SETIEMBRE":
                    {
                        Nromes = "09";
                        break;
                    }
                case "OCTUBRE":
                    {
                        Nromes = "10";
                        break;
                    }
                case "NOVIEMBRE":
                    {
                        Nromes = "11";
                        break;
                    }
                case "DICIEMBRE":
                    {
                        Nromes = "12";
                        break;
                    }

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
                        FechaTexto = "SETIEMBRE";
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


        private void CargarPlanillas()
        {
            
            //dgvListaPlanillas.DataSource = oExportar.ListarPlanillas();
            
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {   if (dgvIngresos.Columns.Count != 0)
            {
                concatenarDatos();
                milista.Clear();
            }
            else
                MessageBox.Show("No hay datos para Exportar");
        }
        public void CrearCarpeta()
        {
            DirectoryInfo di = Directory.CreateDirectory(@"C:\Users\Usuario\Desktop\Textos SUNAT");//ruta de la carpeta
        }
        public void concatenarDatos()
        {
            
            try
            {
                for (int i = 0; i < dgvIngresos.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string mes = dgvIngresos[1, i].Value.ToString();
                    string año = dgvIngresos[2, i].Value.ToString();
                    string dni = dgvIngresos[3, i].Value.ToString();
                    string codigo = dgvIngresos[4, i].Value.ToString();
                    string MontoDevengado = dgvIngresos[5, i].Value.ToString();
                    string Monto = dgvIngresos[5, i].Value.ToString();
                    string TipoDoc = "02";
                    string codigoform = txtCodForm.Text;
                    string Ruc = txtRuc.Text;
                    ConvertirMes(mes);
                    Ingresos = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                    Titulo = oExportar.ExportarTitulo(codigoform, año, Nromes, Ruc);
                    milista.Add(Ingresos);//agregamos los datos concatenados al arreglo(ArrayList)
                }
            }
            catch
            {
            }
            try
            {
                for (int i = 0; i < dgvDescuentos.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string mes = dgvDescuentos[1, i].Value.ToString();
                    string año = dgvDescuentos[2, i].Value.ToString();
                    string dni = dgvDescuentos[3, i].Value.ToString();
                    string codigo = dgvDescuentos[4, i].Value.ToString();
                    string MontoDevengado = dgvDescuentos[5, i].Value.ToString();
                    string Monto = dgvDescuentos[5, i].Value.ToString();
                    string TipoDoc = "02";
                    Descuentos = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                    milista.Add(Descuentos);//agregamos los datos concatenados al arreglo(ArrayList)
                }
            }
            catch
            {
            }
            try
            {
                for (int i = 0; i < dgvAportaciones.Rows.Count; i++)
                {
                    //obtenemos los datos de las columnas que queremos
                    string mes = dgvAportaciones[1, i].Value.ToString();
                    string año = dgvAportaciones[2, i].Value.ToString();
                    string dni = dgvAportaciones[3, i].Value.ToString();
                    string codigo = dgvAportaciones[4, i].Value.ToString();
                    string MontoDevengado = dgvAportaciones[5, i].Value.ToString();
                    string Monto = dgvAportaciones[5, i].Value.ToString();
                    string TipoDoc = "02";
                    string codigoform = txtCodForm.Text;
                    string Ruc = txtRuc.Text;
                    ConvertirMes(mes);
                    Aportaciones = oExportar.ExportarTexto(TipoDoc, dni, codigo, MontoDevengado, Monto);
                    milista.Add(Aportaciones);//agregamos los datos concatenados al arreglo(ArrayList)
                }
            }
            catch
            {
            }
            //CrearCarpeta();
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.FileName = Titulo;
            string Ruta = "";
            if (Titulo != "")
            {
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
            else
                MessageBox.Show("No hay datos para Exportar");
            
        }

        private void dgvListaPlanillas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Valor = dgvListaPlanillas.CurrentCell.RowIndex;
            string numero = "";
            numero = dgvListaPlanillas[0, Valor].Value.ToString();
            dgvIngresos.DataSource = oExportar.ListarTrabajadoresPorPlanillaIngresos(numero);
            dgvDescuentos.DataSource = oExportar.ListarTrabajadoresPorPlanillaDescuentos(numero);
            dgvAportaciones.DataSource = oExportar.ListarTrabajadoresPorPlanillaAportaciones(numero);
        }
        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            dgvListaPlanillas.DataSource = oExportar.BuscarPlanillas(cbMes.Text, cbAños.Text);
        }

        private void cbAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmExportarTributosDescuentosTrabajador_Load(object sender, EventArgs e)
        {

        }

        private void bntListarTodo_Click(object sender, EventArgs e)
        {
            dgvListaPlanillas.DataSource = oExportar.ListarPlanillas(cbAños.Text);
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
    }
}
